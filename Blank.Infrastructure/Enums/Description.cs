using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Infrastructure.Enums
{
    public class Description : Attribute
    {
        public string Value { get; set; }

        public Description(string value)
        {
            this.Value = value;
        }
    }
}
