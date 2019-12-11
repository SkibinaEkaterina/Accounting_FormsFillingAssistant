using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class ViewModel_AddEdit_Bank : ViewModel_Base
    {
        /// <summary>
        ///  Конструктор
        /// </summary>
        public ViewModel_AddEdit_Bank(Bank CorrectedBank,
                                      Action GoToTheHomePage)
        { 
            m_CorrectedBank = CorrectedBank; // Если == -1, то добавляется новый банк.
            m_GoToTheHomePage = GoToTheHomePage;

            if(m_CorrectedBank == null)
            {
                // Создается новый банк.
                HeaderText = "Новый банк";

                BankAccount = "";
                BankBIK = "";

                OkButtonContent = "Добавить";
            }
            else
            {
                HeaderText = "Существующий банк";

                BankName = m_CorrectedBank.Bank_Name;
                BankAddress = m_CorrectedBank.Bank_City;
                BankAccount = m_CorrectedBank.Bank_OwnBankAccount;
                BankBIK = m_CorrectedBank.Bank_BIK;

                OkButtonContent = "Редактировать";
            }

            AddNewBank = new RelayCommand(AddNewBank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);
        }

        #region Fields

        /// <summary>
        /// Номер корректируемой организации. Если добавляется новая организация, число < 0.
        /// </summary>
        private Bank m_CorrectedBank;

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
        private string ms_BankName;

        /// <summary>
        /// Адрес организации.
        /// </summary>
        private string ms_BankAddress;

        /// <summary>
        /// ИНН организации.
        /// </summary>
        private string ms_BankAccount;

        /// <summary>
        /// КПП организации.
        /// </summary>
        private string ms_BankBIK;

        /// <summary>
        /// Надпись на кнопке ОК.
        /// </summary>
        private string ms_OkButtonContent;

        // Команды.
        private ICommand mcmnd_AddNewBank;
        private ICommand mcmnd_CancelPage;
        #endregion




        #region Properties

        #region Inscriptions
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
        /// Свойство для названия банка.
        /// </summary>
        public string BankName
        {
            get
            {
                return ms_BankName;
            }
            set
            {
                ms_BankName = value;
                RaisePropertyChanged("BankName");
            }
        }

        /// <summary>
        /// Свойство для города банка.
        /// </summary>
        public string BankAddress
        {
            get
            {
                return ms_BankAddress;
            }
            set
            {
                ms_BankAddress = value;
                RaisePropertyChanged("BankAddress");
            }
        }

        /// <summary>
        /// Свойство для счета банка.
        /// </summary>
        public string BankAccount
        {
            get
            {
                return ms_BankAccount;
            }
            set
            {
                

                if (value.ToString().All(char.IsDigit))
                {
                    ms_BankAccount = value;
                    RaisePropertyChanged("BankAccount");
                }
                else
                {
                    MessageBox.Show("Данное поле должно содержать только цифры от 0 до 9");
                    //BankAccount = ms_BankAccount;
                }
            }
        }

        /// <summary>
        /// Свойство для БИК банка.
        /// </summary>
        public string BankBIK
        {
            get
            {
                return ms_BankBIK;
            }
            set
            {
                if (value.ToString().All(char.IsDigit))
                {
                    ms_BankBIK = value;
                    RaisePropertyChanged("BankBIK");
                }
                else
                {
                    MessageBox.Show("Данное поле должно содержать только цифры от 0 до 9");
                    //BankAccount = ms_BankAccount;
                }


            }
        }


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

        #endregion

        #region Commands

        /// <summary>
        /// Свойство Комманды - нажата кнопка ОК (добавить/редактировать банк).
        /// </summary>
        public ICommand AddNewBank
        {
            get { return mcmnd_AddNewBank; }
            set
            {
                mcmnd_AddNewBank = value;
                RaisePropertyChanged("AddNewOrganisation");
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

        #endregion



        #region Methods


        /// <summary>
        /// Проверка выполнения всех условий для успешного добавления банка в БД.
        /// </summary>
        /// <returns></returns>
        private bool CheckCorrectFilling()
        {
            // Проверка поля Название
            if (BankName.Length == 0)
            {
                MessageBox.Show("Поле \"Название банка\" не заполнено.");
                return false;
            }

            // Проверка поля Номер счета Банка
            if (BankAccount.Length == 0)
            {
                MessageBox.Show("Поле \"Номер счета Банка\" не заполнено.");
                return false;
            }


            // Проверка поля БИК.
            if (BankBIK.Length != 9)
            {
                if (BankBIK.Length == 0)
                {
                    MessageBox.Show("Поле \"БИК\" не заполнено.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Поле \"БИК\" должно содержать 9 символов.");
                    return false;
                }
            }

            


            return true;
        }
        private void AddNewBank_Execute(object o)
        {

            if (CheckCorrectFilling())
            {


                

                // Добавить банк в БД.
                if (m_CorrectedBank == null)
                {
                    // Создать объект банк.
                    Bank BunkUnderConsideration = new Bank(-1,
                                                           BankName,
                                                           BankAddress,
                                                           BankBIK,
                                                           BankAccount);

                    ObjectsDBManipulations.AddNewBankToDB(BunkUnderConsideration);
                }
                else
                {
                    m_CorrectedBank.Bank_Name           = BankName;
                    m_CorrectedBank.Bank_City           = BankAddress;
                    m_CorrectedBank.Bank_BIK            = BankBIK;
                    m_CorrectedBank.Bank_OwnBankAccount = BankAccount;

                    ObjectsDBManipulations.EditBankInDB(m_CorrectedBank);
                }
                    

                m_GoToTheHomePage.Invoke();
            }


            
        }


        private void BankAccountTextChanged_Execute(object o)
        {
            
            if (BankAccount.ToString().All(char.IsDigit))
            {

            }
            else
            {
                BankAccount = ms_BankAccount;

            }
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
