using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accounting_FormsFillingAssistant;


namespace Accounting_Application_Test
{
    [TestClass]
    public class TextRepresentationForNumber_Test
    {
        [TestMethod]
        public void ConvertSumToNumericRepresentation_Test()
        {
            BlankViewModel_Accreditiv BlankViewModel_Accreditiv1 = new BlankViewModel_Accreditiv ();


            string actual = BlankViewModel_Accreditiv1.ConvertSumToNumericRepresentation("222", "33");
            string expected = "222-33";

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void ConvertSumToTextRepresentation_Test1()
        {
            BlankViewModel_Accreditiv BlankViewModel_Accreditiv1 = new BlankViewModel_Accreditiv();

            string actual = BlankViewModel_Accreditiv1.ConvertSumToTextRepresentation("222", "33");
            string expected = "Двести двадцать два рубля 33 копеек";

            Assert.AreEqual(expected, actual);


            
        }
    }
}
