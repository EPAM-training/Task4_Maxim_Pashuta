using EPAM_Task4.ClientModels;
using NUnit.Framework;

namespace EPAM_Task4_NUnitTest.ClientModesTest
{
    /// <summary>
    /// Class for testing class Translator.
    /// </summary>
    public class TranslatorNUnitTest
    {
        /// <summary>
        /// The method tests a method TranslateMessage.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="actualResult">Translated message</param>
        [TestCase("fsdjfns", "фсдджфнс")]
        [TestCase("плпытыл", "plpitil")]
        public void Test_TranslateMessage(string message, string actualResult)
        {
            string result = Translator.TranslateMessage(message);

            Assert.AreEqual(result, actualResult);
        }
    }
}
