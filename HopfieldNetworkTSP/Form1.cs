namespace HopfieldNetworkTSP
{
    public partial class Form1 : Form
    {
        public Form1()
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
                    int[,] array = new int[rowCount, columnCount];

                    for (int i = 0; i < rowCount; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        for (int j = 0; j < columnCount; j++)
                        {
                            array[i, j] = int.Parse(columns[j]);
                        }
                    }
                }
            }
        }
    }
}