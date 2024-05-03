using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumValueAssignableAttribute : Attribute
    {
        private Type Object;

        public EnumValueAssignableAttribute(Type _object)
        {
            this.Object = _object;
        }
        public Type Values() => this.Object;
    }
}
