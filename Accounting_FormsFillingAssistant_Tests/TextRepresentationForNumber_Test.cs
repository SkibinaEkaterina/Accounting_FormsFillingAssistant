using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accounting_FormsFillingAssistant;
using System.Collections.Generic;

namespace Accounting_FormsFillingAssistant_Tests
{
    [TestClass]
    public class TextRepresentationForNumber_Test
    {
        [TestMethod]
        public void ConvertSumToNumericRepresentation_Test()
        {
            Blank_Accreditiv Blank1 = new Blank_Accreditiv();


            string actual = Blank1.ConvertSumToNumericRepresentation("222", "33");
            string expected = "222-33";

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void LoadAllObjectsFromExcelTable_Test1()
        {


            string PathToTestDB = "C:\\Users\\EkaterinaSkibina\\source\\repos\\Accounting_FormsFillingAssistant\\Accounting_FormsFillingAssistant_Tests\\test_Resources\\Test_DB.xlsx";
            //C://Users//EkaterinaSkibina//source//repos//Accounting_FormsFillingAssistant//Accounting_FormsFillingAssistant_Tests//test_Resources//Test_DB.xlsx
            List<Dictionary<string, string>> actualExcelData = DatabaseConnection.LoadAllObjectsFromExcelTable(PathToTestDB, "Организации");

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

    }
}
