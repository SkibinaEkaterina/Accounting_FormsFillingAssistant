using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;


namespace Accounting_FormsFillingAssistant
{
    public static class DatabaseConnection
    {

        static Dictionary<string, List<string>> DataBaseHeaders = new Dictionary<string, List<string>> { 
        
        ["Организации"] = new List<string> {"Id", "Название", "ИНН", "КПП", "Адрес"},
        ["Счета"] = new List<string> { "Id", "Номер счета", "Название организации владельца", "Название банка", "id организации владельца", "id банка" },
        ["Банки"] = new List<string> { "Id", "Название", "Город","Номер счета банка", "БИК" }

        };



        /// <summary>
        /// Создаёт Excel файл (в формате БД, необходимой для работы программы) по указанному пути.
        /// </summary>
        /// <param name="PathToFile"> Путь, по которому будет создана БД. </param>
        public static void CreateDataBase(string PathToFile)
        {


            if (File.Exists(PathToFile))
            {
                MessageBox.Show("В рабочей директории уже существует файл База_данных_программы.xlsx. Чтобы создать новую базу, удалите данный файл и заново нажмите кнопку 'Создать'.");
                return;
            }


            if (!Directory.Exists(PathToFile)) // "!" забыл поставить
            {

                Excel.Application xlApp = null;
                Excel.Workbook xlWorkBook = null;
                object misValue = System.Reflection.Missing.Value;

                try
                {
                    xlApp = new Excel.Application();
                    

                    if (xlApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    // Создать страницу excel с банками.
                    Excel.Worksheet xlWorkSheet_Banks = xlWorkBook.ActiveSheet as Excel.Worksheet;
                    xlWorkSheet_Banks.Name = "Банки";

                    for (var i = 0; i < DataBaseHeaders["Банки"].Count; i++)
                    {
                        xlWorkSheet_Banks.Cells[1, i + 1] = DataBaseHeaders["Банки"][i];
                    }

                    // Создать страницу excel со счетами.
                    Excel.Worksheet xlWorkSheet_BankAccounts = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue)
                            as Excel.Worksheet;
                    xlWorkSheet_BankAccounts.Name = "Счета";

                    for (var i = 0; i < DataBaseHeaders["Счета"].Count; i++)
                    {
                        xlWorkSheet_BankAccounts.Cells[1, i + 1] = DataBaseHeaders["Счета"][i];
                    }

                    // Создать страницу excel с организациями.
                    Excel.Worksheet xlWorkSheet_Organisations = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue);
                    xlWorkSheet_Organisations.Name = "Организации";

                    for (var i = 0; i < DataBaseHeaders["Организации"].Count; i++)
                    {
                        xlWorkSheet_Organisations.Cells[1, i + 1] = DataBaseHeaders["Организации"][i];
                    }

                    xlWorkBook.SaveAs(PathToFile, Excel.XlFileFormat.xlOpenXMLWorkbook,
                                        misValue, misValue, misValue, misValue,
                                        Excel.XlSaveAsAccessMode.xlNoChange,
                                        misValue, misValue, misValue, misValue, misValue);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    xlWorkBook.Close(misValue, misValue, misValue);
                    xlApp.UserControl = true;
                    xlApp.Quit();
                }

                
            }
        }


        // где хранится файл базы





        /// <summary>
        /// Загрузить объекты из БД. Возращает список объектов.
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string, string>> LoadAllObjectsFromExcelTable(string PathToExcelFile, string SheetName)
        {
            //string PathToExcelFile = Properties.Settings.Default.PathToDataBase;

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return null;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\") + 1);
            KillSpecificExcelFileProcess(FileName);


            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            object misValue = System.Reflection.Missing.Value;
            List<Dictionary<string, string>> DataOnExcelSheet = new List<Dictionary<string, string>>();


            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return null;
                }

  
                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;

  
                Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;

            


                // количество заполненных строк
                int NumberOfNonEmptyRows = excelWorksheet.UsedRange.Rows.Count;
                // количество заполненных колонок
                int NumberOfNonEmptyColumns = excelWorksheet.UsedRange.Columns.Count;

                // Выгрузить заголовки
                List<string> Headers = new List<string>();
                for(var i=0; i< NumberOfNonEmptyColumns; i++)
                {
                    Headers.Add((string)(excelWorksheet.Cells[1, i + 1] as Excel.Range).Value);
                }
          


                for (var row=1; row < NumberOfNonEmptyRows; row++)
                {
                    Dictionary<string, string> CurrentDictionary = new Dictionary<string, string>();

                    //var hhh = (excelWorksheet.Cells[row + 1, 1] as Excel.Range).Value.ToString();


                    for (var col = 0; col < NumberOfNonEmptyColumns; col++)
                    {

                        CurrentDictionary[Headers[col]] = (excelWorksheet.Cells[row+1, col + 1] as Excel.Range).Value.ToString();
                    }
                    DataOnExcelSheet.Add(CurrentDictionary);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                xlWorkBook.Close(misValue, misValue, misValue);
                xlApp.UserControl = true;
                xlApp.Quit();
            }

            if (DataOnExcelSheet.Count == 0)
            {
                DataOnExcelSheet = null;
            }


            return DataOnExcelSheet;
        }

        /// <summary>
        /// Сохранить список объектов в БД. БД полностью очищается, будет содержать только загружаемый список объектов.
        /// </summary>
        /// <param name="listOfObjects"></param>
        public static void SaveAllObjectsToExcelTable(string PathToExcelFile, 
                                                      List<Dictionary<string, string>> DataToSave, 
                                                      string SheetName)
        {
            // проверить набор данных
            

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return ;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\")+1);
            KillSpecificExcelFileProcess(FileName);

            if (DataToSave == null)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            if(DataToSave.Count == 0)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            // сверить заголовки
            
            List<string> LoadedHeadersList = DataToSave[0].Keys.ToList();
            List<string> TemplateHeaders = DataBaseHeaders[SheetName];

            if (LoadedHeadersList.Count != TemplateHeaders.Count)
            {
                MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                return;
            }

            for(int i=0; i< TemplateHeaders.Count; i++)
            {
                if(LoadedHeadersList[i] != TemplateHeaders[i])
                {
                    MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                    return;
                }
            }



            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return ;
                }


                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                xlApp.DisplayAlerts = false;

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;


                Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;

                // удалить информацию на странице (кроме заголовков)
                ClearSheet(excelWorksheet);

                Excel.Range cells = excelWorksheet.Cells;
              
                cells.NumberFormat = "@";

                // сохранить информацию на листе
                for (int row=0; row<DataToSave.Count; row++)
                {
                    for(int col=0; col< TemplateHeaders.Count; col++)
                    {
                        excelWorksheet.Cells[row + 2, col + 1] = DataToSave[row][TemplateHeaders[col]];
                    }
                }


                //File.Delete(PathToExcelFile);

                xlWorkBook.SaveAs(PathToExcelFile, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, 
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);



                xlApp.DisplayAlerts = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                xlWorkBook.Close(misValue, misValue, misValue);
                xlApp.UserControl = true;
                xlApp.Quit();
            }
        }

        private static void ClearSheet(Excel.Worksheet excelWorksheet)
        {
            // количество заполненных строк
            int NumberOfNonEmptyRows = excelWorksheet.UsedRange.Rows.Count;

            if(NumberOfNonEmptyRows == 1)
            {
                return;
            }

            for(int row = NumberOfNonEmptyRows; row > 1; row--)
            {
                excelWorksheet.Rows[row].Delete();
            }
            

        }


        /// <summary>
        /// Добавить новый объект в конец списка в БД.
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveObjectInTheEndOfExcelTable(Organisation obj, string SheetName)
        {
            
        }


        /// <summary>
        /// Закрыть все процессы EXCEL, связанные с файлом.
        /// </summary>
        /// <param name="excelFileName"> Имя файла. </param>
        private static void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                //if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName ||
                //    process.MainWindowTitle == excelFileName + " - Excel")
                //    process.Kill();

                if (process.MainWindowTitle.Contains(excelFileName))
                    process.Kill();

            }
            



        }

    }
}
