using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {
    public class Tile {
        public string Name { get; set; }
        public int Layer { get; set; }
        public int Id { get; set; }
        public string Path { get; set; }
        public Bitmap Texture { get; set; }

        public Tile() { }
        public Tile(string Name, int Layer, int Id, string Path) {
            SetBitmaps(Name, Layer, Id, Path);
        }

        public void SetBitmaps(string Name, int Layer, int Id, string Path) {
            this.Name = Name;
            this.Layer = Layer;
            this.Id = Id;
            this.Path = Path;
            try {
                this.Texture = new Bitmap(Path);
            } catch (FileNotFoundException ex) {
                MessageBox.Show("Nie można znaleść tekstury w lokacji: \n" + Path + "!");
            }
        }
        
    }
}
