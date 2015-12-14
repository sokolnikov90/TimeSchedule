namespace TimeSchedule
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    using CardReaderDLL;

    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing.Charts;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;

    using M3Utils;

    using SQLite;

    class UserHistoryReport
    {
       // private List<ReportColumns> reportColumns;

        private SQLiteConnection context;

        private DateTime from;

        private DateTime to;

        public UserHistoryReport(SQLiteConnection context, DateTime from, DateTime to)
        {
            this.context = context;
            this.from = from;
            this.to = to;
        }

        internal void MakeAnExcel()
        {
            string[] fromArray = from.ToString("yyyy-MM-dd HH:mm:ss").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] toArray = to.ToString("yyyy-MM-dd HH:mm:ss").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string path = Directory.GetCurrentDirectory() + "\\Reports\\USER_HISTORY_" + fromArray[0].Replace("-", "").Substring(2) + fromArray[1].Replace(":", "") + "_" + toArray[0].Replace("-", "").Substring(2) + toArray[1].Replace(":", "") + ".xlsx";

            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart;
                WorksheetPart worksheetPart;
                WorkbookStylesPart workbookStylesPart;

                workbookpart = spreadSheet.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                workbookStylesPart = workbookpart.AddNewPart<WorkbookStylesPart>();
                workbookStylesPart.Stylesheet = M3Utils.ExcelHelper.MakeStyleSheet();
                Sheets sheets = spreadSheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

                worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheet sheet = new Sheet()
                {
                    Id = spreadSheet.WorkbookPart.GetIdOfPart(worksheetPart),
                    Name = "Сотрудники",
                    SheetId = (uint)1
                };
                sheets.Append(sheet);

                this.CreateHeaderRow(worksheetPart);
                this.CreateDataRows(worksheetPart);

                var totalDates = Convert.ToInt32((to - from).TotalDays);
                double width;

                M3Utils.ExcelHelper.SetColumnWidth(worksheetPart.Worksheet, 1, 40);
            }
        }

        private void CreateHeaderRow(WorksheetPart worksheetPart)
        {
            try
            {
                Row row;
                SheetData sheetData = (SheetData)worksheetPart.Worksheet.First();

                sheetData.Append(new Row() { RowIndex = 1, Height = 30D, CustomHeight = true });
                row = (Row)sheetData.LastChild;

                string title = String.Format("История присутствия сотрудников с {0} по {1}", from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));

                var totalDates = Convert.ToInt32((to - from).TotalDays);

                for (int i = 1; i <= (totalDates + 1) * 3 - 1; i++)
                {
                    if (i > 1) title = "";

                    M3Utils.ExcelHelper.CreateCell(row, i, row.RowIndex, title, CellValues.String, 4U);
                }

                M3Utils.ExcelHelper.MergeCellsInRange(
                    worksheetPart.Worksheet,
                    "A" + row.RowIndex,
                    Encoding.ASCII.GetString(new[] { Convert.ToByte((totalDates + 1) * 3 - 2 + 65) }) + row.RowIndex);

                sheetData.Append(new Row() { RowIndex = (row.RowIndex + 1), Height = 20D, CustomHeight = true });
                
                row = (Row)sheetData.LastChild;

                var tempDateTime = from;
                row = (Row)sheetData.LastChild;
                sheetData.Append(new Row() { RowIndex = (row.RowIndex + 1) });
                row = (Row)sheetData.LastChild;

                for (int i = 1; i <= (totalDates + 1) * 3 - 2; i++)
                {
                    if (i == 1)
                    {
                        title = "Сотрудник";
                    } 
                    else if (i % 3 == 2)
                    {
                        title = tempDateTime.ToString("yyyy-MM-dd");
                        tempDateTime = tempDateTime.AddDays(1);
                    }
                    else
                    {
                        title = "";
                    }

                    M3Utils.ExcelHelper.CreateCell(row, i, row.RowIndex, title, CellValues.String, 4U);

                    if (i % 3 == 0)
                    {
                        M3Utils.ExcelHelper.MergeCellsInRange(
                            worksheetPart.Worksheet,
                            Encoding.ASCII.GetString(new[] { Convert.ToByte(i - 2 + 65) }) + row.RowIndex,
                            Encoding.ASCII.GetString(new[] { Convert.ToByte(i + 65) }) + row.RowIndex);
                    }
                }

                M3Utils.ExcelHelper.CreateCell(row, (totalDates + 1) * 3 - 1, row.RowIndex, "Среднее", CellValues.String, 4U);

                sheetData.Append(new Row() { RowIndex = (row.RowIndex + 1) });
                row = (Row)sheetData.LastChild;

                for (int i = 1; i <= (totalDates + 1) * 3 - 2; i++)
                {
                    if (i == 1)
                    {
                        title = "";
                    } 
                    else if (i % 3 == 2)
                    {
                        title = "Приход";                        
                    }
                    else if (i % 3 == 0)
                    {
                        title = "Уход";     
                    }
                    else if (i % 3 == 1)
                    {
                        title = "Время";     
                    }

                    M3Utils.ExcelHelper.CreateCell(row, i, row.RowIndex, title, CellValues.String, 4U);
                }


                M3Utils.ExcelHelper.CreateCell(row, (totalDates + 1) * 3 - 1, row.RowIndex, "", CellValues.String, 4U);

                M3Utils.ExcelHelper.MergeCellsInRange(
                   worksheetPart.Worksheet,
                   "A" + (row.RowIndex - 1),
                   "A" + row.RowIndex);  

                M3Utils.ExcelHelper.MergeCellsInRange(
                   worksheetPart.Worksheet,
                   Encoding.ASCII.GetString(new[] { Convert.ToByte((totalDates + 1) * 3 - 2 + 65) }) + (row.RowIndex - 1),
                   Encoding.ASCII.GetString(new[] { Convert.ToByte((totalDates + 1) * 3 - 2 + 65) }) + row.RowIndex);               
                //
//                for (int i = 1; i <= this.reportColumns.Count; i++)
//                    M3Utils.ExcelHelper.CreateCell(row, i, row.RowIndex, this.reportColumns[i - 1].title, CellValues.String, 4U);
            }
            catch (Exception exp)
            {
                M3Utils.Log.Instance.Info(
                    this + ".CreateHeaderRow(...) exception:",
                    exp.Message,
                    exp.Source,
                    exp.StackTrace);
            }
        }

        private void CreateDataRows(WorksheetPart worksheetPart)
        {
            try
            {
                Row row;
                SheetData sheetData;

                sheetData = (SheetData)worksheetPart.Worksheet.First();
                row = (Row)sheetData.LastChild;

                var userList = context.Query<User>("SELECT * FROM USER");

                var totalDates = Convert.ToInt32((to - from).TotalDays);

                for (int i = 0; i < userList.Count; i++)
                {
                    var cardHistoryList = context.Query<CardHistory>(String.Format(@"SELECT * FROM CARDHISTORY WHERE CardNumber = '{0}' AND DateTime BETWEEN '{1}' AND '{2}'", userList[i].CardNumber, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss")));

                    sheetData.Append(new Row() { RowIndex = (row.RowIndex + 1) });
                    row = (Row)sheetData.LastChild;

                    var tempDateTime = from;

                    string title = "";
                    TimeSpan userTotalTime = new TimeSpan();
                    int userTotalDates = 0;


                    for (int j = 1; j <= (totalDates + 1) * 3 - 2; j++)
                    {
                        if (j == 1)
                        {
                            //title = "";
                            title = userList[i].FIO;
                        }
                        else
                        {
                            var todayCardDateTime = cardHistoryList.Where(cardHistory => cardHistory.DateTime.Contains(tempDateTime.ToString("yyyy-MM-dd"))).Select(dt => DateTime.Parse(dt.DateTime)).ToList();

                            if (j % 3 == 2)
                            {
                                //title = "Приход";
                                title = todayCardDateTime.Count > 0
                                            ? (todayCardDateTime.Min()).ToString("HH:mm:ss")
                                            : "00:00:00";
                            }
                            else if (j % 3 == 0)
                            {
                                //title = "Уход";
                                title = todayCardDateTime.Count > 0
                                            ? (todayCardDateTime.Max()).ToString("HH:mm:ss")
                                            : "00:00:00";
                            }
                            else if (j % 3 == 1)
                            {
                                //title = "Время";
                                title = todayCardDateTime.Count > 0
                                            ? (todayCardDateTime.Max() - todayCardDateTime.Min()).ToString()
                                            : "00:00:00";
                                tempDateTime = tempDateTime.AddDays(1);

                                if (todayCardDateTime.Count > 0)
                                {
                                    title = (todayCardDateTime.Max() - todayCardDateTime.Min()).ToString();
                                    userTotalTime = userTotalTime.Add(todayCardDateTime.Max() - todayCardDateTime.Min());
                                    userTotalDates++;
                                }
                                else
                                {
                                    title = "00:00:00";
                                }
                            }
                        }
                        M3Utils.ExcelHelper.CreateCell(row, j, row.RowIndex, title, CellValues.String, 2U);  
                    }

                    if (userTotalDates != 0)
                    {
                        title = TimeSpan.FromTicks(userTotalTime.Ticks / userTotalDates).ToString();
                    }
                    else
                    {
                        title = "00:00:00";                        
                    }

                    M3Utils.ExcelHelper.CreateCell(row, (totalDates + 1) * 3 - 1, row.RowIndex, title, CellValues.String, 2U);

                    
                }
            }
            catch (Exception exp)
            {
                M3Utils.Log.Instance.Info(
                    this + ".CreateDataRows(...) exception:",
                    exp.Message,
                    exp.Source,
                    exp.StackTrace);
            }
        }

        private List<ReportColumns> ParseXML(string xmlPath)
        {
            XDocument xmlDocument = XDocument.Load(xmlPath);

            var columns =
                xmlDocument.Root.Elements("Column")
                    .Select(
                        column =>
                        new ReportColumns()
                        {
                            localtion = column.Element("Location").Value,
                            name = column.Element("Name").Value,
                            title = column.Element("Title").Value,
                            width = Convert.ToDouble(column.Element("Width").Value)
                        });
            return columns.ToList();
        }  
    }

    internal class ReportColumns
    {
        public string localtion { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public double width { get; set; }
    }
}
