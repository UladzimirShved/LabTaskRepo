//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Excel = Microsoft.Office.Interop.Excel;
//using System.IO;

/*
 * не используется, но может пригодиться
 */


//namespace Task2
//{
//    public static class DataFromFile
//    {
//        private static Excel.Application excelApp = new Excel.Application();
//        private static Excel._Worksheet workSheet = new Excel.Worksheet();


//        public static List<Journs> GetDataFromExcelFile()
//        {
//            List<Journs> fullDataFromFile = new List<Journs>();
//            Navigations navModel;
//            Journs jourModel;
//            string newName;
//            var workBook = excelApp.Workbooks.Open(TestData.filePath);
//            for (int journalCount = 1; journalCount <= workBook.Sheets.Count; journalCount++)
//            {
//                workSheet = workBook.Sheets[journalCount];
//                if (workSheet.Name == "journalofpediatricsurgicalnursi")
//                {
//                    newName = "journalofpediatricsurgicalnursing";
//                }
//                else
//                {
//                    newName = workSheet.Name;
//                }

//                jourModel.journalName = newName;


//                List<Navigations> nav = new List<Navigations>();

//                for (int col = 1; GetValue(2, col) != ""; col++)
//                {
//                    string navigationName = GetValue(2, col);
//                    bool flag = false;
//                    for (int row = 3; GetValue(row, col) != ""; row++)
//                    {
//                        if (GetValue(row, col) != "")
//                        {
//                            navModel.item = GetValue(row, col);
//                            navModel.bigItem = navigationName;
//                            nav.Add(navModel);
//                            flag = true;
//                        }
//                        else
//                        {
//                            if (!flag)
//                            {
//                                navModel.item = null;
//                                navModel.bigItem = navigationName;
//                                nav.Add(navModel);
//                                break;
//                            }
//                        }
//                    }
//                }
//                jourModel.navigation = nav;
//                fullDataFromFile.Add(jourModel);
//            }

//            CloseExcelApp();
//            return fullDataFromFile;
//        }

//        private static void CloseExcelApp()
//        {
//            excelApp.Quit();
//            excelApp = null;
//        }

//        private static string GetValue(int row, int col)
//        {
//            string cellValue = "";
//            Excel.Range cell = (Excel.Range)workSheet.Cells[row, col];
//            if (cell.Value != null)
//            {
//                cellValue = cell.Value.ToString();
//            }
//            return cellValue;
//        }
//        public static List<Journs> MakeParamsData(List<string> journName)//string jourName)
//        {
//            List<Journs> someJournals = new List<Journs>();
//            List<string> journalNames = new List<string>();
//            var journalsFromXml = DeserealiseJournals.DeserealiseXml();
//            //if (jourName == "")
//            //{
//            //    return GetDataFromExcelFile();
//            //}

//            if (journalsFromXml.journalName.Count() == 0)//journName.Count == 0)
//            {
//                return GetDataFromExcelFile();
//            }
//            else
//            {                
//                //string[] namesFromTestData = jourName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//                //for (int i = 0; i < namesFromTestData.Count(); i++)
//                //{
//                //    journalNames.Add(namesFromTestData[i]);
//                //}
//                foreach (var k in journalsFromXml.journalName)//journName)
//                {
//                    journalNames.Add(k.ToString());
//                }

//                foreach (var j in journalsFromXml.navigation)//GetDataFromExcelFile())
//                {
//                    foreach (string s in journalNames)
//                    {
//                        if (s == j.journalName)
//                        {
//                            someJournals.Add(j);
//                        }
//                    }
//                }
//                return someJournals;
//            }
//        }
//        }
//}
