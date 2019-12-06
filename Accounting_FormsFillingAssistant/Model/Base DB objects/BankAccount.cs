using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    public class BankAccount
    {
        int m_BankAc_ID;
        int m_BankAc_Org_ID;
        int m_BankAc_Bank_ID;
        string m_BankAc_Org_Name;
        string m_BankAc_Number;
        Bank m_BankAc_Bank;

        #region Properties
        public int Id
        {
            get { return m_BankAc_ID; }
            set { m_BankAc_ID = value; }
        }
        public int BankAc_Org_ID
        {
            get { return m_BankAc_Org_ID; }
            set { m_BankAc_Org_ID = value; }
        }
        public int BankAc_Bank_ID
        {
            get { return m_BankAc_Bank_ID; }
            set { m_BankAc_Bank_ID = value; }
        }
        public string BankAc_Org_Name
        {
            get { return m_BankAc_Org_Name; }
            set { m_BankAc_Org_Name = value; }
        }
        public string BankAc_Number
        {
            get { return m_BankAc_Number; }
            set { m_BankAc_Number = value; }
        }

        public Bank BankAc_Bank
        {
            get { return m_BankAc_Bank; }
            set { m_BankAc_Bank = value; }
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

    }
}
