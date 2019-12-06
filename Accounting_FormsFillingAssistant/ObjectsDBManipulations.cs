using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс предназначен для непосредственной манипуляцией конкретными объектами.
    /// Напрмер, выгрузить организации (что предполагает выгрузку счетов с банками.
    /// </summary>
    public static class ObjectsDBManipulations
    {


       
        /// <summary>
        /// Загрузить все банки из Excel-файла.
        /// </summary>
        /// <returns> Вернет список банков.</returns>
        public static List<Bank> LoadAllBanksFromDB()
        {
            List<Bank> lAllBanks = new List<Bank>();

            // Выгрузить все банки
            List<Dictionary<string, string>> dAllBanks = 
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Банки");
            
            foreach(var newBank in dAllBanks)
            {
                lAllBanks.Add(
                    new Bank(Int32.Parse(newBank["Id"]),
                             newBank["Название"],
                             newBank["Город"],
                             newBank["Номер счета банка"],
                             newBank["БИК"]));
            }
            return lAllBanks;
        }

        public static void RemoveBankFromDB(Bank RemovingBank)
        {
            // Удалить счета банка

            // Удалить Банк

            // Выгрузить все банки
            List<Dictionary<string, string>> dAllBanks =
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Банки");

            List<Dictionary<string, string>> dAllBanksCorrected = dAllBanks.Where(b => b["Id"] != RemovingBank.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBanksCorrected, "Банки");

        }


    }



}
