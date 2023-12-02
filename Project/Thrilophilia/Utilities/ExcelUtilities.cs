using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrilophilia.Utilities;

namespace Thrilophilia.Utilities
{
    internal class ExcelUtilities
    {
        public static List<SearchProductData> ReadExcelData(string excelFilePath, string sheetName)

        {

            List<SearchProductData> excelDataList = new List<SearchProductData>();

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);



            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });



                    var dataTable = result.Tables[sheetName];



                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            SearchProductData excelData = new SearchProductData

                            {

                                Destination = GetValueOrDefault(row, "destination"),
                                Name = GetValueOrDefault(row, "Name"),
                                Email=GetValueOrDefault(row, "Email"),
                                Phone= GetValueOrDefault(row,"Phone"),
                                Date= GetValueOrDefault(row,"Date"),
                                Count= GetValueOrDefault(row, "Count"),
                                Message= GetValueOrDefault(row, "Message"),
                                LoginEmail= GetValueOrDefault(row,"LoginEmail"),
                                Password= GetValueOrDefault(row, "Password")   



                            };



                            excelDataList.Add(excelData);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }



            return excelDataList;

        }

        public static List<LoginForm> ReadExcelData2(string excelFilePath, string sheetName)
        {
            List<LoginForm> excelDataList2 = new List<LoginForm>();

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);



            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });



                    var dataTable2 = result.Tables[sheetName];



                    if (dataTable2 != null)

                    {

                        foreach (DataRow row in dataTable2.Rows)

                        {

                            LoginForm excelData2 = new LoginForm

                            {

                                
                                Name = GetValueOrDefault(row, "Name"),
                                Email = GetValueOrDefault(row, "Email"),
                                Phone = GetValueOrDefault(row, "Phone"),

                                Password = GetValueOrDefault(row, "Password"),
                                Re_Password = GetValueOrDefault(row, "Re_Password")



                            };



                            excelDataList2.Add(excelData2);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }



            return excelDataList2;

        }



        static string GetValueOrDefault(DataRow row, string columnName)

        {

            Console.WriteLine(row + "  " + columnName);

            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;

        }
    }
}
