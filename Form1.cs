using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_zakupów
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Nic nie podałeś do dodania!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                if (pasekPostepu.Value < 100)
                {
                    if (!lista.Items.Contains(textBox1.Text))
                    {
                        lista.Items.Add(textBox1.Text);
                        pasekPostepu.Value += 10;
                        labelBar.Text = $"{pasekPostepu.Value}%";


                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Już ta rzecz jest na liście. \nNapewno chcesz dodać jeszcze raz?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            lista.Items.Add(textBox1.Text);
                            pasekPostepu.Value += 10;
                            labelBar.Text = $"{pasekPostepu.Value}%";

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Przekroczyłeś limit 10 rzeczy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void wyjdźToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nic nie podałeś do usunięcia!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lista.Items.Contains(textBox1.Text))
                {
                    lista.Items.Remove(textBox1.Text);
                    pasekPostepu.Value -= 10;
                    labelBar.Text = $"{pasekPostepu.Value}%";

                }
                else
                {
                MessageBox.Show("Nie ma takiego przedmiotu na liście!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lista.Items.Count != 0)
            {
                lista.Items.Clear();
                pasekPostepu.Value = 0;
                labelBar.Text = $"{pasekPostepu.Value}%";

            }
            else
            {
                MessageBox.Show("Lista już jest pusta!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
