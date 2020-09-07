using System;
using System.Diagnostics;

namespace CheckPasswordStrength
{
    public static class ClassifyStrength
    {
        public static StrengthProperty PasswordStrength(this string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();

            Debug.WriteLine("Test");

            return new StrengthProperty();
        }
    }
}
