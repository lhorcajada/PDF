using ClosedXML.Excel;
using DemoHarce.CrossCutting.Excel.Format;
using DemoHarce.CrossCutting.Excel.Format.Factory;
using DemoHarce.CrossCutting.Excel.Style;
using DemoHarce.CrossCutting.Excel.Style.Factory;
using DemoHarce.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoHarce.CrossCutting.Excel
{
    /// <summary>
    /// Clase abstracta que dispone de toda la funcionalidad para crear un libro excel.
    /// Permite sobreescribir el método GenerateExcel.
    /// </summary>
    public abstract class ExcelWriter<T> where T : class
    {
        private ExcelDataFormat _dataFormat;
        private ExcelStyle _excelStyle;
        private XLWorkbook _workbook;
        private List<ExcelSheet> _sheets;
        private readonly string _sheetName;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="sheets">Listado de hojas que se crearán en el libro excel</param>
        protected ExcelWriter(List<ExcelSheet> sheets = null)
        {
            _sheets = sheets;
        }

        /// <summary>
        /// Crea un nuevo libro excel
        /// </summary>
        /// <param name="fileName">Ruta del fichero, incluido el nombre del fichero sin extensión.</param>
        /// <returns></returns>
        public virtual bool GenerateExcel(string fileName = "Excel",
            string sheetName = "Sheet", ExcelColumn[] columnsToExcel = null,
            List<T> dataList = null, string[] headerNames = null)
        {
            string extension = ".xlsx";
            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                _workbook = workbook;
                GenerateSheets(sheetName, columnsToExcel, dataList, headerNames);
                SaveAsFile(fileName, extension);
            }
            return true;
        }



        private void SaveAsFile(string fileName, string extension)
        {
            _workbook.SaveAs($"{fileName}{extension}");

        }

        private void GenerateSheets(string sheetName, ExcelColumn[] columnsToExcel,
            List<T> dataList, string[] headerNames)
        {
            if (_sheets != null)
            {


                foreach (var sheet in _sheets)
                {
                    using (IXLWorksheet worksheet = _workbook.Worksheets.Add(sheet.Name))
                    {
                        AddRegions(worksheet, sheet);

                    }
                }
            }
            else
            {

                _sheets = new List<ExcelSheet>();
                var excelSheet = new ExcelSheet();
                var regions = new List<ExcelDataRegion>();
                var region = new ExcelDataRegion();

                region.ColumnsToExcel = columnsToExcel;
                region.HeaderNames = headerNames;
                region.DataList = new List<object>();
                region.DataList.AddRange(dataList);
                region.Coordinates = new ExcelCoordinates();
                region.Coordinates.DataColumnInitial = 1;
                region.Coordinates.DataRowInitial = 2;
                region.Coordinates.HeaderColumnInitial = 1;
                region.Coordinates.HeaderRowInitial = 1;
                regions.Add(region);
                excelSheet.Name = sheetName;
                excelSheet.Regions = regions;

                using (IXLWorksheet worksheet = _workbook.Worksheets.Add(sheetName))
                {
                    AddRegions(worksheet, excelSheet);
                }
            }

        }
        private void AddRegions(IXLWorksheet worksheet, ExcelSheet sheet)
        {
            foreach (var dataRegion in sheet.Regions)
            {
                Throw<ArgumentNullException>.WhenObject.IsNull(() => dataRegion.Coordinates);
                _dataFormat = ExcelDataFormatFactory.GetDataFormat(dataRegion.ConfigurationDataFormat);
                _excelStyle = ExcelStyleFactory.GetStyle(dataRegion.ConfigurationExcelStyle);
                AddHeader(worksheet, dataRegion);
                AddRows(worksheet, dataRegion);
                SetStyles(worksheet, dataRegion);
                dataRegion.Coordinates.HeaderRowInitial++;
            }
        }
        private void AddHeader(IXLWorksheet worksheet, ExcelDataRegion dataRegion)
        {

            var headerRow = dataRegion.Coordinates.HeaderRowInitial;
            var headerColumn = dataRegion.Coordinates.HeaderColumnInitial;

            foreach (var name in dataRegion.HeaderNames)
            {
                worksheet.Cell(headerRow, headerColumn).Value = name;
                headerColumn++;
            }

        }
        private void AddRows(IXLWorksheet worksheet, ExcelDataRegion dataRegion)
        {

            var row = dataRegion.Coordinates.DataRowInitial;

            foreach (var item in dataRegion.DataList)
            {
                var column = dataRegion.Coordinates.DataColumnInitial;
                if (dataRegion.ColumnsToExcel.Count() == 0)
                {
                    return;
                }

                foreach (var property in dataRegion.ColumnsToExcel)
                {
                    var p = item.GetType().GetProperty(property.Name);
                    if (p != null)
                    {
                        SetFormat(worksheet.Cell(row, column), p.GetValue(item, null), property.FormatWithEuros);
                        worksheet.Cell(row, column).Value = p.GetValue(item, null);
                    }
                    column++;
                }
                row++;
            }
        }
        private void SetFormat(IXLCell cell, object column, bool formatWithEuros)
        {

            _dataFormat.ApplyFormat(cell, column, formatWithEuros);


        }



        private void SetStyles(IXLWorksheet worksheet, ExcelDataRegion dataRegion)
        {
            //Rango de la cabecera
            int firstCellRow = dataRegion.Coordinates.HeaderRowInitial;
            int firstCellColumn = dataRegion.Coordinates.HeaderColumnInitial;
            int lastCellRow = dataRegion.Coordinates.HeaderRowInitial;
            int lastCellColumn = dataRegion.ColumnsToExcel.Count();
            var rngHeader = worksheet.Range(firstCellRow, firstCellColumn, lastCellRow, lastCellColumn);

            _excelStyle.ApplyStyles(rngHeader);
            worksheet.Columns().AdjustToContents();

        }


    }
}
