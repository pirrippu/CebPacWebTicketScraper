using System;
using ExcelLibrary.SpreadSheet;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineScraper.Model;

namespace AirlineScraper.BusinessLogic
{
    public class ReportGenerator
    {
        /// <summary>
        /// phillip.esguerra 03152017
        /// Generate excel report
        /// </summary>
        /// <param name="resultsList"></param>
        /// <param name="airline"></param>
        /// <returns>MemoryStream type. Dynamic data.</returns>
        public static MemoryStream GenerateReport(ref List<SearchResultsModel> resultsList, string airline)
        {
            MemoryStream mStream = new MemoryStream();
            Workbook workBook = new Workbook();
            Worksheet workSheet = new Worksheet(airline);

            try
            {
                workSheet.Cells[0, 0] = new Cell("Flight Number");
                workSheet.Cells[0, 1] = new Cell("Time");
                workSheet.Cells[0, 2] = new Cell("Date");
                workSheet.Cells[0, 3] = new Cell("Price");
                workSheet.Cells[0, 4] = new Cell("URL");

                int row = 1;
                foreach (var item in resultsList)
                {
                    workSheet.Cells[row, 0] = new Cell(item.FlightNo);
                    workSheet.Cells[row, 1] = new Cell(item.Time);
                    workSheet.Cells[row, 2] = new Cell(item.Date.ToShortDateString());
                    workSheet.Cells[row, 3] = new Cell(item.Price);
                    workSheet.Cells[row, 4] = new Cell(item.URL);
                }


                workBook.Worksheets.Add(workSheet);

                workBook.Save(mStream);
                mStream.Position = 0;
                mStream.Flush();
            }
            catch (Exception)
            {
                
            }

            return mStream;
        }
    }
}
