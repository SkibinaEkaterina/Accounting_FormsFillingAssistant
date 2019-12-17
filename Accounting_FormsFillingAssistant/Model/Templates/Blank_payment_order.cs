using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    class Blank_payment_order : Blank_Base
    {

        #region Fields
        /// <summary>
        /// Статус плательщика.
        /// </summary>
        string ms_PayerStatus;
        /// <summary>
        /// Очередность платежа.
        /// </summary>
        string ms_Priority;
        /// <summary>
        /// Назначение платежа
        /// </summary>
        string ms_PaymentAppoinment;
        /// <summary>
        /// Код УИН.
        /// </summary>
        string ms_Code_UIN;
        /// <summary>
        /// Код КБК.
        /// </summary>
        string ms_Code_KBK;
        /// <summary>
        /// Код ОКТМО.
        /// </summary>
        string ms_Code_oktmo;
        /// <summary>
        /// Основание платежа.
        /// </summary>
        string ms_BasisOfPayment;
        /// <summary>
        /// Показатель налогового периода.
        /// </summary>
        string ms_TaxPeriodIndicator;
        /// <summary>
        /// Номер основание платежа.
        /// </summary>
        string ms_PaymentBasisNumber;
        /// <summary>
        /// Дата документа-основания плат.
        /// </summary>
        string ms_DocumentDate;
        /// <summary>
        /// Тип платежа.
        /// </summary>
        string ms_PaymentType2;
        #endregion


        public Blank_payment_order(DateTime dateSignDate, string sPaymentType, string sBlankNumber,
                          string sSumRubles, string sSumKopeyki,
                          Organisation orgPayerOrganisation, BankAccount PayerOrganisation_BankAccount,
                          Organisation orgRecipientOrganisation, BankAccount RecipientOrganisation_BankAccount,
                          //string OperationType,
                          string sPaymentPurpose,string sCode, string sReservedField,

                          string s_PayerStatus, string s_PaymentAppoinment,
                          string s_Code_UIN, string s_Code_KBK,
                          string s_Code_oktmo, string s_BasisOfPayment,
                          string s_DocumentDate, string s_PaymentType2,
                          string s_TaxPeriodIndicator, string s_PaymentBasisNumber, string s_Priority)
            :base(dateSignDate, sPaymentType, sBlankNumber,
                           sSumRubles, sSumKopeyki,
                           orgPayerOrganisation, PayerOrganisation_BankAccount,
                           orgRecipientOrganisation, RecipientOrganisation_BankAccount,
                           "01", sPaymentPurpose, sCode, sReservedField)
        {
            ms_Priority             = s_Priority;
            ms_PayerStatus          = s_PayerStatus;
            ms_PaymentAppoinment    = s_PaymentAppoinment;
            ms_Code_UIN             = s_Code_UIN;
            ms_Code_KBK             = s_Code_KBK;
            ms_Code_oktmo           = s_Code_oktmo;
            ms_BasisOfPayment       = s_BasisOfPayment;
            ms_DocumentDate         = s_DocumentDate;
            ms_PaymentType2         = s_PaymentType2;

            ms_TaxPeriodIndicator   = s_TaxPeriodIndicator;
            ms_PaymentBasisNumber   = s_PaymentBasisNumber;
        }

        #region Methods


        // Метод создания словаря
        public override Dictionary<string, string> CreateDictionaryWithFieldValues()
        {
            Dictionary<string, string> DictionaryWithFieldValues = new Dictionary<string, string>
            {                
                // {Key,Value}
                { "po_01_Number", BlankNumber},
                { "po_02_CurrentDate", SignDate.ToString("dd.MM.yyyy")}, // ПЕРЕДЕЛАТЬ ТОЛЬКО НА ДАТУ!!!!!!!!!!!!
                { "po_03_PaymentType", PaymentType},
                { "po_04_SumInCuirsive", ConvertSumToTextRepresentation(SumRubles,SumKopeyki)},
                { "po_07_SumNumber", ConvertSumToNumericRepresentation(SumRubles,SumKopeyki)},

 
                // Инфрмация о плательщике
                { "po_08_PayerName", PayerOrganisation.Org_Name },
                { "po_05_INN_Payer", PayerOrganisation.Org_INN},
                { "po_06_KPP_Payer", PayerOrganisation.Org_KPP},
                { "po_09_PayerBankAccount", PayerOrganisation_BankAccount.BankAc_Number},
                { "po_10_Payer_BankName", PayerOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "po_11_Payer_Bank_BIK", PayerOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "po_12_Payer_Bank_BankAccount", PayerOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},
                
                // Инфрмация о получателе
                { "po_18_RecpientName", RecipientOrganisation.Org_Name },
                { "po_16_INN_Recipient", RecipientOrganisation.Org_INN},
                { "po_17_KPP_Recipient", RecipientOrganisation.Org_KPP},
                { "po_19_Recipient_BankAccount", RecipientOrganisation_BankAccount.BankAc_Number},
                { "po_13_Recipient_BankName", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_Name},
                { "po_14_Recipient_Bank_BIK", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_BIK},
                { "po_15_Recipient_Bank_BankAccount", RecipientOrganisation_BankAccount.BankAc_Bank.Bank_OwnBankAccount},


                { "po_20_OperationType", OperationType},
                { "po_21_NazPL", PaymentPurpose},
                { "po_22_Code", ms_Code_UIN},

                { "po_23_TimePeriod", ""},
                { "po_24_PayOrder", ms_Priority},
                { "po_25_ResField", ReservedField},
                { "po_26_PaymentAppoinment", ms_PaymentAppoinment },

                { "po_27_CodeKBK", ms_Code_KBK},
                { "po_28_CodeOKTMO", ms_Code_oktmo},
                { "po_29_BasisOfPayment", ms_BasisOfPayment},
                { "po_30_TaxPeriodIndicator", ms_TaxPeriodIndicator},
                { "po_31_PaymentBasisNumber", ms_PaymentBasisNumber},
                { "po_32_PaymentBasisDate", ms_DocumentDate},
                { "po_33_PayType2", ms_PaymentType2},
                { "po_35_payerStatus", ms_PayerStatus}
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
