using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{

    class ViewModel_ShowBanckAccounts : ViewModel_Base
    {
        
        public ViewModel_ShowBanckAccounts()
        {
            // все манипуляции происходят исключительно в программе. 
            // Выгрузка счетов с банками будет производиться только при сохранении организации.
        }

        #region Fields

        /// <summary>
        /// Список всех банковских счетов организации, который будет выведен в DataGrid и который далее будет сохранен в БД.
        /// </summary>
        ObservableCollection<BankAccount> ml_ObjectsList = new ObservableCollection<BankAccount>();

        /// <summary>
        /// Выбранная организация - соответствует выделенной строке в DataGrid.
        /// </summary>
        BankAccount m_SelectedObject;


        private ICommand mcmnd_DeleteButtonClicked;
        private ICommand mcmnd_AddObjectButtonClicked;
        private ICommand mcmnd_EditObjectButtonClicked;

        #endregion





        #region Properties
        public ObservableCollection<BankAccount> ObjectsList
        {
            get { return ml_ObjectsList; }
        }

        public BankAccount SelectedObject
        {
            get { return m_SelectedObject; }
            set
            {
                m_SelectedObject = value;
                RaisePropertyChanged("SelectedObject");
            }
        }

        public ICommand DeleteObjectButtonClicked
        {
            get { return mcmnd_DeleteButtonClicked; }
            set
            {
                mcmnd_DeleteButtonClicked = value;
                RaisePropertyChanged("DeleteObjectButtonClicked");
            }
        }
        public ICommand AddObjectButtonClicked
        {
            get { return mcmnd_AddObjectButtonClicked; }
            set
            {
                mcmnd_AddObjectButtonClicked = value;
                RaisePropertyChanged("AddObjectButtonClicked");
            }
        }
        public ICommand EditObjectButtonClicked
        {
            get { return mcmnd_EditObjectButtonClicked; }
            set
            {
                mcmnd_EditObjectButtonClicked = value;
                RaisePropertyChanged("EditObjectButtonClicked");
            }
        }



        #endregion

        #region Methids


        private void DeleteButtonClicked_Execute(object o)
        {
            
        }

        private void AddObjectButtonClicked_Execute(object o)
        {
            // Откроется окно добавления и изменения будут внесены в саму базу. 
            // После завершения добавления мы вернемся на страниццу со всеми объектами.

        }
        private void EditObjectButtonClicked_Execute(object o)
        {


        }

        #endregion



    }
}
