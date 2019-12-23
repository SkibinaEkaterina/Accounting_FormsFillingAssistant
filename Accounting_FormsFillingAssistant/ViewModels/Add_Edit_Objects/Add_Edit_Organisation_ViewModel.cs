using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс ViewModel для добавления/редактирования организации.
    /// </summary>
    public class Add_Edit_Organisation_ViewModel : ViewModel_Base
    {


        public Add_Edit_Organisation_ViewModel(Organisation CorrectedOrganisation,
                                               NavigationService FrameNavigationService,
                                               Action GoToTheHomePage)
        {
            m_AppNavigationSystemAdditional = new Navigation(FrameNavigationService);
            m_CorrectedOrganisation = CorrectedOrganisation; // Если == -1, то добавляется новая организация
            m_GoToTheHomePage = GoToTheHomePage;


            if(CorrectedOrganisation == null)
            {
                HeaderText = "Новая организация";
                OkButtonContent = "Добавить";
                AddNewOrganisation = new RelayCommand(AddNewOrganisation_Execute);
            }
            else
            {
                HeaderText = "Существующая организация";
                OkButtonContent = "Редактировать";

                // Передать информацию о редактируемой организации.
                OrganisationName = CorrectedOrganisation.Org_Name;
                OrganisationAddress = CorrectedOrganisation.Org_Address;
                OrganisationINN = CorrectedOrganisation.Org_INN;
                OrganisationKPP = CorrectedOrganisation.Org_KPP;
                AddNewOrganisation = new RelayCommand(EditExistingOrganisation_Execute);
            }


            

            
            CancelPage = new RelayCommand(CancelPage_Execute);

            DB_ObjectsManipulation_Page Current_DB_ObjectsManipulation_Page = new DB_ObjectsManipulation_Page();
            ViewModel_ShowBanckAccounts CurrentViewModel_ShowBanckAccounts = new ViewModel_ShowBanckAccounts(CorrectedOrganisation,
                                                                                                             m_AppNavigationSystemAdditional, 
                                                                                                             Current_DB_ObjectsManipulation_Page);

            // передать информацию о счетах редактируемой организации.
            if (CorrectedOrganisation != null)
            {
                CurrentViewModel_ShowBanckAccounts.ObjectsList = new ObservableCollection<BankAccount>(CorrectedOrganisation.Org_BankAccounts);
            }

            m_AppNavigationSystemAdditional.AppNavigationService.Navigate(Current_DB_ObjectsManipulation_Page,
               CurrentViewModel_ShowBanckAccounts);

            CollectionOfBankAccounts = CurrentViewModel_ShowBanckAccounts.ObjectsList;
        }


        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppNavigationSystemAdditional;

        /// <summary>
        /// Номер корректируемой организации. Если добавляется новая организация, число < 0.
        /// </summary>
        private Organisation m_CorrectedOrganisation;

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

        /// <summary>
        /// Надпись на кнопке ОК.
        /// </summary>
        private string ms_OkButtonContent;

        readonly ObservableCollection<BankAccount> CollectionOfBankAccounts;

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
                if (value.ToString().All(char.IsDigit))
                {
                    ms_OrganisationINN = value;
                    RaisePropertyChanged("OrganisationINN");
                }
                else
                {
                    MessageBox.Show("Данное поле должно содержать только цифры от 0 до 9");
                }
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
                if (value.ToString().All(char.IsDigit))
                {
                    ms_OrganisationKPP = value;
                    RaisePropertyChanged("OrganisationKPP");
                }
                else
                {
                    MessageBox.Show("Данное поле должно содержать только цифры от 0 до 9");
                }
            }
        }

        public string OkButtonContent
        {
            get { return ms_OkButtonContent; }
            set
            {
                ms_OkButtonContent = value;
                RaisePropertyChanged("OkButtonContent");
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
        /// <summary>
        /// Проверка выполнения всех условий для успешного добавления банка в БД.
        /// </summary>
        /// <returns></returns>
        private bool CheckCorrectFilling()
        {
            // Проверка поля Номер счета Банка
            if (OrganisationINN.Length < 10)
            {
                MessageBox.Show("Поле \"ИНН\" должно содержать не менее 10 цифр.");
                return false;
            }

            if (OrganisationName == null || OrganisationName == "")
            {
                MessageBox.Show("Поле \"Название организации\" не заполнено.");
                return false;
            }

            if (OrganisationKPP.Length != 9)
            {
                MessageBox.Show("Поле \"КПП\" должно содержать 9 цифр.");
                return false;
            }
            

            return true;
        }

        /// <summary>
        /// Метод - добавить новую организацию.
        /// </summary>
        /// <param name="o"></param>
        private void AddNewOrganisation_Execute(object o)
        {

            if (CheckCorrectFilling())
            {
                // Имеем данные для организации и список ее счетов. И то и то надо добавить в базу.

                //CollectionOfBankAccounts

                ObjectsDBManipulations.AddNewOrganisationWithItsBankAccountsToDB(
                                 new Organisation(-1, OrganisationName, OrganisationINN, 
                                                  OrganisationKPP, OrganisationAddress,
                                                  new List<BankAccount>(CollectionOfBankAccounts)));

                m_GoToTheHomePage.Invoke();
            }


            
        }

        private void EditExistingOrganisation_Execute(object o)
        {
            if (CheckCorrectFilling())
            {
                m_CorrectedOrganisation.Org_Name = OrganisationName;
                m_CorrectedOrganisation.Org_Address = OrganisationAddress;
                m_CorrectedOrganisation.Org_INN = OrganisationINN;
                m_CorrectedOrganisation.Org_KPP = OrganisationKPP;

                m_CorrectedOrganisation.Org_BankAccounts = new List<BankAccount>(CollectionOfBankAccounts);

                ObjectsDBManipulations.EditOrganisationWithAllBankAccounts(m_CorrectedOrganisation);
            }
            
        }


        /// <summary>
        /// Метод - закрыть страницу и перейти на домашнюю страницу или списку всех объектов.
        /// </summary>
        /// <param name="o"></param>
        private void CancelPage_Execute(object o)
        {
            CollectionOfBankAccounts.Count();

            m_GoToTheHomePage.Invoke();
        }

        #endregion

    }
}
