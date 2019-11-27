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
    /// 
    /// </summary>
    class RelayCommand : ICommand
    {

        /*
         
            Обязательн должны быть реализваны:

            void Execute(object arg)
            bool CanExecute(object arg)
            event EventHandler CanExecuteChangedэ

            Немного теории:
            All user controls that implement the ICommandSource interface support a 
            Command property that will be invoked when the control’s default action 
            occurs. There are many controls that implement this interface such as Buttons, 
            MenuItems, CheckBoxes, RadioButtons, Hyperlinks, etc.

            Commands are simply objects that implement the ICommand interface. Or, put another way,
            Commands are messages from the View to your View Model. When the control’s 
            default event occurs, such as button click, the Execute method on the command
            is invoked. Commands can also indicate when they are able to execute. This 
            allows the control to enable or disable itself based on whether its command 
            can be executed.

         */


        // самая простейшая реализация

        // Action - это делегат, обобщенный делегат.
        // Инкапсулирует метод, который принимает один параметр и не возвращает значения
        // Данный делегат имеет ряд перегруженных версий. Каждая версия принимает разное
        // число параметров: от Action<in T1> до Action<in T1, in T2,....in T16>.  Таким 
        // образом можно передать до 16 значений в метод.
        // самая простейшая реализация

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

    // Еще реализация класса (если в комманду надо передавать параметр.

    /*
     
     public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute = null;
        private readonly Predicate<object> _canExecute = null;

        #endregion


        #region Constructors

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }
        
        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            if (execute == null)
	        {
                throw new ArgumentNullException("execute");
	        }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion


        #region ICommand Implementation
        
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (parameter is T)
            {
                var typedParameter = (T)parameter;
                _execute(typedParameter);
            }            
        }

        #endregion
    }
     
     
     */

}
