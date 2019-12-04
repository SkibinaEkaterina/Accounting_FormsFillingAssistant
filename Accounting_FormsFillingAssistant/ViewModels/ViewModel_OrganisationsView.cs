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

    

    


    //public class MyExaple
    //{

    //    [DisplayName("Column Name")]
    //    public string field1 { get; set; }

    //    [DisplayName("Column Name 2")]
    //    public string field2 { get; set; }

    //    [DisplayName("Column Name 3")]
    //    public string field3 { get; set; }
    //    public MyExaple()
    //    {
        
    //    }

    //    public MyExaple(string s1, string s2, string s3)
    //    {
    //        field1 = s1;
    //        field2 = s2;
    //        field3 = s3;
    //    }
    //}


    class ViewModel_OrganisationsView : ViewModel_Base
    {


        #region Fields



        /// <summary>
        /// Список всех организаций, который будет выведен в DataGrid.
        /// </summary>
        ObservableCollection<Organisation> ml_ObjectsList = new ObservableCollection<Organisation>();

        /// <summary>
        /// Выбранная организация - соответствует выделенной строке в DataGrid.
        /// </summary>
        Organisation m_SelectedObject;


        private ICommand mcmnd_DeleteButtonClicked;
        private ICommand mcmnd_AddObjectButtonClicked;
        private ICommand mcmnd_EditObjectButtonClicked;

        #endregion




        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewModel_OrganisationsView()
        {
            AddObjectButtonClicked = new RelayCommand(AddObjectButtonClicked_Execute);
            EditObjectButtonClicked = new RelayCommand(EditObjectButtonClicked_Execute);
            DeleteObjectButtonClicked = new RelayCommand(DeleteButtonClicked_Execute);



            // Пример
            ObjectsList.Add(new Organisation(1, 
                                            "Organisation 1",
                                            "КПП",
                                            "ИНН",
                                            "ООО",
                                            "Москва",
                                            "ул. Пупкина д.3",
                                            "+123456789",
                                            new List<BankAccount>()) );


            //ObjectsList.Add(new Organisation() { field1 = "org 2", field2 = "stbeetk;o jerngkn", field3 = "2" });

        }


        //#region Headers properties
        //public string Header_2
        //{
        //    get
        //    {
        //        return ms_Header_2;
        //    }
        //    set
        //    {
        //        ms_Header_2 = value;
        //        RaisePropertyChanged("Header_2");
        //    }
        //}

        //public string Header_3
        //{
        //    get
        //    {
        //        return ms_Header_3;
        //    }
        //    set
        //    {
        //        ms_Header_3 = value;
        //        RaisePropertyChanged("Header_3");
        //    }
        //}

        //public string Header_4
        //{
        //    get
        //    {
        //        return ms_Header_4;
        //    }
        //    set
        //    {
        //        ms_Header_4 = value;
        //        RaisePropertyChanged("Header_4");
        //    }
        //}

        //public string Header_5
        //{
        //    get
        //    {
        //        return ms_Header_5;
        //    }
        //    set
        //    {
        //        ms_Header_5 = value;
        //        RaisePropertyChanged("Header_5");
        //    }
        //}

        //private string Column5_Width
        //{
        //    get { return mi_Column5_Width; }
        //    set
        //    {
        //        mi_Column5_Width = value;
        //        RaisePropertyChanged("Column5_Width");
        //    }
        //}

        //#endregion


        #region Other Properties
        public ObservableCollection<Organisation> ObjectsList
        {
            get { return ml_ObjectsList; }
        }

        public Organisation SelectedObject
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

        


        private void DeleteButtonClicked_Execute(object o)
        {
            int id = -1;
            if (m_SelectedObject != null)
            {
                id = m_SelectedObject.Org_id;
            }

        }

        private void AddObjectButtonClicked_Execute(object o)
        {
         

        }
        private void EditObjectButtonClicked_Execute(object o)
        {
            

        }

        #endregion


    }
}
