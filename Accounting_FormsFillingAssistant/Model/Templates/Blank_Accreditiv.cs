using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс - бланка аккредитива.
    /// </summary>
    public class Blank_Accreditiv : Blank_Base
    {
        #region Fields        
        /// <summary>
        /// Срок действия аккредитива.
        /// </summary>
        DateTime mdate_AccreditivEOLDate;
        /// <summary>
        /// Вид аккредитива.
        /// </summary>
        string ms_AccreditivType;
        /// <summary>
        /// Условия оплаты.
        /// </summary>
        string ms_PaymentCondition;
        /// <summary>
        /// Детали условий.
        /// </summary>
        string ms_ConditionsDetails;
        /// <summary>
        /// Подтверждение оплаты.
        /// </summary>
        string ms_SubmissionPayment;
        /// <summary>
        /// Дополнительные детали.
        /// </summary>
        string ms_AdditionalDetails;
        #endregion

        #region Properties
        public string AccreditivType
        {
            get { return ms_AccreditivType; }
            set { ms_AccreditivType = value; }
        }
        public string PaymentCondition
        {
            get { return ms_PaymentCondition; }
            set { ms_PaymentCondition = value; }
        }
        public string ConditionsDetails
        {
            get { return ms_ConditionsDetails; }
            set { ms_ConditionsDetails = value; }
        }
        public string SubmissionPayment
        {
            get { return ms_SubmissionPayment; }
            set { ms_SubmissionPayment = value; }
        }
        public string AdditionalDetails
        {
            get { return ms_AdditionalDetails; }
            set { ms_AdditionalDetails = value; }
        }

        #endregion


        /// <summary>
        /// Конструктор 1.
        /// </summary>
        public Blank_Accreditiv()
            :base()
        {

        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="dateSignDate">Датат на бланке</param>
        /// <param name="sPaymentType">Тип оплаты</param>
        /// <param name="sBlankNumber">Номер бланка</param>
        /// <param name="sSumRubles">Сумма, рубли</param>
        /// <param name="sSumKopeyki">Сумма, копейки</param>
        /// <param name="orgPayerOrganisation">Плательщик</param>
        /// <param name="PayerOrganisation_BankAccount">Счёт Плательщика</param>
        /// <param name="orgRecipientOrganisation">Получатель</param>
        /// <param name="RecipientOrganisation_BankAccount">Счёт Получателя</param>
        /// <param name="sPaymentPurpose">Назначение платежа</param>
        /// <param name="sCode">Код</param>
        /// <param name="sReservedField">Резервное поле</param>
        /// <param name="dateAccreditivEOLDate">Дата окончания</param>
        /// <param name="sAccreditivType">Типа аккредитива</param>
        /// <param name="sPaymentCondition">Условие оплаты</param>
        /// <param name="sConditionsDetails">Детали</param>
        /// <param name="sSubmissionPayment">Подтверждение оплаты</param>
        /// <param name="sAdditionalDetails">Дополнительные сведения</param>
        public Blank_Accreditiv(DateTime dateSignDate, string sPaymentType, string sBlankNumber,
                          string sSumRubles, string sSumKopeyki,
                          Organisation orgPayerOrganisation, BankAccount PayerOrganisation_BankAccount,
                          Organisation orgRecipientOrganisation, BankAccount RecipientOrganisation_BankAccount,
                          //string OperationType,
                          string sPaymentPurpose,
                          string sCode, string sReservedField,

                          DateTime dateAccreditivEOLDate,
                          string sAccreditivType, string sPaymentCondition,
                          string sConditionsDetails,  string sSubmissionPayment,
                          string sAdditionalDetails
                          ) 
            : base( dateSignDate,  sPaymentType,  sBlankNumber,
                           sSumRubles,  sSumKopeyki,
                           orgPayerOrganisation,  PayerOrganisation_BankAccount,
                           orgRecipientOrganisation,  RecipientOrganisation_BankAccount,
                           "08",  sPaymentPurpose,
                           sCode,  sReservedField)
        {

            mdate_AccreditivEOLDate = dateAccreditivEOLDate;
            ms_AccreditivType = sAccreditivType;
            ms_PaymentCondition = sPaymentCondition;
            ms_ConditionsDetails = sConditionsDetails;
            ms_SubmissionPayment = sSubmissionPayment;
            ms_AdditionalDetails = sAdditionalDetails;
        }






        #region Methods
        /// <summary>
        /// Метод создания словаря
        /// </summary>
        /// <returns>Словарь со значениями для бланка.</returns>
        public override Dictionary<string, string> CreateDictionaryWithFieldValues()
        {
  
            Dictionary<string, string> DictionaryWithFieldValues = new Dictionary<string, string>
            {
                
                // {Key,Value}
                { "ak_01_Number", BlankNumber},
                { "ak_02_CurrentDate", SignDate.ToString("dd.MM.yyyy")}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "ak_03_PaymentType", PaymentType},
                { "ak_04_SumInCuirsive", ConvertSumToTextRepresentation(SumRubles,SumKopeyki)},
                { "ak_06_SumNumber", ConvertSumToNumericRepresentation(SumRubles,SumKopeyki)},

                // Инфрмация о плательщике
                { "ak_07_PayerName", PayerOrganisation.Org_Name },
                { "ak_05_INN_Payer", PayerOrganisation.Org_INN},
                { "ak_08_PayerBankAccount", PayerOrganisation_BankAccount.BankAc_Number},
                { "ak_09_Payer_BankName", PayerOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "ak_10_Payer_Bank_BIK", PayerOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "ak_11_Payer_Bank_BankAccount", PayerOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},

                // Инфрмация о получателе
                { "ak_16_RecipientName", RecipientOrganisation.Org_Name },
                { "ak_15_INN_Recipient", RecipientOrganisation.Org_INN},
                { "ak_17_Recipient_BankAccount", RecipientOrganisation_BankAccount.BankAc_Number},
                { "ak_12_Recipient_BankName", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "ak_13_Recipient_Bank_BIK", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "ak_14_Recipient_Bank_BankAccount", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},

                { "ak_18_OperationType", OperationType},
                { "ak_19_NazPL", PaymentPurpose},
                { "ak_20_Code", Code},
                { "ak_21_AkTimePeriod", mdate_AccreditivEOLDate.ToString("dd.MM.yyyy")}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "ak_22_ResField", ReservedField},
                { "ak_23_AkType", AccreditivType},
                { "ak_24_PaymentCondition", PaymentCondition},
                { "ak_25_ConditionsDetails", ConditionsDetails},
                { "ak_26_SubmissionPayment", SubmissionPayment},
                { "ak_27_AdditionalDetails", AdditionalDetails},
                { "ak_28_Recipient_BankAccount_2", RecipientOrganisation_BankAccount.BankAc_Number}
            };


            return DictionaryWithFieldValues;
        }


        /// <summary>
        /// Метод выгрузки информации из словаря в поля класса.
        /// </summary>
        /// <param name="DictionaryWithFieldValues"></param>
        public override void LoadValuesFromDictionary(Dictionary<string, string> DictionaryWithFieldValues)
        {
            if (DictionaryWithFieldValues == null)
                return;

            if (DictionaryWithFieldValues.Count == 0)
                return;

            // Предусмотреть возможность добавления новой организации


        }

        #endregion


    }
}
