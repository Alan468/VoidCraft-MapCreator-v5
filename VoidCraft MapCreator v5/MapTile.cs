using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoidCraft_MapCreator_v5 {
    public class MapTile {
        public int[] Id;
        public MapTile(int NumberOfLayers) {
            Id = new int[NumberOfLayers];
        }
    }
}
