using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Accounting_FormsFillingAssistant
{
    static class AdditionalDocumentsActionsClass
    {

        /// <summary>
        /// Заменит текст в документе по имени вкладки.
        /// </summary>
        /// <param name="Doc"> Объект документа. </param>
        /// <param name="BookmarkName"> Имя вкладки. </param>
        /// <param name="Text"> Текст на замену. </param>
        static public void ReplaceTextInWordDocumentByBookmark(Microsoft.Office.Interop.Word.Document Doc, string BookmarkName, string Text)
        {
            if (Doc.Bookmarks.Exists(BookmarkName))
            {
                Object name = BookmarkName;
                Microsoft.Office.Interop.Word.Range range = Doc.Bookmarks.get_Item(ref name).Range;

                range.Text = Text;
                object newRange = range;
                Doc.Bookmarks.Add(BookmarkName, ref newRange);
            }
        }

        /// <summary>
        /// Вернет значение конкретного поля в бланке. Поиск нужного поля в документе - по имени вкладки.
        /// </summary>
        /// <param name="Doc"> Объект документа. </param>
        /// <param name="BookmarkName"> Имя вкладки. </param>
        /// <returns></returns>
        static public string GetFieldValueFromWordDocumentByBookmark(Microsoft.Office.Interop.Word.Document Doc, string BookmarkName)
        {
            if (Doc.Bookmarks.Exists(BookmarkName))
            {
                Object name = BookmarkName;
                Microsoft.Office.Interop.Word.Range range = Doc.Bookmarks.get_Item(ref name).Range;

                return range.Text;
            }
            return null;
        }

        /// <summary>
        /// Загрузить список закладок из настроек, для выбранного типа бланка.
        /// </summary>
        static public List<string> LoadBookmarksNames(string BlankType)
        {
            List<string> Bookmarks_Names = null;

            switch (BlankType)
            {
                case "Аккредитив":
                    Bookmarks_Names = Properties.Settings.Default.ListOfBookmarksNames_Accreditiv.Cast<string>().ToList();
                    break;

                case "Инкассовое поручение":
                    Bookmarks_Names = Properties.Settings.Default.ListOfBookmarksNames_Inkasso.Cast<string>().ToList();
                    break;

                case "Платежное поручение":
                    Bookmarks_Names = Properties.Settings.Default.ListOfBookmarksNames_PaymentOrder.Cast<string>().ToList();
                    break;

                case "Платежное требование":
                    Bookmarks_Names = Properties.Settings.Default.ListOfBookmarksNames_PaymentRequirement.Cast<string>().ToList();
                    break;

                default:
                    MessageBox.Show("Выбран несуществующий тип бланка.");
                    break;
            }

            return Bookmarks_Names;
        }

        /// <summary>
        /// Загрузить шаблон бланка из ресурсов.
        /// </summary>
        /// <param name="BlankType"></param>
        /// <param name="Doc"></param>
        /// <param name="WordApplication"></param>
        static public Microsoft.Office.Interop.Word.Document LoadBlankTemplateFromResources(string BlankType, Microsoft.Office.Interop.Word.Document Doc,
                                                     Microsoft.Office.Interop.Word.Application WordApplication)
        {
            String fileName = System.IO.Path.GetTempFileName();

            byte[] template = null;

            switch (BlankType)
            {
                case "Аккредитив":
                    template = Properties.Resources.Template_Accreditiv;
                    break;

                case "Платежное требование":
                    template = Properties.Resources.Templaet_PaymentRequirement;
                    break;
                case "Платежное поручение":
                    template = Properties.Resources.Payment_order;
                    break;
                default:
                    MessageBox.Show("Указан неверный вид бланка. Выгрузка шаблона невозможна.");
                    Doc = null;
                    return null;
                    
            }



            File.WriteAllBytes(fileName, template);
            Doc = WordApplication.Documents.Add(fileName);

            return Doc;
        }



    }
}
