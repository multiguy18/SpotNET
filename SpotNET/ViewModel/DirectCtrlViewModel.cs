using SpotNET.Model;
using SpotNET.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotNET.ViewModel
{
    public class DirectCtrlViewModel : ObservableObject
    {
        private byte[] dimmers = new byte[16];

        public ObservableCollection<SliderData<byte>> Sliders { get; set; }

        private int _columnCount;
        public int ColumnCount
        { 
            get { return _columnCount; } 
            set {
                SetProperty(ref _columnCount, value);
            }
        }

        public DirectCtrlViewModel()
        {
            Sliders = new ObservableCollection<SliderData<byte>>();
            for (int i = 0; i < 256; i++)
            {
                Sliders.Add(new SliderData<byte> { Label = i.ToString(), Value = 0, ColumnIndex = i });
            }
            ColumnCount = Sliders.Count;
        }
    }
}
