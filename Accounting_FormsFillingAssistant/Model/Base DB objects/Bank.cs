using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    public class Bank
    {
        // Поля
        int m_Bank_Id;
        string m_Bank_Name;
        string m_Bank_City;
        string m_Bank_BIK;
        string m_Bank_OwnBankAccount;

        // Свойства
        #region Properties

        [DisplayName("ID")]
        public int Id
        {
            get { return m_Bank_Id; }
            set { m_Bank_Id = value; }
        }
        [DisplayName("Название")]
        public string Bank_Name
        {
            get { return m_Bank_Name; }
            set { m_Bank_Name = value; }
        }
        [DisplayName("Город")]
        public string Bank_City
        {
            get { return m_Bank_City; }
            set { m_Bank_City = value; }
        }
        [DisplayName("БИК")]
        public string Bank_BIK
        {
            get { return m_Bank_BIK; }
            set { m_Bank_BIK = value; }
        }

        [DisplayName("Счет банка")]
        public string Bank_OwnBankAccount
        {
            get { return m_Bank_OwnBankAccount; }
            set { m_Bank_OwnBankAccount = value; }
        }
        #endregion


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

        public void GetBankForCurrentBankAccount(List<Bank> ListOfBanks, int id)
        {
            ListOfBanks.Where(bank_Id => id == m_Bank_Id);
        }


    }
}
