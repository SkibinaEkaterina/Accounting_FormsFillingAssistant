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
    /// <summary>
    /// Класс ViewModel для добавления/редактирования счёта.
    /// </summary>
    class Add_Edit_BankAccount_ViewModel : ViewModel_Base
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="CorrectedBankAccount">Корректируемый счет.</param>
        /// <param name="GoToTheHomePage">Переход на домашнюю страницу (делегат).</param>
        /// <param name="LoadInfoToDataBase">Флаг - загружать ли информацию в БД.</param>
        public Add_Edit_BankAccount_ViewModel(BankAccount CorrectedBankAccount,
                                              Action GoToTheHomePage,
                                              bool LoadInfoToDataBase)
        {
            m_CorrectedBankAccount = CorrectedBankAccount; // Если == -1, то добавляется новый банк.
            m_GoToTheHomePage = GoToTheHomePage;
            mb_LoadInfoToDataBase = LoadInfoToDataBase;

            // Загрузим содержимое комбобоксов.
            CollectionOfAllBanks = new ObservableCollection<Bank>(ObjectsDBManipulations.LoadAllBanksFromDB());

            // Выгрузка организаций не происходит - если создаем новую организацию.
            if (LoadInfoToDataBase)
            {
                CollectonOfAllOrganisations = new ObservableCollection<Organisation>(ObjectsDBManipulations.LoadAllOrganisationsFromDB());
                IsOrganisationsEnabled = true;
            }
            else
            {
                IsOrganisationsEnabled = false;
            }

            if (m_CorrectedBankAccount == null)
            {
                // Создается новый банк.
                HeaderText = "Новый cчет";
                BankAccountNumber = "";
                OkButtonContent = "Добавить";
            }
            else
            {
                HeaderText = "Существующий счет";
                BankAccountNumber = m_CorrectedBankAccount.BankAc_Number;



                OkButtonContent = "Редактировать";
            }

            AddNewBankAccount = new RelayCommand(AddNewBankAccount_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);
        }

        #region Fields

        /// <summary>
        /// Поле с информацией о счёте, с которым работаем на данной странице.
        /// </summary>
        BankAccount m_CorrectedBankAccount; // Если == -1, то добавляется новый банк.

        /// <summary>
        /// Делегат - возврат на указанную страницу.
        /// </summary>
        Action m_GoToTheHomePage;

        /// <summary>
        /// Флаг - загружать ли информацию в базу (зависит от той страницы, с которой произошел вызов данной страницы).
        /// </summary>
        bool mb_LoadInfoToDataBase;

        /// <summary>
        /// Строка заголовка.
        /// </summary>
        string ms_HeaderText;

        /// <summary>
        /// Доступ выбора организации.
        /// </summary>
        private bool _IsOrganisationsEnabled;

        /// <summary>
        /// Надпись на кнопке ОК.
        /// </summary>
        string ms_OkButtonContent;

        /// <summary>
        /// Номер счета
        /// </summary>
        string ms_BankAccountNumber;

        #region Comboboxes info

        /// <summary>
        /// Набор всех организаций, связанный с комбобоксом.
        /// </summary>
        ObservableCollection<Organisation> moc_CollectonOfAllOrganisations;

        /// <summary>
        /// Набор всех банков, связанный с комбобоксом.
        /// </summary>
        ObservableCollection<Bank> moc_CollectionOfAllBanks;

        /// <summary>
        /// Выбранный Банк.
        /// </summary>
        Bank m_SelectedBank;

        /// <summary>
        /// Выбранная организация
        /// </summary>
        Organisation m_SelectedOrganisation;

        #endregion

        ICommand mcmnd_AddNewBankAccount;
        ICommand mcmnd_CancelPage;

        // События нажатия кнопок (нужны для взаимодействия со списком счетов при добавлениие новой организации.
        public event EventHandler AddButtonClicked;
        protected virtual void OnAddButtonClicked(EventArgs e)
        {
            var handler = AddButtonClicked;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler CancelButtonClicked;
        protected virtual void OnCancelButtonClicked(EventArgs e)
        {
            var handler = CancelButtonClicked;
            if (handler != null)
                handler(this, e);
        }


        #endregion



        #region Properties
        /// <summary>
        /// Свойство - надпись в заголовке страницы.
        /// </summary>
        public string HeaderText
        {
            get { return ms_HeaderText; }
            set
            {
                ms_HeaderText = value;
                RaisePropertyChanged("HeaderText");
            }
        }

        public bool IsOrganisationsEnabled // here, underscore typo
        {
            get { return _IsOrganisationsEnabled; }
            set
            {
                _IsOrganisationsEnabled = value; // You miss this line, could be ok to do an equality check here to. :)
                RaisePropertyChanged("IsOrganisationsEnabled"); // 
            }
        }


        /// <summary>
        /// Свойство - номер счета.
        /// </summary>
        public string BankAccountNumber
        {
            get { return ms_BankAccountNumber; }
            set
            {
                if (value.ToString().All(char.IsDigit))
                {
                    ms_BankAccountNumber = value;
                    RaisePropertyChanged("BankAccountNumber");
                }
                else
                {
                    MessageBox.Show("Данное поле должно содержать только цифры от 0 до 9");
                }
            }
        }
        /// <summary>
        /// Свойство - надпись на кнопке ОК.
        /// </summary>
        public string OkButtonContent
        {
            get
            {
                return ms_OkButtonContent;
            }
            set
            {
                ms_OkButtonContent = value;
                RaisePropertyChanged("OkButtonContent");
            }
        }

        #region Comboboxes
        public ObservableCollection<Bank> CollectionOfAllBanks
        {
            get => moc_CollectionOfAllBanks;
            set => moc_CollectionOfAllBanks = value;
        }

        public ObservableCollection<Organisation> CollectonOfAllOrganisations
        {
            get => moc_CollectonOfAllOrganisations;
            set => moc_CollectonOfAllOrganisations = value;
        }


        /// <summary>
        /// Свойство - надпись на кнопке ОК.
        /// </summary>
        public Bank SelectedBank
        {
            get
            {
                return m_SelectedBank;
            }
            set
            {
                m_SelectedBank = value;
                RaisePropertyChanged("SelectedBank");
            }
        }
        /// <summary>
        /// Свойство - надпись на кнопке ОК.
        /// </summary>
        public Organisation SelectedOrganisation
        {
            get
            {
                return m_SelectedOrganisation;
            }
            set
            {
                m_SelectedOrganisation = value;
                RaisePropertyChanged("SelectedOrganisation");
            }
        }
        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// Свойство Комманды - нажата кнопка ОК (добавить/редактировать банк).
        /// </summary>
        public ICommand AddNewBankAccount
        {
            get { return mcmnd_AddNewBankAccount; }
            set
            {
                mcmnd_AddNewBankAccount = value;
                RaisePropertyChanged("AddNewBankAccount");
            }
        }
        /// <summary>
        /// Свойство Комманды - закрыть.
        /// </summary>
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
            if (BankAccountNumber.Length == 0)
            {
                MessageBox.Show("Поле \"Номер счета Банка\" не заполнено.");
                return false;
            }

            if(SelectedBank == null)
            {
                MessageBox.Show("Поле \"Банк\" не заполнено.");
                return false;
            }

            if (SelectedOrganisation == null && mb_LoadInfoToDataBase)
            {
                MessageBox.Show("Поле \"Организация\" не заполнено.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработка нажатия кнопки добавить.
        /// </summary>
        /// <param name="o"></param>
        private void AddNewBankAccount_Execute(object o)
        {

            if (CheckCorrectFilling())
            {
                if (m_CorrectedBankAccount == null) // новый счет.
                {
                    if (mb_LoadInfoToDataBase)  // информация загружается прямо в БД.
                    {
                        m_CorrectedBankAccount = new BankAccount(
                       -1,
                       SelectedOrganisation.Id,
                       SelectedBank.Id,
                       SelectedOrganisation.Org_Name,
                       BankAccountNumber,
                       SelectedBank
                       );
                        ObjectsDBManipulations.AddNewBankAccountToDB(m_CorrectedBankAccount);
                        m_GoToTheHomePage.Invoke();
                    }
                    else
                    { 
                        // данный код вызовется во время добавления/редактироания новой организации.
                        m_CorrectedBankAccount = new BankAccount(
                          -1,
                          -1,
                          SelectedBank.Id,
                          null,
                          BankAccountNumber,
                          SelectedBank
                          );

                        OnAddButtonClicked(null);
                    }


                }
                else
                {
                    

                    if (mb_LoadInfoToDataBase)
                    {

                        // Реализация в будущих версиях.
                        m_GoToTheHomePage.Invoke();
                    }
                    else
                    {

                        m_CorrectedBankAccount = new BankAccount(
                        0,
                        0,
                        SelectedBank.Id,
                        null,
                        BankAccountNumber,
                        SelectedBank
                        );

                        OnAddButtonClicked(null);
                    }
                }
            }
        }

        /// <summary>
        /// Метод вернет объект Счёта, с которым работали при вызове данной страницы.
        /// </summary>
        /// <returns></returns>
        public BankAccount GetBankAccountUnderConsideration()
        {
            return m_CorrectedBankAccount;
        }

        /// <summary>
        /// Метод - закрыть страницу и перейти на домашнюю страницу или списку всех объектов.
        /// </summary>
        /// <param name="o"></param>
        private void CancelPage_Execute(object o)
        {
            m_CorrectedBankAccount = null;
            

            if (mb_LoadInfoToDataBase)
            {
                m_GoToTheHomePage.Invoke();
            }
            else
            {
                OnCancelButtonClicked(null);
            }

        }


        #endregion


    }
}
