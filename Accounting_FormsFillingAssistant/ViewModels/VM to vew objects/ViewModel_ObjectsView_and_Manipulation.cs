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
        public ViewModel_ObjectsView_and_Manipulation()
        {
            AddObjectButtonClicked = new RelayCommand(AddObjectButtonClicked_Execute);
            EditObjectButtonClicked = new RelayCommand(EditObjectButtonClicked_Execute);
            DeleteObjectButtonClicked = new RelayCommand(DeleteButtonClicked_Execute);




            CurrentType = typeof(T).Name;

            // Выгрузка необходимых строк из базы
            LoadObjects();



            //// Пример
            //ObjectsList.Add(new Organisation(1, 
            //                                "Organisation 1",
            //                                "КПП",
            //                                "ИНН",
            //                                "ООО",
            //                                "Москва",
            //                                "ул. Пупкина д.3",
            //                                "+123456789",
            //                                new List<BankAccount>()) );


            //ObjectsList.Add(new Organisation() { field1 = "org 2", field2 = "stbeetk;o jerngkn", field3 = "2" });

        }


       private void LoadObjects()
        {
            
            ObjectsList = new ObservableCollection<T>();

            switch (CurrentType)
            {
                case "Organisation":
                    {



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

        #region Methids


        private void DeleteButtonClicked_Execute(object o)
        {
            // Удаление объектов происходит непосредственно в базе.
            // после удаления страница перегрузится

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
