using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotNET.Model
{
    public class DMXUniverse
    {
        public byte[] DmxBus = new byte[512];
        public ushort[] Dimmers = new ushort[512];

        public DMXUniverse()
        {
            for (int i = 0; i < Dimmers.Length; i++)
            {
                // Mark all as unpatched on instantion
                Dimmers[i] = 513;
            }
        }

        public byte this[int i]
        {
            get
            {
                if (Dimmers[i] < 512)
                {
                    return DmxBus[Dimmers[i]];
                }

                return 0;
            }
            set
            {
                if (Dimmers[i] < 512)
                {
                    DmxBus[Dimmers[i]] = value;
                }
            }
        }

        public void Patch(ushort dimmerNo, ushort dmxChannelNo)
        {
            Dimmers[dimmerNo] = dmxChannelNo <= 512 ? dmxChannelNo : (ushort)512;
        }

        public void Unpatch(ushort dimmerNo)
        {
            Dimmers[dimmerNo] = 513;
        }

        public bool IsPatched(ushort dimmerNo)
        {
            return Dimmers[dimmerNo] < 513;
        }

        public List<Tuple<ushort, ushort>> GetPatchlist()
        {
            List<Tuple<ushort, ushort>> patchlist = new List<Tuple<ushort, ushort>>();

            for (ushort i = 0; i < Dimmers.Length; i++)
            {
                if (IsPatched(i))
                {
                    patchlist.Add(new Tuple<ushort, ushort>(i, Dimmers[i]));
                }
            }

            return patchlist;
        }
    }
}
