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
    public class BlankViewModel_PaymentRequirement : Blank_ViewModel_Base
    {

        public BlankViewModel_PaymentRequirement(Action GoToTheHomePage)
            :base()
        {

            m_GoToTheHomePage = GoToTheHomePage;

            // Выгрузка организаций.
            LoadObjects();
            
            MainOrganisation    = CollectonOfAllOrganisations.Where(id => id.Id == Properties.Settings.Default.MainOrganisationId).FirstOrDefault();

            TemplateDate        = DateTime.Now;
            SendingDate         = DateTime.Now;
            
            PaymentType         = "";
            Priority            = "";
            PaymentCondition    = "";
            PaymentAppointment  = "";
            AcceptType          = "";
            AcceptTypePeriod    = "";

            SaveBlank  = new RelayCommand(SaveBlank_Execute);
            PrintBlank = new RelayCommand(PrintBlank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);

        }


        #region Fields

        #region Blank_Information

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
        /// Условие оплаты
        /// </summary>
        string ms_PaymentCondition;

        #endregion

        #region PaymentInfo
        /// <summary>
        /// Очередность.
        /// </summary>
        string ms_Priority;
        #endregion


        #region Actions
        /// <summary>
        /// Делегат - возврат на указанную страницу.
        /// </summary>
        Action m_GoToTheHomePage;
        #endregion
        #endregion


        #region Properties

        #region Collections for ComboBoxes


        #endregion




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

                if (Sum_kop == "0")  Sum_kop = "00";
                if (Sum_kop.Length == 1) Sum_kop = "0" + Sum_kop;

                // Создание бланка типа.
                Blank_payment_requirement pr_Blank = new Blank_payment_requirement(
                TemplateDate, PaymentType, TemplateNumber, Sum_rub, Sum_kop,
                OrganisationPayer, OrganisationPayer_BankAccount,
                MainOrganisation, MainOrganisation_BankAccount,
                "", "", "", PaymentCondition,
                AcceptTypePeriod, Priority, PaymentAppointment,
                SendingDate);

                // Перевод данных в словарь.
                Dictionary<string, string> dict_pr_Blank = pr_Blank.CreateDictionaryWithFieldValues();

                string blankName = "Платежное_требование_" + DateTime.Now.ToString("MMddHHmmss") + ".docx";

                // Сохранение бланка на диск.
                Blank_Word Blank_Word_1 = new Blank_Word(
                    Properties.Settings.Default.PathToWorkingDirectory + "//"+ blankName,
                    "Платежное требование",
                    dict_pr_Blank);
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
