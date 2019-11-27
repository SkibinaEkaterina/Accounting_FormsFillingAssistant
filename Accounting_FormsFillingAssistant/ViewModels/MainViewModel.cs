using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;




namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Здесь должны инициализироваться все мелкие ViewModels
    /// </summary>
    class MainViewModel : ViewModel_Base
    {
        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppNavigationSystem;


        
        /// <summary>
        /// Конструктор класса с входным параметром - сервис навигации.
        /// </summary>
        /// <param name="navService"> Сервис навигации контрола, в котором осуществляется навигация. </param>
        public MainViewModel(NavigationService navService)
        {
            // Создаем экземпляр сервиса навигации
            m_AppNavigationSystem = new Navigation(navService);

           

            GoToHomePage = new RelayCommand(GoToHomePage_Execute);
            OpenSettingsWindow = new RelayCommand(OpenSettingsWindow_Execute);
            GoToAccreditivePage_Create = new RelayCommand(GoToAccreditivePage_Create_Execute);





        }





        private ICommand mcmnd_GoToHomePage;
        private ICommand mcmnd_OpenSettingsWindow;
        private ICommand mcmnd_GoToAccreditivePage_Create;


        public ICommand GoToHomePage
        {
            get { return mcmnd_GoToHomePage; }
            set
            {
                mcmnd_GoToHomePage = value;
                RaisePropertyChanged("GoToHomePage");
            }
        }

        public ICommand OpenSettingsWindow
        {
            get { return mcmnd_OpenSettingsWindow; }
            set
            {
                mcmnd_OpenSettingsWindow = value;
                RaisePropertyChanged("OpenSettingsWindow");
            }
        }

        public ICommand GoToAccreditivePage_Create
        {
            get { return mcmnd_GoToAccreditivePage_Create; }
            set
            {
                mcmnd_GoToAccreditivePage_Create = value;
                RaisePropertyChanged("GoToAccreditivePage_Create");
            }
        }





        private void GoToHomePage_Execute(object o)
        {
            
            m_AppNavigationSystem.AppNavigationService.Navigate(new Page_Home(), new ViewModel_Home());
        }

        private void OpenSettingsWindow_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new SettingsPage(),
                new ViewModel_SettingsWindow(() => FinishWorkOnChildPage()));
        }

        private void GoToAccreditivePage_Create_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new View_Accreditiv(),
               new BlankViewModel_Accreditiv(() => FinishWorkOnChildPage()));
        }



        /// <summary>
        /// Метод передается в качестве параметра в ViewModel дочерних страниц.
        /// </summary>
        void FinishWorkOnChildPage()
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new Page_Home(), null);
        }


    }
}
