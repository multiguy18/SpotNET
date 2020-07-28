using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotNET.Model
{
    public class SliderData<T>
    {
        public string Label { get; set; }
        public T Value { get; set; }
        public int ColumnIndex { get; set; }
    }
}
