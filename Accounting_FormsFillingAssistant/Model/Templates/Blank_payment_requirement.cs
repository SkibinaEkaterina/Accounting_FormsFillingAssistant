using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс - бланка платежного требования.
    /// </summary>
    class Blank_payment_requirement : Blank_Base
    {

        #region Fields
        string ms_paymentCondition;

        /// <summary>
        /// срок для акцепта
        /// </summary>
        string ms_acceptTime;

        /// <summary>
        /// Очер. Плат.
        /// </summary>
        string ms_prTimePeriod;
        /// <summary>
        /// Назначение платежа
        /// </summary>
        string ms_PaymentAppoinment;

        /// <summary>
        /// Дата отсылки.
        /// </summary>
        DateTime mdate_date_of_Dispatch;
        #endregion



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
        /// <param name="paymentCondition">Условия платежа</param>
        /// <param name="acceptTime">Время получения</param>
        /// <param name="prTimePeriod">Период получения</param>
        /// <param name="PaymentAppoinment">Цель платежа</param>
        /// <param name="date_of_Dispatch">Дата отправки</param>
        public Blank_payment_requirement(DateTime dateSignDate, string sPaymentType, string sBlankNumber,
                          string sSumRubles, string sSumKopeyki,
                          Organisation orgPayerOrganisation, BankAccount PayerOrganisation_BankAccount,
                          Organisation orgRecipientOrganisation, BankAccount RecipientOrganisation_BankAccount,
                          //string OperationType,
                          string sPaymentPurpose,
                          string sCode, string sReservedField,

                          string paymentCondition,
                          string acceptTime, string prTimePeriod,
                          string PaymentAppoinment, DateTime date_of_Dispatch) 
            : base(dateSignDate, sPaymentType, sBlankNumber,
                           sSumRubles, sSumKopeyki,
                           orgPayerOrganisation, PayerOrganisation_BankAccount,
                           orgRecipientOrganisation, RecipientOrganisation_BankAccount,
                           "02",  sPaymentPurpose,
                           sCode, sReservedField)
        {
            ms_paymentCondition     = paymentCondition;
            ms_acceptTime           = acceptTime;
            ms_prTimePeriod         = prTimePeriod;
            ms_PaymentAppoinment    = PaymentAppoinment;
            mdate_date_of_Dispatch  = date_of_Dispatch;
        }

        #region Methods



        /// <summary>
        /// Метод создания словаря
        /// </summary>
        /// <returns>Словарь значений полей бланка.</returns>
        public override Dictionary<string, string> CreateDictionaryWithFieldValues()
        {
            Dictionary<string, string> DictionaryWithFieldValues = new Dictionary<string, string>
            {                
                // {Key,Value}
                { "pr_01_Number", BlankNumber},
                { "pr_02_CurrentDate", SignDate.ToString("dd.MM.yyyy")}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "pr_03_PaymentType", PaymentType},
                { "pr_06_SumInCuirsive", ConvertSumToTextRepresentation(SumRubles,SumKopeyki)},
                { "pr_08_SumNumber", ConvertSumToNumericRepresentation(SumRubles,SumKopeyki)},

                { "pr_04_paymentCondition", ms_paymentCondition},
                { "pr_05_acceptTime", ms_acceptTime},


                // Инфрмация о плательщике
                { "pr_09_PayerName", PayerOrganisation.Org_Name },
                { "pr_07_INN_Payer", PayerOrganisation.Org_INN},
                { "pr_10_PayerBankAccount", PayerOrganisation_BankAccount.BankAc_Number},
                { "pr_11_Payer_BankName", PayerOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "pr_12_Payer_Bank_BIK", PayerOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "pr_13_Payer_Bank_BankAccount", PayerOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},

                // Инфрмация о получателе
                { "pr_18_RecipientName", RecipientOrganisation.Org_Name },
                { "pr_17_INN_Recipient", RecipientOrganisation.Org_INN},
                { "pr_19_Recipient_BankAccount", RecipientOrganisation_BankAccount.BankAc_Number},
                { "pr_14_Recipient_BankName", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "pr_15_Recipient_Bank_BIK", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "pr_16_Recipient_Bank_BankAccount", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},


                { "pr_20_OperationType", OperationType},
                { "pr_21_NazPL", PaymentPurpose},
                { "pr_22_Code", Code},
                { "pr_23_prTimePeriod", ms_prTimePeriod}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "pr_24_ResField", ReservedField},
                { "pr_25_PaymentAppoinment", ms_PaymentAppoinment },
                { "pr_26_date_of_Dispatch", mdate_date_of_Dispatch.ToString("dd.MM.yyyy")}
            };


            return DictionaryWithFieldValues;
        }

        /// <summary>
        /// Метод выгрузки информации из словаря в поля класса. Не будет реализовано в данной версии.
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
