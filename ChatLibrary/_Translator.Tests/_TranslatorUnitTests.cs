using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorLibrary.Models;

namespace _Translator.Tests
{
    [TestClass]
    public class _TranslatorUnitTests
    {
        [TestMethod]
        [DataRow("При вет", "Pri vet")]
        [DataRow("Хлеб.  ", "Hleb.  ")]
        [DataRow("Ча ща:", "Cha scha:")]
        [DataRow("Перпен дику ляр/,;", "Perpen diku lyar/,;")]
        public void CheckMethodeTranslate_From_Russian_into_EnglishTranslet(string str, string expected)
        {
            //act
            string actual = Translator.Translate(str);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
