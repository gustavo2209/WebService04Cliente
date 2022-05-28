using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebService04Cliente
{
    public partial class Form1 : Form
    {

        private PeruWs.WebServicePeru combos;

        public Form1()
        {
            InitializeComponent();
            combos = new PeruWs.WebServicePeru();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Departamentos();
        }

        private void Departamentos()
        {
            object[][] depa = combos.departamentos();

            comboBox1.Items.Clear();

            foreach(object[] d in depa)
            {
                comboBox1.Items.Add(new Item(Convert.ToInt32(d[0]), Convert.ToString(d[1])));
            }

            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "text";

            comboBox1.SelectedIndex = 0;
        }

        // CLASE AUXILIAR PARA POBLAR COMBOS
        class Item
        {
            private int id;
            private string text;

            public Item(int id, string text)
            {
                this.id = id;
                this.text = text;
            }

            public Item()
            {
            }

            public int Id { get => id; set => id = value; }

            public string Text { get => text; set => text = value; }
        }
    }
}
