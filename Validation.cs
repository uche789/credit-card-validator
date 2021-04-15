using System;
using System.Text.RegularExpressions;

namespace Validation {
    class Validator
    {
        public static bool LuhnValidator(string input) {
            input = input.Replace(" ", "");
            Regex rx = new Regex(@"^\d+$");
            if (!rx.IsMatch(input) || string.IsNullOrEmpty(input)) {
                return false;
            }
            
            char[] characters = input.ToCharArray();
            int sum = 0;
            bool isSecond = true;
            
            foreach (char c in characters) {
                int digit = int.Parse(c.ToString());

                if (isSecond) {
                    digit *= 2;
                    digit = digit > 9 ? (digit - 9) : digit;
                }

                sum += digit;
                isSecond = !isSecond;
            }

            return (sum % 10) == 0;
        }
    }
}