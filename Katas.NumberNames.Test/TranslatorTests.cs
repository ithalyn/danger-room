using System;
using NUnit.Framework;
namespace Katas.NumberNames.Test {
    [TestFixture]
    public class TranslatorTests {
        private Translator _subject;
        public TranslatorTests() {
            _subject = new Translator();
        }
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-1234)]
        public void GetNumberName_ValueLessThanZero_ThrowsException(int value) {
            Assert.Throws<ArgumentException>(() => _subject.GetNumberName(value));
        }

        [Test]
        public void GetNumberName_ValueIs0_ReturnsZero() {
            Assert.AreEqual(expected: "Zero", actual: _subject.GetNumberName(0));
        }

        [TestCase(1, "One")]
        [TestCase(2, "Two")]
        [TestCase(3, "Three")]
        [TestCase(5, "Five")]
        [TestCase(9, "Nine")]
        [TestCase(10, "Ten")]
        [TestCase(11, "Eleven")]
        [TestCase(12, "Twelve")]
        [TestCase(13, "Thirteen")]
        [TestCase(14, "Fourteen")]
        [TestCase(15, "Fifteen")]
        [TestCase(20, "Twenty")]
        [TestCase(26, "Twenty Six")]
        [TestCase(37, "Thirty Seven")]
        [TestCase(48, "Forty Eight")]
        [TestCase(59, "Fifty Nine")]
        [TestCase(60, "Sixty")]
        [TestCase(71, "Seventy One")]
        [TestCase(82, "Eighty Two")]
        [TestCase(93, "Ninety Three")]
        [TestCase(103, "One Hundred and Three")]
        [TestCase(307, "Three Hundred and Seven")]
        [TestCase(1234, "One Thousand Two Hundred and Thirty Four")]
        [TestCase(105034, "One Hundred and Five Thousand and Thirty Four")]
        [TestCase(437500, "Four Hundred and Thirty Seven Thousand Five Hundred")]
        [TestCase(7654321, "Seven Million Six Hundred and Fifty Four Thousand Three Hundred and Twenty One")]
        [TestCase(9999999, "Nine Million Nine Hundred and Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        public void GetNumberName_CanTranslate(int value, string expected) {
            Assert.AreEqual(expected: expected, actual: _subject.GetNumberName(value));
        }

        [TestCase(1000000000)]
        public void GetNumberName_CanNotTranslatOverOverMillions(int value) {
            Assert.Throws<ArgumentException>(() => _subject.GetNumberName(value));
        }
    }
}
