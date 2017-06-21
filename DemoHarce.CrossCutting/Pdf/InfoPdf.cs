using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHarce.CrossCutting.Pdf
{
    public class InfoPdf
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Creator { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Keywords { get; set; }
        public string Author { get; set; }

        public InfoPdf PdfDto(InfoPdf infoPdf)
        {
            Title = infoPdf.Title;
            Subject = infoPdf.Subject;
            Creator = infoPdf.Creator;
            Description1 = infoPdf.Description1;
            Description2 = infoPdf.Description2;
            Description3 = infoPdf.Description3;
            Keywords = infoPdf.Keywords;
            Author = infoPdf.Author;

            return this;
        }
    }
}
