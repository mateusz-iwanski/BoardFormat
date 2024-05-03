using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardFormat.MVVM.Models;

namespace BoardFormat.FurnitureLibrary
{
    public class MinMaxStatic<T> where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
        public T Static { get; set; }

        public bool IsEmpty() => 
            Min.Equals(default(T)) && Max.Equals(default(T)) && Static.Equals(default(T));

        public void CheckRange(T value)
        {
            if (!Static.Equals(default(T)))
            {
                if (!value.Equals(Static))
                {
                    throw new Exception("Static value is out of range");
                }
            }
            else if (!Min.Equals(default(T)) && !Max.Equals(default(T)))
            {
                //if (Comparer<T>.Default.Compare(value, Min) < 0 || Comparer<T>.Default.Compare(value, Max) > 0)
                //    throw new Exception("Range value is out of range");
                if (value.CompareTo(Min) < 0 || value.CompareTo(Max) > 0)
                    throw new Exception("Range value is out of range");
            }
            else
            {
                throw new Exception("Range is not set properly");
            }
        }
    }
}
