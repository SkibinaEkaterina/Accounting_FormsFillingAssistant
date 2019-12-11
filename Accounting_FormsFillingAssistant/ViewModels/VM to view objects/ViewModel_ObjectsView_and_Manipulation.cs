using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Accounting_FormsFillingAssistant
{

    class ViewModel_ObjectsView_and_Manipulation<T> : ViewModel_Base
    {


        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppParentNavigationSystem;

        /// <summary>
        /// Список всех организаций, который будет выведен в DataGrid.
        /// </summary>
        ObservableCollection<T> ml_ObjectsList = new ObservableCollection<T>();

        /// <summary>
        /// Выбранная организация - соответствует выделенной строке в DataGrid.
        /// </summary>
        T m_SelectedObject;

        string CurrentType;

        private ICommand mcmnd_DeleteButtonClicked;
        private ICommand mcmnd_AddObjectButtonClicked;
        private ICommand mcmnd_EditObjectButtonClicked;

        #endregion


        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewModel_ObjectsView_and_Manipulation(Navigation ParentNavigator)
        {

            m_AppParentNavigationSystem = ParentNavigator;

            AddObjectButtonClicked = new RelayCommand(AddObjectButtonClicked_Execute);
            EditObjectButtonClicked = new RelayCommand(EditObjectButtonClicked_Execute);
            DeleteObjectButtonClicked = new RelayCommand(DeleteButtonClicked_Execute);


            CurrentType = typeof(T).Name;

            // Выгрузка необходимых строк из базы
            LoadObjects();


        }


       private void LoadObjects()
        {
            
            ObjectsList = new ObservableCollection<T>();

            switch (CurrentType)
            {
                case "Organisation":
                    {

                        foreach (Organisation org in ObjectsDBManipulations.LoadAllOrganisationsFromDB())
                        {
                            ObjectsList.Add((T)Convert.ChangeType(org, typeof(T)));
                        }

                        break;

                        
                    }
                case "Bank":
                    {
                        foreach (Bank b in ObjectsDBManipulations.LoadAllBanksFromDB())
                        {
                            ObjectsList.Add((T)Convert.ChangeType(b, typeof(T)));
                        }

                        break;
                    }
                case "BankAccount":
                    {
                        foreach (BankAccount ba in ObjectsDBManipulations.LoadAllBankAccountsFromDB())
                        {
                            ObjectsList.Add((T)Convert.ChangeType(ba, typeof(T)));
                        }

                        break;
                    }
                default:
                    break;
            }
        }


        #region Properties
        public ObservableCollection<T> ObjectsList
        {
            get { return ml_ObjectsList; }
            set { 
                    ml_ObjectsList = value;
                    RaisePropertyChanged("ObjectsList");
                }
        }

        public T SelectedObject
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

        #region Methods

        /// <summary>
        /// Обработка нажатия кнопки - добавить объект.
        /// </summary>
        /// <param name="o"></param>
        private void AddObjectButtonClicked_Execute(object o)
        {
            // Откроется окно добавления и изменения будут внесены в саму базу. 
            // После завершения добавления мы вернемся на страниццу со всеми объектами.
            switch (CurrentType)
            {
                case "Organisation":
                    {

                        break;
                    }
                case "Bank":
                    {

                        m_AppParentNavigationSystem.AppNavigationService.Navigate(new Add_Edit_Bank_Page(),
                                                                new ViewModel_AddEdit_Bank(null, () => BackToTheCurrentPage_Execute(null)));

                        break;
                    }
                default:
                    break;
            }
        }


        /// <summary>
        /// Обработка нажатия кнопки - удалить объект.
        /// </summary>
        /// <param name="o"></param>
        private void DeleteButtonClicked_Execute(object o)
        {
            // Удаление объектов происходит непосредственно в базе.
            // после удаления страница перегрузится
            if(m_SelectedObject != null)
            {
                switch (CurrentType)
                {
                    case "Organisation":
                        {

                            break;
                        }
                    case "Bank":
                        {
                            ObjectsDBManipulations.RemoveBankFromDB(m_SelectedObject as Bank);
                            break;
                        }
                    default:
                        break;
                }

                LoadObjects();
            }
            
        }

        
        /// <summary>
        /// Обработка нажатия кнопки - редактировать объект.
        /// </summary>
        /// <param name="o"></param>
        private void EditObjectButtonClicked_Execute(object o)
        {
            if(m_SelectedObject != null)
            {
                switch (CurrentType)
                {
                    case "Organisation":
                        {

                            break;
                        }
                    case "Bank":
                        {
                            m_AppParentNavigationSystem.AppNavigationService.Navigate(new Add_Edit_Bank_Page(),
                                                                  new ViewModel_AddEdit_Bank(m_SelectedObject as Bank, () => BackToTheCurrentPage_Execute(null)));


                            break;
                        }
                    default:
                        break;
                }
            }
            

        }

        private void BackToTheCurrentPage_Execute(object o)
        {
            m_AppParentNavigationSystem.AppNavigationService.Navigate(new DB_ObjectsManipulation_Page(),
                                                                new ViewModel_ObjectsView_and_Manipulation<T>(m_AppParentNavigationSystem));

        }

        #endregion

    }
}
