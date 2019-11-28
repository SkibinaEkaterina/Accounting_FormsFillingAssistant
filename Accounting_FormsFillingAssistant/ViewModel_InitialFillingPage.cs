﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Accounting_FormsFillingAssistant
{
    public class ViewModel_InitialFillingPage : ViewModel_Base
    {

        
        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewModel_InitialFillingPage()
        {
            PathToWorkingDirectory = "выберите или введите путь к рабочей директории.";
            DatabaseStatus = "...";

            ChooseWorkingDirectory = new RelayCommand(ChooseWorkingDirectory_execute);



                //Properties.Settings.Default.PathToWorkingDirectory;
        }


        #region Fields
        /// <summary>
        /// Поле, в котором хранится путь рабочей директории.
        /// </summary>
        private string ms_PathToWorkingDirectory;
        private string ms_DatabaseStatus;
        private ICommand mcmnd_ChooseWorkingDirectory;

        #endregion


        #region Properties

        /// <summary>
        /// Свойство, для доступа к пути рабочей директории.
        /// </summary>
        public string PathToWorkingDirectory
        {
            get { return ms_PathToWorkingDirectory; }
            set
            {
                ms_PathToWorkingDirectory = value;
                RaisePropertyChanged("PathToWorkingDirectory");

                // Далее, если путь существует, то надо создать файл с БД


            }
        }

        public string DatabaseStatus
        {
            get { return ms_DatabaseStatus; }
            set
            {
                ms_DatabaseStatus = value;
                RaisePropertyChanged("DatabaseStatus");
            }
        }



        public ICommand ChooseWorkingDirectory
        {
            get { return mcmnd_ChooseWorkingDirectory; }
            set { mcmnd_ChooseWorkingDirectory = value;
                RaisePropertyChanged("ChooseWorkingDirectory");
            }
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
                PathToWorkingDirectory = DirDialog.SelectedPath + "\\";
            }
        }



        private void CreateDatabase()
        {
            if (Directory.Exists(PathToWorkingDirectory))
            {
                // Если существует, то создадим базу в этой директории.

                try
                {


                    // Если все хорошо и база создана
                    
                }
                catch
                {

                }


            }
            else
            {
                MessageBox.Show("Введенная директория не существует. Выберите существующую дирекоторию.");
            }


        }

        #endregion


    }
}
