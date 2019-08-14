using System;
using System.Collections.Generic;

namespace Katas.NumberNames {
    public class Translator {
        public Translator() {
        }

        protected string[] _baseNumbers = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        protected string[] _tens = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        Dictionary<int, string> _bounds = new Dictionary<int, string>() { { 1000000, "Million" },{ 1000, "Thousand" }, { 100, "Hundred" } };

        public string GetNumberName(int number) {
            if (number < 0) {
                throw new ArgumentException("Negative numbers are not allowed.");
            }
            else if (number >= 1000000000) {
                throw new ArgumentException("Values of one billion and above are not allowed.");
            }
            else if (number == 0) {
                return "Zero";
            }

            string name = string.Empty;

            foreach (var bound in _bounds) {
                if ((number / bound.Key) > 0) {
                    if (name != string.Empty) { name += " "; }
                    name += $"{GetNumberName(number / bound.Key)} {bound.Value}";
                    number %= bound.Key;
                }
            }

            if (number > 0) {
                if (name != "" && number < 100)
                    name += " and ";

                if (number < 20)
                    name += _baseNumbers[number];
                else {
                    name += _tens[number / 10];
                    if ((number % 10) > 0)
                        name += " " + _baseNumbers[number % 10];
                }
            }

            return name;
        }
    }
}
