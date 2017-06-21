using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers;
using DemoHarce.CrossCutting.Pdf.Common;
using DemoHarce.CrossCutting.Pdf.Events;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace DemoHarce.CrossCutting.Pdf
{
    public class PdfCreate
    {
        private FileStream _fileStream;
        private Document _document;
        private PdfWriter _writer;
        private PdfPTable _table;
        private InfoPdf _infoPdf;

        public PdfCreate(InfoPdf infoPdf)
        {
            InfoPdf info = new InfoPdf();
            _infoPdf = info.PdfDto(infoPdf);
        }

        public void CreateFile(string path)
        {
            _fileStream = new FileStream(path + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            _document = new Document(PageSize.A4, 40f, 40f, 70f, 75f);
            _writer = PdfWriter.GetInstance(_document, _fileStream);
            PageEvents();

            _document.Open();
            SetMetadata();
        }

        private void SetMetadata()
        {
            _document.AddTitle(_infoPdf.Title);
            _document.AddAuthor(_infoPdf.Author);
            _document.AddSubject(_infoPdf.Subject);
            _document.AddKeywords(_infoPdf.Keywords);
            _document.AddCreator(_infoPdf.Creator);
        }

        private void PageEvents()
        {
            _writer.PageEvent = new Events.Header(_infoPdf.Title);
            _writer.PageEvent = new Footer(_infoPdf.Subject);
            //_writer.PageEvent = new WaterMark(_infoPdf.Creator);
            _writer.PageEvent = new Cover(_infoPdf.Title, _infoPdf.Subject, _infoPdf.Description1, _infoPdf.Description2, _infoPdf.Description3);
            _writer.PageEvent = new ChapterBorder();
        }

        public void CloseFile()
        {
            if (_table != null)
                _document.Add(_table);

            _document.Close();
            _writer.Close();
            _writer.Dispose();
            _document.Dispose();
            _fileStream.Close();
            _fileStream.Dispose();
        }

        public void AddSection(string text)
        {
            Paragraph paragraph = new Paragraph(text, new Font(CustomFont.BaseFontVerdana(), 14f));
            Chapter chapter = new Chapter(paragraph, 0);
            chapter.NumberDepth = 0;
            paragraph.IndentationLeft = 10f;
            ChapterBorder border = new ChapterBorder();
            _writer.PageEvent = border;
            border.SetActive(true);
            _document.Add(chapter);
            border.SetActive(false);
        }

        public void AddQuestion(string text)
        {
            Paragraph paragraph = new Paragraph(text, new Font(CustomFont.BaseFontVerdana(), 10f, Font.BOLD));
            paragraph.SpacingBefore = 5f;
            paragraph.SpacingAfter = -5f;
            paragraph.IndentationLeft = 10f;
            _document.Add(paragraph);
        }

        public void AddAnswer(ResultDto result)
        {
            Context.AddAnswer(result, _document);
        }

        public void AddParagraph(string text)
        {
            _document.Add(new Paragraph(text));

        }
        public void CreateTable(int columns)
        {
            _table = new PdfPTable(columns);
        }

        public void AddCell(string value)
        {
            _table.AddCell(value);
        }
    }
}
