using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Accounting_FormsFillingAssistant
{
    public static class DatabaseConnection<T>
    {



        // где хранится файл базы



        public static void CreateExcelDataBase(string PathToDataBase)
        {
            if (!Directory.Exists(PathToDataBase)) // "!" забыл поставить
            {



                //Directory.CreateDirectory(dir);
            }
        }


        /// <summary>
        /// Загрузить объекты из БД. Возращает список объектов.
        /// </summary>
        /// <returns></returns>
        public static List<T> LoadAllObjectsFromExcelTable(string SheetName)
        {
            return null;
        }

        /// <summary>
        /// Сохранить список объектов в БД. БД полностью очищается, будет содержать только загружаемый список объектов.
        /// </summary>
        /// <param name="listOfObjects"></param>
        public static void SaveAllObjectsToExcelTable(List<T> listOfObjects, string SheetName)
        {
            
        }

        /// <summary>
        /// Добавить новый объект в конец списка в БД.
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveObjectInTheEndOfExcelTable(T obj, string SheetName)
        {
            
        }

    }
}
