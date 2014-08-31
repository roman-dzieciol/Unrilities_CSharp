using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UnrilitiesForms
{
    public partial class Form1 : Form
    {
        private PackageDataSource packageData;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }


        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            /*OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Unreal Engine Script Packages (*.u)|*.u|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 2;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = dialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            Program.OpenPackage(myStream, this);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }*/

            myStream = File.OpenRead("Core.u");
            OpenPackage(myStream);

        }


        ListView newListView()
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.VirtualMode = true;
            listView.View = View.Details;
            listView.GridLines = true;
            return listView;
        }

        void OpenPackage(Stream stream)
        {
            packageData = new PackageDataSource(stream);

            TabControl tabs = (TabControl)Controls["panel1"].Controls["tabControl1"];
            tabs.Controls.Clear();

            TabPage namePage = new TabPage("NameTable");
            TabPage importPage = new TabPage("ImportTable");
            TabPage exportPage = new TabPage("ExportTable");

            ListView nameTableListView = newListView();
            ListView exportTableListView = newListView();
            ListView importTableListView = newListView();

            packageData.nameTableDataSource.SetupListView(nameTableListView);
            packageData.exportTableDataSource.SetupListView(exportTableListView);
            packageData.importTableDataSource.SetupListView(importTableListView);

            namePage.Controls.Add(nameTableListView);
            exportPage.Controls.Add(exportTableListView);
            importPage.Controls.Add(importTableListView);

            tabs.Controls.Add(namePage);
            tabs.Controls.Add(exportPage);
            tabs.Controls.Add(importPage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Panel panel = (Panel)this.Controls["panel1"];

            //TabControl tabControl = new TabControl();
            //tabControl.Dock = DockStyle.Fill;
            //tabControl.Location = 

            //this.Controls.Add(tabControl);
        }
    }
}
