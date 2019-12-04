using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private int mi_PayerOrganisation_BankAccount_Id;
        private Organisation m_org_RecipientOrganisation;
        private int mi_RecipientOrganisation_BankAccount_Id;

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
        public int PayerOrganisation_BankAccount_Id
        {
            get { return mi_PayerOrganisation_BankAccount_Id; }
            set { mi_PayerOrganisation_BankAccount_Id = value; }
        }
        public Organisation RecipientOrganisation
        {
            get { return m_org_RecipientOrganisation; }
            set { m_org_RecipientOrganisation = value; }
        }
        public int RecipientOrganisation_BankAccount_Id
        {
            get { return mi_RecipientOrganisation_BankAccount_Id; }
            set { mi_RecipientOrganisation_BankAccount_Id = value; }
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
                          Organisation PayerOrganisation, int PayerOrganisation_BankAccount_Id,
                          Organisation RecipientOrganisation, int RecipientOrganisation_BankAccount_Id,
                          string OperationType, string PaymentPurpose,
                          string  Code, string ReservedField)
        {
            mdate_SignDate = SignDate;
            ms_PaymentType = PaymentType;
            ms_BlankNumber = BlankNumber;
            ms_SumRubles   = SumRubles;
            ms_SumKopeyki  = SumKopeyki;

            m_org_PayerOrganisation = PayerOrganisation;
            mi_PayerOrganisation_BankAccount_Id = PayerOrganisation_BankAccount_Id;
            m_org_RecipientOrganisation = RecipientOrganisation;
            mi_RecipientOrganisation_BankAccount_Id = RecipientOrganisation_BankAccount_Id;

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

            string rubLastCharacter = rub.Substring(rub.Length - 1);
            if (rubLastCharacter == "1")
                rubleWord = "рубль";
            if (rubLastCharacter == "2" || rubLastCharacter == "3")
                rubleWord = "рубля";




            string FullTextRepresentation = $"{Rubles_TextRepresentation}{rubleWord} {kop} копеек";
            // одна копейка 2-3-4 копейки 5 кпеек

            return (FullTextRepresentation);
        }
        #endregion

    }








}
