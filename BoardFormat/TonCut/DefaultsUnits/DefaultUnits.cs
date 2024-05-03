using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class DefaultUnits : DataGroupInput
    {


        /// <summary>
        /// This units is used to output data in the default units.
        /// The length unit in C# can be specified as "mm" for millimeters, "cm" for centimeters, and "in" for inches. 
        /// The default length unit can be changed by setting the length property in the defaultUnits JSON object. 
        /// The default length unit is a millimeter "mm".
        /// </summary>
        [StringValueAssignable("mm", "cm", "in")]
        public string length { get; set; }

        /// <summary>
        /// The field unit in C# can be specified as "sqmm" for square millimeters, "sqcm" for square centimeters, "sqm" for square meters, "sqin" for square inches, and "sqft" for square feet. 
        /// It can be changed by setting the field property in the defaultUnits JSON object. 
        /// The default field unit is used only if the value does not specify the unit. 
        /// For example, if the default unit is set to square meters "sqm" and you specify { "value": 250 }, then it will be treated as 250 square meters (250m2). 
        /// However, you can still force the unit in the value by setting it as a string, such as { "value": "250sqmm" }, which will be treated as 250 square millimeters (250mm2), regardless of the default field unit. 
        /// The default field unit is a square millimeter "sqmm".
        /// </summary>
        [StringValueAssignable("sqmm", "sqcm", "sqm", "sqin", "sqft")]
        public string field { get; set; }

        /// <summary>
        /// The angle unit in C# can be specified as "rad" for radians and "deg" for degrees. 
        /// The default angle unit can be changed by setting the angle property in the defaultUnits JSON object. 
        /// The default angle unit is used only if the value does not specify the unit. 
        /// For example, if the default unit is set to degrees "deg" and you specify { "value": 0.5 }, then it will be treated as 0.5 degrees (0.5°). 
        /// However, you can still force the unit in the value by setting it as a string, such as { "value": "0.5rad" }, which will be treated as 0.5 radians, regardless of the default angle unit. 
        /// The default angle unit is radian "rad".
        /// </summary>
        [StringValueAssignable("deg", "rad")]
        public string angle { get; set;  }

        public DefaultUnits(string _length, string _field, string _angle)
        {
            length = _length;
            field = _field;
            angle = _angle;

            StringValueCheckAttribute<DefaultUnits>(this);
        }

        public DefaultUnits(JToken jToken)
        {
            length = jToken["length"].ToString();
            field = jToken["field"].ToString();
            angle = jToken["angle"].ToString();

            StringValueCheckAttribute<DefaultUnits>(this);
        }
    }

    
}
