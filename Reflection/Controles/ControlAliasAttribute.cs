using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Controles
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ControlAlias : Attribute
    {
        private readonly string _alias;

        public ControlAlias(string alias)
        {
            _alias = alias;
        }

        public string Name()
        {
            return _alias;
        }

        public override string ToString()
        {
            return _alias;
        }
    }
}
