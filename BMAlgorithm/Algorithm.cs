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
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics.PerformanceData;

namespace BMAlgorithm
{
    public partial class Algorithm : Form
    {
        public Algorithm()
        {
            InitializeComponent();
        }

        /*
        public DBViewer DBViewer
        {
            get => default;
            set
            {
            }
        }
        */
        public class BMmeasures
        {

            public string originalregister { get; set; }
            public string shortregister { get; set; }
            public string linearcomm { get; set; }
            public int registerlength { get; set; }
            public string primpoly { get; set; }
            public string GF { get; set; }
            public string timewaste { get; set; }
            public string date { get; set; }


        }

        public static (int length, string binarystring, string linearcomm) BarlekampMassey(int[] s)
        {


            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            long memorybeforeUsed = currentProcess.PrivateMemorySize64;
            //long memoryUsed = currentProcess.PeakVirtualMemorySize64;
            Stopwatch stopwatch = new Stopwatch(); // Засекаем время работы функции
            stopwatch.Start();
            string startedbinary = ""; // Задаем переменные
            int L;
            int N;
            int M;
            int d;
            int n = s.Length;
            byte[] c = new byte[n];
            byte[] b = new byte[n];
            byte[] t = new byte[n];
            string linearcomm = "";

            for (int i = 0; i < n; i++)
            {

                startedbinary += s[i].ToString();

            }

            b[0] = c[0] = 1;

            N = 0;
            L = 0;
            M = -1;


            while (N < n) // Основной цикл алгоритма
            {
                d = s[N];

                for (int i = 1; i <= L; i++)
                {


                    d = d ^ (c[i] & s[N - i]);//(d+=c[i]*s[N-i] mod 2)


                }
                if (d == 1) // Если данный регистр или функция обратной связи не устраивают
                {
                    Array.Copy(c, t, n);    //Копируем массив
                    for (int i = 0; (i + N - M) < n; i++)
                        c[i + N - M] ^= b[i]; // Изменение обратной связи 

                    if (L <= (N >> 1)) // L <= N / 2?
                    {

                        L = N + 1 - L; // Обновляем L, M
                        M = N;
                        Array.Copy(t, b, n);    //Копируем массив

                    }

                }


                N++;

            }



            int length = L;
            for (int i = 0; i < n; i++)
            {

                linearcomm += c[i].ToString();


            }
            stopwatch.Stop();

            // Process currentProcess = Process.GetCurrentProcess();
            //long memoryUsed = currentProcess.WorkingSet64;
            currentProcess.Refresh();
            long memoryafterUsed = currentProcess.PrivateMemorySize64;
            //var memuse = currentProcess.PeakVirtualMemorySize64 - memoryUsed;
            double time = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000.0;
            string ended = startedbinary.Substring(0, length);
            char[] arr = ended.ToCharArray();
            Array.Reverse(arr);
            if (length == linearcomm.Length)
                linearcomm = linearcomm.Substring(0, length) + "0";
            else
                linearcomm = linearcomm.Substring(0, length + 1);

            char[] temp = linearcomm.ToCharArray();
            string tempstr = "";

            string[] mass = { "\x2070", "\xB9", "\xB2", "\xB3", "\x2074", "\x2075", "\x2076", "\x2077", "\x2078", "\x2079" };

            for (int i = 0; i < temp.Length; i++)
            {

                if (temp[i] == '1' && i == 0 && temp.Length > 1)
                {

                    tempstr += "1";
                    /*
                    if(i != temp.Length - 1)
                        tempstr += " + ";
                    */

                }

                else if (temp[i] == '1')
                {


                    tempstr += " + ";

                    char[] grade = i.ToString().ToCharArray();
                    string graded = "x";

                    for (int j = 0; j < grade.Length; j++)
                    {

                        graded += mass[Convert.ToInt32(new string(grade[j], 1))];

                    }

                    tempstr += graded;

                    /*
                    if (i != temp.Length - 1)
                        tempstr += " + ";
                    */
                }



            }

            linearcomm = tempstr;

            ended = new string(arr);


            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {

                writer.WriteLine($"{DateTime.Now} : Входная последовательность: {startedbinary}\nКратчайший регистр: {ended}");
                writer.WriteLine($"Функция обратной связи: {linearcomm}\nДлина минимального регистра: {length}\nВремя выполнения: {time} мс.");
                writer.WriteLine($"Памяти задействовано: {memoryafterUsed} байт\n\n");
                writer.Close();
            }

            string date = DateTime.Now.ToString();

            var measure = new BMmeasures
            {
                originalregister = startedbinary,
                shortregister = ended,
                linearcomm = linearcomm,
                registerlength = length,
                primpoly = "-",
                GF = "2",
                timewaste = time.ToString() + "мс.",
                date = date
            };

            // File.Exists("db.json") ? JsonConvert.DeserializeObject<BMmeasures>(File.ReadAllText("db.json")) : File.Create("db.json");

            List<BMmeasures> objects = JsonConvert.DeserializeObject<List<BMmeasures>>(File.ReadAllText("db.json"));
            objects.Add(measure);
            string updatedJson = JsonConvert.SerializeObject(objects);
            File.WriteAllText("db.json", updatedJson);
            //ended
            return (length, ended, linearcomm);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            char[] a = binarybox.Text.ToArray();
            int[] binary = Array.ConvertAll(a, c => (int)Char.GetNumericValue(c));

            try
            {
                var reg = BarlekampMassey(binary);
                registerbox.Text = reg.binarystring;
                lengthbox.Text = reg.length.ToString();
                functb.Text = reg.linearcomm;
            }

            catch (Exception ex)
            {

                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {

                    writer.WriteLine($"{DateTime.Now} : {ex.Message}\n\n");
                    MessageBox.Show("Введите полином!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    writer.Close();
                    //writer.WriteLine($"Памяти задействовано: {memoryUsed} байт\n\n");
                }

            }

        }

        private void binarybox_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            char num = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 50) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }
    }
}
