using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KostkaStats
{
    public partial class Stats : Form
    {
        private bool docked;
        public bool Docked {
            get { return docked; }
            private set {
                docked = value;
                button2.Text = docked ? "Undock" : "Dock";
            }
        }

        public event Action DockRequested;

        //private StatsData currentData;
        //private StatsData globalData;

        public Stats(/*CurrentData current, GlobalData global*/) {
            InitializeComponent();
            Docked = true;

            //this.currentData = current;
            //this.globalData = global;

            StatsLoader.CurrentData.ValuesChanged += OnCurrentDataChanged;
            StatsLoader.GlobalData.ValuesChanged += OnGlobalDataChanged;
        }

        private void OnCurrentDataChanged(StatsData data) {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 6; i++) {
                sb.Append(i+1);
                sb.Append(": ");
                sb.Append(data.data[i]);
                sb.Append("x");
                sb.Append("\n");
            }
            currentStats.Text = sb.ToString();
            //currentStats.Text = 
        }

        private void OnGlobalDataChanged(StatsData data) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++) {
                sb.Append(i + 1);
                sb.Append(": ");
                sb.Append(data.data[i]);
                sb.Append("x");
                sb.Append("\n");
            }
            gloabalStats.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e) {
            Docked = !Docked;
            if(Docked) {
                DockRequested?.Invoke();
            } 
        }
    }
}
