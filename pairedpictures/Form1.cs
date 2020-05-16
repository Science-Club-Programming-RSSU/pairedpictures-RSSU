using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pairedpictures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            squares();
        }

        Random rdm = new Random();
        List<string> ics = new List<string>()
        {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Label firstClicked = null;
        Label secondClicked = null;

        private void squares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int rdmNumber = rdm.Next(ics.Count);
                    iconLabel.Text = ics[rdmNumber];
                    ics.RemoveAt(rdmNumber);
                    iconLabel.ForeColor = iconLabel.BackColor;
                }
            }
        }

        private void newgame()
        {
            System.Windows.Forms.Application.Restart();
            System.Environment.Exit(1);
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }



        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;


            if (secondClicked != null)
                return;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                win();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void win()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }


            MessageBox.Show("Ты победил!", "Поздравляю!");
            newgame();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }



        private void loserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = Color.Black;

            }
            MessageBox.Show("Для начала новой игры нажмите 'Новая игра'");

        }
    }
}

