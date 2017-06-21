using DemoHarce.Application.Core.Engine;
using DemoHarce.CrossCutting.Pdf.Answers.IDataTypes;
using DemoHarce.CrossCutting.Pdf.Common;
using iTextSharp.text;
using static iTextSharp.text.Font;

namespace DemoHarce.CrossCutting.Pdf.Answers.DataTypes
{
    public class ListType : IDataType
    {
        public void AddAnswer(Document _document, ResultDto result)
        {
            if (IfYouHaveAResult(result))
                ShowAResult(_document, result);
            else
                ShowList(_document, result);
        }

        private static bool IfYouHaveAResult(ResultDto result)
        {
            return result.ResultList.Count == 1;
        }

        private static void ShowAResult(Document _document, ResultDto result)
        {
            var text = result.ResultList[0].ToString();
            Paragraph paragraph = new Paragraph(text, new Font(CustomFont.BaseFontVerdana(), Context.SIZE));
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            paragraph.IndentationLeft = Context.SPACINGLEFT;
            _document.Add(paragraph);
        }

        private static void ShowList(Document _document, ResultDto result)
        {
            //Font zapfdingbats = new Font(FontFamily.ZAPFDINGBATS, 8);
            Font font = new Font(CustomFont.BaseFontVerdana(), Context.SIZE);
            //Chunk bullet = new Chunk((char)109, zapfdingbats);

            Paragraph paragraph = new Paragraph(null, font);
            paragraph.IndentationLeft = 20f;
            paragraph.SpacingBefore = Context.SPACINGBEFORE;
            foreach (var item in result.ResultList)
            {
                //paragraph.Add(bullet);
                paragraph.Add(new Phrase(" " + item + " \n", font));
            }

            _document.Add(paragraph);
        }
    }
}
