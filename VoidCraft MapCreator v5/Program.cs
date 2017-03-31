using System;
using System.Linq;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            do {

                string ProjectFile = "";
                try {
                    ProjectFile = Environment.GetCommandLineArgs()[1];
                    if (ProjectFile.Split('.').Last().ToLower() != "vcmd") {
                        MessageBox.Show("Wybrany plik nie jest plikiem projektu.");
                        return;
                    }
                } catch (IndexOutOfRangeException ex) { }

                StartUpConfig STUC = new StartUpConfig(ProjectFile);
                if (!STUC.Status)
                    Application.Run(STUC);

                MapCreator ME = new MapCreator(ProjectFile);
                if (STUC.Status) {
                    Application.Run(ME);
                }
                if (!ME.RestartApp) break;

            } while (true);
        }
    }
}
