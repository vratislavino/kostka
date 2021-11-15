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
    //https://github.com/vratislavino/kostka
    public partial class Form1 : Form
    {
        public event Action<int> KostkaVrzena;

        Random random = new Random();
        Kostka kostka;
        Stats stats;

        public Form1() {
            InitializeComponent();
            kostka = new Kostka(panel1.Width / 2, panel1.Height / 2);
            kostka.Invalidate += panel1.Refresh;
            
            StatsLoader.Create(this);
        }

        private void button1_Click(object sender, EventArgs e) {
            Hod();
        }

        private void button2_Click(object sender, EventArgs e) {
            for (int i = 0; i < 100; i++)
                Hod();
        }

        private void Hod() {
            var cislo = random.Next(1, 7);
            kostka.Cislo = cislo;
            KostkaVrzena?.Invoke(cislo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            kostka.VykresliSe(e.Graphics);
        }

        private void button3_Click(object sender, EventArgs e) {
            if(stats == null) {
                stats = new Stats();
                stats.Show();
                stats.Location = new Point(this.Location.X + this.Width - 18, this.Location.Y);
                stats.DockRequested += () => {
                    Form1_LocationChanged(null, null);
                };
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e) {
            if(stats != null) {
                stats.Location = new Point(this.Location.X + this.Width - 18, this.Location.Y);
            }
        }
    }
}
