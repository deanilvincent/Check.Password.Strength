using System;
using System.Collections.Generic;
using System.Text;

namespace CheckPasswordStrength
{
    public class StrengthProperty
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int Length { get; set; }

        public IList<Contain> Contains { get; set; }
    }

    public class Contain
    {
        public string Message { get; set; }
    }
}
