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
    /// <summary>
    /// Класс, осуществляющий взаимодействие непосредственно с файлом БД.
    /// </summary>
    public static class DatabaseConnection
    {
        /// <summary>
        /// Значение - поле пусто.
        /// </summary>
        static object misValue = System.Reflection.Missing.Value;
        /// <summary>
        /// Словарь с правильными заголовками БД.
        /// </summary>
        static Dictionary<string, List<string>> DataBaseHeaders = new Dictionary<string, List<string>>
        {

            ["Организации"] = new List<string> { "Id", "Название", "ИНН", "КПП", "Адрес" },
            ["Счета"] = new List<string> { "Id", "Номер счета", "Название организации владельца", "Название банка", "id организации владельца", "id банка" },
            ["Банки"] = new List<string> { "Id", "Название", "Город", "Номер счета банка", "БИК" }

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


        /// <summary>
        /// Загрузить объекты из БД. Возращает список объектов.
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string, string>> LoadAllObjectsFromOneExcelSHeet(string PathToExcelFile, string SheetName)
        {

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return null;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\") + 1);
            KillSpecificExcelFileProcess(FileName);


            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            
            List<Dictionary<string, string>> DataOnExcelSheet = new List<Dictionary<string, string>>();

            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel не инсталлирован!");
                    return null;
                }

  
                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;

                DataOnExcelSheet = LoadInfoFromOneWorkSheet(excelSheets, SheetName);

                
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
        /// Загрузить объекты нескольких типов из БД. Возращает список объектов.
        /// </summary>
        /// <param name="PathToExcelFile">Путь к БД.</param>
        /// <param name="SheetNames"></param>
        /// <returns></returns>
        public static Dictionary<string, List<Dictionary<string, string>>> LoadAllObjectsFromSeveralExcelSheets(string PathToExcelFile, string[] SheetNames)
        {

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return null;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\") + 1);
            KillSpecificExcelFileProcess(FileName);

            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Dictionary<string,List<Dictionary<string, string>>> DictionaryOfObjectsOnExcelSheets = new Dictionary<string,List<Dictionary<string, string>>>();


            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Приложение Excel не инсталлировано!");
                    return null;
                }

                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;

                foreach(var SheetName in SheetNames)
                {
                    DictionaryOfObjectsOnExcelSheets[SheetName] = LoadInfoFromOneWorkSheet(excelSheets, SheetName);
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

            if (DictionaryOfObjectsOnExcelSheets.Count == 0)
            {
                DictionaryOfObjectsOnExcelSheets = null;
            }

            return DictionaryOfObjectsOnExcelSheets;
        }

        /// <summary>
        /// Выгрузка информации с одной страницы файла.
        /// </summary>
        /// <param name="excelSheets">Список страниц файла.</param>
        /// <param name="SheetName">Название страницы, с которой будем выгружать объекты.</param>
        /// <returns></returns>
        private static List<Dictionary<string, string>> LoadInfoFromOneWorkSheet(Excel.Sheets excelSheets, string SheetName)
        {
            Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;

            if (excelWorksheet == null)
                throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Excel файл не содержит нужной страницы. Создайте файл заново или укажите путь к файлу в верном формате.", "original");


            List<Dictionary<string, string>> DataOnExcelSheet = new List<Dictionary<string, string>>();

            // количество заполненных строк
            int NumberOfNonEmptyRows = excelWorksheet.UsedRange.Rows.Count;
            // количество заполненных колонок
            int NumberOfNonEmptyColumns = excelWorksheet.UsedRange.Columns.Count;

            if(NumberOfNonEmptyColumns == 0)
                throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Создайте файл заново или укажите путь к файлу в верном формате.", "original");


            List<string> TemplateHeaders = DataBaseHeaders[SheetName];

            // Выгрузить заголовки на странице
            List<string> Headers = new List<string>();
            for (var i = 0; i < NumberOfNonEmptyColumns; i++)
            {
                Headers.Add((string)(excelWorksheet.Cells[1, i + 1] as Excel.Range).Value);
            }

            // Проверка заголовков страницы.
            for (int i = 0; i < NumberOfNonEmptyColumns; i++)
            {
                if (TemplateHeaders[i] != Headers[i])
                {
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Имена колонок на выбранной странице Excel файла указаны неверно. Создайте файл заново или укажите путь к файлу в верном формате.", "original");
                }
            }

            for (var row = 1; row < NumberOfNonEmptyRows; row++)
            {
                Dictionary<string, string> CurrentDictionary = new Dictionary<string, string>();

                for (var col = 0; col < NumberOfNonEmptyColumns; col++)
                {

                    CurrentDictionary[Headers[col]] = (excelWorksheet.Cells[row + 1, col + 1] as Excel.Range).Value.ToString();
                }
                DataOnExcelSheet.Add(CurrentDictionary);
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

            List<string> TemplateHeaders = DataBaseHeaders[SheetName];
            if (DataToSave.Count != 0)
            {
                // сверить заголовки

                List<string> LoadedHeadersList = DataToSave[0].Keys.ToList();
                

                if (LoadedHeadersList.Count != TemplateHeaders.Count)
                {
                    MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                    return;
                }

                for (int i = 0; i < TemplateHeaders.Count; i++)
                {
                    if (LoadedHeadersList[i] != TemplateHeaders[i])
                    {
                        MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                        return;
                    }
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
                    MessageBox.Show("Excel не инсталлирован!");
                    return ;
                }


                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                xlApp.DisplayAlerts = false;

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;


                Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;

                if (excelWorksheet == null)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Excel файл не содержит нужной страницы. Создайте файл заново или укажите путь к файлу в верном формате.", "original");


                // удалить информацию на странице (кроме заголовков)
                ClearSheet(excelWorksheet);

                Excel.Range cells = excelWorksheet.Cells;
              
                cells.NumberFormat = "@";

                // количество заполненных колонок
                int NumberOfNonEmptyColumns = excelWorksheet.UsedRange.Columns.Count;

                if (NumberOfNonEmptyColumns == 0)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Создайте файл заново или укажите путь к файлу в верном формате.", "original");

                // Проверка заголовков страницы.
                for (int i = 0; i < NumberOfNonEmptyColumns; i++)
                {
                    if (TemplateHeaders[i ] != (cells[1, i+1] as Excel.Range).Value.ToString())
                    {
                        throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Имена колонок на выбранной странице Excel файла указаны неверно. Создайте файл заново или укажите путь к файлу в верном формате.", "original");
                    }
                }


                if (DataToSave.Count > 0)
                {
                    // сохранить информацию на листе
                    for (int row = 0; row < DataToSave.Count; row++)
                    {
                        for (int col = 0; col < TemplateHeaders.Count; col++)
                        {
                            cells[row + 2, col + 1] = DataToSave[row][TemplateHeaders[col]];
                        }
                    }
                }
               


                //File.Delete(PathToExcelFile);

                xlWorkBook.SaveAs(PathToExcelFile, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, 
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);



                xlApp.DisplayAlerts = true;
                //MessageBox.Show("Изменения успешно добавлены в базу.");
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


        /// <summary>
        /// Очистить страницу (кроме заголовков).
        /// </summary>
        /// <param name="excelWorksheet"></param>
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
        /// <param name="obj">Словарь значений.</param>
        public static void SaveObjectInTheEndOfExcelTable(string PathToExcelFile,
                                                          Dictionary<string, string> obj, 
                                                          string SheetName)
        {
            // проверить набор данных

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\") + 1);
            KillSpecificExcelFileProcess(FileName);

            if (obj == null)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            if (obj.Count == 0)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            // сверить заголовки

            List<string> LoadedHeadersList = obj.Keys.ToList();
            List<string> TemplateHeaders = DataBaseHeaders[SheetName];

            if (LoadedHeadersList.Count != TemplateHeaders.Count)
            {
                MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                return;
            }

            for (int i = 0; i < TemplateHeaders.Count; i++)
            {
                if (LoadedHeadersList[i] != TemplateHeaders[i])
                {
                    MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                    return;
                }
            }


            // Сохранение данных.
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel не инсталлирован!");
                    return;
                }


                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                xlApp.DisplayAlerts = false;

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;


                Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;

                if (excelWorksheet == null)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Excel файл не содержит нужной страницы. Создайте файл заново или укажите путь к файлу в верном формате.", "original");


                Excel.Range cells = excelWorksheet.Cells;

                cells.NumberFormat = "@";

                // количество заполненных строк
                int NumberOfNonEmptyRows = excelWorksheet.UsedRange.Rows.Count;
                // количество заполненных колонок
                int NumberOfNonEmptyColumns = excelWorksheet.UsedRange.Columns.Count;

                if (NumberOfNonEmptyColumns == 0)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Создайте файл заново или укажите путь к файлу в верном формате.", "original");

                // Проверка заголовков страницы.
                for (int i = 0; i < NumberOfNonEmptyColumns; i++)
                {
                    if (TemplateHeaders[i] != (cells[1, i + 1] as Excel.Range).Value.ToString())
                    {
                        throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Имена колонок на выбранной странице Excel файла указаны неверно. Создайте файл заново или укажите путь к файлу в верном формате.", "original");
                    }
                }

                if (NumberOfNonEmptyRows == 1)
                {
                    obj["Id"] = "1";
                }
                else
                {
                    obj["Id"] = (Int32.Parse((excelWorksheet.Cells[NumberOfNonEmptyRows, 1] as Excel.Range).Value.ToString()) + 1).ToString();

                }

                // сохранить информацию на листе
                for (int col = 0; col < TemplateHeaders.Count; col++)
                {
                        excelWorksheet.Cells[NumberOfNonEmptyRows+1, col + 1] = obj[TemplateHeaders[col]]; 
                }

                xlWorkBook.SaveAs(PathToExcelFile, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                xlApp.DisplayAlerts = true;
                //MessageBox.Show("Новый объект успешно добавлен в базу.");
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

        /// <summary>
        /// Редактирвоать нужный объект в БД.
        /// </summary>
        /// <param name="PathToExcelFile">Путь к файлу БД.</param>
        /// <param name="obj">Словарь новых значений.</param>
        /// <param name="SheetName">Название страницы, на котрой производим редактирование.</param>
        public static void EditObjectInExcelTable(string PathToExcelFile,
                                                          Dictionary<string, string> obj,
                                                          string SheetName)
        {
            // проверить набор данных

            if (!File.Exists(PathToExcelFile))
            {
                MessageBox.Show("База данных не найдена. Пройдите в настройки и укажите путь к базе.");
                return;
            }

            string FileName = PathToExcelFile.Substring(PathToExcelFile.LastIndexOf(@"\") + 1);
            KillSpecificExcelFileProcess(FileName);

            if (obj == null)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            if (obj.Count == 0)
            {
                MessageBox.Show("Загружаемый набор данных не содержит элементов.");
                return;
            }

            // сверить заголовки

            List<string> LoadedHeadersList = obj.Keys.ToList();
            List<string> TemplateHeaders = DataBaseHeaders[SheetName];

            if (LoadedHeadersList.Count != TemplateHeaders.Count)
            {
                MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                return;
            }

            for (int i = 0; i < TemplateHeaders.Count; i++)
            {
                if (LoadedHeadersList[i] != TemplateHeaders[i])
                {
                    MessageBox.Show("Загружаемый набор данных не соответствует шаблону для заявленного типа.");
                    return;
                }
            }


            // Сохранение данных.
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Excel не инсталлирован!");
                    return;
                }


                xlWorkBook = xlApp.Workbooks.Open(PathToExcelFile,
                                                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                                    true, false, 0, true, false, false);

                xlApp.DisplayAlerts = false;

                Excel.Sheets excelSheets = xlWorkBook.Worksheets;


                Excel.Worksheet excelWorksheet =
                    (Excel.Worksheet)excelSheets.get_Item(SheetName) as Excel.Worksheet;


                if(excelWorksheet == null)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Excel файл не содержит нужной страницы. Создайте файл заново или укажите путь к файлу в верном формате.", "original");


                Excel.Range cells = excelWorksheet.Cells;

                cells.NumberFormat = "@";

                // количество заполненных строк
                int NumberOfNonEmptyRows = excelWorksheet.UsedRange.Rows.Count;
                // количество заполненных колонок
                int NumberOfNonEmptyColumns = excelWorksheet.UsedRange.Columns.Count;
                int NumberOfRowWithNeededBank = -1;

                if (NumberOfNonEmptyColumns == 0)
                    throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Создайте файл заново или укажите путь к файлу в верном формате.", "original");

                // Проверка заголовков страницы.
                for (int i = 0; i < NumberOfNonEmptyColumns; i++)
                {
                    if (TemplateHeaders[i] != (cells[1, i + 1] as Excel.Range).Value.ToString())
                    {
                        throw new System.ArgumentException("Формат базы данных не удовлетворяет требованиям. Имена колонок на выбранной странице Excel файла указаны неверно. Создайте файл заново или укажите путь к файлу в верном формате.", "original");
                    }
                }



                for (int i = 2; i< NumberOfNonEmptyRows+1; i++)
                {
                    if(obj["Id"] == (cells[i, 1] as Excel.Range).Value.ToString())
                    {
                        NumberOfRowWithNeededBank = i;
                    }
                }

                // Не нашлии нужной строки - создаем новую запись.
                if (NumberOfRowWithNeededBank == -1) 
                {
                    NumberOfRowWithNeededBank = NumberOfNonEmptyRows+1;
                }

                // сохранить информацию на листе
                for (int col = 0; col < TemplateHeaders.Count; col++)
                {
                    excelWorksheet.Cells[NumberOfRowWithNeededBank, col + 1] = obj[TemplateHeaders[col]];
                }

                xlWorkBook.SaveAs(PathToExcelFile, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                xlApp.DisplayAlerts = true;
                //MessageBox.Show("Изменения успешно добавлены в базу.");
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
                process.Kill();
                //if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName ||
                //    process.MainWindowTitle == excelFileName + " - Excel")
                //    process.Kill();

                //if (process.MainWindowTitle.Contains(excelFileName))
                //    process.Kill();

            }
            



        }

    }
}
