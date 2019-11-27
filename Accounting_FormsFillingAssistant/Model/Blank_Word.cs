using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace Accounting_FormsFillingAssistant
{
    /// <summary>
    /// Класс для работы непосредственно с Word-файлами бланков: выгрузка/загрузка бланков и их параметров с диска.
    /// </summary>
    class Blank_Word
    {
        /// <summary>
        ///  Словарь закладки-значения.
        /// </summary>
        Dictionary<string, string> md_ParametersValues;

        /// <summary>
        ///  Свойство - словаря закладки-значения.
        /// </summary>
        Dictionary<string, string> DictionaryWithParametersValues
        {
            get { return md_ParametersValues; }
            set { md_ParametersValues = value; }
        }

        /// <summary>
        /// Список названий вкладок в документе бланка.
        /// </summary>
        private List<string> ml_Bookmarks_Names;

        /// <summary>
        /// Путь к файлу на диске.
        /// </summary>
        private string m_PathToWordFile;

        /// <summary>
        /// Тип бланка (Аккредитив, Инкассовое поручение, Платежное поручение или Платежное требование).
        /// </summary>
        private string m_BlankType;


        /// <summary>
        /// Кнструктор класса бъекта Word бланка.
        /// </summary>
        /// <param name="PathToWordFile"> Путь к файлу Word на диске (для чтения/сохранения). </param>
        /// <param name="BlankType"> Тип бланка (один из 4х: Аккредитив, Инкассовое поручение, Платежное 
        /// поручение или Платежное требование). </param>
        /// <param name="ParametersValues"> Словарь со значениями соответствующих полей в бланке. Если поле равно null, 
        /// предполагается, что экземпляр класса создан для редактирования бланка и на первом шаге необходимо выгрузить 
        /// значения полей из бланка и создать словарь. В противном случае предполагается, что экземпляр класса создан,
        /// чтобы записать значения из словаря в бланк. </param>
        public Blank_Word(string PathToWordFile,
                          string BlankType,
                          Dictionary<string, string> ParametersValues)
        {
            m_PathToWordFile = PathToWordFile;
            md_ParametersValues = ParametersValues;


            m_BlankType = BlankType;
            // осуществить проверку на BlankType значение - при несуществующем - вызвать Exception.

            // Загружается список закладок для выбранного типа бланка
            ml_Bookmarks_Names = AdditionalDocumentsActionsClass.LoadBookmarksNames(m_BlankType);

        }




        // Методы

        // Word -> словарь со значениями
        /// <summary>
        /// Выгрузить значения поелй в словарь md_ParametersValues.
        /// </summary>
        public void LoadParametersFromWord()
        {
            // слоаврь пуст, выгрузим значения из него
            if (md_ParametersValues != null)
                md_ParametersValues.Clear();

            md_ParametersValues = new Dictionary<string, string>();

            Word.Document WordDoc = null;
            Word.Application WordApplication = new Word.Application();

            try
            {
                if (m_PathToWordFile == "" || m_PathToWordFile == null)
                {
                    //MessageBox.Show("Невозможно осуществить операцию выгрузки параметров из файла. Отсутствует путь к файлу. ");
                    throw new ArgumentNullException("Путь к Wоrd файлу.");
                }
                
                WordDoc = WordApplication.Documents.Add(m_PathToWordFile);
                WordDoc.Activate();
                Word.Bookmarks wBookmarks = WordDoc.Bookmarks;

                // Выгрузим значения полей бланка в словарь
                foreach(string bookmarkName in ml_Bookmarks_Names)
                {
                    md_ParametersValues[bookmarkName] = AdditionalDocumentsActionsClass.GetFieldValueFromWordDocumentByBookmark(WordDoc, bookmarkName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            finally
            {
                WordDoc.Close();
                WordDoc = null;
                WordApplication.Quit();
            }
        }


        // словарь -> Word
        /// <summary>
        /// Загрузить значения словаря md_ParametersValues в файл документа, расположенного по пути m_PathToWordFile.
        /// </summary>
        public void LoadParametersToWord()
        {

            Word.Document WordDoc = null;
            Word.Application WordApplication = new Word.Application();
            try
            {

                if (md_ParametersValues == null || md_ParametersValues.Count == 0)
                {
                    throw new ArgumentNullException("Словарь со значениями полей.");
                }
                if (m_PathToWordFile == "" || m_PathToWordFile == null)
                {
                    //MessageBox.Show("Невозможно осуществить операцию выгрузки параметров из файла. Отсутствует путь к файлу. ");
                    throw new ArgumentNullException("Путь к Wоrd файлу.");
                }

                // Выгрузить новый шаблон бланка
                AdditionalDocumentsActionsClass.LoadBlankTemplateFromResources(m_BlankType, WordDoc, WordApplication);

                if(WordDoc == null)
                {
                    throw new ArgumentNullException("Шаблон документа.");
                }

                //WordDoc = WordApplication.Documents.Add(m_PathToWordFile);


                WordDoc.Activate();
                Word.Bookmarks wBookmarks = WordDoc.Bookmarks;

                // Выгрузим значения полей бланка в словарь
                foreach (string bookmarkName in ml_Bookmarks_Names)
                {
                    AdditionalDocumentsActionsClass.ReplaceTextInWordDocumentByBookmark(WordDoc, bookmarkName, md_ParametersValues[bookmarkName]);
                }

                WordDoc.SaveAs2(m_PathToWordFile);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                WordDoc.Close();
                WordDoc = null;
                WordApplication.Quit();
            }
        }


        

    }
}
