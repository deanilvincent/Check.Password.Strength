using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CheckPasswordStrength
{
    public static class ClassifyStrength
    {
        public static StrengthProperty PasswordStrength(this string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            var lowerCaseRegex = "(?=.*[a-z])";
            var upperCaseRegex = "(?=.*[A-Z])";
            var symbolsRegex = "(?=.*[!@#$%^&*])";
            var numericRegex = "(?=.*[0-9])";

            var strengthProperty = new StrengthProperty();
            var contains = new List<Contain>();
            if (new Regex(@"^" + lowerCaseRegex + "").IsMatch(password))
            {
                contains.Add(new Contain { Message = "lowercase" });
            }
            if (new Regex(@"^" + upperCaseRegex + "").IsMatch(password))
            {
                contains.Add(new Contain { Message = "uppercase" });
            }
            if (new Regex(@"^" + symbolsRegex + "").IsMatch(password))
            {
                contains.Add(new Contain { Message = "symbol" });
            }
            if (new Regex(@"^" + numericRegex + "").IsMatch(password))
            {
                contains.Add(new Contain { Message = "number" });
            }

            // strong
            if (new Regex(@"^" + lowerCaseRegex + upperCaseRegex + numericRegex + symbolsRegex + "(?=.{8,})").IsMatch(password))
            {
                strengthProperty.Id = 2;
                strengthProperty.Value = "Strong";
            } // medium
            else if (new Regex(@"^((" + lowerCaseRegex + upperCaseRegex + ")|(" + lowerCaseRegex + numericRegex + ")|(" + upperCaseRegex + numericRegex + ")|(" + upperCaseRegex + symbolsRegex + ")|(" + lowerCaseRegex + symbolsRegex + ")|(" + numericRegex + symbolsRegex + "))(?=.{6,})").IsMatch(password))
            {
                strengthProperty.Id = 1;
                strengthProperty.Value = "Medium";
            } // weak
            else
            {
                strengthProperty.Id = 0;
                strengthProperty.Value = "Weak";
            }

            strengthProperty.Contains = contains;
            strengthProperty.Length = password.Length;
            return strengthProperty;
        }
    }
}
