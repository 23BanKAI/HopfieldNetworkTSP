using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace HopfieldNetworkTSP
{
    public partial class HopfieldTSP : Form
    {
        public HopfieldTSP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                using (StreamReader reader = new StreamReader(filename))
                {
                    string fileContent = File.ReadAllText(filename);
                    string[] rows = fileContent.Split('\n');
                    int rowCount = rows.Length;

                    int columnCount = rows[0].Split(',').Length;
                    double[,] array = new double[rowCount, columnCount];

                    for (int i = 0; i < rowCount; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        for (int j = 0; j < columnCount; j++)
                        {
                            array[i, j] = int.Parse(columns[j]);
                        }
                    }
                    TSPHopfieldNetwork hopfieldNetwork = new TSPHopfieldNetwork();
                    hopfieldNetwork.HopfieldAlgorithm(array);
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog fileDialog = new OpenFileDialog();
             fileDialog.InitialDirectory = @"C:\";
             fileDialog.Filter = "Text Files|*.txt|All Files|*.*";
             if (fileDialog.ShowDialog() != DialogResult.OK)
             {
                 return;
             }*/
            StreamReader reader = new StreamReader("result.txt");
            string fileContents = reader.ReadToEnd();//File.ReadAllText(fileDialog.FileName);
            richTextBox1.Text = fileContents;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}