using System;
using System.Collections.Generic;
using System.IO;
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

            // Бланки.
            GoToAccreditivePage_Create = new RelayCommand(GoToAccreditivePage_Create_Execute);
            GoToPaymentRequirementPage_Create = new RelayCommand(GoToPaymentRequirementPage_Create_Execute);
            GoToPaymentOrderPage_Create = new RelayCommand(GoToPaymentOrderPage_Create_Execute);



            // Организации.
            GoToAllOrganisationsPage = new RelayCommand(GoToAllOrganisationsPage_Execute);
            GoToAddOrganisationsPage = new RelayCommand(GoToAddOrganisationsPage_Execute);

            // Банки.
            GoToPageWithAllBanks = new RelayCommand(GoToPageWithAllBanks_Execute);
            GoToPageAddEditBank = new RelayCommand(GoToPageAddBank_Execute);


            // Счета.
            GoToPageWithAllBankAccounts = new RelayCommand(GoToPageWithAllBankAccounts_Execute);
            GoToThePageAddBankAccount = new RelayCommand(GoToThePageAddBankAccount_Execute);

            // Проверка наличия всех необходимых данных для работы программы (путь к базе, рабочая директория)
            CheckNecessaryFieldsFilled();




        }


        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppNavigationSystem;

        // Комманды
        private ICommand mcmnd_GoToHomePage;
        private ICommand mcmnd_OpenSettingsWindow;
        private ICommand mcmnd_GoToAccreditivePage_Create;
        private ICommand mcmnd_GoToPaymentRequirementPage_Create;
        private ICommand mcmnd_GoToPaymentOrderPage_Create;


        private ICommand mcmnd_GoToAllOrganisationsPage;
        private ICommand mcmnd_GoToAddOrganisationsPage;
        private ICommand mcmnd_GoToPageWithAllBanks;
        private ICommand mcmnd_GoToPageAddEditBank;
        private ICommand mcmnd_GoToPageWithAllBankAccounts;
        private ICommand mcmnd_GoToThePageAddBankAccount;

        #endregion

        #region Commands
        /// <summary>
        /// Свойство команды - Вернуться на домашнюю страницу.
        /// </summary>
        public ICommand GoToHomePage
        {
            get { return mcmnd_GoToHomePage; }
            set
            {
                mcmnd_GoToHomePage = value;
                RaisePropertyChanged("GoToHomePage");
            }
        }

        /// <summary>
        /// Своство комманды - открыть окно натсроек.
        /// </summary>
        public ICommand OpenSettingsWindow
        {
            get { return mcmnd_OpenSettingsWindow; }
            set
            {
                mcmnd_OpenSettingsWindow = value;
                RaisePropertyChanged("OpenSettingsWindow");
            }
        }

        /// <summary>
        /// Свойство команды - перейти на страницу создания бланка аккредитива.
        /// </summary>
        public ICommand GoToAccreditivePage_Create
        {
            get { return mcmnd_GoToAccreditivePage_Create; }
            set
            {
                mcmnd_GoToAccreditivePage_Create = value;
                RaisePropertyChanged("GoToAccreditivePage_Create");
            }
        }

        /// <summary>
        /// Свойство команды - переход к странице создания платежного требования.
        /// </summary>
        public ICommand GoToPaymentRequirementPage_Create
        {
            get { return mcmnd_GoToPaymentRequirementPage_Create; }
            set
            {
                mcmnd_GoToPaymentRequirementPage_Create = value;
                RaisePropertyChanged("GoToPaymentRequirementPage_Create");
            }
        }
        /// <summary>
        /// Свойство команды - переход к странице создания платежного поручения.
        /// </summary>
        public ICommand GoToPaymentOrderPage_Create
        {
            get { return mcmnd_GoToPaymentOrderPage_Create; }
            set
            {
                mcmnd_GoToPaymentOrderPage_Create = value;
                RaisePropertyChanged("GoToPaymentOrderPage_Create");
            }
        }
        

        /// <summary>
        /// Свойство команды - перейти к странице со всеми организациями.
        /// </summary>
        public ICommand GoToAllOrganisationsPage
        {
            get { return mcmnd_GoToAllOrganisationsPage; }
            set
            {
                mcmnd_GoToAllOrganisationsPage = value;
                RaisePropertyChanged("GoToAllOrganisationsPage");
            }
        }

        public ICommand GoToAddOrganisationsPage
        {
            get { return mcmnd_GoToAddOrganisationsPage; }
            set
            {
                mcmnd_GoToAddOrganisationsPage = value;
                RaisePropertyChanged("GoToAddOrganisationsPage");
            }
        }


        public ICommand GoToPageWithAllBanks
        {
            get { return mcmnd_GoToPageWithAllBanks; }
            set
            {
                mcmnd_GoToPageWithAllBanks = value;
                RaisePropertyChanged("GoToPageWithAllBanks");
            }
        }

        public ICommand GoToPageAddEditBank
        {
            get { return mcmnd_GoToPageAddEditBank; }
            set
            {
                mcmnd_GoToPageAddEditBank = value;
                RaisePropertyChanged("GoToPageAddEditBank");
            }
        }


        public ICommand GoToPageWithAllBankAccounts
        {
            

            get { return mcmnd_GoToPageWithAllBankAccounts; }
            set
            {
                mcmnd_GoToPageWithAllBankAccounts = value;
                RaisePropertyChanged("GoToPageWithAllBankAccounts" +
                    "");
            }
        }


        public ICommand GoToThePageAddBankAccount
        {


            get { return mcmnd_GoToThePageAddBankAccount; }
            set
            {
                mcmnd_GoToThePageAddBankAccount = value;
                RaisePropertyChanged("GoToThePageAddBankAccount" +
                    "");
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


            if (Properties.Settings.Default.PathToWorkingDirectory == "" ||
              Properties.Settings.Default.PathToWorkingDirectory == null ||
              !Directory.Exists(Properties.Settings.Default.PathToWorkingDirectory))
            {
                m_AppNavigationSystem.AppNavigationService.Navigate(new InitialFillingPage(), new ViewModel_InitialFillingPage());
            }
            else
            {
                if(Properties.Settings.Default.PathToDataBase == "" ||
                   Properties.Settings.Default.PathToDataBase == null)
                {
                    // Создать БД в рабочей директории

                    

                }
            }


            return true;

        }


        #region Основные страницы


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

        #endregion


        #region Бланки


        /// <summary>
        /// Метод, осуществляющий переход к странице создания Аккредитива.
        /// </summary>
        /// <param name="o"></param>
        private void GoToAccreditivePage_Create_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new View_Accreditiv(),
               new BlankViewModel_Accreditiv(() => FinishWorkOnChildPage()));
        }
        

         private void GoToPaymentOrderPage_Create_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new View_payment_order(),
               new Blank_ViewModel_Payment_Order(() => FinishWorkOnChildPage()));
        }

        private void GoToPaymentRequirementPage_Create_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new View_payment_requirement(),
               new BlankViewModel_PaymentRequirement(() => FinishWorkOnChildPage()));
        }

        #endregion


        #region Манипуляция с объектами

        /// <summary>
        /// Действие - перейти на страницу добавления/редактирования организации.
        /// </summary>
        /// <param name="o"></param>
        private void GoToAddOrganisationsPage_Execute(object o)
        {
            Add_organisation_Page newPage = new Add_organisation_Page();
            Add_Edit_Organisation_ViewModel newVM = new Add_Edit_Organisation_ViewModel(null, newPage.GetFrameNavigationService(),
                                                                                        () => FinishWorkOnChildPage());

            m_AppNavigationSystem.AppNavigationService.Navigate(newPage, newVM);
        }

        /// <summary>
        /// Действие - перейти на страницу обзора всех организаций в БД.
        /// </summary>
        /// <param name="o"></param>
        private void GoToAllOrganisationsPage_Execute(object o)
        {

            m_AppNavigationSystem.AppNavigationService.Navigate(new DB_ObjectsManipulation_Page(),
               new ViewModel_ObjectsView_and_Manipulation<Organisation>(m_AppNavigationSystem));
        }




        /// <summary>
        /// Действие - перейти на страницу обзора всех банков в БД.
        /// </summary>
        /// <param name="o"></param>
        private void GoToPageWithAllBanks_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new DB_ObjectsManipulation_Page(),
                                                                new ViewModel_ObjectsView_and_Manipulation<Bank>(m_AppNavigationSystem));
        }


        /// <summary>
        /// Действие - перейти на страницу добавления/редактирования банка.
        /// </summary>
        /// <param name="o"></param>
        private void GoToPageAddBank_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new Add_Edit_Bank_Page(),
                                                                new ViewModel_AddEdit_Bank(null, 
                                                                () => FinishWorkOnChildPage()));
        }


        private void GoToPageWithAllBankAccounts_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new DB_ObjectsManipulation_Page(),
                                                                new ViewModel_ObjectsView_and_Manipulation<BankAccount>(m_AppNavigationSystem));
        }

        private void GoToThePageAddBankAccount_Execute(object o)
        {
            m_AppNavigationSystem.AppNavigationService.Navigate(new AddEditBankAccount_Page(),
                                                               new Add_Edit_BankAccount_ViewModel(null,
                                                               () => FinishWorkOnChildPage(),
                                                               true));

        }

        #endregion


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
