using SpotNET.Model;
using SpotNET.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SpotNET.ViewModel
{
    public class DirectCtrlViewModel : ObservableObject
    {

        private readonly DMXUniverse _universe;

        private DispatcherTimer updateTimer;

        public ObservableCollection<string> Patches;

        public ObservableCollection<DirectCtrlSliderData<byte>> Sliders { get; set; }

        private int _columnCount;
        public int ColumnCount
        { 
            get { return _columnCount; } 
            set {
                SetProperty(ref _columnCount, value);
            }
        }

        public DirectCtrlViewModel(DMXUniverse universe)
        {
            _universe = universe;

            Patches = new ObservableCollection<string>();

            Sliders = new ObservableCollection<DirectCtrlSliderData<byte>>();
            for (int i = 1; i < 512; i++)
            {
                Sliders.Add(new DirectCtrlSliderData<byte> { Label = i.ToString(), Value = 0, ColumnIndex = i });
            }
            ColumnCount = Sliders.Count;

            updateTimer = new DispatcherTimer();
            // TODO: Fed the time from some static class that represents the settings
            updateTimer.Interval = TimeSpan.FromMilliseconds(100);
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.IsEnabled = true;

            _universe.Patch(0, 10);

            UpdatePatchlist();
        }

        private void UpdatePatchlist()
        {
            Patches.Clear();
            
            foreach (Tuple<ushort, ushort> entry in _universe.GetPatchlist())
            {
                Patches.Add(entry.Item1 + " -> " + entry.Item2);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            foreach (DirectCtrlSliderData<byte> sliderEntry in Sliders)
            {
                //if (!submasterOrPlayback)
                //{
                    _universe[sliderEntry.ColumnIndex] = sliderEntry.Value;
                //}

                sliderEntry.Value = _universe[sliderEntry.ColumnIndex];
            }
        }
    }
}
