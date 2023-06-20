using System.Text;
using System.Windows.Forms;

namespace BMAlgorithm
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public Algorithm Algorithm
        {
            get => default;
            set
            {
            }
        }

        private void алгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void логжурналToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader("log.txt", Encoding.UTF8))
            {
                richTextBox1.Text = "";

                string text = sr.ReadToEnd();
                richTextBox1.AppendText(text);
                sr.Close();
            }

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader("help.txt", Encoding.UTF8))
            {
                richTextBox1.Text = "";

                string text = sr.ReadToEnd();
                richTextBox1.AppendText(text);
            }

        }

        private void историяЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DBViewer dBViewer = new DBViewer();
            dBViewer.ShowDialog();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

            richTextBox1.Dock = DockStyle.Fill;
            if (File.Exists("db.json") != true)
            {

                using (StreamWriter writer = new StreamWriter("db.json", true))
                {

                    writer.WriteLine("[]");
                    writer.Close();
                }

            }

            if (File.Exists("log.txt") != true)
            {
                using (FileStream fileStream = File.Create("log.txt"))
                {
                    // код для записи в файл
                }
            }

            if (File.Exists("help.txt") != true)
            {
                using (FileStream fileStream = File.Create("help.txt"))
                {



                }

            }

        }

        private void дляБинарныхПоследовательностейToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Algorithm algorithm = new Algorithm();
            algorithm.ShowDialog();

        }

        private void надПроизвольнымПолемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaloisBM Galgorithm = new GaloisBM();
            Galgorithm.ShowDialog();
        }
    }
}