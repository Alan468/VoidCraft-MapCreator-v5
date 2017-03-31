using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
