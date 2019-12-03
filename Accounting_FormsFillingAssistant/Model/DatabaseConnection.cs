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
            "Id", "Название", "ИНН", "БИК", "КПП"
            };

            List<string> ListOfBankAccountsHeaders = new List<string> {
            "Id", "Номер счета", "Название организации владельца", "Название банка", "id организации владельца", "id банка"
            };

            List<string> ListOfBanksHeaders = new List<string> {
            "Id", "Название", "Номер счета", "БИК"
            };


            if (File.Exists(PathToFile))
            {
                MessageBox.Show("В рабочей директории уже существует файл База_данных_программы.xlsx. Чтобы создать новую базу, удалите данный файл и заново нажмите кнопку 'Создать'.");
                return;
            }


            if (!Directory.Exists(PathToFile)) // "!" забыл поставить
            {

                Excel.Application xlApp = new Excel.Application();
                object misValue = System.Reflection.Missing.Value;

                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }


                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);


                // Создать страницу excel с банками.
                Excel.Worksheet xlWorkSheet_Banks = xlWorkBook.ActiveSheet as Excel.Worksheet;
                xlWorkSheet_Banks.Name = "Банки";

                for (var i = 0; i < ListOfBanksHeaders.Count; i++)
                {
                    xlWorkSheet_Banks.Cells[1, i+1] = ListOfBanksHeaders[i];
                }


               

                // Создать страницу excel со счетами.
                Excel.Worksheet xlWorkSheet_BankAccounts = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue)
                        as Excel.Worksheet;
                xlWorkSheet_BankAccounts.Name = "Счета";

                for (var i = 0; i < ListOfBankAccountsHeaders.Count; i++)
                {
                    xlWorkSheet_BankAccounts.Cells[1, i+1] = ListOfBankAccountsHeaders[i];
                }


                // Создать страницу excel с организациями.
                Excel.Worksheet xlWorkSheet_Organisations = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue);
                xlWorkSheet_Organisations.Name = "Организации";

                for (var i = 0; i < ListOfOrganisationsHeaders.Count; i++)
                {
                    xlWorkSheet_Organisations.Cells[1, i+1] = ListOfOrganisationsHeaders[i];
                }




                xlWorkBook.SaveAs(PathToFile, Excel.XlFileFormat.xlOpenXMLWorkbook,
                                    misValue, misValue, misValue, misValue,
                                    Excel.XlSaveAsAccessMode.xlNoChange,
                                    misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(misValue, misValue, misValue);
                xlApp.UserControl = true;
                xlApp.Quit();




                ////Here saving the file in xlsx
                //xlWorkBook.SaveAs(PathToFile, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                //misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Quit();


            }
        }


        // где хранится файл базы





        /// <summary>
        /// Загрузить объекты из БД. Возращает список объектов.
        /// </summary>
        /// <returns></returns>
        public static List<Organisation> LoadAllObjectsFromExcelTable(string SheetName)
        {
            return null;
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
