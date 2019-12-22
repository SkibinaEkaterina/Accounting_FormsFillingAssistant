using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Базовый класс для всех бланков.
    /// </summary>
    public abstract class Blank_Base
    {
        #region Fields
        /// <summary>
        /// Дата на бланке.
        /// </summary>
        private DateTime mdate_SignDate;
        /// <summary>
        /// Тип оплаты.
        /// </summary>
        private string ms_PaymentType;
        /// <summary>
        /// Номер бланка.
        /// </summary>
        private string ms_BlankNumber;
        /// <summary>
        /// Сумма в рублях.
        /// </summary>
        private string ms_SumRubles;
        /// <summary>
        /// Сумма - копейки.
        /// </summary>
        private string ms_SumKopeyki;
        /// <summary>
        /// Организация Плательщик.
        /// </summary>
        private Organisation m_org_PayerOrganisation;
        /// <summary>
        /// Счёи Организации Плательщика.
        /// </summary>
        private BankAccount m_PayerOrganisation_BankAccount;
        /// <summary>
        /// Организация получатель.
        /// </summary>
        private Organisation m_org_RecipientOrganisation;
        /// <summary>
        /// Счёи Организации получателя.
        /// </summary>
        private BankAccount m_RecipientOrganisation_BankAccount;
        /// <summary>
        /// Тип операции.
        /// </summary>
        private string ms_OperationType;
        /// <summary>
        /// Цель платежа.
        /// </summary>
        private string ms_PaymentPurpose;
        /// <summary>
        /// Код.
        /// </summary>
        private string ms_Code;
        /// <summary>
        /// Резервное поле.
        /// </summary>
        private string ms_ReservedField;
        #endregion

        public Blank_Base()
        {

        }


        #region Properties
        /// <summary>
        /// Свойство - дата на бланке.
        /// </summary>
        public DateTime SignDate {
            get { return mdate_SignDate; }
            set { mdate_SignDate = value; }
        }
        /// <summary>
        /// Свойство - тип оплаты.
        /// </summary>
        public string PaymentType
        {
            get { return ms_PaymentType; }
            set { ms_PaymentType = value; }
        }
        /// <summary>
        /// Свойство - номер бланка.
        /// </summary>
        public string BlankNumber
        {
            get { return ms_BlankNumber; }
            set { ms_BlankNumber = value; }
        }
        /// <summary>
        /// Свойство - сумма, рубли.
        /// </summary>
        public string SumRubles
        {
            get { return ms_SumRubles; }
            set { ms_SumRubles = value; }
        }
        /// <summary>
        /// Свойство - сумма, копейки.
        /// </summary>
        public string SumKopeyki
        {
            get { return ms_SumKopeyki; }
            set { ms_SumKopeyki = value; }
        }
        /// <summary>
        /// Свойство - плательщик.
        /// </summary>
        public Organisation PayerOrganisation
        {
            get { return m_org_PayerOrganisation; }
            set { m_org_PayerOrganisation = value; }
        }
        /// <summary>
        /// Свойство - счёт плательщика.
        /// </summary>
        public BankAccount PayerOrganisation_BankAccount
        {
            get { return m_PayerOrganisation_BankAccount; }
            set { m_PayerOrganisation_BankAccount = value; }
        }
        /// <summary>
        /// Свойство - организация получатель.
        /// </summary>
        public Organisation RecipientOrganisation
        {
            get { return m_org_RecipientOrganisation; }
            set { m_org_RecipientOrganisation = value; }
        }
        /// <summary>
        /// Свойство - счёт получателя.
        /// </summary>
        public BankAccount RecipientOrganisation_BankAccount
        {
            get { return m_RecipientOrganisation_BankAccount; }
            set { m_RecipientOrganisation_BankAccount = value; }
        }
        /// <summary>
        /// Свойство - тип операции.
        /// </summary>
        public string OperationType
        {
            get { return ms_OperationType; }
            set { ms_OperationType = value; }
        }
        /// <summary>
        /// Свойство - цель платежа.
        /// </summary>
        public string PaymentPurpose
        {
            get { return ms_PaymentPurpose; }
            set { ms_PaymentPurpose = value; }
        }
        /// <summary>
        /// Свойство - код.
        /// </summary>
        public string Code
        {
            get { return ms_Code; }
            set { ms_Code = value; }
        }
        /// <summary>
        /// Свойство - резервное поле.
        /// </summary>
        public string ReservedField
        {
            get { return ms_ReservedField; }
            set { ms_ReservedField = value; }
        }

        #endregion

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="SignDate">Дата на бланке</param>
        /// <param name="PaymentType">Тип оплаты</param>
        /// <param name="BlankNumber">Номер бланка</param>
        /// <param name="SumRubles">Сумма, рубли</param>
        /// <param name="SumKopeyki">Сумма, копейки</param>
        /// <param name="PayerOrganisation">Плательщик.</param>
        /// <param name="PayerOrganisation_BankAccount">Счёт плательщика</param>
        /// <param name="RecipientOrganisation">Полёчатель</param>
        /// <param name="RecipientOrganisation_BankAccount">Счёт полёчателя</param>
        /// <param name="OperationType">Тип операции</param>
        /// <param name="PaymentPurpose">Назначение платежа</param>
        /// <param name="Code">Код</param>
        /// <param name="ReservedField">Резервное поле</param>
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


        /// <summary>
        /// Метод создания словаря
        /// </summary>
        /// <returns>Словарь со значениями.</returns>
        public abstract Dictionary<string, string> CreateDictionaryWithFieldValues();

        /// <summary>
        /// Метод выгрузки информации из словаря в поля класса.
        /// </summary>
        /// <param name="DictionaryWithFieldValues"></param>
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
