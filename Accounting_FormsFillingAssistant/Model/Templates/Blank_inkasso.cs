using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс - бланка ИНКАССОвого поручения.
    /// </summary>
    class Blank_inkasso : Blank_Base
    {
        #region Fields
        /// <summary>
        /// Очередность платежа.
        /// </summary>
        string ms_Priority;
        /// <summary>
        /// Назначение платежа
        /// </summary>
        string ms_PaymentAppoinment;

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
        /// <param name="s_PaymentAppoinment">Цель платежа</param>
        /// <param name="s_Priority">Очередность</param>
        public Blank_inkasso(DateTime dateSignDate, string sPaymentType, string sBlankNumber,
                          string sSumRubles, string sSumKopeyki,
                          Organisation orgPayerOrganisation, BankAccount PayerOrganisation_BankAccount,
                          Organisation orgRecipientOrganisation, BankAccount RecipientOrganisation_BankAccount,
                          //string OperationType,
                          string sPaymentPurpose, string sCode, string sReservedField,

                          string s_PaymentAppoinment, string s_Priority)
            : base(dateSignDate, sPaymentType, sBlankNumber,
                           sSumRubles, sSumKopeyki,
                           orgPayerOrganisation, PayerOrganisation_BankAccount,
                           orgRecipientOrganisation, RecipientOrganisation_BankAccount,
                           "06", sPaymentPurpose, sCode, sReservedField)
        {
            ms_Priority = s_Priority;
            ms_PaymentAppoinment = s_PaymentAppoinment;
  
        }

        #region Methods


        /// <summary>
        /// Метод создания словаря со значениями.
        /// </summary>
        /// <returns>СЛоварь со значениями полей.</returns>
        public override Dictionary<string, string> CreateDictionaryWithFieldValues()
        {
            Dictionary<string, string> DictionaryWithFieldValues = new Dictionary<string, string>
            {                
                // {Key,Value}
                { "i_01_Number", BlankNumber},
                { "i_02_CurrentDate", SignDate.ToString("dd.MM.yyyy")}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "i_03_PaymentType", PaymentType},
                { "i_04_SumInCuirsive", ConvertSumToTextRepresentation(SumRubles,SumKopeyki)},
                { "i_07_SumNumber", ConvertSumToNumericRepresentation(SumRubles,SumKopeyki)},

 
                // Инфрмация о плательщике
                { "i_08_PayerName", PayerOrganisation.Org_Name },
                { "i_05_INN_Payer", PayerOrganisation.Org_INN},
                { "i_06_KPP_Payer", PayerOrganisation.Org_KPP},
                { "i_09_PayerBankAccount", PayerOrganisation_BankAccount.BankAc_Number},
                { "i_10_Payer_BankName", PayerOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "i_11_Payer_Bank_BIK", PayerOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "i_12_Payer_Bank_BankAccount", PayerOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},
                
                // Инфрмация о получателе
                { "i_18_RecpientName", RecipientOrganisation.Org_Name },
                { "i_16_INN_Recipient", RecipientOrganisation.Org_INN},
                { "i_17_KPP_Recipient", RecipientOrganisation.Org_KPP},
                { "i_19_Recipient_BankAccount", RecipientOrganisation_BankAccount.BankAc_Number},
                { "i_13_Recipient_BankName", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "i_14_Recipient_Bank_BIK", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "i_15_Recipient_Bank_BankAccount", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},

                { "i_20_OperationType", OperationType},
                { "i_21_NazPL", PaymentPurpose},
                { "i_22_Code", Code},

                { "i_23_PayOrder", ms_Priority},
                { "i_24_ResField", ReservedField},
                { "i_26_PaymentAppoinment", ms_PaymentAppoinment}
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
