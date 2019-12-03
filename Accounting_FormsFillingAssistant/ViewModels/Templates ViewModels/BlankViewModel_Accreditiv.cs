using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class BlankViewModel_Accreditiv : ViewModel_Base
    {
        
        

        private Action m_GoToTheHomePage;

        public BlankViewModel_Accreditiv(Action GoToTheHomePage)
        {

            Sum_Rubles = "0";
            Sum_Kopeyki = "0";

            m_GoToTheHomePage = GoToTheHomePage;
            OkButtonClick = new RelayCommand(OkButtonClick_Execute);

            

        }

        public BlankViewModel_Accreditiv()
        {
        }




        #region Blank fields

        string ms_Sum_Rubles;
        string ms_Sum_Kopeyki;


        public string Sum_Rubles
        {
            get { return ms_Sum_Rubles; }
            set { 



                ms_Sum_Rubles = value;
                
                RaisePropertyChanged("Sum_Rubles");
            }
        }
        
        public string Sum_Kopeyki
        {
            get { return ms_Sum_Kopeyki; }
            set
            {
                ms_Sum_Kopeyki = value;
                RaisePropertyChanged("Sum_Kopeyki");
            }
        }

        #endregion


        #region Commands
        // Обработка нажатия кнопок

        private ICommand mcmnd_OkButtonClick;
        public ICommand OkButtonClick
        {
            get { return mcmnd_OkButtonClick; }
            set
            {
                mcmnd_OkButtonClick = value;
                RaisePropertyChanged("OkButtonClick");
            }
        }

        

        #endregion


        #region Methods
        // Методы
        /// <summary>
        /// Действие на нажатие кнопки завершения работы с бланком (Сохранить).
        /// </summary>
        /// <param name="o"></param>
        public void OkButtonClick_Execute(object o)
        {
            //MessageBox.Show(ConvertSumToTextRepresentation(Sum_Rubles, Sum_Kopeyki));
        }



        


        #endregion




       
    }
}
