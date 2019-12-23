using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Рабочая директория.
        /// </summary>
        private string ms_html;
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

        /// <summary>
        /// Рабочая директория.
        /// </summary>
        public string HtmlString
        {
            get => ms_html;
            set
            {
                ms_html = value;
                RaisePropertyChanged("HtmlString");
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

            HtmlString = Properties.Resources.UserGuide2.ToString();
        }


        public static string GetEmbeddedResource()
        {
            Assembly _assembly;

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                using (Stream resourceStream = _assembly.GetManifestResourceStream("Accounting_FormsFillingAssistant.UserGuid.htm"))
                {
                    if (resourceStream == null)
                        return null;

                    using (StreamReader reader = new StreamReader(resourceStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error accessing resources!");
            }
            return null;
            
        }
     

    }
}
