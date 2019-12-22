using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс ViewModel - базовый для ViewModel всех бланков.
    /// </summary>
    public abstract class Blank_ViewModel_Base : ViewModel_Base
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Blank_ViewModel_Base()
        {
            TemplateNumber  = "";
            PaymentSum      = "0.0";
            CollectonOfPaymentTypes = new ObservableCollection<string> { "", "Срочно", "Электронно", "Почтой", "Телеграфом", "Иное, указанное банком"};
        }

        #region Fields

        #region Blank_Information

        /// <summary>
        /// Номер бланка.
        /// </summary>
        string ms_TemplateNumber;
        /// <summary>
        /// Дата оформления бланка.
        /// </summary>
        DateTime mdate_TemplateDate;
        #endregion

        #region Organisations_Information
        /// <summary>
        /// Организация плательщик.
        /// </summary>
        Organisation m_OrganisationPayer;
        /// <summary>
        /// Организация, которой придет оплата.
        /// </summary>
        Organisation m_MainOrganisation;

        /// <summary>
        /// Счёт плательщика.
        /// </summary>
        BankAccount m_OrganisationPayer_BankAccount;
        /// <summary>
        /// Счёт организации, которой придет оплата.
        /// </summary>
        BankAccount m_MainOrganisation_BankAccount;

        /// <summary>
        /// ИНН плательщика.
        /// </summary>
        string ms_OrganisationPayer_INN;
        /// <summary>
        /// ИНН организации, которой придет оплата.
        /// </summary>
        string ms_MainOrganisation_INN;

        #endregion

        #region Collections for ComboBoxes
        /// <summary>
        /// Список всех организаций.
        /// </summary>
        ObservableCollection<Organisation> m_CollectonOfAllOrganisations;

        /// <summary>
        /// Список счетов организации плательщика.
        /// </summary>
        ObservableCollection<BankAccount> m_CollectonOfBankAccountsForPayerOrganisation;

        /// <summary>
        /// Список банковских счетов организации - получателя.
        /// </summary>
        ObservableCollection<BankAccount> m_CollectonOfBankAccountsForMainOrganisation;

        ObservableCollection<string> m_CollectonOfPaymentTypes;

        #endregion

        #region PaymentInfo
        /// <summary>
        /// Сумма оплаты.
        /// </summary>
        string ms_PaymentSum;
        /// <summary>
        /// Тип оплаты.
        /// </summary>
        string ms_PaymentType;
        #endregion


        #region Blank_Information

        /// <summary>
        /// Свойство - Номер бланка.
        /// </summary>
        public string TemplateNumber
        {
            get { return ms_TemplateNumber; }
            set
            {
                ms_TemplateNumber = value;
                RaisePropertyChanged("TemplateNumber");
            }
        }
        /// <summary>
        /// Свойство - Дата оформления бланка.
        /// </summary>
        public DateTime TemplateDate
        {
            get { return mdate_TemplateDate; }
            set
            {
                mdate_TemplateDate = value;
                RaisePropertyChanged("TemplateDate");
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Сохраниь бланк.
        /// </summary>
        ICommand mcmnd_SaveBlank;
        /// <summary>
        /// Печать бланка.
        /// </summary>
        ICommand mcmnd_PrintBlank;
        /// <summary>
        /// Закрыть страницу.
        /// </summary>
        ICommand mcmnd_CancelPage;

        #endregion


        #endregion

        #region Properties
        #region Organisatuins_Information Properties
        /// <summary>
        /// Свойство - Организация плательщик.
        /// </summary>
        public Organisation OrganisationPayer
        {
            get { return m_OrganisationPayer; }
            set
            {
                m_OrganisationPayer = value;
                RaisePropertyChanged("OrganisationPayer");

                CollectonOfBankAccountsForPayerOrganisation = new ObservableCollection<BankAccount>(m_OrganisationPayer.Org_BankAccounts);
                OrganisationPayer_INN = m_OrganisationPayer.Org_INN;

            }
        }
        /// <summary>
        /// Свойство - Организация, которой придет оплата.
        /// </summary>
        public Organisation MainOrganisation
        {
            get { return m_MainOrganisation; }
            set
            {
                m_MainOrganisation = value;
                RaisePropertyChanged("MainOrganisation");

                MainOrganisation_INN = m_MainOrganisation.Org_INN;

                CollectonOfBankAccountsForMainOrganisation = new ObservableCollection<BankAccount>(m_MainOrganisation.Org_BankAccounts);
                RaisePropertyChanged("CollectonOfBankAccountsForMainOrganisation");
            }
        }

        /// <summary>
        /// Свойство - Счёт плательщика.
        /// </summary>
        public BankAccount OrganisationPayer_BankAccount
        {
            get { return m_OrganisationPayer_BankAccount; }
            set
            {
                m_OrganisationPayer_BankAccount = value;
                RaisePropertyChanged("OrganisationPayer_BankAccount");
            }
        }

        /// <summary>
        /// Свойство - Счёт организации, которой придет оплата.
        /// </summary>
        public BankAccount MainOrganisation_BankAccount
        {
            get { return m_MainOrganisation_BankAccount; }
            set
            {
                m_MainOrganisation_BankAccount = value;
                RaisePropertyChanged("MainOrganisation_BankAccount");
            }
        }

        /// <summary>
        /// Свойство - ИНН плательщика.
        /// </summary>
        public string OrganisationPayer_INN
        {
            get { return ms_OrganisationPayer_INN; }
            set
            {
                ms_OrganisationPayer_INN = value;
                RaisePropertyChanged("OrganisationPayer_INN");
            }
        }
        /// <summary>
        /// Свойство - ИНН организации, которой придет оплата.
        /// </summary>
        public string MainOrganisation_INN
        {
            get { return ms_MainOrganisation_INN; }
            set
            {
                ms_MainOrganisation_INN = value;
                RaisePropertyChanged("MainOrganisation_INN");
            }
        }


        #endregion

        #region Collections for ComboBoxes
        /// <summary>
        /// Свойство - Список всех организаций. Связан как со списком для выбора плательщика, так и выбора получающей оплату организации.
        /// </summary>
        public ObservableCollection<Organisation> CollectonOfAllOrganisations
        {
            get => m_CollectonOfAllOrganisations;
            set => m_CollectonOfAllOrganisations = value;
        }


        /// <summary>
        /// Список счетов организации плательщика.
        /// </summary>
        public ObservableCollection<BankAccount> CollectonOfBankAccountsForPayerOrganisation
        {
            get => m_CollectonOfBankAccountsForPayerOrganisation;
            set
            {
                m_CollectonOfBankAccountsForPayerOrganisation = value;
                RaisePropertyChanged("CollectonOfBankAccountsForPayerOrganisation");
            }
        }

        public ObservableCollection<BankAccount> CollectonOfBankAccountsForMainOrganisation
        {
            get => m_CollectonOfBankAccountsForMainOrganisation;
            set
            {
                m_CollectonOfBankAccountsForMainOrganisation = value;
                RaisePropertyChanged("CollectonOfBankAccountsForMainOrganisation");
            }

        }

        /// <summary>
        /// Свойство - Типы оплаты.
        /// </summary>
        public ObservableCollection<string> CollectonOfPaymentTypes
        {
            get => m_CollectonOfPaymentTypes;
            set
            {
                m_CollectonOfPaymentTypes = value;
                RaisePropertyChanged("CollectonOfPaymentTypes");
            }

        }

        #endregion

        #region PaymentInfo
        /// <summary>
        /// Свойство - Сумма оплаты.
        /// </summary>
        public string PaymentSum
        {
            get { return ms_PaymentSum; }
            set
            {
                ms_PaymentSum = value;
                RaisePropertyChanged("PaymentSum");
            }
        }
        /// <summary>
        /// Свойство - Тип оплаты.
        /// </summary>
        public string PaymentType
        {
            get { return ms_PaymentType; }
            set
            {
                ms_PaymentType = value;
                RaisePropertyChanged("PaymentType");
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Свойство - сохранить бланк.
        /// </summary>
        public ICommand SaveBlank
        {
            get => mcmnd_SaveBlank;
            set
            {
                mcmnd_SaveBlank = value;
                RaisePropertyChanged("mcmnd_SaveBlank");
            }
        }
        /// <summary>
        /// Свойство - Печать бланка.
        /// </summary>
        public ICommand PrintBlank
        {
            get => mcmnd_PrintBlank;
            set
            {
                mcmnd_PrintBlank = value;
                RaisePropertyChanged("PrintBlank");
            }
        }
        /// <summary>
        /// Свойство - Закрыть страницу.
        /// </summary>
        public ICommand CancelPage
        {
            get => mcmnd_CancelPage;
            set
            {
                mcmnd_CancelPage = value;
                RaisePropertyChanged("CancelPage");
            }
        }

        #endregion

        #endregion


        #region Methods
        /// <summary>
        /// Сигнатура Метода - Загрузить объекты.
        /// </summary>
        public abstract void LoadObjects();
        /// <summary>
        /// Сигнатура Метода - Сохранить бланк.
        /// </summary>
        public abstract void SaveBlank_Execute(object o);
        /// <summary>
        /// Сигнатура Метода - Печатать бланк.
        /// </summary>
        public abstract void PrintBlank_Execute(object o);
        /// <summary>
        /// Сигнатура Метода - Закрыть страницу.
        /// </summary>
        public abstract void CancelPage_Execute(object o);

        public bool CheckDataFilling()
        {
            if (TemplateNumber == "" || TemplateNumber == null)
            {
                MessageBox.Show("Не заполнен номер бланка.");
                return false;
            }

            if (PaymentSum == "" || PaymentSum == null || PaymentSum == "0.0")
            {
                MessageBox.Show("Не заполнена сумма.");
                return false;
            }

            // организации.
            if (OrganisationPayer == null)
            {
                MessageBox.Show("Не выбрана организация-плательщик.");
                return false;
            }

            if (OrganisationPayer_BankAccount == null)
            {
                MessageBox.Show("Не выбран счёт организации-плательщика.");
                return false;
            }

            if (MainOrganisation == null)
            {
                MessageBox.Show("Не выбрана организации-получателя.");
                return false;
            }

            if (MainOrganisation_BankAccount == null)
            {
                MessageBox.Show("Не выбран счёт организации-получателя.");
                return false;
            }

            return true;
        }
        #endregion

    }
}
