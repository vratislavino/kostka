using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostkaStats
{
    public abstract class StatsData
    {
        public event Action<StatsData> ValuesChanged;

        public int[] data;
        public StatsData(int[] data = null) {

        }

        public void SetDirty() {
            ValuesChanged?.Invoke(this);
        }
    }

    public class CurrentData : StatsData
    {
        public CurrentData(int[] data = null) {
            this.data = new int[6];
        }
    }

    public class GlobalData : StatsData
    {
        public GlobalData(int[] data) {
            this.data = new int[6];
            for(int i = 0; i < data.Length; i++) {
                this.data[i] = data[i];
            }
        }
    }
}
