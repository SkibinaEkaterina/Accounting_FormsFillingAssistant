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
        public void ConvertSumToTextRepresentation_Test1()
        {
            Blank_Accreditiv Blank1 = new Blank_Accreditiv();
            string actual = Blank1.ConvertSumToTextRepresentation("222", "33");
            string expected = "Двести двадцать два рубля 33 копеек";

            Assert.AreEqual(expected, actual);
        }


    }
}
