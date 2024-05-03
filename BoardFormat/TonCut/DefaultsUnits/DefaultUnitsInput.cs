using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public class DefaultUnitsInput : DefaultUnits, IDataGroupRoot
    {
        /// <summary>
        /// The time unit in C# can be specified as "s" for seconds, "m" for minutes, "h" for hours, and "d" for days. 
        /// It can be changed by setting the time property in the defaultUnits JSON object. 
        /// If the value does not specify the unit, the default time unit is used. 
        /// For example, if the default unit is set to "m" and you specify { "value": 5.5 }, it will be treated as 5.5 minutes. 
        /// However, you can still force the unit in the value by setting it as a string, such as { "value": "5.5s" }, which will be treated as 5.5 seconds, regardless of the default time unit. 
        /// The default time unit is "s".
        /// </summary>
        [StringValueAssignable("s", "m", "h", "d")]
        public string time { get; }

        /// <summary>
        /// In C#, when specifying a percentage value, whether as 50 or "50%", it will always be treated as 50%. 
        /// To be consistent, the percent property in the defaultUnits JSON object should always be set to "%". 
        /// The percent unit can only take one value: "%", which is also the default.
        /// </summary>
        [StringValueAssignable("%")]
        public string percent { get; }

        public DefaultUnitsInput(string _time, string _length, string _field, string _angle)
                : base(_length, _field, _angle)
        {
            percent = "%";
            time = _time;

            StringValueCheckAttribute<DefaultUnitsInput>(this);
        }
    }
}
