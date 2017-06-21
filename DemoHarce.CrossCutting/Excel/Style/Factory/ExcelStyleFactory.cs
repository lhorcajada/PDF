using ClosedXML.Excel;

namespace DemoHarce.CrossCutting.Excel.Style.Factory
{
    public static class ExcelStyleFactory
    {
        public static ExcelStyle GetStyle(ExcelConfigurationStyle configurationStyle)
        {
            if (configurationStyle == null)
            {
                //Default
                configurationStyle = new ExcelConfigurationStyle()
                {
                    Header = new ExcelHeader()
                    {
                        BackGroundColor = XLColor.Blue,
                        FontBold = true,
                        FontColor = XLColor.White,
                        Font = XLFontFamilyNumberingValues.Roman
                    }
                };

                return new ExcelStyle(configurationStyle);

            }
            else
            {
                return new ExcelStyle(configurationStyle);
            }

        }
    }
}