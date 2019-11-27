using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Accounting_FormsFillingAssistant
{
    public static class DatabaseConnection<T>
    {

        // где хранится файл базы
        /// <summary>
        /// Загрузить объекты из БД. Возращает список объектов.
        /// </summary>
        /// <returns></returns>
        public static List<T> LoadAllObjectsFromTable()
        {
            return null;
        }

        /// <summary>
        /// Сохранить список объектов в БД. БД полностью очищается, будет содержать только загружаемый список объектов.
        /// </summary>
        /// <param name="listOfObjects"></param>
        public static void SaveAllObjectsToTable(List<T> listOfObjects)
        {
            
        }

        /// <summary>
        /// Добавить новый объект в конец списка в БД.
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveObjectInTheEndOfTable(T obj)
        {
            
        }

    }
}
