using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DemoHarce.CrossCutting.Pdf
{
    public class PdfReplace
    {
        private readonly string _pathSource;
        private readonly string _pathDest;
        /// <summary>
        /// Valores que se pretenden remplazar.
        /// String: Nombre del texto a localizar
        /// Object: valor por el que se quiere sustituir el texto encontrado.
        /// </summary>
        private readonly Dictionary<string, object> _values;
        public PdfReplace(string pathSource, string pathDest, Dictionary<string, object> values)
        {
            _pathSource = pathSource;
            _pathDest = pathDest;
            _values = values;
        }
        /// <summary>
        /// Fill a fillable form fields
        /// </summary>
        public void FillForm()
        {
            using (PdfReader reader = new PdfReader(_pathSource))
            {
                using (PdfStamper stamper = new PdfStamper(reader, new FileStream(_pathDest, FileMode.Create)))
                {
                    AcroFields form = stamper.AcroFields;
                    foreach (KeyValuePair<string, AcroFields.Item> kvp in form.Fields)
                    {
                        string translatedFileName = form.GetTranslatedFieldName(kvp.Key);
                        var value = _values.FirstOrDefault(v => v.Key == translatedFileName);
                        if (value.Value != null)
                        {
                            form.SetField(translatedFileName, value.Value.ToString());
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Replace texts. 
        /// TODO: Los textos con formato creado en word introducen caracteres entre las palabras y no lo localiza.
        /// </summary>
        public void Replace()
        {
            using (FileStream stream = new FileStream(_pathSource, FileMode.Open))
            {

                using (PdfReader pdfReader = new PdfReader(stream))
                {
                    for (int x = 1; x <= pdfReader.NumberOfPages; x++)
                    {
                        using (FileStream streamDest = new FileStream(_pathDest, FileMode.Create))
                        {
                            PdfDictionary dict = pdfReader.GetPageN(x);
                            PdfObject obj = dict.GetDirectObject(PdfName.CONTENTS);
                            if (obj.GetType() == typeof(PRStream))
                            {
                                ReplacePRStream(obj);
                            }
                            if (obj.GetType() == typeof(PdfArray))
                            {
                                foreach (var r in (PdfArray)obj)
                                {
                                    PRIndirectReference ir = (PRIndirectReference)r;
                                    PdfObject refdObj = pdfReader.GetPdfObject(ir.Number);
                                    if (refdObj.IsStream())
                                    {
                                        ReplacePRStream(refdObj);
                                    }
                                }
                            }
                            using (PdfStamper stamper = new PdfStamper(pdfReader, streamDest))
                            {
                            }
                        }
                    }
                }
            }



        }
        /// <summary>
        /// Reemplaza las cadenas de texto que encuentre en el array de datos del PDF.
        /// </summary>
        /// <param name="obj"></param>
        private void ReplacePRStream(PdfObject obj)
        {
            PRStream prStream = (PRStream)obj;
            byte[] data = PdfReader.GetStreamBytes(prStream);
            prStream.SetData(ReplaceValues(data));

        }
        /// <summary>
        /// Convierte a cadena el array de datos y remplaza los valores.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] ReplaceValues(byte[] data)
        {
            var dataString = Encoding.UTF8.GetString(data);
            foreach (var value in _values)
            {
                data = Encoding.UTF8.GetBytes(dataString.Replace(value.Key.ToString(), value.Value.ToString()));
            }
            return data;
        }



    }

}
