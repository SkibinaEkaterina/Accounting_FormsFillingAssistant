using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс ViewModel для ИНКАССО.
    /// </summary>
    class Blank_ViewModel_Inkasso : Blank_ViewModel_Base
    {
        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="GoToTheHomePage">Делегат - переход на домашнюю страницу.</param>
        public Blank_ViewModel_Inkasso(Action GoToTheHomePage)
            : base()
        {
            m_GoToTheHomePage = GoToTheHomePage;

            LoadObjects();

            TemplateDate = DateTime.Now;
            Priority = "";
            PaymentAppointment = "";

            SaveBlank = new RelayCommand(SaveBlank_Execute);
            PrintBlank = new RelayCommand(PrintBlank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);

        }


        #region Fields

        /// <summary>
        /// Основание платежа.
        /// </summary>
        string ms_PaymentAppointment;
        /// <summary>
        /// Очередность.
        /// </summary>
        string ms_Priority;

        #region Actions
        /// <summary>
        /// Делегат - возврат на указанную страницу.
        /// </summary>
        Action m_GoToTheHomePage;
        #endregion
        #endregion




        #region Properties

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
                Blank_inkasso i_Blank = new Blank_inkasso(
                                    TemplateDate, PaymentType, TemplateNumber, Sum_rub, Sum_kop,
                                    OrganisationPayer, OrganisationPayer_BankAccount,
                                    MainOrganisation, MainOrganisation_BankAccount,
                                    "", "", "",
                                    PaymentAppointment, Priority);

                // Перевод данных в словарь.
                Dictionary<string, string> dict_pi_Blank = i_Blank.CreateDictionaryWithFieldValues();

                string blankName = "Инкассовое_поручение_" + DateTime.Now.ToString("MMddHHmmss") + ".docx";

                // Сохранение бланка на диск.
                Blank_Word Blank_Word_1 = new Blank_Word(
                    Properties.Settings.Default.PathToWorkingDirectory + "//" + blankName,
                    "Инкассовое поручение",
                    dict_pi_Blank);
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
