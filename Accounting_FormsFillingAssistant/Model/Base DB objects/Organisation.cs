using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс организаций.
    /// </summary>
    public class Organisation
    {
        // поля
        /// <summary>
        /// ID.
        /// </summary>
        private int m_Org_id;
        /// <summary>
        /// Название.
        /// </summary>
        private string m_Org_Name;
        /// <summary>
        /// ИНН.
        /// </summary>
        private string m_Org_INN;
        /// <summary>
        /// КПП.
        /// </summary>
        private string m_Org_KPP;
        /// <summary>
        /// Адрес.
        /// </summary>
        private string m_Org_Address;
        /// <summary>
        /// Список счетов банка.
        /// </summary>
        public List<BankAccount> Org_BankAccounts;


        #region Properties
        /// <summary>
        /// Свойство - Id.
        /// </summary>
        [DisplayName("ID")]
        public int Id
        {
            get { return m_Org_id; }
            set { m_Org_id = value; }
        }
        /// <summary>
        /// Свойство - название.
        /// </summary>
        [DisplayName("Название")]
        public string Org_Name
        {
            get { return m_Org_Name; }
            set { m_Org_Name = value; }
        }
        /// <summary>
        /// Свойство - ИНН.
        /// </summary>
        [DisplayName("ИНН")]
        public string Org_INN
        {
            get { return m_Org_INN; }
            set { m_Org_INN = value; }
        }
        /// <summary>
        /// Свойство- КПП.
        /// </summary>
        [DisplayName("КПП")]
        public string Org_KPP
        {
            get { return m_Org_KPP; }
            set { m_Org_KPP = value; }
        }
        /// <summary>
        /// Свойство - Адрес.
        /// </summary>
        [DisplayName("Адрес")]
        public string Org_Address
        {
            get { return m_Org_Address; }
            set { m_Org_Address = value; }
        }
        #endregion


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="Org_id"></param>
        /// <param name="Org_Name"></param>
        /// <param name="Org_INN"></param>
        /// <param name="Org_KPP"></param>
        /// <param name="Org_Address"></param>
        /// <param name="Org_BankAccounts"></param>
        public Organisation(int Org_id,
                            string Org_Name,
                            string Org_INN,
                            string Org_KPP,
                            string Org_Address,
                            List<BankAccount> OrgBankAccounts)
        {
            m_Org_id = Org_id;
            m_Org_Name = Org_Name;
            m_Org_INN = Org_INN;
            m_Org_KPP = Org_KPP;
          
            m_Org_Address = Org_Address;
            Org_BankAccounts = OrgBankAccounts;
        }
        public Organisation(Dictionary<string,string> org,
                            List<BankAccount> ListOfBankAccountsForOrganisation)
        {
            Id = Int32.Parse(org["Id"]);
            Org_Name = org["Название"];
            Org_INN = org["ИНН"];
            Org_KPP = org["КПП"];
            Org_Address = org["Адрес"];
            Org_BankAccounts = ListOfBankAccountsForOrganisation;
        }

        public List<BankAccount> GetListOfBankAccounts()
        {
            return Org_BankAccounts;
        }


        /*
         
             Название	ИНН	КПП	Адрес

             */

        public Dictionary<string, string> ConvertOrganisationInfoToDictionary()
        {
            Dictionary<string, string> dNewOrg = new Dictionary<string, string>
            {
                ["Id"] = Id.ToString(),
                ["Название"] = Org_Name,
                ["ИНН"] = Org_INN,
                ["КПП"] = Org_KPP,
                ["Адрес"] = Org_Address
            };

            return dNewOrg;
        }


    }
}

