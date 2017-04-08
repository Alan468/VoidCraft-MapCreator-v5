using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VoidCraft_MapCreator_v5 {
    public partial class StartUpConfig : Form {
        public bool Status { get; set; }

        public StartUpConfig(string ProjectFilePath) {
            InitializeComponent();
            Status = false;

            NewLoad_Panel_SC.Hide();
            NewProject_Panel_SC.Hide();
            Layers_Panel_SC.Hide();

            if (ProjectFilePath != "") {
                ProjectFilePath = ProjectFilePath.Replace(ProjectFilePath.Split('\\').Last(),"");
                LoadProjectFromFile(ProjectFilePath);
                Status = true;
            }
            
            NewProject_Input_Path_SC.Text = "C:/";
            NewProject_Input_Name_SC.Text = "NowyProjekt";

            NewLoad_Panel_SC.Show();
        }

        private void NewProject_SC_Click(object sender, EventArgs e) {
            NewLoad_Panel_SC.Hide();
            NewProject_Panel_SC.Show();
        }

        private void NewProject_Back_SC_Click(object sender, EventArgs e) {
            NewLoad_Panel_SC.Show();
            NewProject_Panel_SC.Hide();
        }

        private void NewProject_SaveLocation_SC_Click(object sender, EventArgs e) {
            FolderBrowserDialog SaveLocation = new FolderBrowserDialog();
            SaveLocation.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = SaveLocation.ShowDialog();

            if (result == DialogResult.OK) {
                string Path = SaveLocation.SelectedPath;

                NewProject_Input_Path_SC.Text = Path;
            }

        }

        private void LoadProject_SC_Click(object sender, EventArgs e) {
            OpenFileDialog ProjectLocation = new OpenFileDialog();
            ProjectLocation.Filter = "(vcmd)|*.vcmd";

            DialogResult result = ProjectLocation.ShowDialog();

            if (result == DialogResult.OK) {

                string Path = ProjectLocation.FileName;

                if (Path.Split('.').Last() != "vcmd") {
                    MessageBox.Show("Nieprawidłowy format pliku!");
                    return;
                }

                Path = Path.Replace(Path.Split('\\').Last(), "");
                LoadProjectFromFile(Path);
                Status = true;
                Close();
            }
        }

        private void NewProject_Ok_SC_Click(object sender, EventArgs e) {
            NewProject_Input_Name_SC.Text=NewProject_Input_Name_SC.Text.Replace(" ", "");
            if (Directory.Exists(NewProject_Input_Path_SC.Text + "/" + NewProject_Input_Name_SC.Text)) {
                MessageBox.Show("Projekt o tej nazwie już istnieje!");
                return;
            }
            if (NewProject_Input_Name_SC.Text == "") {
                MessageBox.Show("Nieprawidłowa nazwa projektu!");
                return;
            }
            if (!Directory.Exists(NewProject_Input_Path_SC.Text)) {
                MessageBox.Show("Nieprawidłowy katalog!");
                return;
            }

            ProjectData.Path = NewProject_Input_Path_SC.Text + "/" + NewProject_Input_Name_SC.Text;
            ProjectData.Name = NewProject_Input_Name_SC.Text;
            ProjectData.Width = (int)NewProject_Input_Width_SC.Value;
            ProjectData.Height = (int)NewProject_Input_Height_SC.Value;
            ProjectData.Layers = (int)NewProject_Input_Layers_SC.Value;

            ProjectData.InitBitmaps(ProjectData.Layers);
            NewProject_Panel_SC.Hide();
            Layers_Panel_SC.Show();

            Layers_Layer_Selector_SC.Maximum = ProjectData.Layers - 1;
            UpdateDataGridView();
        }

        private void LoadProjectFromFile(string Path) {

            if (!File.Exists(Path + "texturelist.vctl")) {
                MessageBox.Show("Brak listy tekstur!\n"+Path);
                return;
            }
            try {
                using (StreamReader sr = new StreamReader(new FileStream(Path + "mapdata.vcmd", FileMode.Open))) {
                    ProjectData.Name = sr.ReadLine();
                    ProjectData.Width = int.Parse(sr.ReadLine());
                    ProjectData.Height = int.Parse(sr.ReadLine());
                    ProjectData.Layers = int.Parse(sr.ReadLine());
                    ProjectData.Path = Path;
                }
            } catch (ArgumentNullException ex) {
                MessageBox.Show("Plik projektu jest uszkodzony!");
            }

            ProjectData.InitBitmaps(ProjectData.Layers);

            try {
                using (StreamReader sr = new StreamReader(new FileStream(Path + "/texturelist.vctl", FileMode.Open))) {
                    string line = "";
                    while ((line = sr.ReadLine()) != null) {
                        string[] lineArr = line.Split(' ');
                        int Layer = int.Parse(lineArr[0]);
                        int Id = int.Parse(lineArr[1]);
                        string Name = lineArr[2];
                        string BmpPath = lineArr[3];


                        ProjectData.Bitmaps[Layer].Add(new Tile(Name, Layer, Id, Path+BmpPath));
                    }
                }
            } catch (ArgumentNullException ex) {
                MessageBox.Show("Plik tekstur jest uszkodzony!");
            }
        }

        private void Layers_Back_SC_Click(object sender, EventArgs e) {
            NewProject_Panel_SC.Show();
            Layers_Panel_SC.Hide();
        }

        private void Layers_Ok_SC_Click(object sender, EventArgs e) {

            ProjectData.SaveProjectData();

            // Run Main Editor Windnow
            Status = true;
            Close();
        }

        private void Layers_Add_Texture_SC_Click(object sender, EventArgs e) {
            int Layer = ((int)Layers_Layer_Selector_SC.Value);
            int Id = (int)Layers_Id_Selector_SC.Value;

            //if (ProjectData.Contain(Layer, Id)) {
            //    MessageBox.Show("Duplikat id w warstwie " + (int)Layers_Layer_Selector_SC.Value + "!");
            //    return;
            //}

            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "Image Files (JPG,PNG,BMP)|*.JPG;*.PNG;*.BMP";
            FileDialog.Multiselect = true;

            DialogResult result = FileDialog.ShowDialog();

            if (result == DialogResult.OK) {

                string[] FileNames = FileDialog.FileNames;

                foreach(string Dir in FileNames){

                    while (ProjectData.Contain(Layer, (int)Layers_Id_Selector_SC.Value)) {
                        Layers_Id_Selector_SC.Value++;
                    }

                    Id = (int)Layers_Id_Selector_SC.Value;
                    string Directory = Dir;
                    string name = Directory.Split('\\').Last().Split('.').First();
                    string path = "Texture\\L" + Layer + "\\" + Directory.Split('\\').Last();
                    ProjectData.Bitmaps[Layer].Add(new Tile(name, Layer, Id, Directory));

                    
                }
            }
            if(Layers_Layer_Selector_SC.Value < ProjectData.Layers-1)
                Layers_Layer_Selector_SC.Value++;
            Layers_Id_Selector_SC.Value = 0;
            UpdateDataGridView();
        }

        private void Layers_Remove_Texture_SC_Click(object sender, EventArgs e) {
            int Layer = ((int)Layers_Layer_Selector_SC.Value);
            int Id = (int)Layers_Id_Selector_SC.Value;

            if (!ProjectData.Contain(Layer, Id)) {
                MessageBox.Show("Brak tekstury o Id " + Id + " w warstwie " + Layer + "!");
                return;
            }

            if (MessageBox.Show("Czy napewno usunąć teksture z warstwy " + Layer + " o id " + Id + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                ProjectData.Bitmaps[Layer].Remove(ProjectData.Bitmaps[Layer][Id]);
                UpdateDataGridView();
            }
        }

        private void UpdateDataGridView() {
            Layers_Layers_Data_SC.ClearSelection();
            Layers_Layers_Data_SC.RowCount = 1;
            int row = 0;
            for (int i = 0; i < ProjectData.Layers; i++) {
                foreach (Tile B in ProjectData.Bitmaps[i]) {
                    Layers_Layers_Data_SC.RowCount += 1;
                    Layers_Layers_Data_SC[0, row].Value = B.Layer;
                    Layers_Layers_Data_SC[1, row].Value = B.Id;
                    Layers_Layers_Data_SC[2, row].Value = B.Name;
                    Layers_Layers_Data_SC[3, row].Value = B.Path;
                    if ((i % 2) == 0) {
                        Layers_Layers_Data_SC.Rows[row].DefaultCellStyle.BackColor = Color.White;
                    } else {
                        Layers_Layers_Data_SC.Rows[row].DefaultCellStyle.BackColor = Color.Wheat;
                    }
                    row++;
                }
            }

        }

        private void Layers_Layer_Selector_SC_ValueChanged(object sender, EventArgs e) {
            Layers_Id_Selector_SC.Value = 0;
        }
    }
}
