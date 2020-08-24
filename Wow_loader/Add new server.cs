using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wow_loader
{
    public partial class Add_new_server : Form
    {


        public Add_new_server()
        {
            InitializeComponent();

            if (Form1.edit == true)
            {
                buttonAdd.Text = "Edit";
                textBoxName.Text = Serializacja.GlobalList.ServerList[Form1.x].Name;
                textBoxRealmList.Text = Serializacja.GlobalList.ServerList[Form1.x].RealmList;
                labelVersion.Text = Serializacja.GlobalList.ServerList[Form1.x].Version;
                labelPath.Text = Serializacja.GlobalList.ServerList[Form1.x].Path;
            }
            if (Form1.edit == false)
            {
                buttonAdd.Text = "Add";
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (Form1.edit == false)
            {
                Serializacja.Deserialization();
                Serializacja.GlobalList.ServerList.Add(new Serializacja.Server(
                    textBoxName.Text,
                    textBoxRealmList.Text,
                    labelVersion.Text,
                    labelPath.Text));
                Serializacja.Serialization();
                
                f1.dataGridView1.DataSource = Serializacja.GlobalList.ServerList;
                this.Close();

                
                
                
            }
            if (Form1.edit == true)
            {
                Serializacja.Deserialization();
                Serializacja.GlobalList.ServerList[Form1.x] = (new Serializacja.Server(
                    textBoxName.Text,
                    textBoxRealmList.Text,
                    labelVersion.Text,
                    labelPath.Text));
                Serializacja.Serialization();
                f1.dataGridView1.DataSource = Serializacja.GlobalList.ServerList;
                this.Close();


                
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
                        OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openfile.FileName = "Wow";


            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openfile.FileName;
                labelPath.Text = sourceFile;
                var versionInfo = FileVersionInfo.GetVersionInfo(sourceFile);
                string version = versionInfo.ProductVersion;
                labelVersion.Text = version;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(textBoxName.Text) && string.IsNullOrWhiteSpace(textBoxRealmList.Text) && string.IsNullOrWhiteSpace(labelVersion.Text))
            {
                this.Close();
            }

            else if (MessageBox.Show("Do you want to close this window", "WoW Loader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void Add_new_server_FormClosing(object sender, FormClosingEventArgs e)
        {

            
        }
    }
}
