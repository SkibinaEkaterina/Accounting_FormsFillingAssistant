﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class ViewModel_ShowBanckAccounts : ViewModel_Base
    {
        #region Fields

        /// <summary>
        /// сервис навигации между страницами.
        /// </summary>
        private Navigation m_AppParentNavigationSystem;

        /// <summary>
        /// Список всех организаций, который будет выведен в DataGrid.
        /// </summary>
        ObservableCollection<BankAccount> m_CollectionOfBankAccounts= new ObservableCollection<BankAccount>();

        /// <summary>
        /// Выбранная организация - соответствует выделенной строке в DataGrid.
        /// </summary>
        BankAccount m_SelectedObject;

        /// <summary>
        /// Доступность нажатия кнопки - редактирвоать.
        /// </summary>
        private System.Windows.Visibility _EditButtonEnabled;

        Organisation m_CorrectedOrganisation;

        private ICommand mcmnd_DeleteButtonClicked;
        private ICommand mcmnd_AddObjectButtonClicked;
        private ICommand mcmnd_EditObjectButtonClicked;


        
        Add_Edit_BankAccount_ViewModel New_Add_Edit_BankAccount_ViewModel;

       
        #endregion


        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewModel_ShowBanckAccounts( Organisation CorrectedOrganisation, Navigation ParentNavigator, Page Current_DB_ObjectsManipulation_Page)
        {

            m_AppParentNavigationSystem = ParentNavigator;
            m_CorrectedOrganisation = CorrectedOrganisation;


            AddObjectButtonClicked = new RelayCommand(AddObjectButtonClicked_Execute);
            EditObjectButtonClicked = null;//new RelayCommand(EditObjectButtonClicked_Execute);
            DeleteObjectButtonClicked = new RelayCommand(DeleteButtonClicked_Execute);

            IsEditButtonEnabled = System.Windows.Visibility.Hidden;


            //CurrentType = typeof(T).Name;

            //if (CurrentType == "BankAccount")
            //{
            
            //}


            //// Выгрузка необходимых строк из базы
            //LoadObjects();

        }



        public void LoadObjects()
        {

            ObjectsList = new ObservableCollection<BankAccount>();
            foreach (BankAccount ba in ObjectsDBManipulations.LoadAllBankAccountsFromDB())
            {
                ObjectsList.Add(ba);
            }
        }


        #region Properties
        public ObservableCollection<BankAccount> ObjectsList
        {
            get { return m_CollectionOfBankAccounts; }
            set
            {
                m_CollectionOfBankAccounts = value;
                RaisePropertyChanged("ObjectsList");
            }
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

        public System.Windows.Visibility IsEditButtonEnabled // here, underscore typo
        {
            get { return _EditButtonEnabled; }
            set
            {
                _EditButtonEnabled = value; // You miss this line, could be ok to do an equality check here to. :)
                RaisePropertyChanged("IsEditButtonEnabled"); // 
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
            //// Откроется окно добавления и изменения будут внесены в саму базу. 
            //// После завершения добавления мы вернемся на страниццу со всеми объектами.

            //NewBankAccount = new BankAccount(-1,);

            New_Add_Edit_BankAccount_ViewModel = new Add_Edit_BankAccount_ViewModel( null,
                                                    null,
                                                    false);

            // событие - нажатие кнопки Добавить.
            New_Add_Edit_BankAccount_ViewModel.AddButtonClicked += ChildPage_OkButtonClicked;
            New_Add_Edit_BankAccount_ViewModel.CancelButtonClicked += ChildPage_CancelButtonClicked;

            m_AppParentNavigationSystem.AppNavigationService.Navigate(new AddEditBankAccount_Page(),
                                                    New_Add_Edit_BankAccount_ViewModel);


        }

        private void ChildPage_OkButtonClicked(object sender, EventArgs e)
        {
            // добавить новый объект и снавигировать обратно.

            if(New_Add_Edit_BankAccount_ViewModel != null)
            {
                BankAccount NewBankAccount = 
                New_Add_Edit_BankAccount_ViewModel.GetBankAccountUnderConsideration();

                if(NewBankAccount != null)
                {
                    if(m_CorrectedOrganisation != null)
                    {
                        NewBankAccount.BankAc_Org_ID = m_CorrectedOrganisation.Id;
                        NewBankAccount.BankAc_Org_Name = m_CorrectedOrganisation.Org_Name;
                    }
                    
                    ObjectsList.Add(NewBankAccount);
                }
            }
            
            Page page = Application.LoadComponent(new Uri(@"\Accounting_FormsFillingAssistant;Component\Pages\Add or Edit objects\DB_ObjectsManipulation_Page.xaml", UriKind.RelativeOrAbsolute)) as Page;
            m_AppParentNavigationSystem.AppNavigationService.Navigate(page, this);

        }

        private void ChildPage_CancelButtonClicked(object sender, EventArgs e)
        {
            Page page = Application.LoadComponent(new Uri(@"\Accounting_FormsFillingAssistant;Component\Pages\Add or Edit objects\DB_ObjectsManipulation_Page.xaml", UriKind.RelativeOrAbsolute)) as Page;
            page.DataContext = this;
            m_AppParentNavigationSystem.AppNavigationService.Navigate(page, this);
        }

        /// <summary>
        /// Обработка нажатия кнопки - удалить объект.
        /// </summary>
        /// <param name="o"></param>
        private void DeleteButtonClicked_Execute(object o)
        {
            ObjectsList.Remove(SelectedObject);
        }

        #endregion
    }
}