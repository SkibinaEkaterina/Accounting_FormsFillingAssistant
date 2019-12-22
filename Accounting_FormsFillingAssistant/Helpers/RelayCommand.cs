using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Вспомогательный класс - реализация интерфейса ICommand, необходимая для
    /// создания объектов-комманд.
    /// </summary>
    class RelayCommand : ICommand
    {

        /*
         
            Обязательн должны быть реализваны:

            void Execute(object arg)
            bool CanExecute(object arg)
            event EventHandler CanExecuteChangedэ


         */


    

        private readonly Action<object> _executeAction;

        public RelayCommand(Action<object> executeAction)
        {
            // где executeAction - это метод
            _executeAction = executeAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;


    }
}
