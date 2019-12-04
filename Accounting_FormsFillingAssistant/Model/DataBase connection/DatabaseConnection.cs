using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Создаёт Excel файл (в формате БД, необходимой для работы программы) по указанному пути.
        /// </summary>
        /// <param name="PathToFile"> Путь, по которому будет создана БД. </param>
        public static void CreateDataBase(string PathToFile)
        {

            List<string> ListOfOrganisationsHeaders = new List<string> { 
            "Id", "Название", "ИНН", "КПП", "Адрес"
            };

            List<string> ListOfBankAccountsHeaders = new List<string> {
            "Id", "Номер счета", "Название организации владельца", "Название банка", "id организации владельца", "id банка"
            };

            List<string> ListOfBanksHeaders = new List<string> {
            "Id", "Название", "Номер счета банка", "БИК"
            };


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

                    for (var i = 0; i < ListOfBanksHeaders.Count; i++)
                    {
                        xlWorkSheet_Banks.Cells[1, i + 1] = ListOfBanksHeaders[i];
                    }

                    // Создать страницу excel со счетами.
                    Excel.Worksheet xlWorkSheet_BankAccounts = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue)
                            as Excel.Worksheet;
                    xlWorkSheet_BankAccounts.Name = "Счета";

                    for (var i = 0; i < ListOfBankAccountsHeaders.Count; i++)
                    {
                        xlWorkSheet_BankAccounts.Cells[1, i + 1] = ListOfBankAccountsHeaders[i];
                    }

                    // Создать страницу excel с организациями.
                    Excel.Worksheet xlWorkSheet_Organisations = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue);
                    xlWorkSheet_Organisations.Name = "Организации";

                    for (var i = 0; i < ListOfOrganisationsHeaders.Count; i++)
                    {
                        xlWorkSheet_Organisations.Cells[1, i + 1] = ListOfOrganisationsHeaders[i];
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
        public static void SaveAllObjectsToExcelTable(List<Organisation> listOfObjects, string SheetName)
        {
            
        }

        /// <summary>
        /// Добавить новый объект в конец списка в БД.
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveObjectInTheEndOfExcelTable(Organisation obj, string SheetName)
        {
            
        }

    }
}
