using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accounting_FormsFillingAssistant;


namespace Accounting_FormsFillingAssistant_Tests
{
    [TestClass]
    public class DatabaseConnection_Test
    {

        [TestMethod]
        public void LoadAllObjectsFromExcelTable_Test1()
        {
            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB.xlsx";
            //C://Users//EkaterinaSkibina//source//repos//Accounting_FormsFillingAssistant//Accounting_FormsFillingAssistant_Tests//test_Resources//Test_DB.xlsx
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Организации");

            List<Dictionary<string, string>> expectedExcelData = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>{ ["Id"]="1",
                                                ["Название"]="ООО \"Пупкин энд КО\"",
                                                ["ИНН"]="123456778",
                                                ["КПП"]="87654321",
                                                ["Адрес"]="г. Москва ул. Жуковского д.9"},
                new Dictionary<string, string>{ ["Id"]="2",
                                                ["Название"]="ЗАО \"КуКаРеКу\"",
                                                ["ИНН"]="9876545676546",
                                                ["КПП"]="456467",
                                                ["Адрес"]="г. Новосибирск ул. Васильковая д.8"}
            };


            string actual = actualExcelData[1]["ИНН"] + actualExcelData[0]["ИНН"] + actualExcelData[1]["Название"];
            string expected = expectedExcelData[1]["ИНН"] + expectedExcelData[0]["ИНН"] + expectedExcelData[1]["Название"];

            Assert.AreEqual(expected, actual);





            //Test method threw exception: System.IO.FileNotFoundException: Could not load file or assembly 
            //    'PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.Не удается найти указанный файл.


        }


        [TestMethod]
        public void SaveAllObjectsToExcelTable_Test1()
        {

            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\" +
                "Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB_2.xlsx";

            List<Dictionary<string, string>> TableToSave = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    ["Id"]="21",
                    ["Название"]="Банк 1",
                    ["Город"]="Москва",
                    ["Номер счета банка"]="1234567890",
                    ["БИК"]="654323456789"
                },
                new Dictionary<string, string>
                {
                    ["Id"]="31",
                    ["Название"]="Банк 2",
                    ["Город"]="Москва",
                    ["Номер счета банка"]="0987654321",
                    ["БИК"]="098767896"
                }

            };


            DatabaseConnection.SaveAllObjectsToExcelTable(PathToTestDB, TableToSave, "Банки");
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Банки");


            string actual = actualExcelData[0]["Id"] + actualExcelData[0]["БИК"] + actualExcelData[1]["Номер счета банка"];
            string expected = TableToSave[0]["Id"] + TableToSave[0]["БИК"] + TableToSave[1]["Номер счета банка"];

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void SaveLastObjectToExcelTable_Test1()
        {

            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\" +
                "Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB_2.xlsx";

            Dictionary<string, string> NewObject = new Dictionary<string, string>
                {
                    ["Id"]="",
                    ["Название"]="Банк Super",
                    ["Город"]="Москва",
                    ["Номер счета банка"]="98765467890",
                    ["БИК"]="654398765689"
                };


            DatabaseConnection.SaveObjectInTheEndOfExcelTable(PathToTestDB, NewObject, "Банки");
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Банки");

            int lastNmb = actualExcelData.Count-1;
            string actual = actualExcelData[lastNmb]["Id"] + actualExcelData[lastNmb]["БИК"] + actualExcelData[lastNmb]["Номер счета банка"];
            string expected = "32" + NewObject["БИК"] + NewObject["Номер счета банка"];

            Assert.AreEqual(expected, actual);


        }

        // Проверка работы с пустым списком
        [TestMethod]
        public void SaveLastObjectToExcelTable_Test2()
        {

            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\" +
                "Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB_3.xlsx";

            Dictionary<string, string> NewObject = new Dictionary<string, string>
            {
                ["Id"] = "1",
                ["Название"] = "Банк Super",
                ["Город"] = "Москва",
                ["Номер счета банка"] = "98765467890",
                ["БИК"] = "654398765689"
            };


            DatabaseConnection.SaveObjectInTheEndOfExcelTable(PathToTestDB, NewObject, "Банки");
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Банки");

            
            string actual = actualExcelData[0]["Id"] + actualExcelData[0]["БИК"] + actualExcelData[0]["Номер счета банка"];
            string expected = "1" + NewObject["БИК"] + NewObject["Номер счета банка"];

            Assert.AreEqual(expected, actual);


            // Удалить Банк - выгрузить все банки и загрузить только те, что не являются нашим банком.
            List<Dictionary<string, string>> dAllBanks =
                DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Банки");

            List<Dictionary<string, string>> dAllBanksCorrected = dAllBanks.Where(b => b["Id"] != actualExcelData[0]["Id"]).ToList();

            DatabaseConnection.SaveAllObjectsToExcelTable(PathToTestDB,
                                                            dAllBanksCorrected, "Банки");




        }


        [TestMethod]
        public void EditObjectInExcelTable_Test1()
        {
            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\" +
              "Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB_2.xlsx";

            Dictionary<string, string> NewObject = new Dictionary<string, string>
            {
                ["Id"] = "21",
                ["Название"] = "Банк 1",
                ["Город"] = "Рим",
                ["Номер счета банка"] = "1234567890",
                ["БИК"] = "222"
            };


            DatabaseConnection.EditObjectInExcelTable(PathToTestDB, NewObject, "Банки");
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromOneExcelSHeet(PathToTestDB, "Банки");


            Dictionary<string, string> actualBankInfo = (from bank in actualExcelData
                                                         where bank["Id"] == NewObject["Id"]
                                                         select bank).FirstOrDefault();


            string actual = actualBankInfo["Id"] + actualBankInfo["БИК"] + actualBankInfo["Город"];
            string expected = "21" + NewObject["БИК"] + NewObject["Город"];

            Assert.AreEqual(expected, actual);

        }
    }
}
