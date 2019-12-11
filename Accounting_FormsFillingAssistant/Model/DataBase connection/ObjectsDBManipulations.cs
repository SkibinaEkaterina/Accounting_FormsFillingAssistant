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

        #region Banks

        /// <summary>
        /// Загрузить все банки из БД.
        /// </summary>
        /// <returns> Вернет список банков.</returns>
        public static List<Bank> LoadAllBanksFromDB()
        {
            List<Bank> lAllBanks = new List<Bank>();

            // Выгрузить все банки
            List<Dictionary<string, string>> dAllBanks = 
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Банки");
            if(dAllBanks != null)
            {
                foreach (var newBank in dAllBanks)
                {
                    lAllBanks.Add(
                        new Bank
                        {
                            Id = Int32.Parse(newBank["Id"]),
                            Bank_Name = newBank["Название"],
                            Bank_City = newBank["Город"],
                            Bank_BIK = newBank["БИК"],
                            Bank_OwnBankAccount = newBank["Номер счета банка"]
                        });

                }
            }
            
            return lAllBanks;
        }

        /// <summary>
        /// Удалить выбранный банк из БД.
        /// </summary>
        /// <param name="RemovingBank"></param>
        public static void RemoveBankFromDB(Bank RemovingBank)
        {
            // Удалить счета банка

            // Удалить Банк - выгрузить все банки и загрузить только те, что не являются нашим банком.
            List<Dictionary<string, string>> dAllBanks =
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Банки");

            List<Dictionary<string, string>> dAllBanksCorrected = dAllBanks.Where(b => b["Id"] != RemovingBank.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBanksCorrected, "Банки");

        }

        /// <summary>
        /// Добавить новый банк в БД.
        /// </summary>
        /// <param name="NewBank"></param>
        public static void AddNewBankToDB(Bank NewBank)
        {
            Dictionary<string, string> dNewBank = NewBank.ConvertBankInfoToDictionary();
            dNewBank["Id"] = null;

            DatabaseConnection.SaveObjectInTheEndOfExcelTable(Properties.Settings.Default.PathToDataBase, dNewBank, "Банки");
        }

        /// <summary>
        /// Редактировать информацию о банке в БД.
        /// </summary>
        /// <param name="ExistingBank"></param>
        public static void EditBankInDB(Bank ExistingBank)
        {

            Dictionary<string, string> dExistingBank = ExistingBank.ConvertBankInfoToDictionary();
            DatabaseConnection.EditObjectInExcelTable(Properties.Settings.Default.PathToDataBase, dExistingBank, "Банки");

        }


        #endregion


        #region Bank Accounts

        public static List<BankAccount> LoadAllBankAccountsFromDB()
        {

            // Выгрузить все банки.
            List<Bank> lAllBanks = LoadAllBanksFromDB();

            // Выгрузить все счета.
            List<BankAccount> lAllBankAccounts = new List<BankAccount>();
            List<Dictionary<string, string>> dAllBankAccounts =
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Счета");

            if (dAllBankAccounts != null)
            {
                foreach (var newBankAc in dAllBankAccounts)
                {
                    int AccountBank_id = Int32.Parse(newBankAc["id банка"]);

                    Bank currentBank = (from   bank in lAllBanks
                                        where  bank.Id == AccountBank_id
                                        select bank).FirstOrDefault();

                    lAllBankAccounts.Add(
                        new BankAccount
                        {
                            Id              = Int32.Parse(newBankAc["Id"]),
                            BankAc_Number   = newBankAc["Номер счета"],
                            BankAc_Org_Name = newBankAc["Название организации владельца"],
                            BankAc_Org_ID   = Int32.Parse(newBankAc["id организации владельца"]),
                            BankAc_Bank_ID  = Int32.Parse(newBankAc["id банка"]),
                            BankAc_Bank     = currentBank
                        }
                    );

                }
            }

            return lAllBankAccounts;
        }


        #endregion


        #region Organisations

        public static List<Organisation> LoadAllOrganisationsFromDB()
        {
            // Выгрузить все счета.
            List<BankAccount> ListOfBankAccounts = LoadAllBankAccountsFromDB();


            // Выгрузить все организации.
            List<Organisation> lAllOrganisations = new List<Organisation>();
            List<Dictionary<string, string>> dAllOrganisations =
                DatabaseConnection.LoadAllObjectsFromExcelTable(Properties.Settings.Default.PathToDataBase, "Организации");

            // Для каждой организации надо добавлятть информацию в лист, искать все счета и тоже добавлять в лист

            foreach (var org in dAllOrganisations)
            {


                // Получить счета этой организации.
                List<BankAccount> ListOfBankAccountsForOrganisation = (from ba in ListOfBankAccounts
                                                                       where ba.BankAc_Org_ID == Int32.Parse(org["Id"])
                                                                       select ba).ToList();

                lAllOrganisations.Add(
                    new Organisation {
                        Id = Int32.Parse(org["Id"]),
                        Org_Name = org["Название"],
                        Org_INN = org["ИНН"],
                        Org_KPP = org["КПП"],
                        Org_Address = org["Адрес"],
                        Org_BankAccounts = ListOfBankAccountsForOrganisation
                    }
                );
            }
            return lAllOrganisations;

        }
        #endregion
    }



}
