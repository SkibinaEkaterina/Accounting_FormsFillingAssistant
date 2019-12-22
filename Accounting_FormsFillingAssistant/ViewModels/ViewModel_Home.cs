using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс  ViewModel домашней страницы.
    /// </summary>
    class ViewModel_Home : ViewModel_Base
    {
        #region Fields
        /// <summary>
        /// Рабочая директория.
        /// </summary>
        private string ms_WorkingDirectoryPath;
        /// <summary>
        /// Текущая дата.
        /// </summary>
        private string ms_CurrentDate;
        #endregion

        #region Properties
        /// <summary>
        /// Свойство - Рабочая директория.
        /// </summary>
        public string WorkingDirectoryPath
        {
            get => ms_WorkingDirectoryPath;
            set
            {
                ms_WorkingDirectoryPath = value;
                RaisePropertyChanged("WorkingDirectoryPath");
            }
        }
        /// <summary>
        /// Свойство - Текущая дата.
        /// </summary>
        public string CurrentDate
        {
            get => ms_CurrentDate;
            set
            {
                ms_CurrentDate = value;
                RaisePropertyChanged("CurrentDate");
            }
        }
        #endregion



        /// <summary>
        /// Конструткор.
        /// </summary>
        public ViewModel_Home()
        {
            CurrentDate = DateTime.Now.ToString("DD-mm-yyyy");
            WorkingDirectoryPath = Properties.Settings.Default.PathToWorkingDirectory;

        }

       
    }
}
