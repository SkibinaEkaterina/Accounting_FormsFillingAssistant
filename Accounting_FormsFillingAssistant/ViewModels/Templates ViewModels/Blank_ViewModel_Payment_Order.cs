using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    class Blank_ViewModel_Payment_Order : Blank_ViewModel_Base
    {


        public Blank_ViewModel_Payment_Order(Action GoToTheHomePage)
            : base()
        {
            m_GoToTheHomePage = GoToTheHomePage;

            LoadObjects();

            MainOrganisation = CollectonOfAllOrganisations.Where(id => id.Id == Properties.Settings.Default.MainOrganisationId).FirstOrDefault();

            TemplateDate        = DateTime.Now;
            PayerStatus         = "";
            Priority            = "";
            PaymentAppointment  = "";
            Code_UIN            = "0";
            Code_KBK            = "";
            Code_oktmo          = "";
            BasisOfPayment      = "";
            TaxPeriodIndicator  = "";
            PaymentBasisNumber  = "";
            PaymentBasisDate    = "";
            PayType2            = "";

            SaveBlank   = new RelayCommand(SaveBlank_Execute);
            PrintBlank  = new RelayCommand(PrintBlank_Execute);
            CancelPage  = new RelayCommand(CancelPage_Execute);
        }

        #region Fields

        #region Blank_Information

        /// <summary>
        /// Основание платежа.
        /// </summary>
        string ms_PaymentAppointment;
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

        
        #endregion

        #region PaymentInfo
        /// <summary>
        /// Очередность.
        /// </summary>
        string ms_Priority;

        /// <summary>
        /// Статус плательщика.
        /// </summary>
        string ms_PayerStatus;

        /// <summary>
        /// Основание платежа.
        /// </summary>
        string ms_BasisOfPayment;
        /// <summary>
        /// Показатель налог. периода.
        /// </summary>
        string ms_TaxPeriodIndicator;
        /// <summary>
        /// Номер основания плат.
        /// </summary>
        string ms_PaymentBasisNumber;

        /// <summary>
        /// Дата документа-основания плат.
        /// </summary>
        string ms_PaymentBasisDate;

        /// <summary>
        /// Тип платежа.
        /// </summary>
        string ms_PayType2;
        #endregion


        #region Actions
        /// <summary>
        /// Делегат - возврат на указанную страницу.
        /// </summary>
        Action m_GoToTheHomePage;
        #endregion
        #endregion




        #region Properties

        #region Blank_Information

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
        /// Свойство - Код УИН.
        /// </summary>
        public string Code_UIN
        {
            get => ms_Code_UIN;
            set
            {
                ms_Code_UIN = value;
                RaisePropertyChanged("Code_UIN");
            }
        }

        /// <summary>
        /// Свойство - Код КБК.
        /// </summary>
        public string Code_KBK
        {
            get => ms_Code_KBK;
            set
            {
                ms_Code_KBK = value;
                RaisePropertyChanged("Code_KBK");
            }

        }

        /// <summary>
        /// Свойство - Код ОКТМО.
        /// </summary>
        public string Code_oktmo
        {
            get => ms_Code_oktmo;
            set
            {
                ms_Code_oktmo = value;
                RaisePropertyChanged("Code_oktmo");
            }

        }


        #endregion

        #region PaymentInfo

        /// <summary>
        /// Свойство - Очередность.
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

        /// <summary>
        /// Свойство - Статус плательщика.
        /// </summary>
        public string PayerStatus
        {
            get => ms_PayerStatus;
            set
            {
                ms_PayerStatus = value;
                RaisePropertyChanged("PayerStatus");
            }
        }



        /// <summary>
        /// Свойство - Основание платежа.
        /// </summary>
        public string BasisOfPayment
        {
            get => ms_BasisOfPayment;
            set
            {
                ms_BasisOfPayment = value;
                RaisePropertyChanged("BasisOfPayment");
            }

        }

        /// <summary>
        /// Свойство - Показатель налог. периода.
        /// </summary>
        public string TaxPeriodIndicator
        {
            get => ms_TaxPeriodIndicator;
            set
            {
                ms_TaxPeriodIndicator = value;
                RaisePropertyChanged("TaxPeriodIndicator");
            }

        }

        /// <summary>
        /// Свойство - Номер основания плат.
        /// </summary>
        public string PaymentBasisNumber
        {
            get => ms_PaymentBasisNumber;
            set
            {
                ms_PaymentBasisNumber = value;
                RaisePropertyChanged("PaymentBasisNumber");
            }

        }
        /// <summary>
        /// Свойство - Дата документа-основания плат.
        /// </summary>
        public string PaymentBasisDate
        {
            get => ms_PaymentBasisDate;
            set
            {
                ms_PaymentBasisDate = value;
                RaisePropertyChanged("PaymentBasisDate");
            }

        }

        /// <summary>
        /// Свойство - Тип платежа.
        /// </summary>
        public string PayType2
        {
            get => ms_PayType2;
            set
            {
                ms_PayType2 = value;
                RaisePropertyChanged("PayType2");
            }

        }
        #endregion

        #endregion


        #region Methods

        /// <summary>
        /// Загрузка объектов из БД.
        /// </summary>
        public override void LoadObjects()
        {
            CollectonOfAllOrganisations = new ObservableCollection<Organisation>(ObjectsDBManipulations.LoadAllOrganisationsFromDB());
        }

        /// <summary>
        /// Метода - Сохранить бланк.
        /// </summary>
        /// <param name="o"></param>
        public override void SaveBlank_Execute(object o)
        {

            if (CheckDataFilling())
            {

                if (!PaymentSum.Contains('.')) PaymentSum += ".0";

                string Sum_rub = PaymentSum.Split('.')[0];
                string Sum_kop = PaymentSum.Split('.')[1];

                if (Sum_kop == "0") Sum_kop = "00";
                if (Sum_kop.Length == 1) Sum_kop = "0" + Sum_kop;

                // Создание бланка типа.
                Blank_payment_order po_Blank = new Blank_payment_order(
                                    TemplateDate, PaymentType, TemplateNumber, Sum_rub, Sum_kop,
                OrganisationPayer, OrganisationPayer_BankAccount,
                MainOrganisation, MainOrganisation_BankAccount,
                "", "", "",
                PayerStatus, PaymentAppointment, Code_UIN,
                Code_KBK, Code_oktmo, BasisOfPayment, PaymentBasisDate,
                PayType2, TaxPeriodIndicator, PaymentBasisNumber, Priority);

                // Перевод данных в словарь.
                Dictionary<string, string> dict_po_Blank = po_Blank.CreateDictionaryWithFieldValues();

                string blankName = "Платежное_поручение_" + DateTime.Now.ToString("MMddHHmmss") + ".docx";

                // Сохранение бланка на диск.
                Blank_Word Blank_Word_1 = new Blank_Word(
                    Properties.Settings.Default.PathToWorkingDirectory + "//" + blankName,
                    "Платежное поручение",
                    dict_po_Blank);
                Blank_Word_1.LoadParametersToWord();

                // Переход на домашнюю страницу.
                m_GoToTheHomePage.Invoke();
            }

        }
        /// <summary>
        /// Метода - Сохранить бланк.
        /// </summary>
        /// <param name="o"></param>
        public override void PrintBlank_Execute(object o)
        {

        }

        /// <summary>
        /// Метода - Закрыть страницу.
        /// </summary>
        /// <param name="o"></param>
        public override void CancelPage_Execute(object o)
        {
            m_GoToTheHomePage.Invoke();
        }


        #endregion


    }
}
