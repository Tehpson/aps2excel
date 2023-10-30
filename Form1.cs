using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace aps2excel
{
    public partial class Form1 : Form
    {
        public string? FilePath { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "APL files (*.aps)|*.aps"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.EndsWith(".aps", StringComparison.OrdinalIgnoreCase))
                {
                    FilePath = openFileDialog.FileName;
                    FilePathlbl.Text = FilePath;
                }
                else
                    MessageBox.Show("Plase select a valid .aps file.");
            }
        }
        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath))
                FileConvertor.Convert(FilePath);
            else
                MessageBox.Show("Plase Select a file");
        }
    }
}