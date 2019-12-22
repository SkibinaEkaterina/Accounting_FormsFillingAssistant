using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс Банка.
    /// </summary>
    public class Bank
    {
        // Поля
        /// <summary>
        /// Id банка.
        /// </summary>
        int m_Bank_Id;
        /// <summary>
        /// Название.
        /// </summary>
        string m_Bank_Name;
        /// <summary>
        /// Город.
        /// </summary>
        string m_Bank_City;
        /// <summary>
        /// БИК.
        /// </summary>
        string m_Bank_BIK;
        /// <summary>
        /// Счёт банка.
        /// </summary>
        string m_Bank_OwnBankAccount;

        // Свойства
        #region Properties

        /// <summary>
        /// Свойство - Id.
        /// </summary>
        [DisplayName("ID")]
        public int Id
        {
            get { return m_Bank_Id; }
            set { m_Bank_Id = value; }
        }
        /// <summary>
        /// Свойство - навание.
        /// </summary>
        [DisplayName("Название")]
        public string Bank_Name
        {
            get { return m_Bank_Name; }
            set { m_Bank_Name = value; }
        }
        /// <summary>
        /// Свойство - город.
        /// </summary>
        [DisplayName("Город")]
        public string Bank_City
        {
            get { return m_Bank_City; }
            set { m_Bank_City = value; }
        }
        /// <summary>
        /// Свойство - БИК.
        /// </summary>
        [DisplayName("БИК")]
        public string Bank_BIK
        {
            get { return m_Bank_BIK; }
            set { m_Bank_BIK = value; }
        }
        /// <summary>
        /// Свойство - счёт банка.
        /// </summary>
        [DisplayName("Счет банка")]
        public string Bank_OwnBankAccount
        {
            get { return m_Bank_OwnBankAccount; }
            set { m_Bank_OwnBankAccount = value; }
        }
        #endregion

        /// <summary>
        /// Конструктор класса с парамтерами.
        /// </summary>
        /// <param name="bank_Id"></param>
        /// <param name="bank_Name"></param>
        /// <param name="bank_City"></param>
        /// <param name="bank_BIK"></param>
        /// <param name="bank_OwnBankAccount"></param>
        public Bank(int bank_Id,
                    string bank_Name,
                    string bank_City,
                    string bank_BIK,
                    string bank_OwnBankAccount)
        {

            m_Bank_Id = bank_Id;
            m_Bank_Name = bank_Name;
            m_Bank_City = bank_City;
            m_Bank_BIK = bank_BIK;
            m_Bank_OwnBankAccount = bank_OwnBankAccount;
        }

        /// <summary>
        /// Конструктор класса - выгрузка значений из словаря.
        /// </summary>
        /// <param name="newBank"></param>
        public Bank(Dictionary<string, string> newBank)
        {
            Id = Int32.Parse(newBank["Id"]);
            Bank_Name = newBank["Название"];
            Bank_City = newBank["Город"];
            Bank_BIK = newBank["БИК"];
            Bank_OwnBankAccount = newBank["Номер счета банка"];
        }

        /// <summary>
        /// Перевсти поля банка в словарь.
        /// </summary>
        /// <returns>Словарь со значениями.</returns>
        public Dictionary<string,string> ConvertBankInfoToDictionary()
        {
            Dictionary<string, string> dNewBank = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Название"] = Bank_Name,
                ["Город"] = Bank_City,
                ["Номер счета банка"] = Bank_OwnBankAccount,
                ["БИК"] = Bank_BIK
            };

            return dNewBank;
        }

        
    }
}
