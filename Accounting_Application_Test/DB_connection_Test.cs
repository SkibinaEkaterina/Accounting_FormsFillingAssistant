using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Accounting_FormsFillingAssistant;
using System.IO;

namespace Accounting_Application_Test
{
    [TestClass]
    public class DB_connection_Test
    {

        [TestMethod]
        public void LoadAllObjectsFromExcelTable_Test1()
        {


            string PathToTestDB = @"C://Users//EkaterinaSkibina//Documents//Бухгалтерия рабочая директория//База_данных_программы.xlsx";

            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromExcelTable(PathToTestDB, "Организации");

            //List<Dictionary<string, string>> expectedExcelData = new List<Dictionary<string, string>>
            //{
            //    new Dictionary<string, string>{ ["Id"]="1",
            //                                    ["Название"]="ООО \"Пупкин энд КО\"",
            //                                    ["ИНН"]="123456778",
            //                                    ["КПП"]="87654321",
            //                                    ["Адрес"]="г. Москва ул. Жуковского д.9"},
            //    new Dictionary<string, string>{ ["Id"]="2",
            //                                    ["Название"]="ЗАО \"КуКаРеКу\"",
            //                                    ["ИНН"]="9876545676546",
            //                                    ["КПП"]="456467",
            //                                    ["Адрес"]="г. Новосибирск ул. Васильковая д.8"}
            //};


            //Assert.AreEqual(expectedExcelData, actualExcelData);

        }

    }
}
