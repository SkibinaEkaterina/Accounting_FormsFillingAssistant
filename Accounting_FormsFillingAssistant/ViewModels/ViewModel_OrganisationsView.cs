using System;
using System.Collections.Generic;
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

    

    


    public class MyExaple
    {


        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public MyExaple()
        {
        
        }

        public MyExaple(string s1, string s2)
        {
            field1 = s1;
            field2 = s2;
        }
    }


    class ViewModel_OrganisationsView : ViewModel_Base
    {

        List<MyExaple> m_lOrganisations = new List<MyExaple>();
        MyExaple m_SelectedObject;
        private ICommand mcmnd_DeleteButtonClicked;



        public ViewModel_OrganisationsView()
        {
           
            m_lOrganisations.Add(new MyExaple() { field1 = "org 1", field2 ="sdjfvkjsfvlnev", field3 ="1"});
            m_lOrganisations.Add(new MyExaple() { field1 = "org 2", field2 = "stbeetk;o jerngkn", field3 = "2" });


            DeleteButtonClicked = new RelayCommand(DeleteButtonClicked_Execute);

           
        }
        public List<MyExaple> OrganisationsList
        {
            get { return m_lOrganisations; }
        }

        public MyExaple SelectedObject
        {
            get { return m_SelectedObject; }
            set { m_SelectedObject = value;
                RaisePropertyChanged("SelectedObject");
            }
        }

        public ICommand DeleteButtonClicked
        {
            get { return mcmnd_DeleteButtonClicked; }
            set
            {
                mcmnd_DeleteButtonClicked = value;
                RaisePropertyChanged("DeleteButtonClicked");
            }
        }




        private void DeleteButtonClicked_Execute(object o)
        {
            string id = null;
            if (m_SelectedObject != null)
            {
                id = m_SelectedObject.field3;
            }
                
        }




    }
}
