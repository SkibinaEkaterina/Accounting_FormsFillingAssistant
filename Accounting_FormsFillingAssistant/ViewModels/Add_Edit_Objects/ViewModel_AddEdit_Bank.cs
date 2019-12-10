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
        public ViewModel_AddEdit_Bank(int idOfCorrectedBank,
                                      Action GoToTheHomePage)
        {
          
            mi_idOfCorrectedBank = idOfCorrectedBank; // Если == -1, то добавляется новый банк.
            m_GoToTheHomePage = GoToTheHomePage;

            if(mi_idOfCorrectedBank < 0)
            {
                // Создается новый банк.
                HeaderText = "Новый банк";
            }


            AddNewBank = new RelayCommand(AddNewBank_Execute);
            CancelPage = new RelayCommand(CancelPage_Execute);

        }

        #region Fields

        /// <summary>
        /// Номер корректируемой организации. Если добавляется новая организация, число < 0.
        /// </summary>
        private int mi_idOfCorrectedBank;

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

        // Команды.
        private ICommand mcmnd_AddNewBank;
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
                ms_BankAccount = value;
                RaisePropertyChanged("BankAccount");
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
                ms_BankBIK = value;
                RaisePropertyChanged("BankBIK");
            }
        }

        public ICommand AddNewBank
        {
            get { return mcmnd_AddNewBank; }
            set
            {
                mcmnd_AddNewBank = value;
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


                m_GoToTheHomePage.Invoke();
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
