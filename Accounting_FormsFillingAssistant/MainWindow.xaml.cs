using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Добавление контента на вкладку
            //mtab_OrganisationsTab.Content = new TextBlock { Text = "jngkjrntkgn"};


            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB.xlsx";
            //C://Users//EkaterinaSkibina//source//repos//Accounting_FormsFillingAssistant//Accounting_FormsFillingAssistant_Tests//test_Resources//Test_DB.xlsx
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromExcelTable(PathToTestDB, "Организации");






        }


        private void mbtn_MainSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             Свойства элемента Binding помогают установить источник привязки. 
             Для установки источника или контекста данных в элементах управления 
             WPF предусмотрено свойство DataContext. 
             */

            MainViewModel mvm_MainViewModel = new MainViewModel(mfr_WorkingPanel.NavigationService);
            DataContext = mvm_MainViewModel;
        }
    }
}
