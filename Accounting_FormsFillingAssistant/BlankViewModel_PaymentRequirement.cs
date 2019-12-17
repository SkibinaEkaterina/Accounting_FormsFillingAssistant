using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class BlankViewModel_PaymentRequirement : ViewModel_Base
    {

        public BlankViewModel_PaymentRequirement()
        {
            // Выгрузка организаций.
            LoadObjects();

            MainOrganisation = m_CollectonOfAllOrganisations[0];

            TemplateDate = DateTime.Now;
            SendingDate = DateTime.Now;
            TemplateNumber = "";
            PaymentSum = "0.0";
            PaymentType = "";
            Priority = "";
            PaymentCondition = "";
            PaymentAppointment = "";
            AcceptType = "";
            AcceptTypePeriod = "";


            SaveBlank = new RelayCommand(SaveBlank_Execute);
            PrintBlank = new RelayCommand(PrintBlank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);




        }


        #region Fields

        #region Collections for ComboBoxes
        /// <summary>
        /// Список всех организаций.
        /// </summary>
        ObservableCollection<Organisation> m_CollectonOfAllOrganisations;

        /// <summary>
        /// Список счетов организации плательщика.
        /// </summary>
        ObservableCollection<BankAccount> m_CollectonOfBankAccountsForPayerOrganisation;

        ObservableCollection<BankAccount> m_CollectonOfBankAccountsForMainOrganisation;

        #endregion



        #region Organisatuins_Information
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

        #region Blank_Information
        /// <summary>
        /// Вид операции (вид оп.). 02 - Для платежного требования.
        /// </summary>
        string ms_TemplateOperationType;
        /// <summary>
        /// Номер бланка.
        /// </summary>
        string ms_TemplateNumber;

        /// <summary>
        /// Дата оформления бланка.
        /// </summary>
        DateTime mdate_TemplateDate;

        /// <summary>
        /// Основание платежа.
        /// </summary>
        string ms_PaymentAppointment;
        /// <summary>
        /// Тип акцепта.
        /// </summary>
        string ms_AcceptType;
        /// <summary>
        /// Срок для акцепта.
        /// </summary>
        string ms_AcceptTypePeriod;
        /// <summary>
        /// Дата отправки документов.
        /// </summary>
        DateTime mdate_SendingDate;
        /// <summary>
        /// Условие опдаты
        /// </summary>
        string ms_PaymentCondition;
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
        /// <summary>
        /// Очередность.
        /// </summary>
        string ms_Priority;
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


        #endregion


        #region Organisatuins_Information
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

                // Загрузка счетов
                // 

                CollectonOfBankAccountsForPayerOrganisation = new ObservableCollection<BankAccount>(m_OrganisationPayer.Org_BankAccounts);


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
        public string _OrganisationPayer_INN
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

        /// <summary>
        /// Свойство - Основание платежа.
        /// </summary>
        public string PaymentAppointment
        {
            get { return ms_PaymentAppointment; }
            set
            {
                ms_PaymentAppointment = value;
                RaisePropertyChanged("PaymentAppointment");
            }
        }
        /// <summary>
        /// Свойство - Тип акцепта.
        /// </summary>
        public string AcceptType
        {
            get { return ms_AcceptType; }
            set
            {
                ms_AcceptType = value;
                RaisePropertyChanged("AcceptType");
            }
        }
        /// <summary>
        /// Свойство - Срок для акцепта.
        /// </summary>
        public string AcceptTypePeriod
        {
            get { return ms_AcceptTypePeriod; }
            set
            {
                ms_AcceptTypePeriod = value;
                RaisePropertyChanged("AcceptTypePeriod");
            }
        }
        /// <summary>
        /// Свойство - Дата отправки документов.
        /// </summary>
        public DateTime SendingDate
        {
            get { return mdate_SendingDate; }
            set
            {
                mdate_SendingDate = value;
                RaisePropertyChanged("SendindDate");
            }
        }

        /// <summary>
        /// Условие опдаты
        /// </summary>
        public string PaymentCondition
        {
            get => ms_PaymentCondition;
            set
            {
                ms_PaymentCondition = value;
                RaisePropertyChanged("PaymentCondition");
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
        /// <summary>
        ///  Свойство - Очередность.
        /// </summary>
        public string Priority
        {
            get { return ms_Priority; }
            set
            {
                ms_Priority = value;
                RaisePropertyChanged("Priority");
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
        /// Загрузка объектов из БД.
        /// </summary>
        public void LoadObjects()
        {
            m_CollectonOfAllOrganisations = new ObservableCollection<Organisation>(ObjectsDBManipulations.LoadAllOrganisationsFromDB());
        }


        private void SaveBlank_Execute(object o)
        {
            Blank_payment_requirement pr_Blank = new Blank_payment_requirement(
                TemplateDate, PaymentType, TemplateNumber, PaymentSum.Split('.')[0], PaymentSum.Split('.')[1],
                OrganisationPayer, OrganisationPayer_BankAccount,
                MainOrganisation, MainOrganisation_BankAccount,
                PaymentAppointment, "", "", PaymentCondition,
                AcceptTypePeriod, Priority, PaymentAppointment, SendingDate
                );
            Dictionary<string, string> dict_pr_Blank = pr_Blank.CreateDictionaryWithFieldValues();

            Blank_Word Blank_Word_1 = new Blank_Word(
                Properties.Settings.Default.PathToWorkingDirectory + "Blank1.docx",
                "Платежное требование",
                dict_pr_Blank
                );
            Blank_Word_1.LoadParametersToWord();

        }

        private void PrintBlank_Execute(object o)
        {

        }

        private void CancelPage_Execute(object o)
        {

        }


        #endregion
    }
}
