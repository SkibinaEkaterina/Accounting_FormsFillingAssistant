using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс предназначен для манипуляции объектами в БД, включая добавление, удаление и редактирвоание объектов. 
    /// Для некоторых типов подразумевается набор нескольких манипуляций с БД. Например, выгрузка организаций подразумевает выгрузку банков и счетов).
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
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Банки");
            if (dAllBanks != null)
            {
                foreach (var newBank in dAllBanks)
                {
                    lAllBanks.Add(
                        new Bank(newBank));

                }
            }

            return lAllBanks;
        }

        /// <summary>
        /// Удалить выбранный банк из БД.
        /// </summary>
        /// <param name="RemovingBank">Удаляемый банк.</param>
        public static void RemoveBankFromDB(Bank RemovingBank)
        {
            // Шаг 1.
            // Удалить счета банка
            List<Dictionary<string, string>> dAllBankAccounts =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Счета");
            List<Dictionary<string, string>> dAllBankAccountsCorrected = dAllBankAccounts.Where(b => b["id банка"] != RemovingBank.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBankAccountsCorrected, "Счета");

            // Шаг 2.
            // Удалить Банк - выгрузить все банки и загрузить только те, что не являются нашим банком.
            List<Dictionary<string, string>> dAllBanks =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Банки");

            List<Dictionary<string, string>> dAllBanksCorrected = dAllBanks.Where(b => b["Id"] != RemovingBank.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBanksCorrected, "Банки");

        }

        /// <summary>
        /// Добавить новый банк в БД.
        /// </summary>
        /// <param name="NewBank">Новый банк.</param>
        public static void AddNewBankToDB(Bank NewBank)
        {
            Dictionary<string, string> dNewBank = NewBank.ConvertBankInfoToDictionary();
            dNewBank["Id"] = null;

            DatabaseConnection.SaveObjectInTheEndOfExcelTable(Properties.Settings.Default.PathToDataBase, dNewBank, "Банки");
        }

        /// <summary>
        /// Редактировать информацию о банке в БД.
        /// </summary>
        /// <param name="ExistingBank">Редактируемый банк.</param>
        public static void EditBankInDB(Bank ExistingBank)
        {

            Dictionary<string, string> dExistingBank = ExistingBank.ConvertBankInfoToDictionary();
            DatabaseConnection.EditObjectInExcelTable(Properties.Settings.Default.PathToDataBase, dExistingBank, "Банки");

        }


        #endregion


        #region Bank Accounts
        /// <summary>
        /// Выгрузить список всех банковских счетов из БД.
        /// </summary>
        /// <returns>Возвращает список всех банковских счетов в БД.</returns>
        public static List<BankAccount> LoadAllBankAccountsFromDB()
        {
            // Выгрузить все счета и банки.
            Dictionary<string, List<Dictionary<string, string>>> DictionaryWithBanksAndBankAccounts = DatabaseConnection.LoadAllObjectsFromSeveralExcelSheets(Properties.Settings.Default.PathToDataBase,
                                                                    new string[] { "Счета", "Банки" });
            // Перевести все банки в нужный вид.
            List<Bank> lAllBanks = new List<Bank>();
            foreach (var dbank in DictionaryWithBanksAndBankAccounts["Банки"])
            {
                lAllBanks.Add(new Bank(dbank));
            }


            // Выгрузить все счета.
            List<BankAccount> lAllBankAccounts = FormAListOfBankAccounts(lAllBanks,DictionaryWithBanksAndBankAccounts["Счета"]);
            
            return lAllBankAccounts;
        }

        /// <summary>
        /// Сформировать список банковских счетов в нужном для работы программы виде.
        /// </summary>
        /// <param name="lAllBanks">Все банки.</param>
        /// <param name="dAllBankAccounts">Список словарей со значениями для каждого счета.</param>
        /// <returns></returns>
        private static List<BankAccount> FormAListOfBankAccounts(List<Bank> lAllBanks, List<Dictionary<string, string>> dAllBankAccounts)
        {
            List<BankAccount> lAllBankAccounts = new List<BankAccount>();
            if (dAllBankAccounts != null)
            {
                foreach (var newBankAc in dAllBankAccounts)
                {
                    int AccountBank_id = Int32.Parse(newBankAc["id банка"]);

                    Bank currentBank = (from bank in lAllBanks
                                        where bank.Id == AccountBank_id
                                        select bank).FirstOrDefault();

                    lAllBankAccounts.Add(
                        new BankAccount(newBankAc, currentBank)
                    );

                }
            }
            return lAllBankAccounts;
        }

        /// <summary>
        /// Добавить новый счёт в БД.
        /// </summary>
        /// <param name="NewBankAccount">Новый счет.</param>
        public static void AddNewBankAccountToDB(BankAccount NewBankAccount)
        {
            Dictionary<string, string> dNewBankAccount = NewBankAccount.ConvertBankaccountInfoToDictionary();
            dNewBankAccount["Id"] = null;

            DatabaseConnection.SaveObjectInTheEndOfExcelTable(Properties.Settings.Default.PathToDataBase, dNewBankAccount, "Счета");
        }

        /// <summary>
        /// Удалить счёт из БД.
        /// </summary>
        /// <param name="BankAccount"></param>
        public static void RemoveBankAccountFromDB(BankAccount BankAccount)
        {
            //Удалить счет.
            List<Dictionary<string, string>> dAllBanks =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Счета");

            List<Dictionary<string, string>> dAllBanksCorrected = dAllBanks.Where(b => b["Id"] != BankAccount.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBanksCorrected, "Счета");
        }
        #endregion


        #region Organisations
        /// <summary>
        /// Выгрузить все организации из БД.
        /// </summary>
        /// <returns>Возвращает список всех организаций в БД.</returns>
        public static List<Organisation> LoadAllOrganisationsFromDB()
        {

            // Выгрузить все.
            Dictionary<string, List<Dictionary<string, string>>> DictionaryWithObjects = DatabaseConnection.LoadAllObjectsFromSeveralExcelSheets(Properties.Settings.Default.PathToDataBase,
                                                                    new string[] {"Организации","Счета", "Банки"});

            // Перевести все банки в нужный вид.
            List<Bank> ListOfAllBanks = new List<Bank>();
            foreach (var dbank in DictionaryWithObjects["Банки"])
            {
                ListOfAllBanks.Add(new Bank(dbank));
            }


            // Выгрузить все счета.
            List<BankAccount> ListOfBankAccounts = FormAListOfBankAccounts(ListOfAllBanks, DictionaryWithObjects["Счета"]);

            // Выгрузить все организации.
            List<Organisation> lAllOrganisations = new List<Organisation>();
            List<Dictionary<string, string>> dAllOrganisations = DictionaryWithObjects["Организации"];

            // Для каждой организации надо добавлятть информацию в лист, искать все счета и тоже добавлять в лист

            foreach (var dOrganisation in dAllOrganisations)
            {


                // Получить счета этой организации.
                List<BankAccount> ListOfBankAccountsForOrganisation = (from ba in ListOfBankAccounts
                                                                       where ba.BankAc_Org_ID == Int32.Parse(dOrganisation["Id"])
                                                                       select ba).ToList();

                lAllOrganisations.Add(
                    new Organisation(dOrganisation, ListOfBankAccountsForOrganisation)
                    
                );
            }
            return lAllOrganisations;

        }


        /// <summary>
        /// Добавить новую организацию в БД.
        /// </summary>
        /// <param name="NewOrganisation">Добавляемая организация.</param>
        public static void AddNewOrganisationWithItsBankAccountsToDB(Organisation NewOrganisation)
        {
            Dictionary<string, string> dNewOrganisation = NewOrganisation.ConvertOrganisationInfoToDictionary();
            dNewOrganisation["Id"] = null;

            DatabaseConnection.SaveObjectInTheEndOfExcelTable(Properties.Settings.Default.PathToDataBase, dNewOrganisation, "Организации");

            // Выгрузить все организации
            List<Dictionary<string, string>> dAllOrganisations =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Организации");

            int NewOrgId = Int32.Parse(dAllOrganisations.Where(d => 
            (d["КПП"] == dNewOrganisation["КПП"]) && (d["ИНН"] == dNewOrganisation["ИНН"])).FirstOrDefault()["Id"]) ;
            // Сохранить организацию, затем сохранить ее счета.


            // Новые счета идут с id = -1.


            if(NewOrganisation.Org_BankAccounts!= null)
            {
                foreach (BankAccount ba in NewOrganisation.Org_BankAccounts)
                {
                    ba.BankAc_Org_ID = NewOrgId;
                    ba.BankAc_Org_Name = NewOrganisation.Org_Name;
                    AddNewBankAccountToDB(ba);
                }
            }
            

        }


        /// <summary>
        /// УДалить организацию из БД.
        /// </summary>
        /// <param name="RemovingOrganisation">Удаляемая организация.</param>
        public static void RemoveOrganisationWithBankAccountsFromDB(Organisation RemovingOrganisation)
        {
            // Выгрузить все.
            Dictionary<string, List<Dictionary<string, string>>> DictionaryWithObjects = DatabaseConnection.LoadAllObjectsFromSeveralExcelSheets(Properties.Settings.Default.PathToDataBase,
                                                                    new string[] { "Организации", "Счета" });

            // Шаг 1.
            // Удалить счета организации
            List<Dictionary<string, string>> dAllBankAccounts = DictionaryWithObjects["Счета"];

                //DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Счета");
            List<Dictionary<string, string>> dAllBankAccountsCorrected = dAllBankAccounts.Where(b => b["id организации владельца"] !=
                                    RemovingOrganisation.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBankAccountsCorrected, "Счета");

            // Шаг 2.
            // Удалить Банк - выгрузить все банки и загрузить только те, что не являются нашим банком.
            List<Dictionary<string, string>> dAllOrganisations = DictionaryWithObjects["Организации"];
            //DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Банки");

            List<Dictionary<string, string>> dAllOrganisationsCorrected = dAllOrganisations.Where(b => b["Id"] != 
                                                            RemovingOrganisation.Id.ToString()).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllOrganisationsCorrected, "Организации");
        }

        /// <summary>
        /// Редактировать организацию.
        /// </summary>
        /// <param name="EditingOrganisation">Изменяемая организация.</param>
        public static void EditOrganisationWithAllBankAccounts(Organisation EditingOrganisation)
        {
            // Изменить информацию об организациях
            Dictionary<string, string> dExistingOrganisation = EditingOrganisation.ConvertOrganisationInfoToDictionary();
            DatabaseConnection.EditObjectInExcelTable(Properties.Settings.Default.PathToDataBase, dExistingOrganisation, "Организации");

            // удалить счета, которые пользователь удалил

            // Выгрузить все банки
            List<Dictionary<string, string>> dAllBankAccounts =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(Properties.Settings.Default.PathToDataBase, "Счета");


            dAllBankAccounts = new List<Dictionary<string, string>>(dAllBankAccounts.Where(d => (d["id организации владельца"] != dExistingOrganisation["Id"]) ||
                                        (d["id организации владельца"] == dExistingOrganisation["Id"] && 
                                        EditingOrganisation.Org_BankAccounts.Any(item2 => item2.Id.ToString() == d["Id"]))));

            DatabaseConnection.SaveAllObjectsToExcelTable(Properties.Settings.Default.PathToDataBase,
                                                            dAllBankAccounts, "Счета");
            // добавить новые счета

            foreach (var ba in EditingOrganisation.Org_BankAccounts.Where(b => b.Id == -1))
            {
                DatabaseConnection.SaveObjectInTheEndOfExcelTable(Properties.Settings.Default.PathToDataBase,
                                    ba.ConvertBankaccountInfoToDictionary(), "Счета");
                
            }


        }

        #endregion
    }



}
