using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class ViewModel_SettingsWindow : ViewModel_Base
    {

        #region Fields and properties

        
        private string ms_PathToWorkingDirectory;
        private string ms_PathToDataBase;
        private ICommand mcmnd_ChooseWorkingDirectory;
        private ICommand mcmnd_OkClicked;
        private ICommand mcmnd_CancelClicked;
        private Action m_GoToTheHomePage;


        

        public string PathToWorkingDirectory
        {
            get { return ms_PathToWorkingDirectory; }
            set
            {
                ms_PathToWorkingDirectory = value;
                RaisePropertyChanged("PathToWorkingDirectory");
            }
        }

        public string PathToDataBase
        {
            get { return ms_PathToDataBase; }
            set
            {
                ms_PathToDataBase = value;
                RaisePropertyChanged("PathToDataBase");
            }
        }

        public ICommand ChooseWorkingDirectory
        {
            get { return mcmnd_ChooseWorkingDirectory; }
            set
            {
                mcmnd_ChooseWorkingDirectory = value;
                RaisePropertyChanged("ChooseWorkingDirectory");
            }
        }

        public ICommand OkClicked
        {
            get { return mcmnd_OkClicked; }
            set
            {
                mcmnd_OkClicked = value;
                RaisePropertyChanged("OkClicked");
            }
        }
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
        public ViewModel_SettingsWindow(Action GoToTheHomePage)
        {

            PathToWorkingDirectory = Properties.Settings.Default.PathToWorkingDirectory;
            if(PathToWorkingDirectory == null || PathToWorkingDirectory == "\\")
                PathToWorkingDirectory = @"";
            m_GoToTheHomePage = GoToTheHomePage;


            ChooseWorkingDirectory = new RelayCommand(ChooseWorkingDirectory_execute);
            OkClicked = new RelayCommand(AddValuesToSettings);
            CancelClicked = new RelayCommand(FinishWorkOnCurrentPage);

        }



        public ViewModel_SettingsWindow()
        {

            PathToWorkingDirectory = Properties.Settings.Default.PathToWorkingDirectory;
            if (PathToWorkingDirectory == null || PathToWorkingDirectory == "\\")
                PathToWorkingDirectory = @"";


            ChooseWorkingDirectory = new RelayCommand(ChooseWorkingDirectory_execute);
            OkClicked = new RelayCommand(AddValuesToSettings);
            CancelClicked = new RelayCommand(FinishWorkOnCurrentPage);

            // Добавть создание выпадающего списка и выбор нужной организации

            // решение проблемы с обновлением комба - см. https://stackoverflow.com/questions/34321074/wpf-binding-combobox-to-my-viewmodel
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


            //m_GoToTheHomePage.Invoke();
        }


        private void FinishWorkOnCurrentPage(object o)
        {
            m_GoToTheHomePage.Invoke();
        }

        #endregion
    }
}
