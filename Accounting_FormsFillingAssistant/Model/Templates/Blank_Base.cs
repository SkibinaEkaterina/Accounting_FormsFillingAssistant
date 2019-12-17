using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    public abstract class Blank_Base
    {
        #region Fields
        private DateTime mdate_SignDate;
        private string ms_PaymentType;
        private string ms_BlankNumber;
        private string ms_SumRubles;
        private string ms_SumKopeyki;

        private Organisation m_org_PayerOrganisation;
        private BankAccount m_PayerOrganisation_BankAccount;
        private Organisation m_org_RecipientOrganisation;
        private BankAccount m_RecipientOrganisation_BankAccount;

        private string ms_OperationType;
        private string ms_PaymentPurpose;
        private string ms_Code;
        private string ms_ReservedField;
        #endregion


        #region Properties
        public DateTime SignDate {
            get { return mdate_SignDate; }
            set { mdate_SignDate = value; }
        }
        public string PaymentType
        {
            get { return ms_PaymentType; }
            set { ms_PaymentType = value; }
        }
        public string BlankNumber
        {
            get { return ms_BlankNumber; }
            set { ms_BlankNumber = value; }
        }

        public string SumRubles
        {
            get { return ms_SumRubles; }
            set { ms_SumRubles = value; }
        }
        public string SumKopeyki
        {
            get { return ms_SumKopeyki; }
            set { ms_SumKopeyki = value; }
        }

        public Organisation PayerOrganisation
        {
            get { return m_org_PayerOrganisation; }
            set { m_org_PayerOrganisation = value; }
        }
        public BankAccount PayerOrganisation_BankAccount
        {
            get { return m_PayerOrganisation_BankAccount; }
            set { m_PayerOrganisation_BankAccount = value; }
        }
        public Organisation RecipientOrganisation
        {
            get { return m_org_RecipientOrganisation; }
            set { m_org_RecipientOrganisation = value; }
        }
        public BankAccount RecipientOrganisation_BankAccount
        {
            get { return m_RecipientOrganisation_BankAccount; }
            set { m_RecipientOrganisation_BankAccount = value; }
        }

        public string OperationType
        {
            get { return ms_OperationType; }
            set { ms_OperationType = value; }
        }
        public string PaymentPurpose
        {
            get { return ms_PaymentPurpose; }
            set { ms_PaymentPurpose = value; }
        }
        public string Code
        {
            get { return ms_Code; }
            set { ms_Code = value; }
        }
        public string ReservedField
        {
            get { return ms_ReservedField; }
            set { ms_ReservedField = value; }
        }

        #endregion

        public Blank_Base(DateTime SignDate, string PaymentType, string BlankNumber,
                          string SumRubles, string SumKopeyki, 
                          Organisation PayerOrganisation, BankAccount PayerOrganisation_BankAccount,
                          Organisation RecipientOrganisation, BankAccount RecipientOrganisation_BankAccount,
                          string OperationType, string PaymentPurpose,
                          string  Code, string ReservedField)
        {
            mdate_SignDate = SignDate;
            ms_PaymentType = PaymentType;
            ms_BlankNumber = BlankNumber;
            ms_SumRubles   = SumRubles;
            ms_SumKopeyki  = SumKopeyki;

            m_org_PayerOrganisation = PayerOrganisation;
            m_PayerOrganisation_BankAccount = PayerOrganisation_BankAccount;
            m_org_RecipientOrganisation = RecipientOrganisation;
            m_RecipientOrganisation_BankAccount = RecipientOrganisation_BankAccount;

            ms_OperationType = OperationType;
            ms_PaymentPurpose = PaymentPurpose;
            ms_Code = Code;
            ms_ReservedField = ReservedField;
        }

        public Blank_Base()
        {

        }


        // Метод создания словаря
        public abstract Dictionary<string, string> CreateDictionaryWithFieldValues();

        // Метод выгрузки информации из словаря в поля класса
        public abstract void LoadValuesFromDictionary(Dictionary<string,string> DictionaryWithFieldValues);







        #region Sum Methods
        // Формат -   РУБ-КОП
        public string ConvertSumToNumericRepresentation(string rub, string kop)
        {
            return (rub + "-" + kop);
        }

        // Письменное представление суммы
        public string ConvertSumToTextRepresentation(string rub, string kop)
        {
            string rubleWord = "рублей";


            int i_Rubles = int.Parse(rub);
            string Rubles_TextRepresentation = TextRepresentationForNumber.Str(i_Rubles, true);

           // Rubles_TextRepresentation.Replace("  ", " ");

            Rubles_TextRepresentation = Regex.Replace(Rubles_TextRepresentation, @"\s+", " ");


            string rubLastCharacter = rub.Substring(rub.Length - 1);
            if (rubLastCharacter == "1")
                rubleWord = "рубль";
            if (rubLastCharacter == "2" || rubLastCharacter == "3" || rubLastCharacter == "4")
                rubleWord = "рубля";


            

            string FullTextRepresentation = $"{Rubles_TextRepresentation}{rubleWord} {kop} копеек";

            return (FullTextRepresentation);
        }
        #endregion

    }








}
