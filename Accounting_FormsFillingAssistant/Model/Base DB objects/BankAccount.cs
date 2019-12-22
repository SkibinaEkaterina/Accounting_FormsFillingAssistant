using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс счёта.
    /// </summary>
    public class BankAccount
    {
        private int m_BankAc_ID;
        private int m_BankAc_Org_ID;
        private int m_BankAc_Bank_ID;
        private string m_BankAc_Org_Name;
        private string m_BankAc_Number;
        public Bank BankAc_Bank;
        public string BankAccountDescription;
        #region Properties

        [DisplayName("ID")]
        public int Id
        {
            get { return m_BankAc_ID; }
            set { m_BankAc_ID = value; }
        }

        [DisplayName("Номер счёта")]
        public string BankAc_Number
        {
            get { return m_BankAc_Number; }
            set { m_BankAc_Number = value; }
        }

        [DisplayName("Название организации")]
        public string BankAc_Org_Name
        {
            get { return m_BankAc_Org_Name; }
            set { m_BankAc_Org_Name = value; }
        }

        

        [DisplayName("Название банка")]
        public string BankAc_BankName
        {
            get { return BankAc_Bank.Bank_Name; }
            
        }

        [DisplayName("ID организации")]
        public int BankAc_Org_ID
        {
            get { return m_BankAc_Org_ID; }
            set { m_BankAc_Org_ID = value; }
        }

        [DisplayName("ID банка")]
        public int BankAc_Bank_ID
        {
            get { return m_BankAc_Bank_ID; }
            set { m_BankAc_Bank_ID = value; }
        }

       

        #endregion


        /// <summary>
        /// конструктор класса с параметрами.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bankAc_Org_ID"></param>
        /// <param name="bankAc_Bank_ID"></param>
        /// <param name="bankAc_Org_Name"></param>
        /// <param name="bankAc_Number"></param>
        /// <param name="bank"></param>
        public BankAccount(int id,
                           int bankAc_Org_ID,
                           int bankAc_Bank_ID,
                           string bankAc_Org_Name,
                           string bankAc_Number,
                           Bank bank)
        {
            m_BankAc_ID = id;
            m_BankAc_Org_ID = bankAc_Org_ID;
            m_BankAc_Bank_ID = bankAc_Bank_ID;
            m_BankAc_Org_Name = bankAc_Org_Name;
            m_BankAc_Number = bankAc_Number;
            BankAc_Bank = bank;
            BankAccountDescription = m_BankAc_Number + "" + m_BankAc_Org_Name;
        }
        /// <summary>
        /// Конструктор класса - перевод значений из словаря.
        /// </summary>
        /// <param name="newBankAc"></param>
        /// <param name="currentBank"></param>
        public BankAccount(Dictionary<string,string> newBankAc,
                           Bank currentBank)
        {
            Id = Int32.Parse(newBankAc["Id"]);
            BankAc_Number = newBankAc["Номер счета"];
            BankAc_Org_Name = newBankAc["Название организации владельца"];
            BankAc_Org_ID = Int32.Parse(newBankAc["id организации владельца"]);
            BankAc_Bank_ID = Int32.Parse(newBankAc["id банка"]);
            BankAc_Bank = currentBank;
            BankAccountDescription = m_BankAc_Number + ", " + BankAc_Bank.Bank_Name;
        }

        /// <summary>
        /// Конвертировать значения полей счёта в словарь.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ConvertBankaccountInfoToDictionary()
        {
            Dictionary<string, string> dNewBank = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Номер счета"] = BankAc_Number,
                ["Название организации владельца"] = BankAc_Org_Name,
                ["Название банка"] = BankAc_Bank.Bank_Name,
                ["id организации владельца"] = BankAc_Org_ID.ToString(),
                ["id банка"] = BankAc_Bank_ID.ToString()
            };

            return dNewBank;
        }

    }
}
