using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс ViewModel для страницы настроек.
    /// </summary>
    public class ViewModel_SettingsWindow : ViewModel_Base
    {

        #region Fields

        /// <summary>
        /// Путь к рабочей директории.
        /// </summary>
        private string ms_PathToWorkingDirectory;
        /// <summary>
        /// Путь к БД.
        /// </summary>
        private string ms_PathToDataBase;
        /// <summary>
        /// Команда - нажатие кнопки выбора рабочей директории.
        /// </summary>
        private ICommand mcmnd_ChooseWorkingDirectory;
        /// <summary>
        /// Команда - нажатие кнопки выбора БД.
        /// </summary>
        private ICommand mcmnd_ChooseDBPath;
        /// <summary>
        /// Команда - нажатие кнопки ОК.
        /// </summary>
        private ICommand mcmnd_OkClicked;
        /// <summary>
        /// Свойство. Команда - нажатие кнопки Закрыть.
        /// </summary>
        private ICommand mcmnd_CancelClicked;
        /// <summary>
        /// Делегат - вернуться на домашнюю страницу.
        /// </summary>
        private Action m_GoToTheHomePage;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство - Путь к рабочей директории.
        /// </summary>
        public string PathToWorkingDirectory
        {
            get { return ms_PathToWorkingDirectory; }
            set
            {
                ms_PathToWorkingDirectory = value;
                RaisePropertyChanged("PathToWorkingDirectory");
            }
        }
        /// <summary>
        /// Свойство - Путь к БД.
        /// </summary>
        public string PathToDataBase
        {
            get { return ms_PathToDataBase; }
            set
            {
                ms_PathToDataBase = value;
                RaisePropertyChanged("PathToDataBase");
            }
        }
        /// <summary>
        /// Свойство. Команда - нажатие кнопки выбора рабочей директории.
        /// </summary>
        public ICommand ChooseWorkingDirectory
        {
            get { return mcmnd_ChooseWorkingDirectory; }
            set
            {
                mcmnd_ChooseWorkingDirectory = value;
                RaisePropertyChanged("ChooseWorkingDirectory");
            }
        }
        /// <summary>
        /// Свойство. Команда - нажатие кнопки выбора БД.
        /// </summary>
        public ICommand ChooseDBPath
        {
            get { return mcmnd_ChooseDBPath; }
            set
            {
                mcmnd_ChooseDBPath = value;
                RaisePropertyChanged("ChooseDBPath");
            }
        }
        /// <summary>
        /// Свойство. Команда - нажатие кнопки ОК.
        /// </summary>
        public ICommand OkClicked
        {
            get { return mcmnd_OkClicked; }
            set
            {
                mcmnd_OkClicked = value;
                RaisePropertyChanged("OkClicked");
            }
        }
        /// <summary>
        /// Свойство. Команда - нажатие кнопки Закрыть.
        /// </summary>
        public ICommand CancelClicked
        {
            get { return mcmnd_CancelClicked; }
            set
            {
                mcmnd_CancelClicked = value;
                RaisePropertyChanged("CancelClicked");
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="GoToTheHomePage">Делегат - переход на домашнюю страницу.</param>
        public ViewModel_SettingsWindow(Action GoToTheHomePage)
        {
            PathToWorkingDirectory = Properties.Settings.Default.PathToWorkingDirectory;
            if(PathToWorkingDirectory == null || PathToWorkingDirectory == "\\")
                PathToWorkingDirectory = @"";

            ms_PathToDataBase = Properties.Settings.Default.PathToDataBase;
            if (ms_PathToDataBase == null || ms_PathToDataBase == "\\")
                ms_PathToDataBase = @"";

            m_GoToTheHomePage = GoToTheHomePage;


            ChooseWorkingDirectory = new RelayCommand(ChooseWorkingDirectory_execute);
            ChooseDBPath = new RelayCommand(ChooseDBPath_Execute);
            OkClicked = new RelayCommand(AddValuesToSettings);
            CancelClicked = new RelayCommand(FinishWorkOnCurrentPage);
        }
        #endregion


        #region Methods

        /// <summary>
        /// Действие на нажатие кнопки mbtn_ChooseWorkingDirectory - "Выбрать рабочу директорию"
        /// </summary>
        private void ChooseWorkingDirectory_execute(object o)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор рабочей директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                PathToWorkingDirectory = DirDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Сохранить значения в настройки.
        /// </summary>
        /// <param name="o"></param>
        private void AddValuesToSettings(object o)
        {
            if(Properties.Settings.Default.PathToWorkingDirectory != ms_PathToWorkingDirectory)
            {
                Properties.Settings.Default.PathToWorkingDirectory = ms_PathToWorkingDirectory ;
                Properties.Settings.Default.Save();
            }
            
            if(Properties.Settings.Default.PathToDataBase != ms_PathToDataBase)
            {
                Properties.Settings.Default.PathToDataBase = ms_PathToDataBase;
                Properties.Settings.Default.Save();

                MessageBox.Show("Путь к базе был изменен.");

            }

            m_GoToTheHomePage.Invoke();
        }
        /// <summary>
        /// Метод - выбор пути к базе.
        /// </summary>
        /// <param name="o"></param>
        private void ChooseDBPath_Execute(object o)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ms_PathToWorkingDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PathToDataBase = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Метод - закончить рабоу на данной странице и перейти на главную.
        /// </summary>
        /// <param name="o"></param>
        private void FinishWorkOnCurrentPage(object o)
        {
            m_GoToTheHomePage.Invoke();
        }

       
        #endregion
    }
}
