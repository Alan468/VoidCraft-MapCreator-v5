using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {

    public partial class MapCreator : Form {
        private string projectFile;

        private Graphics ToolBoxGraphics;
        private Bitmap ToolBoxBitmap;
        private Graphics MapGraphics;
        private Bitmap MapBitmap;
        private Graphics MapCounterGraphics;
        private Bitmap MapCounterBitmap;
        Graphics SelectionGraphics;
        Bitmap SelectionBitMap;

        private int ActiveLayer;
        private int[] SelectedTile_Left, SelectedTile_Right;//0 Layer ,1 id
        private int MapSizeZoom;

        private MapTile[,] Map;
        private int PenSize;
        bool LinieSiatki, NumerowanieLinii;
        public bool RestartApp { get; set; }
        private bool AutomaticRefres = true;
        private bool PaintAreaSelector = true;

        public MapCreator(string projectFile) {
            this.InitializeComponent();
            this.projectFile = projectFile;
            ActiveLayer = 0;
            RestartApp = false;
            PenSize = 0;
            MapSizeZoom = 50;
            LinieSiatki = true;
            NumerowanieLinii = true;
            SelectedTile_Left = new int[2];
            SelectedTile_Right = new int[2];

            SelectedTile_Left[0] = -1;
            SelectedTile_Left[1] = -1;
            SelectedTile_Right[0] = -1;
            SelectedTile_Right[1] = -1;

            Map = new MapTile[ProjectData.Height, ProjectData.Width];
            for (int y = 0; y < ProjectData.Height; y++) {
                for (int x = 0; x < ProjectData.Width; x++) {
                    Map[y, x] = new MapTile(ProjectData.Layers);
                    for (int l = 0; l < ProjectData.Layers; l++)
                        Map[y, x].Id[l] = 0;
                }
            }

            if (File.Exists(ProjectData.Path + "Map/L0.vcmf")) {
                for (int l = 0; l < ProjectData.Layers; l++) {
                    using (StreamReader sw = new StreamReader(new FileStream(ProjectData.Path + "Map/L" + l + ".vcmf", FileMode.Open))) {
                        for (int y = 0; y < ProjectData.Height; y++) {
                            string[] line = sw.ReadLine().Split(' ');
                            for (int x = 0; x < ProjectData.Width; x++) {
                                Map[y, x].Id[l] = int.Parse(line[x]);
                            }
                        }
                    }
                }
            }


            ToolStripMenuItem[] items = new ToolStripMenuItem[ProjectData.Layers];
            for (int i = 0; i < items.Length; i++) {
                Layer_Selector_MC.Items.Add(i.ToString());
            }

            ToolBoxBitmap = new Bitmap(500, 1000);
            ToolBoxGraphics = Graphics.FromImage(ToolBoxBitmap);
            MapBitmap = new Bitmap(1920, 1080);
            MapGraphics = Graphics.FromImage(MapBitmap);
            MapCounterBitmap = new Bitmap(1820, 1000);
            MapCounterGraphics = Graphics.FromImage(MapCounterBitmap);
            SelectionBitMap = new Bitmap(1920, 1080);
            SelectionGraphics = Graphics.FromImage(SelectionBitMap);

            this.Text += " - " + ProjectData.Name;
        }

        private bool IsInView(int P, int W, int ElementSize) {

            if ((P * MapSizeZoom) + W + MapSizeZoom >= 0 &&
             (((P * MapSizeZoom) + W) <= (ElementSize))) return true;

            return false;
        }

        private void UpdateView() {

            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Map_View_Panel_MC.BackColor);
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int PanelScrolX = Map_Counter_Panel_MC.AutoScrollPosition.X;
            int PanelScrolY = Map_Counter_Panel_MC.AutoScrollPosition.Y;

            if (NumerowanieLinii) {
                for (int x = 0; x < ProjectData.Width; x++) {
                    if (IsInView(x, PanelScrolX, Map_View_Panel_MC.Width))
                        MapCounterGraphics.DrawString(x.ToString(), drawFont, drawBrush, (MapSizeZoom * (x + 1)) - (MapSizeZoom / 2) + PanelScrolX + 30, 5);
                }
            }
            for (int y = 0; y < ProjectData.Height; y++) {
                for (int x = 0; x < ProjectData.Width; x++) {

                    if (IsInView(x, PanelScrolX, Map_View_Panel_MC.Width) && IsInView(y, PanelScrolY, Map_View_Panel_MC.Height)) {
                        for (int l = 0; l < ProjectData.Layers; l++)
                            if (Map[y, x].Id[l] != 0)
                                MapGraphics.DrawImage(
                                    ProjectData.GetBitmap(l, Map[y, x].Id[l]),
                                    (x * MapSizeZoom) + PanelScrolX,
                                    (y * MapSizeZoom) + PanelScrolY,
                                    MapSizeZoom,
                                    MapSizeZoom);

                        if (LinieSiatki)
                            MapGraphics.DrawRectangle(pen, (x * MapSizeZoom) + PanelScrolX, (y * MapSizeZoom) + PanelScrolY, MapSizeZoom, MapSizeZoom);
                    }
                }
                if (NumerowanieLinii) {
                    if (IsInView(y, PanelScrolY, Map_View_Panel_MC.Height))
                        MapCounterGraphics.DrawString(y.ToString(), drawFont, drawBrush, 5, (MapSizeZoom * (y + 1)) - (MapSizeZoom / 2) - 10 + PanelScrolY + 35);

                }
            }
            drawFont.Dispose();
            drawBrush.Dispose();
            pen.Dispose();
            brush.Dispose();

            /////////////////////////////
            if (PaintAreaSelector) {
                pen = new Pen(Color.Black, 3);

                int X = (Map_View_Panel_MC.PointToClient(Cursor.Position).X - PanelScrolX) / MapSizeZoom;
                int Y = (Map_View_Panel_MC.PointToClient(Cursor.Position).Y - PanelScrolY) / MapSizeZoom;

                MapGraphics.DrawRectangle(pen,
                    ((X - PenSize) * MapSizeZoom) + PanelScrolX,
                    ((Y - PenSize) * MapSizeZoom) + PanelScrolY,
                    (((2 * PenSize) + 1) * MapSizeZoom),
                    (((2 * PenSize) + 1) * MapSizeZoom)
                    );

                pen.Dispose();
            }
            //////////////////////////////

            Map_View_Panel_MC.CreateGraphics().DrawImage(MapBitmap, 0, 0);
            Map_Counter_Panel_MC.CreateGraphics().DrawImage(MapCounterBitmap, 0, 0);

            MapGraphics.Clear(Map_View_Panel_MC.BackColor);
            MapCounterGraphics.Clear(Map_Counter_Panel_MC.BackColor);


            int _x = 0, _y = 0;
            foreach (Tile T in ProjectData.Bitmaps[ActiveLayer]) {
                if (T.Layer == ActiveLayer) {

                    ToolBoxGraphics.DrawImage(T.Texture, 40 + (_x * 60), (20 + (_y * 60)) + Tool_Box_Panel_MC.AutoScrollPosition.Y, 50, 50);

                    if (SelectedTile_Left[0] != -1)
                        if (T.Layer == SelectedTile_Left[0] && T.Id == SelectedTile_Left[1]) {
                            ToolBoxGraphics.DrawRectangle(new Pen(Color.Black, 2), 38 + (_x * 60), (18 + (_y * 60)) + Tool_Box_Panel_MC.AutoScrollPosition.Y, 52, 52);
                        }
                    if (SelectedTile_Right[0] != -1)
                        if (T.Layer == SelectedTile_Right[0] && T.Id == SelectedTile_Right[1]) {
                            ToolBoxGraphics.DrawRectangle(new Pen(Color.Red, 2), 38 + (_x * 60), (18 + (_y * 60)) + Tool_Box_Panel_MC.AutoScrollPosition.Y, 52, 52);
                        }

                    if (++_x % 2 == 0) {
                        _y++;
                        _x = 0;
                    }

                }
            }
            Map_Counter_Panel_MC.AutoScrollMinSize = new Size((MapSizeZoom * ProjectData.Width) + MapSizeZoom, (MapSizeZoom * ProjectData.Height) + MapSizeZoom);

            Tool_Box_Panel_MC.CreateGraphics().DrawImage(ToolBoxBitmap, 0, 0);
            ToolBoxGraphics.Clear(Tool_Box_Panel_MC.BackColor);
        }

        private void SelectingTile(object sender, MouseEventArgs e) {
            int x = 0, y = 0;
            Rectangle TileBtn;

            foreach (Tile T in ProjectData.Bitmaps[ActiveLayer]) {
                TileBtn = new Rectangle(38 + (x * 60), (18 + (y * 60)) + Tool_Box_Panel_MC.AutoScrollPosition.Y, 50, 50);

                if (TileBtn.Contains(e.Location)) {
                    if (e.Button == MouseButtons.Left) {
                        SelectedTile_Left[0] = T.Layer;
                        SelectedTile_Left[1] = T.Id;
                    } else if (e.Button == MouseButtons.Right) {
                        SelectedTile_Right[0] = T.Layer;
                        SelectedTile_Right[1] = T.Id;
                    }

                    UpdateView();
                    break;
                }

                if (++x % 2 == 0) {
                    y++;
                    x = 0;
                }

            }
        }

        private void MapCreator_Paint(object sender, PaintEventArgs e) { if (AutomaticRefres) UpdateView(); }

        private void Map_Counter_Panel_MC_Scroll(object sender, ScrollEventArgs e) { UpdateView(); }

        private void Map_View_Panel_MC_MouseDown(object sender, MouseEventArgs e) {
            int a = Map_Counter_Panel_MC.AutoScrollPosition.X;
            int b = Map_Counter_Panel_MC.AutoScrollPosition.Y;
            int X = (e.Location.X - a) / MapSizeZoom;
            int Y = (e.Location.Y - b) / MapSizeZoom;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle) {
                if (X >= 0 && X < ProjectData.Width && Y >= 0 && Y < ProjectData.Height) {
                    if (e.Button == MouseButtons.Left) {
                        if (SelectedTile_Left[0] != -1) {
                            for (int sx = -PenSize; sx <= PenSize; sx++) {
                                for (int sy = -PenSize; sy <= PenSize; sy++) {
                                    if (SelectedTile_Left[0] == ActiveLayer) {
                                        if (Y + sy >= 0 && Y + sy < ProjectData.Height) {
                                            if (X + sx >= 0 && X + sx < ProjectData.Width) {
                                                Map[Y + sy, X + sx].Id[SelectedTile_Left[0]] = SelectedTile_Left[1];
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    } else if (e.Button == MouseButtons.Right) {
                        if (SelectedTile_Right[0] != -1) {
                            for (int sx = -PenSize; sx <= PenSize; sx++) {
                                for (int sy = -PenSize; sy <= PenSize; sy++) {
                                    if (SelectedTile_Right[0] == ActiveLayer) {
                                        if (Y + sy >= 0 && Y + sy < ProjectData.Height) {
                                            if (X + sx >= 0 && X + sx < ProjectData.Width) {
                                                Map[Y + sy, X + sx].Id[SelectedTile_Right[0]] = SelectedTile_Right[1];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    } else if (e.Button == MouseButtons.Middle) {
                        if (SelectedTile_Right[0] != -1 && SelectedTile_Left[0] != -1) {

                            for (int sx = -PenSize; sx < PenSize; sx += 2) {
                                for (int sy = -PenSize; sy <= PenSize; sy += 2) {

                                    if (SelectedTile_Right[0] == ActiveLayer && SelectedTile_Left[0] == ActiveLayer) {
                                        if (Y + sy >= 0 && Y + sy < ProjectData.Height) {
                                            if (X + sx >= 0 && X + sx < ProjectData.Width) {
                                                Map[Y + sy, X + sx].Id[SelectedTile_Left[0]] = SelectedTile_Left[1];
                                                Map[Y + sy, X + sx + 1].Id[SelectedTile_Right[0]] = SelectedTile_Right[1];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            if (AutomaticRefres) UpdateView();

        }

        private void Zoom_Selector_MC_SelectedIndexChanged(object sender, EventArgs e) {
            int zoomVal = 0;
            if (int.TryParse(Zoom_Selector_MC.Text, out zoomVal))
                MapSizeZoom = zoomVal;
            Map_View_Panel_MC.Focus();
            UpdateView();
        }

        private void Layer_Selector_MC_SelectedIndexChanged(object sender, EventArgs e) {
            int layerVal = 0;
            if (int.TryParse(Layer_Selector_MC.Text, out layerVal))
                ActiveLayer = layerVal;
            Map_View_Panel_MC.Focus();
            UpdateView();
        }

        private void Pen_Size_Selector_MC_SelectedIndexChanged(object sender, EventArgs e) {
            int sizeVal = 0;
            if (int.TryParse(Pen_Size_Selector_MC.Text, out sizeVal))
                PenSize = sizeVal;
            Map_View_Panel_MC.Focus();
            UpdateView();
        }

        private void MapCreator_Load(object sender, EventArgs e) { UpdateView(); }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e) {
            ProjectData.SaveProjectMap(Map);
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "\t\tInformacje\n\n"
                + "\tKreator map VoidCraft\n" +
                "\tSekcja5 Projekt PUM PolSl 2017 Sem 4 Blok A\n" +
                "\n\tAll rights reserved 2017");
        }

        private void MapCreator_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Czy zapisać projekt?", "Zamykanie", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes) {
                ProjectData.SaveProjectMap(Map);

            } else if (result == DialogResult.Cancel) {
                e.Cancel = true;
                this.Activate();
            }
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void przełaczNumerowanieLiniiToolStripMenuItem_Click(object sender, EventArgs e) {
            NumerowanieLinii = !NumerowanieLinii;
            UpdateView();
        }

        private void zapiszJakoNowyToolStripMenuItem_Click(object sender, EventArgs e) {
            FolderBrowserDialog Dialog = new FolderBrowserDialog();
            Dialog.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = Dialog.ShowDialog();

            this.Text = this.Text.Replace(" - " + ProjectData.Name, "");

            if (result == DialogResult.OK) {
                ProjectData.Path = Dialog.SelectedPath;
                ProjectData.SaveProjectData();
                ProjectData.SaveProjectMap(Map);
            }
            this.Text += " - " + ProjectData.Name;
        }

        private void nowyProjektToolStripMenuItem_Click(object sender, EventArgs e) {
            RestartApp = true;
            this.Close();
        }

        private void odświeżToolStripMenuItem_Click(object sender, EventArgs e) {
            UpdateView();
        }

        private void przełaczAutomatyczneOdświeżanieToolStripMenuItem_Click(object sender, EventArgs e) {
            AutomaticRefres = !AutomaticRefres;
        }

        private void przełaczWskaźnikObszaruToolStripMenuItem_Click(object sender, EventArgs e) {
            PaintAreaSelector = !PaintAreaSelector;
            UpdateView();
        }

        private void wyłaczLinieSiatkiToolStripMenuItem_Click(object sender, EventArgs e) {
            LinieSiatki = !LinieSiatki;
            UpdateView();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.A)) { // Wklejenie na calej mapie tekstury wybranej LPM
                if (SelectedTile_Left != null)
                    if (SelectedTile_Left[0] == ActiveLayer)
                        for (int y = 0; y < ProjectData.Height; y++) {
                            for (int x = 0; x < ProjectData.Width; x++) {
                                Map[y, x].Id[ActiveLayer] = SelectedTile_Left[1];
                            }
                        }
                UpdateView();
                return true;
            } else if (keyData == (Keys.Alt | Keys.A)) {// Wklejenie na calej mapie tekstury wybranej PPM
                if (SelectedTile_Right != null)
                    if (SelectedTile_Right[0] == ActiveLayer)
                        for (int y = 0; y < ProjectData.Height; y++) {
                            for (int x = 0; x < ProjectData.Width; x++) {
                                Map[y, x].Id[ActiveLayer] = SelectedTile_Right[1];
                            }
                        }
                UpdateView();
                return true;
            } else if (keyData == (Keys.Control | Keys.S)) { // Zapis projektu
                ProjectData.SaveProjectMap(Map);
                return true;
            } else if (keyData == (Keys.Control | Keys.Z)) { // Przelaczenie lini siatki
                wyłaczLinieSiatkiToolStripMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Control | Keys.X)) { // Przelaczenie numeracji lini
                przełaczNumerowanieLiniiToolStripMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Control | Keys.C)) { // Przelaczenie wskaznika obszaru
                przełaczWskaźnikObszaruToolStripMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Control | Keys.Space)) { // Przelaczenie automatycznego odswiezania
                przełaczAutomatyczneOdświeżanieToolStripMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Space)) { // Wymuszenie odswiezenia
                UpdateView();
                return true;
            } else if (keyData == (Keys.Q)) { // Zoom +
                if (Zoom_Selector_MC.SelectedIndex < 19) {
                    Zoom_Selector_MC.SelectedIndex += 1;
                    Zoom_Selector_MC_SelectedIndexChanged(null, null);
                }
                return true;
            } else if (keyData == (Keys.W)) { // Zoom -
                if (Zoom_Selector_MC.SelectedIndex > 0) {
                    Zoom_Selector_MC.SelectedIndex -= 1;
                    Zoom_Selector_MC_SelectedIndexChanged(null, null);
                }
                return true;
            } else if (keyData == (Keys.D)) { // Zmiana aktywnej warstwy +
                if (Layer_Selector_MC.SelectedIndex < ProjectData.Layers - 1) {
                    Layer_Selector_MC.SelectedIndex += 1;
                    Layer_Selector_MC_SelectedIndexChanged(null, null);
                }
                return true;
            } else if (keyData == (Keys.F)) { // Zmiana aktywnej warstwy -
                if (Layer_Selector_MC.SelectedIndex > 0) {
                    Layer_Selector_MC.SelectedIndex -= 1;
                    Layer_Selector_MC_SelectedIndexChanged(null, null);
                }
                return true;
            } 
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
