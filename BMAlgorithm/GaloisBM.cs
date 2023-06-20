using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Newtonsoft.Json;
using static System.Windows.Forms.AxHost;

namespace BMAlgorithm
{


    public partial class GaloisBM : Form
    {


        public class BMmeasures
        {

            public string originalregister { get; set; }
            public string shortregister { get; set; }
            public string linearcomm { get; set; }
            public int registerlength { get; set; }
            public string GF { get; set; }
            public string primpoly { get; set; }
            public string timewaste { get; set; }
            public string date { get; set; }

        }

        int GFTonum(int[] num, int field, int grade)
        {

            int result = 0;
            for (int i = 0; i < num.Length; i++)
            {

                result += num[i] * (int)Math.Pow(field, i);

            }
            return result;

        }
        static int[] NumtoGF(int number, int characteristic, int degree)
        {
            // Создаем массив для хранения коэффициентов полинома
            int[] coefficients = new int[degree + 1];

            // Вычисляем полиноминальное представление числа
            for (int i = degree; i >= 0; i--)
            {
                int power = (int)Math.Pow(characteristic, i);
                coefficients[degree - i] = number / power;
                number = number % power;
            }
            if (coefficients.Length > degree)
            {
                int[] b = new int[coefficients.Length - 1];
                Array.Copy(coefficients, 1, b, 0, coefficients.Length - 1);
                Array.Reverse(b);
                return b;
            }
            else
            {

                Array.Reverse(coefficients);
                return coefficients;

            }
        }

        static int[] PrimitivePoly(int field, int grade)
        {
            Random rnd = new Random();
            int[] a = new int[grade + 1];
            a[grade] = 1;
            for (int i = a.Length - 2; i > 0; i--)
            {

                a[i] = rnd.Next(0, field);

            }
            //a[0] = field - 1;
            a[0] = rnd.Next(0, field);
            return a;

        }
        static int FindIndex(int[][] b, int[] a)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].SequenceEqual(a))
                {
                    return i;
                }
            }
            return -1; // если массив a не найден в массиве b
        }
        int[] GFPolydiff(int[] poly, int[] poly2, int field)
        {
            int[] polynom = new int[poly.Length];
            poly.CopyTo(polynom, 0);
            int[] polynom2 = new int[poly2.Length];
            poly2.CopyTo(polynom2, 0);

            for (int i = 0; i < poly.Length; i++)
            {

                polynom[i] = GFDiff(polynom[i], polynom2[i], field);

            }

            return polynom;

        }

        int GFPolyMultiplier(int index1, int index2, int[][] field)
        {
            if (index1 == -1 || index2 == -1)
                return -1;

            int index = index1 + index2;
            if (index >= field.Length)
                index = index - field.Length + 1;



            return index;

        }

        int GFPolySummator(int index1, int index2, int[][] myfield, int field)
        {

            int[] arr1 = new int[myfield[index1].Length];
            myfield[index1].CopyTo(arr1, 0);
            int[] arr2 = new int[myfield[index2].Length];
            myfield[index2].CopyTo(arr2, 0);

            for (int i = 0; i < arr1.Length; i++)
            {

                arr1[i] = GFSum(arr1[i], arr2[i], field);

            }

            int index = Array.IndexOf(myfield, arr1);

            return index;

        }

        static int PrimeChecker(int n)
        {

            if (n == 1)
                return 0;

            int[] primenums = new int[n + 1];
            for (int a = 0; a < primenums.Length; a++)
            {
                primenums[a] = a;
            }

            primenums[1] = 0;
            int j;
            int i = 2;
            while (i <= n)
            {

                if (primenums[i] != 0)
                {

                    j = i + i;
                    while (j <= n)
                    {

                        primenums[j] = 0;
                        j = j + i;

                    }

                }
                i++;

            }

            for (int b = 0; b < primenums.Length; b++)
            {

                if (primenums[b] != 0)
                    primenums[b] = b;

            }


            if (Array.IndexOf(primenums, n) == -1)
            {
                return 1;
            }

            else
            {
                return 0;
            }

        }

        static int NaturalChecker(int grad)
        {

            if (grad >= 1) return 0;
            else return 1;
        }

        static int GFtofield(int a, int field)
        {

            if (a > field)
                while (a > field)
                    a -= field;
            else if (a < 0)
                while (a < 0)
                    a += field;
            return a;

        }

        static int GFReversed(int a, int field)
        {

            if (field == 0)
                return 1;
            else if (field == 1)
                return 0;
            int b = field;
            int x1 = 1;
            int x2 = 0;
            int y1 = 0;
            int y2 = 1;
            int q, r, x, y;
            while (b > 0)
            {

                q = a / b;
                r = a - q * b;
                x = x1 - q * x2;
                y = y1 - q * y2;

                a = b;
                b = r;
                x1 = x2;
                x2 = x;
                y1 = y2;
                y2 = y;


            }

            int d = a;
            x = x1;
            y = y1;
            if (x < 0)
                x += field;
            if (d > 1)
                return 0;
            else
                return x;

        }

        static int GFMult(int a, int b, int field)
        {

            int mult = a * b;
            if (mult >= field)
                while (mult >= field)
                    mult -= field;

            return mult;

        }


        static int GFDiff(int a, int b, int field)
        {

            int diff = a - b;
            if (diff < 0)
                diff += field;


            return diff;

        }

        static int GFSum(int a, int b, int field)
        {

            int sum = a + b;
            if (sum >= field)
                while (sum >= field)
                    sum -= field;


            return sum;

        }

        static int[] GFPolynomMult(int[] a, int[] b, int field)
        {

            int[] mult = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {



                if (a[i] != 0)
                {

                    for (int j = 0; j < b.Length; j++)
                    {

                        if (b[j] != 0)
                            mult[j + i] = GFMult(b[j], a[i], field);

                    }

                }

            }
            return mult;

        }

        static int[] GFPolynomDiff(int[] a, int[] b, int field)
        {

            int[] mult = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {

                mult[i] = GFDiff(a[i], b[i], field);

            }
            return mult;

        }
        static int[] GFPolynomSum(int[] a, int[] b, int field)
        {

            int[] mult = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {

                mult[i] = GFSum(a[i], b[i], field);

            }
            return mult;

        }

        int[][] FieldChecker(int[] poly, int field, int grade)
        {

            int[][] a = new int[(int)Math.Pow(field, grade)][];
            a[0] = new int[grade];
            a[0][0] = 1;
            a[1] = new int[grade];
            a[1][1] = 1;
            for (int i = 2; i < grade; i++)
            {

                a[i] = new int[grade];
                a[i][i] = 1;

            }

            int[] edged = new int[grade + 1];
            edged[grade] = 1;


            var result = Deconv(edged, poly, out double[] quotient, out double[] remainder);

            var res = Converter(result.quotient, result.remainder, field);



            int[] arrtowork = res.remainder;
            int[] loss = new int[arrtowork.Length - 1];

            for (int j = 0; j < loss.Length; j++)
                loss[j] = arrtowork[j];
            for (int i = 0; i < loss.Length; i++)
                loss[i] = GFtofield(loss[i], field);

            a[grade] = loss;

            for (int i = grade + 1; i < a.Length; i++)
            {

                a[i] = Polymult(i, a, field).Item1;

                for (int j = 0; j < i; j++)
                {

                    if (a[i].SequenceEqual(a[j]) == true && i != (int)Math.Pow(field, grade) - 1)
                        //FieldChecker(PrimitivePoly(field, grade), field, grade);
                        return new int[0][];
                }


            }

            return a;
        }

        static (int[], int[][]) Polymult(int index, int[][] grades, int field)
        {


            int[] nextgrade = new int[grades[0].Length];
            grades[index - 1].CopyTo(nextgrade, 0);
            int[] grade = new int[grades[0].Length];

            grades[1].CopyTo(grade, 0);
            //int[] lastgrade = grades[index];
            int tograde;
            int[] checkgrade = new int[grade.Length];

            for (int i = nextgrade.Length - 1; i >= 0; i--)
            {

                for (int j = grade.Length - 1; j >= 0; j--)
                {

                    if ((grade[j] != 0 && nextgrade[i] != 0) && (i + j >= nextgrade.Length))
                    {

                        if (i + j > grades.Length)
                            tograde = (i + j) - grades.Length - 1;

                        else
                            tograde = (i + j);
                        //if(tograde > nextgrade.Length)
                        grades[tograde].CopyTo(checkgrade, 0); ;
                        for (int k = 0; k < checkgrade.Length; k++)
                            checkgrade[k] = GFMult(nextgrade[i], checkgrade[k], field);
                        nextgrade[i] = 0;

                    }

                    else if (grade[j] != 0 && nextgrade[i] != 0)
                    {

                        nextgrade[i + j] = GFMult(nextgrade[i], grade[j], field);
                        nextgrade[i] = 0;

                    }
                }
            }

            for (int i = 0; i < nextgrade.Length; i++)
            {

                nextgrade[i] = GFSum(nextgrade[i], checkgrade[i], field);

            }

            return (nextgrade, grades);

        }

        static (double[] quotient, double[] remainder) Deconv(int[] dividend, int[] divisor, out double[] result, out double[] ost)
        {

            double[] diff = new double[dividend.Length];
            double[] diffor = new double[divisor.Length];

            for (int i = 0; i < dividend.Length; i++)
            {

                diff[i] = (int)dividend[i];

            }

            for (int i = 0; i < divisor.Length; i++)
            {

                diffor[i] = (int)divisor[i];

            }

            if (diff.Last() == 0)
            {
                throw new ArithmeticException("Старший член многочлена делимого не может быть 0");
            }
            if (diffor.Last() == 0)
            {
                throw new ArithmeticException("Старший член многочлена делителя не может быть 0");
            }
            ost = (double[])diff.Clone();
            result = new double[ost.Length - diffor.Length + 1];
            for (int i = 0; i < result.Length; i++)
            {
                double coeff = ost[ost.Length - i - 1] / diffor.Last();
                result[result.Length - i - 1] = coeff;
                for (int j = 0; j < diffor.Length; j++)
                {
                    ost[ost.Length - i - j - 1] -= coeff * diffor[diffor.Length - j - 1];
                }
            }




            return (result, ost);

        }

        static (int[] quotient, int[] remainder) Converter(double[] quot, double[] rem, int field)
        {

            int[] diff = new int[quot.Length];
            int[] diffor = new int[rem.Length];

            for (int i = 0; i < quot.Length; i++)
            {

                diff[i] = GFtofield((int)quot[i], field);

            }

            for (int i = 0; i < rem.Length; i++)
            {

                diffor[i] = GFtofield((int)rem[i], field);

            }

            return (diff, diffor);

        }

        (int[] primpoly, int[] linear, int length) GFGradeBM(int[] s, int field, int grade)
        {

            int[] a = new int[grade];
            a[grade - 1] = grade;
            int[][] myfield = new int[(int)Math.Pow(field, grade)][];
            int[] primpoly = PrimitivePoly(field, grade);
            //int[] primpoly = new int[] {2, 1, 1};
            myfield = FieldChecker(primpoly, field, grade);


            while (myfield.Length == 0)
            {
                primpoly = PrimitivePoly(field, grade);
                myfield = FieldChecker(primpoly, field, grade);
            }

            //myfield = Fieldsort(myfield, field, grade);

            int b = 0;
            int x = 1;
            int L, N, m, d;
            int n = s.Length;
            int[][] C = new int[n][];
            int[][] B = new int[n][];
            int[][] T = new int[n][];
            int[][] tempforb = new int[n][];

            for (int i = 0; i < n; i++)
            {

                C[i] = B[i] = T[i] = new int[grade];

            }
            int[] sum = new int[grade];
            //Initialization
            B[0][0] = C[0][0] = 1;
            N = L = 0;


            while (N < n)
            {
                d = FindIndex(myfield, NumtoGF(s[N], field, grade));
                sum = new int[grade];
                int[] res = new int[grade];
                for (int i = 1; i <= L; i++)
                {

                    int indexfromlinear = FindIndex(myfield, C[i]);
                    int[] tempfromseq = NumtoGF(s[N - i], field, grade);
                    int indexfromseq = FindIndex(myfield, tempfromseq);

                    int fielded = GFPolyMultiplier(indexfromlinear, indexfromseq, myfield);
                    if (fielded != -1)
                        sum = GFPolynomSum(sum, myfield[fielded], field);
                    else
                        sum = GFPolynomSum(sum, new int[grade], field);


                }
                if (d == -1)
                    res = GFPolynomSum(new int[grade], sum, field);
                else
                {
                    int[] id = new int[grade];
                    int tmp = d;
                    myfield[d].CopyTo(id, 0);
                    res = GFPolynomSum(id, sum, field);
                    d = tmp;
                }
                d = FindIndex(myfield, res);
                if (d == -1)
                {

                    x++;

                }

                else if (d != -1 && 2 * L > N)
                {

                    int db;


                    db = GFPolyMultiplier(d, (int)Math.Pow(field, grade) - b - 1, myfield);
                    if (field != 2)
                    {

                        int[] fieldindex = NumtoGF(field - 1, field, grade);
                        int fieldindexid = FindIndex(myfield, fieldindex);
                        db = GFPolyMultiplier(db, fieldindexid, myfield);

                    }
                    int[][] bcopy = new int[n][];
                    B.CopyTo(bcopy, 0);


                    for (int i = 0; i < bcopy.Length; i++)
                    {

                        Array.Copy(bcopy, tempforb, n);

                        if (GFPolyMultiplier(db, FindIndex(myfield, bcopy[i]), myfield) != -1)
                            bcopy[i] = myfield[GFPolyMultiplier(db, FindIndex(myfield, bcopy[i]), myfield)];

                        else
                            bcopy[i] = new int[grade];
                    }
                    int[][] temp = new int[bcopy.Length][];
                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = new int[grade];

                    for (int i = temp.Length - x - 1; i >= 0; i--)
                        if (Array.IndexOf(myfield, temp[i]) != 0 || Array.IndexOf(myfield, temp[i]) != (int)Math.Pow(field, grade) - 1)
                        {

                            temp[i + x] = bcopy[i];
                            temp[i] = new int[grade];

                        }
                    temp.CopyTo(bcopy, 0);

                    if (field == 2)
                    {
                        for (int i = 0; i < C.Length; i++)
                            C[i] = GFPolydiff(C[i], bcopy[i], field);

                    }

                    else
                    {

                        for (int i = 0; i < C.Length; i++)
                            C[i] = GFPolynomSum(C[i], bcopy[i], field);

                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        for (int j = 0; j < grade; j++)
                            Console.Write(C[i][j] + ", ");
                        Console.Write("\n");
                    }

                    //Array.Copy(tempforb, B, n);
                    x++;

                }

                else if (d != -1 && 2 * L <= N)
                {

                    int db;
                    Array.Copy(C, T, n);
                    //Array.Copy(B, tempforb, n);

                    int[][] bcopy = new int[n][];
                    B.CopyTo(bcopy, 0);


                    db = GFPolyMultiplier(d, (int)Math.Pow(field, grade) - b - 1, myfield);

                    if (field != 2)
                    {

                        int[] fieldindex = NumtoGF(field - 1, field, grade);
                        db = GFPolyMultiplier(db, FindIndex(myfield, fieldindex), myfield);

                    }

                    for (int i = 0; i < bcopy.Length; i++)
                    {

                        int another = FindIndex(myfield, bcopy[i]);
                        int myindex = GFPolyMultiplier(db, another, myfield);
                        if (myindex == -1)
                            bcopy[i] = new int[grade];
                        else
                            bcopy[i] = myfield[myindex];
                    }



                    int[][] temp = new int[bcopy.Length][];
                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = new int[grade];



                    for (int i = temp.Length - x - 1; i >= 0; i--)
                        if ((FindIndex(myfield, bcopy[i]) != 0) || (FindIndex(myfield, bcopy[i]) != (int)Math.Pow(field, grade) - 1) && (FindIndex(myfield, bcopy[i]) != -1))
                        {

                            /*
                            Console.WriteLine((FindIndex(myfield, B[i])));
                            for (int e = 0; e < myfield[0].Length; e++)
                               // Console.Write(myfield[FindIndex(myfield, B[i])][e] + ", ");

                            for (int ee = 0; ee < myfield[0].Length; ee++)
                              //Console.Write(B[i][ee] + ", ");
                            */
                            temp[i + x] = bcopy[i];
                            temp[i] = new int[grade];

                        }



                    temp.CopyTo(bcopy, 0);

                    for (int i = 0; i < C.Length; i++)
                    {
                        if (field == 2)
                            C[i] = GFPolydiff(C[i], bcopy[i], field);
                        else
                            C[i] = GFPolynomSum(C[i], bcopy[i], field);
                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        for (int j = 0; j < grade; j++)
                            Console.Write(C[i][j] + ", ");
                        Console.Write("\n");
                    }

                    Array.Copy(T, B, n);

                    L = N + 1 - L;
                    b = d;
                    x = 1;

                }


                N++;

            }

            int[] resulted = new int[C.Length];
            for (int i = 0; i < C.Length; i++)
            {


                if (C[i] != new int[grade])
                    resulted[i] = GFTonum(C[i], field, grade);
                else
                    resulted[i] = 0;



            }
            int[] veryresulted = new int[L + 1];
            for (int i = 0; i <= L; i++)
                veryresulted[i] = resulted[i];
            return (primpoly, veryresulted, L);

        }


        static int[] parser(string a)
        {

            string[] b = a.Split(',');
            int num = b.Length;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == String.Empty)
                    num--;
                //b[i] = Int32.Parse(b[i]);

            }

            int[] result = new int[num];
            num = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != String.Empty)
                {
                    result[num] = Int32.Parse(b[i]);
                    num++;

                }

            }

            return result;

        }



        static (int[] linear, int length) BerlekampMassey(int[] s, int field)
        {
            for (int i = 0; i < s.Length; i++)
            {

                GFtofield(s[i], field);

            }

            int b = 1;
            int x = 1;
            int L, N, m, d;
            int n = s.Length;
            int[] C = new int[n];
            int[] B = new int[n];
            int[] T = new int[n];

            int sum = 0;
            //Initialization
            B[0] = C[0] = 1;
            N = L = 0;
            //m = -1;

            //Algorithm core
            while (N < n)
            {
                d = s[N];
                for (int i = 1; i <= L; i++)
                    sum = GFSum(sum, GFMult(C[i], s[N - i], field), field);
                d = GFSum(d, sum, field);
                if (d == 0)
                {

                    x++;

                }

                else if (d != 0 && 2 * L > N)
                {

                    int db = GFMult(d, GFReversed(b, field), field);
                    int[] temp = new int[n];
                    temp[x] = db;
                    C = GFPolynomDiff(C, GFPolynomMult(temp, B, field), field);
                    x++;

                }

                else if (d != 0 && 2 * L <= N)
                {

                    Array.Copy(C, T, n);

                    int db = GFMult(d, GFReversed(b, field), field);
                    int[] temp = new int[n];
                    temp[x] = db;
                    C = GFPolynomDiff(C, GFPolynomMult(temp, B, field), field);

                    Array.Copy(T, B, n);

                    L = N + 1 - L;
                    b = d;
                    x = 1;

                }


                N++;
                sum = 0;
            }
            return (C, L);
        }

        public GaloisBM()
        {
            InitializeComponent();
        }

        private void numtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void gradetb_KeyPress(object sender, KeyPressEventArgs e)
        {

            char num = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void seqtb_KeyPress(object sender, KeyPressEventArgs e)
        {

            char num = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }

        }

        private void galoisbutt_Click(object sender, EventArgs e)
        {
            if (numtb.Text != string.Empty)
            {
                if (PrimeChecker(Int32.Parse(numtb.Text)) == 1)
                {

                    MessageBox.Show("Введите корректную характеристику!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {

                        writer.WriteLine($"{DateTime.Now} : Введите корректную характеристику\n\n");
                        writer.Close();

                    }

                    return;

                }
            }
            if (numtb.Text == string.Empty || gradetb.Text == string.Empty || seqtb.Text == string.Empty)
            {

                MessageBox.Show("Введите корректную характеристику!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {

                    writer.WriteLine($"{DateTime.Now} : Введите корректную характеристику\n\n");
                    writer.Close();

                }


            }

            if (parser(seqtb.Text).Length == 0)
            {

                MessageBox.Show("Введите корректную последовательность!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {

                    writer.WriteLine($"{DateTime.Now} : Введите корректную последовательность!\n\n");
                    writer.Close();

                }

            }
            


            if (((gradetb.Text == String.Empty) || (Int32.Parse(gradetb.Text)) == 1) && seqtb.Text != String.Empty)
            {

                int field = Int32.Parse(numtb.Text);
                int grade;
                if (gradetb.Text != "0")
                    grade = Int32.Parse(gradetb.Text);
                else
                    grade = 0;
                int[] a = parser(seqtb.Text);
                Stopwatch stopwatch = new Stopwatch(); // Засекаем время работы функции
                stopwatch.Start();
                Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
                long memorybeforeUsed = currentProcess.PrivateMemorySize64;
                var resulted = BerlekampMassey(a, field);
                stopwatch.Stop();
                double time = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000.0;
                lengthtb.Text = resulted.length.ToString();
                string result = "";
                string[] mass = { "\x2070", "\xB9", "\xB2", "\xB3", "\x2074", "\x2075", "\x2076", "\x2077", "\x2078", "\x2079" };
                for (int i = 0; i < resulted.linear.Length; i++)
                {

                    if (resulted.linear[i] == 1 && i == 0 && resulted.linear.Length > 1)
                    {

                        result += "1";


                    }

                    else if (resulted.linear[i] != 0)
                    {

                        result += " + ";
                        char[] gradebm = i.ToString().ToCharArray();
                        string graded = resulted.linear[i].ToString() + "x";

                        for (int j = 0; j < gradebm.Length; j++)
                        {

                            graded += mass[Convert.ToInt32(new string(gradebm[j], 1))];

                        }

                        result += graded;

                    }


                }

                string ended = "";
                for (int i = resulted.length - 1; i >= 0; i--)
                {
                    if (i != 0)
                        ended += a[i].ToString() + ", ";
                    else
                        ended += a[i].ToString();

                }

                string started = "";

                for (int i = 0; i < a.Length; i++)
                {
                    if (i != a.Length - 1)
                        started += a[i].ToString() + ", ";
                    else
                        started += a[i].ToString();

                }

                lineartb.Text = result;
                int L = resulted.length - 1;
                string regcond = "";
                while (L >= 1)
                {

                    regcond += a[L].ToString() + ",";
                    L--;
                }
                regcond += a[0].ToString();
                regstatetb.Text = regcond;




                string date = DateTime.Now.ToString();

                var measure = new BMmeasures
                {
                    originalregister = started,
                    shortregister = ended,
                    linearcomm = result,
                    registerlength = resulted.length,
                    GF = field.ToString(),
                    primpoly = "-",
                    timewaste = time.ToString() + "мс.",
                    date = date
                };

                List<BMmeasures> objects = JsonConvert.DeserializeObject<List<BMmeasures>>(File.ReadAllText("db.json"));
                objects.Add(measure);
                string updatedJson = JsonConvert.SerializeObject(objects);
                File.WriteAllText("db.json", updatedJson);

                currentProcess.Refresh();
                long memoryafterUsed = currentProcess.PrivateMemorySize64;

                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {

                    writer.WriteLine($"{DateTime.Now} : Входная последовательность: {started}\nКратчайший регистр: {ended}");
                    writer.WriteLine($"Функция обратной связи: {result}\nДлина минимального регистра: {resulted.length}\nПоле:{field.ToString()}");
                    writer.WriteLine($"Время выполнения: {time} мс.\nПамяти задействовано: {memoryafterUsed} байт\n\n");
                    writer.Close();
                }

            }

            



            else if (((gradetb.Text != String.Empty) && (Int32.Parse(gradetb.Text)) != 1) && seqtb.Text != String.Empty)
            {

                int[] a = parser(seqtb.Text);
                int field = Int32.Parse(numtb.Text);
                int grade = Int32.Parse(gradetb.Text);

                var bf = GFGradeBM(a, field, grade);

                Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
                long memorybeforeUsed = currentProcess.PrivateMemorySize64;

                Stopwatch stopwatch = new Stopwatch(); // Засекаем время работы функции
                stopwatch.Start();

                while (stopwatch.Elapsed.TotalSeconds < (int)Math.Pow(field, grade))
                {
                    var less = GFGradeBM(a, field, grade);
                    if (less.length < bf.length)
                        bf = less;

                    // Прерывание цикла, если прошло field^grade секунд
                    if (stopwatch.Elapsed.TotalSeconds >= field + grade)
                    {
                        break;
                    }
                }

                stopwatch.Stop();
                double time = (double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000.0;
                lengthtb.Text = bf.length.ToString();
                string ended = "";
                for (int i = bf.length - 1; i >= 0; i--)
                {
                    if (i != 0)
                        ended += a[i].ToString() + ", ";
                    else
                        ended += a[i].ToString();

                }

                string started = "";

                for (int i = 0; i < a.Length; i++)
                {
                    if (i != a.Length - 1)
                        started += a[i].ToString() + ", ";
                    else
                        started += a[i].ToString();

                }

                string endly = "";

                for (int i = bf.length; i >= 0; i--)
                {
                    if (i != bf.length - 1)
                        endly += a[i].ToString() + ", ";
                    else
                        endly += a[i].ToString();

                }
                string result = "";
                string[] mass = { "\x2070", "\xB9", "\xB2", "\xB3", "\x2074", "\x2075", "\x2076", "\x2077", "\x2078", "\x2079" };
                for (int i = 0; i < bf.linear.Length; i++)
                {

                    if (bf.linear[i] == 1 && i == 0 && bf.linear.Length > 1)
                    {

                        result += "1";


                    }

                    else if (bf.linear[i] != 0)
                    {

                        result += " + ";
                        char[] gradebm = i.ToString().ToCharArray();
                        string graded = bf.linear[i].ToString() + "x";

                        for (int j = 0; j < gradebm.Length; j++)
                        {

                            graded += mass[Convert.ToInt32(new string(gradebm[j], 1))];

                        }

                        result += graded;

                    }


                }

                string primy = "";

                for (int i = 0; i < bf.primpoly.Length; i++)
                {

                    if (i == 0 && bf.primpoly.Length > 1)
                    {

                        primy += bf.primpoly[0].ToString();


                    }

                    else if (bf.primpoly[i] != 0)
                    {

                        primy += " + ";
                        char[] gradebm = i.ToString().ToCharArray();
                        string graded = bf.primpoly[i].ToString() + "x";

                        for (int j = 0; j < gradebm.Length; j++)
                        {

                            graded += mass[Convert.ToInt32(new string(gradebm[j], 1))];

                        }

                        primy += graded;

                    }


                }

                string gf = field.ToString() + mass[grade];
                lineartb.Text = result;
                regstatetb.Text = ended;
                primpolytb.Text = primy;

                string date = DateTime.Now.ToString();

                var measure = new BMmeasures
                {
                    originalregister = started,
                    shortregister = ended,
                    linearcomm = result,
                    registerlength = bf.length,
                    GF = gf,
                    primpoly = primy,
                    timewaste = time.ToString() + "мс.",
                    date = date
                };

                List<BMmeasures> objects = JsonConvert.DeserializeObject<List<BMmeasures>>(File.ReadAllText("db.json"));
                objects.Add(measure);
                string updatedJson = JsonConvert.SerializeObject(objects);
                File.WriteAllText("db.json", updatedJson);
                currentProcess.Refresh();
                long memoryafterUsed = currentProcess.PrivateMemorySize64;

                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {

                    writer.WriteLine($"{DateTime.Now} : Входная последовательность: {started}\nКратчайший регистр: {ended}");
                    writer.WriteLine($"Функция обратной связи: {result}\nДлина минимального регистра: {bf.length}\nПоле:{gf}");
                    writer.WriteLine($"Время выполнения: {time} мс.\nПамяти задействовано: {memoryafterUsed} байт\n\n");
                    writer.Close();
                }

            }


        }
    }
}
