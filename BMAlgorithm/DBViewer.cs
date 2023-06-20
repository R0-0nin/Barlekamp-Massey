using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BMAlgorithm
{
    public partial class DBViewer : Form
    {
        public DBViewer()
        {
            InitializeComponent();
        }

        public Menu Menu
        {
            get => default;
            set
            {
            }
        }

        private void DBViewer_Load(object sender, EventArgs e)
        {
            var result = JsonConvert.DeserializeObject<List<Algorithm.BMmeasures>>(File.ReadAllText("db.json"));
            dataGridView1.DataSource = result;

            if (result != null)
            {
                this.dataGridView1.Columns["originalregister"].HeaderText = "Входная последовательность";
                this.dataGridView1.Columns["shortregister"].HeaderText = "Состояние минимального регистра";
                this.dataGridView1.Columns["linearcomm"].HeaderText = "Функция обратной связи";
                this.dataGridView1.Columns["registerlength"].HeaderText = "Длина минимального регистра";
                this.dataGridView1.Columns["primpoly"].HeaderText = "Примитивный многочлен";
                this.dataGridView1.Columns["GF"].HeaderText = "Поле";
                this.dataGridView1.Columns["timewaste"].HeaderText = "Время выполнения";
                this.dataGridView1.Columns["date"].HeaderText = "Дата";

            }

            dataGridView1.Dock = DockStyle.Fill;

            // Установить свойство AutoSizeMode для каждого столбца в значение Fill
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Установить свойство Resizable для каждого столбца в значение Fill
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Resizable = DataGridViewTriState.True;
            }
        }
    }
}
