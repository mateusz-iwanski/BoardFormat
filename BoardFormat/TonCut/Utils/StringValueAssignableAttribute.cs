using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TonCut
{
    /// <summary>
    /// Custom attribute to check string property (only public) values against a predefined list of values.  
    /// Using:
    ///     public class MyClass {
    ///         // set metadata for property
    ///         [StringValueChecker("x", "y", ...)] - MyProperty must be one of these values
    ///         public string MyProperty { get; set; } - can be only getter
    ///     
    ///     public MyClass{
    ///         MyProperty = "z";
    ///         // check if property is valid
    ///         StringValueAssignableAttribute.CheckObject<MyClass>(this);
    ///     }
    ///     
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)        
    ]
    public class StringValueAssignableAttribute : Attribute
    {
        private readonly string[] _values;

        /// <summary>
        /// Constructor for StringValueAssignableAttribute.
        /// </summary>
        /// <param name="values">The predefined list of string values to check against.</param>
        public StringValueAssignableAttribute(params string[] values)
        {
            this._values = values;
        }

        /// <summary>
        /// Returns the predefined list of string values.
        /// </summary>
        /// <returns>The predefined list of string values.</returns>
        public string[] Values() => this._values;
    }
}
