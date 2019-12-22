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
    public class BlankViewModel_Accreditiv : Blank_ViewModel_Base
    {
        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="GoToTheHomePage">Делегат - переход на домашнюю страницу.</param>
        public BlankViewModel_Accreditiv(Action GoToTheHomePage)
            : base()
        {


            m_GoToTheHomePage = GoToTheHomePage;

            // Выгрузка организаций.
            LoadObjects();

            TemplateDate       = DateTime.Now;
            AkkreditiveEOLDate = DateTime.Now;
            AkkreditiveType    = "";
            PaymentTerm        = "";
            ConditionsDetails  = "";
            SubmissionPayment  = "";
            AdditionalDetails  = "";

            SaveBlank  = new RelayCommand(SaveBlank_Execute);
            PrintBlank = new RelayCommand(PrintBlank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);

        }

        #region Fields
        /// <summary>
        /// Возврат на главную страницу.
        /// </summary>
        private Action m_GoToTheHomePage;


        #region Blank fields
        /// <summary>
        /// Вид аккредитива.
        /// </summary>
        string ms_AkkreditiveType;

        /// <summary>
        /// Условие оплаты.
        /// </summary>
        string ms_PaymentTerm;

        /// <summary>
        /// Условия сделки.
        /// </summary>
        string ms_ConditionsDetails;

        /// <summary>
        /// Платеж по представлению (вид документа).
        /// </summary>
        string ms_SubmissionPayment;

        /// <summary>
        /// Дополнительные условия.
        /// </summary>
        string ms_AdditionalDetails;

        /// <summary>
        /// Срок действия аккредитива.
        /// </summary>
        DateTime mdate_AkkreditiveEOLDate;
        #endregion

        #endregion

        #region Properties


        #region Blank fields
        /// <summary>
        /// Свойство - Вид аккредитива.
        /// </summary>
        public string AkkreditiveType
        {
            get { return ms_AkkreditiveType; }
            set
            {
                ms_AkkreditiveType = value;
                RaisePropertyChanged("AkkreditiveType");
            }
        }

        /// <summary>
        /// Свойство - Условие оплаты.
        /// </summary>
        public string PaymentTerm
        {
            get { return ms_PaymentTerm; }
            set
            {
                ms_PaymentTerm = value;
                RaisePropertyChanged("PaymentTerm");
            }
        }

        /// <summary>
        /// Свойство - Условия сделки.
        /// </summary>
        public string ConditionsDetails
        {
            get { return ms_ConditionsDetails; }
            set
            {
                ms_ConditionsDetails = value;
                RaisePropertyChanged("ConditionsDetails");
            }
        }

        /// <summary>
        /// Свойство - Платеж по представлению (вид документа).
        /// </summary>
        public string SubmissionPayment
        {
            get { return ms_SubmissionPayment; }
            set
            {
                ms_SubmissionPayment = value;
                RaisePropertyChanged("SubmissionPayment");
            }
        }

        /// <summary>
        /// Свойство - Дополнительные условия.
        /// </summary>
        public string AdditionalDetails
        {
            get { return ms_AdditionalDetails; }
            set
            {
                ms_AdditionalDetails = value;
                RaisePropertyChanged("AdditionalDetails");
            }
        }

        /// <summary>
        /// Свойство - Срок действия аккредитива.
        /// </summary>
        public DateTime AkkreditiveEOLDate
        {
            get { return mdate_AkkreditiveEOLDate; }
            set
            {
                mdate_AkkreditiveEOLDate = value;
                RaisePropertyChanged("AkkreditiveEOLDate");
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

                Blank_Accreditiv ak_Blank = new Blank_Accreditiv(TemplateDate, PaymentType, TemplateNumber, Sum_rub, Sum_kop,
                OrganisationPayer, OrganisationPayer_BankAccount,
                MainOrganisation, MainOrganisation_BankAccount,
                "", "", "",
                AkkreditiveEOLDate, AkkreditiveType, PaymentTerm, ConditionsDetails, SubmissionPayment, AdditionalDetails);

                Dictionary<string, string> dict_ak_Blank = ak_Blank.CreateDictionaryWithFieldValues();

                string blankName = "Аккредитив_" + DateTime.Now.ToString("MMddHHmmss") + ".docx";

                Blank_Word Blank_Word_1 = new Blank_Word(
                    Properties.Settings.Default.PathToWorkingDirectory + "//" + blankName,
                    "Аккредитив",
                    dict_ak_Blank);

                //// Сохранение данных на диске.
                Blank_Word_1.LoadParametersToWord();

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
