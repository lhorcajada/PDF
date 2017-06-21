

namespace DemoHarce.CrossCutting.Excel
{
    public class ExcelColumn
    {
        public string Name { get; set; }
        private bool _formatWithEuros = false;

        public bool FormatWithEuros
        {
            get { return _formatWithEuros; }
            set { _formatWithEuros = value; }
        }
    }
}
