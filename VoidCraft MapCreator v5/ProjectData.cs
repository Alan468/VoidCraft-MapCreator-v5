using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {
    static public class ProjectData {
        static public string Name { get; set; }
        static public string Path { get; set; }
        static public int Width { get; set; }
        static public int Height { get; set; }
        static public int Layers { get; set; }

        static public List<List<Tile>> Bitmaps { get; set; }

        static public void InitBitmaps(int NumberOfLayers) {
            if (Bitmaps != null) Bitmaps.Clear();
            Bitmaps = new List<List<Tile>>();

            for (int l = 0; l < NumberOfLayers; l++) {
                Bitmaps.Add(new List<Tile>());
                Bitmaps[l] = new List<Tile>();
            }
        }

        static public bool Contain(int layer ,int id) {
            if (Bitmaps[layer].Count < 1) return false;
            foreach (Tile B in Bitmaps[layer]) {
                if (B.Id == id) {
                    return true;
                }
            }
            return false;
        }

        static public Bitmap GetBitmap(int layer, int id) {
            foreach (Tile B in Bitmaps[layer]) {
                if (B.Id == id) {
                    return B.Texture;
                }
            }
            return null;
        }

        static public bool SaveProjectData() {
            if (Directory.Exists(ProjectData.Path)) {
                if (Directory.EnumerateFileSystemEntries(Path).Count() != 0) {
                    MessageBox.Show("Folder o tej nazwie już istnieje ,prosze wybrać inny!");
                    return false;
                }
            }
            int NumberOfTextures = 0;
            for (int i = 0; i < ProjectData.Layers; i++) {
                foreach (Tile B in ProjectData.Bitmaps[i]) {
                    NumberOfTextures++;
                    break;
                }
                if (NumberOfTextures != 0) break;
            }

            if (NumberOfTextures == 0) {
                MessageBox.Show("Potrzeba conajmniej jednej tekstury!");
                return false;
            }

            Directory.CreateDirectory(ProjectData.Path);
            //Save vcmd
            using (StreamWriter sw = new StreamWriter(new FileStream(ProjectData.Path + "/mapdata.vcmd", FileMode.Create))) {
                sw.WriteLine(ProjectData.Name);
                sw.WriteLine(ProjectData.Width);
                sw.WriteLine(ProjectData.Height);
                sw.WriteLine(ProjectData.Layers);
            }
            //save vctl
            using (StreamWriter sw = new StreamWriter(new FileStream(ProjectData.Path + "/texturelist.vctl", FileMode.Create))) {
                for (int i = 0; i < ProjectData.Layers; i++) {
                    foreach (Tile B in ProjectData.Bitmaps[i]) {
                        sw.WriteLine(B.Layer + " " + B.Id + " " + B.Name + " " + B.Path);
                    }
                }
            }
            //copy textures
            Directory.CreateDirectory(ProjectData.Path + "/Textures");
            Directory.CreateDirectory(ProjectData.Path + "/Map");

            for (int l = 0; l < ProjectData.Layers; l++) {

                Directory.CreateDirectory(ProjectData.Path + "/Textures/L" + l);
                //copy textures
                foreach (Tile B in ProjectData.Bitmaps[l]) {
                    System.IO.File.Copy(B.Path,
                        ProjectData.Path + "/Textures/L" + l + "/" + B.Path.Split('\\').Last(),
                        true);
                }

            }
            return true;
        }

        internal static void SaveProjectMap(MapTile[,] Map) {
            for (int l = 0; l < ProjectData.Layers; l++) {
                using (StreamWriter sw = new StreamWriter(new FileStream(ProjectData.Path + "/Map/L" + l + ".vcmf", FileMode.Create))) {
                    for (int y = 0; y < ProjectData.Height; y++) {
                        for (int x = 0; x < ProjectData.Width; x++) {
                            sw.Write(Map[y, x].Id[l] + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
