using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Accounting_FormsFillingAssistant
{
    public class Add_Edit_Organisation_ViewModel : ViewModel_Base
    {


        public Add_Edit_Organisation_ViewModel(int idOfCorrectedOrganisation,
                                               NavigationService FrameNavigationService,
                                               Action GoToTheHomePage)
        {
            m_AppNavigationSystemAdditional = new Navigation(FrameNavigationService);
            mi_idOfCorrectedOrganisation = idOfCorrectedOrganisation; // Если == -1, то добавляется новая организация
            m_GoToTheHomePage = GoToTheHomePage;


            if(mi_idOfCorrectedOrganisation < 0)
            {
                HeaderText = "Новая организация";
            }

            AddNewOrganisation = new RelayCommand(AddNewOrganisation_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);


            //ViewModel_ShowBanckAccounts
            //m_AppNavigationSystemAdditional.AppNavigationService.Navigate(new DB_ObjectsManipulation_Page(),
            //   new ViewModel_ShowBanckAccounts());


        }


        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppNavigationSystemAdditional;

        /// <summary>
        /// Номер корректируемой организации. Если добавляется новая организация, число < 0.
        /// </summary>
        private int mi_idOfCorrectedOrganisation;

        /// <summary>
        /// Делегат - переход на домашнюю страницу.
        /// </summary>
        private Action m_GoToTheHomePage;

        /// <summary>
        /// Заголовок страницы.
        /// </summary>
        private string ms_HeaderText;

        /// <summary>
        /// Название организации.
        /// </summary>
        private string ms_OrganisationName;

        /// <summary>
        /// Адрес организации.
        /// </summary>
        private string ms_OrganisationAddress;

        /// <summary>
        /// ИНН организации.
        /// </summary>
        private string ms_OrganisationINN;

        /// <summary>
        /// КПП организации.
        /// </summary>
        private string ms_OrganisationKPP;

        // Команды.
        private ICommand mcmnd_AddNewOrganisation;
        private ICommand mcmnd_CancelPage;





        #endregion

        #region Properties

        /// <summary>
        /// Свойство для заголовка страницы.
        /// </summary>
        public string HeaderText
        {
            get
            {
                return ms_HeaderText;
            }
            set
            {
                ms_HeaderText = value;
                RaisePropertyChanged("HeaderText");
            }
        }

        /// <summary>
        /// Свойство для названия организации.
        /// </summary>
        public string OrganisationName
        {
            get
            {
                return ms_OrganisationName;
            }
            set
            {
                ms_OrganisationName = value;
                RaisePropertyChanged("OrganisationName");
            }
        }

        /// <summary>
        /// Свойство для адреса организации.
        /// </summary>
        public string OrganisationAddress
        {
            get
            {
                return ms_OrganisationAddress;
            }
            set
            {
                ms_OrganisationAddress = value;
                RaisePropertyChanged("OrganisationAddress");
            }
        }

        /// <summary>
        /// Свойство для ИНН организации.
        /// </summary>
        public string OrganisationINN
        {
            get
            {
                return ms_OrganisationINN;
            }
            set
            {
                ms_OrganisationINN = value;
                RaisePropertyChanged("OrganisationINN");
            }
        }

        /// <summary>
        /// Свойство для КПП организации.
        /// </summary>
        public string OrganisationKPP
        {
            get
            {
                return ms_OrganisationKPP;
            }
            set
            {
                ms_OrganisationKPP = value;
                RaisePropertyChanged("OrganisationKPP");
            }
        }


        public ICommand AddNewOrganisation
        {
            get { return mcmnd_AddNewOrganisation;  }
            set
            {
                mcmnd_AddNewOrganisation = value;
                RaisePropertyChanged("AddNewOrganisation");
            }
        }
        public ICommand CancelPage
        {
            get { return mcmnd_CancelPage; }
            set
            {
                mcmnd_CancelPage = value;
                RaisePropertyChanged("CancelPage");
            }
        }

        #endregion

        #region Methods


        private void AddNewOrganisation_Execute(object o)
        {




            m_GoToTheHomePage.Invoke();
        }

        /// <summary>
        /// Метод - закрыть страницу и перейти на домашнюю страницу или списку всех объектов.
        /// </summary>
        /// <param name="o"></param>
        private void CancelPage_Execute(object o)
        {
            m_GoToTheHomePage.Invoke();
        }

        #endregion

    }
}
