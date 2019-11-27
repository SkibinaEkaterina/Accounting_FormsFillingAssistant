using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    class ViewModel_Home : ViewModel_Base
    {
        // Поле
        private ICommand _RaiseMessageBox;

        // Свойство
        public ICommand RaiseMessageBox
        {
            get
            {
                return _RaiseMessageBox;
            }
            set
            {
                //_RaiseMessageBox = value;

                _RaiseMessageBox = value;
                // повещаем о том, что изменилось свойство.
                RaisePropertyChanged("RaiseMessageBox");
            }
        }

        public ViewModel_Home()
        {
            RaiseMessageBox = new RelayCommand(SomeAction);
        }

        public void SomeAction(object prm)
        {
            MessageBox.Show("Hello world!");
        }
    }
}
