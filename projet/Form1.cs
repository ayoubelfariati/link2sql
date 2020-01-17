using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class Form1 : Form
    {
        mydataDataContext data = new mydataDataContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Poste4\source\repos\projet\projet\mydb.mdf;Integrated Security = True");
        private int exist()
        {
            var s = (from element in data.Table
                     where element.Cin == txt_recherche.Text
                     select element).Count();
           
            return s;
           
        }
        private void x ()
        {
            var n = (from v in data.Table
                     select v).Count();
            label8.Text = n.ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table tab = new Table()
            {
                Cin = textBox1.Text,
                Nom = textBox2.Text,
                Prenom = textBox3.Text
            };
            data.Table.InsertOnSubmit(tab);
            data.SubmitChanges();
            MessageBox.Show("kljsdkljvnlsdk");
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (exist() != 0)
            {
                var x = (from ellement in data.Table
                         where ellement.Cin == txt_recherche.Text
                         select ellement).Single();

                textBox6.Text = x.Cin;
                textBox5.Text = x.Nom;
                textBox4.Text = x.Prenom;
            }
            else
                MessageBox.Show("makaaynch ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(data.GetCommand(from ellement in data.Table select ellement).CommandText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (exist() != 0)
            {
                var x = (from element in data.Table
                         where element.Cin == txt_recherche.Text
                         select element).Single();
                data.Table.DeleteOnSubmit(x);
                data.SubmitChanges();
                MessageBox.Show("kljsdkljvnlsdk");
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
                MessageBox.Show("makaynch");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var x = (from element in data.Table
                     where element.Cin == txt_recherche.Text
                     select element).Single();
            x.Cin = textBox6.Text;
            x.Nom = textBox5.Text;
            x.Prenom = textBox4.Text;
            data.SubmitChanges();
            MessageBox.Show("kljsdkljvnlsdk");
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                x();
                if (comboBox1.SelectedIndex == 0)
                {
                    var x = from element in data.Table
                            orderby element.Cin ascending
                            select element;
                    dataGridView1.DataSource = x;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    var x = from element in data.Table
                            orderby element.Nom ascending
                            select element;
                    dataGridView1.DataSource = x;
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    var x = from element in data.Table
                            orderby element.Prenom ascending
                            select element;
                    dataGridView1.DataSource = x;
                }
            }
        }
    }
}
