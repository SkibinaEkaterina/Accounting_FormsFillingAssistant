using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Базовый класс для всех ViewModel - наследуется от INotifyPropertyChanged,
    /// интерфейс, который уведомляет "клиентов" об изменении значения свойства.
    /// В частности, этот клиент - кнопка.
    /// </summary>
    public class ViewModel_Base : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return;
            }

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
