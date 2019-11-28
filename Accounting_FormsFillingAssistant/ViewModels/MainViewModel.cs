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


        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppNavigationSystem;

        private ICommand mcmnd_GoToHomePage;
        private ICommand mcmnd_OpenSettingsWindow;
        private ICommand mcmnd_GoToAccreditivePage_Create;

        #endregion

        #region Commands
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


        #endregion

        #region Methods


        // Внутренний метод - проверка заполненности полей, необходимых для работы программы.
        private bool CheckNecessaryFieldsFilled()
        {
            // PathToWorkingDirectory
            // PathToDataBase
            // MainOrganisationId

            // Шаг 1.
            // Если нет рабочей директории - выводим страницу Начального заполнения и сообщение: рабочая директория не выбрана.
            // Выберите

            // Шаг 2.
            // Выбрали директорию - создание БД. В данной директории будет создан файл, в котором будут храниться данные
            // программы, включая Организации, банки и счета, которые введет пользователь.
            // Кнопка "Создать БД"

            // Шаг 3. Добавить организацию.
            // База создана. Нам нужна наша организация.
            // Добавляем организацию (без счетов).
            // Информация заносится в БД.

            // Шаг 4. Добавить Банк
            // Но прежде надо добавить Банк - занести данные в БД

            // Шаг 5. Добавить счета для организации (автоматически выбрана наша организация)
            // Далее добавляем счета для нашей организации - занести данные в БД




            return true;

        }



        /// <summary>
        /// Метод, осуществляющий переход на домашнюю страницу - по нажатию кнопки "Домой".
        /// </summary>
        /// <param name="o"></param>
        private void GoToHomePage_Execute(object o)
        {
            
            m_AppNavigationSystem.AppNavigationService.Navigate(new Page_Home(), new ViewModel_Home());
        }

        /// <summary>
        /// Метод, осуществляющий переход к странице настроек.
        /// </summary>
        /// <param name="o"></param>
        private void OpenSettingsWindow_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new SettingsPage(),
                new ViewModel_SettingsWindow(() => FinishWorkOnChildPage()));
        }

        /// <summary>
        /// Метод, осуществляющий переход к странице создания Аккредитива.
        /// </summary>
        /// <param name="o"></param>
        private void GoToAccreditivePage_Create_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new View_Accreditiv(),
               new BlankViewModel_Accreditiv(() => FinishWorkOnChildPage()));
        }

        /// <summary>
        /// Метод передается в качестве параметра в ViewModel дочерних страниц.
        /// Метод, осуществляющий переход на домашнюю страницу.
        /// </summary>
        void FinishWorkOnChildPage()
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new Page_Home(), null);
        }

        #endregion
    }
}
