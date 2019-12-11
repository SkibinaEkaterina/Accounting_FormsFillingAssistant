using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    public class BankAccount
    {
        private int m_BankAc_ID;
        private int m_BankAc_Org_ID;
        private int m_BankAc_Bank_ID;
        private string m_BankAc_Org_Name;
        private string m_BankAc_Number;
        public Bank BankAc_Bank;

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


        public BankAccount()
        {

        }

        public BankAccount(int id,
                           int bankAc_Org_ID,
                           int bankAc_Bank_ID,
                           string bankAc_Org_Name,
                           string bankAc_Number,
                           Bank bank)
        {
            m_BankAc_ID = id;
            int m_BankAc_Org_ID = bankAc_Org_ID;
            int m_BankAc_Bank_ID = bankAc_Bank_ID;
            string m_BankAc_Org_Name = bankAc_Org_Name;
            string m_BankAc_Number = bankAc_Number;
            Bank m_BankAc_Bank = bank;

        }

        // 		

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
