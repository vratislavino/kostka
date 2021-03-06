using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KostkaStats
{
    public class StatsLoader
    {
        static StatsLoader instance = null;
        private StatsLoader() { }

        static GlobalData globalData;
        public static GlobalData GlobalData => globalData;
        static CurrentData currentData;
        public static CurrentData CurrentData => currentData;

        public static StatsLoader Create(Form1 f) {
            if(instance == null) {
                instance = new StatsLoader();
                f.KostkaVrzena += ProcessNewNumber;
                instance.LoadStats();
            }
            return instance;
        }

        private void LoadStats() {

            var data = LoadFromFile("data.txt");

            globalData = new GlobalData(data);
            currentData = new CurrentData();
        }

        private int[] LoadFromFile(string filename) {
            if(File.Exists(filename)) {
                var lines = File.ReadAllLines(filename);
                if(lines.Length >= 6) {
                    int[] loadedData = new int[6];
                    for(int i = 0; i < 6; i++) {
                        if(int.TryParse(lines[i], out int a)) {
                            loadedData[i] = a;
                        } else {
                            MessageBox.Show("Data corrupted");
                            return new int[] { 0, 0, 0, 0, 0, 0 };
                        }
                    }
                    return loadedData;
                } else {
                    MessageBox.Show("Corrupted datafile");
                    return new int[] { 0, 0, 0, 0, 0, 0 };
                }
            }
            return new int[] { 0, 0, 0, 0, 0, 0 };
        }

        public static void ProcessNewNumber(int cislo) {
            currentData.data[cislo - 1]++;
            globalData.data[cislo - 1]++;

            currentData.SetDirty();
            globalData.SetDirty();

            SaveData();
        }

        private static void SaveData() {
            /*if(!File.Exists("data.txt")) {
                File.Create("data.txt");
            }*/
            File.WriteAllLines("data.txt", globalData.data.Select(x=>x.ToString()));
        }

    }
}
