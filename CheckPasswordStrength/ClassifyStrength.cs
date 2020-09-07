using System;
using System.Diagnostics;
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
            //if (new Regex(@"^" + lowerCaseRegex + "").IsMatch(password))
            //{
            //    strengthProperty.Contains.Add(new Contain { Message = "lowercase" });
            //}

            // strong
            if (new Regex(@"^" + lowerCaseRegex + upperCaseRegex + numericRegex + symbolsRegex + "(?=.{8,})").IsMatch(password))
            {
                strengthProperty.Id = 2;
                strengthProperty.Value = "Strong";
            } // medium
            else if (new Regex($"@^(({lowerCaseRegex}{upperCaseRegex})|({lowerCaseRegex}{numericRegex})|({upperCaseRegex}{numericRegex}))(?=.{{6,}})").IsMatch(password))
            {
                strengthProperty.Id = 1;
                strengthProperty.Value = "Medium";
            } // weak
            else
            {
                strengthProperty.Id = 0;
                strengthProperty.Value = "Weak";
            }

            return strengthProperty;
        }
    }
}
