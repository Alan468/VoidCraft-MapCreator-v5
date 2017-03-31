using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string ProjectFile = "";
            try {
                ProjectFile = Environment.GetCommandLineArgs()[1];
                if (ProjectFile.Split('.').Last().ToLower() != "vcmd") {
                    MessageBox.Show("Wybrany plik nie jest plikiem projektu.");
                    return;
                }
            } catch (IndexOutOfRangeException ex) {}
            
            StartUpConfig STUC = new StartUpConfig(ProjectFile);
            if(!STUC.Status)
                Application.Run(STUC);
            
            if (STUC.Status) {
                MapCreator ME = new MapCreator(ProjectFile);
                Application.Run(ME);
            }
        }
    }
}
