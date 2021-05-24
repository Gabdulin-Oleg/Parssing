using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;

namespace Parssing
{
    public static class ExcelImport
    {
        
        public static List<Forms> Import(Stream stream)
        {
            IWorksheet worksheet = OpenWorksheet(stream);
            var usedRange = worksheet.UsedRange;
            int rowCount = usedRange.LastRow;

            using var dbcontext = new PostgresSql();

            //Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            List<Forms> forms = new List<Forms>();

            for (int row = 2; row <= rowCount; row++)
            {
                var form = new Forms()
                {
                    //Id = Sanitizer.SanitizeInt(worksheet[row, 1].DisplayText),
                    //FirstName = Sanitizer.Sanitize(worksheet[row, 2].DisplayText),
                    //LastName = Sanitizer.Sanitize(worksheet[row, 3].DisplayText)
                };
                dbcontext.Add(form);
                dbcontext.SaveChanges();
                forms.Add(form);
            }
            return forms;
        }

        public static IWorksheet OpenWorksheet(Stream stream)
        {
            //Creates a new instance for ExcelEngine
            var excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;
            //Optimize parsing
            application.UseFastRecordParsing = true;
            stream.Position = 0;
            //Loads or open an existing workbook through Open method of IWorkbooks
            IWorkbook workbook = application.Workbooks.Open(stream);
            IWorksheet worksheet = workbook.Worksheets[0];
            return worksheet;
        }

    }
}

