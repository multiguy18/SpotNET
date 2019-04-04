using SpotNET.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotNET.ViewModel
{
    public class DirectCtrlViewModel : ObservableObject
    {
        private byte[] dimmers = new byte[16];

        public byte Dimmer1
        {
            get
            {
                return dimmers[0];
            }
            set
            {
                dimmers[0] = value;
                RaisePropertyChanged("Dimmer1");
            }
        }

        public byte Dimmer2
        {
            get
            {
                return dimmers[1];
            }
            set
            {
                dimmers[1] = value;
                RaisePropertyChanged("Dimmer2");
            }
        }

        public byte Dimmer3
        {
            get
            {
                return dimmers[2];
            }
            set
            {
                dimmers[2] = value;
                RaisePropertyChanged("Dimmer3");
            }
        }
    }
}
