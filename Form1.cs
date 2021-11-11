using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hashset
{
    public partial class Form1 : Form
    {
        
        List<string> bombs = new List<string>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        public void buttonevent(object sender, EventArgs e)
        {
            var button = sender as Button;
            Console.WriteLine(button.Name);
            foreach (string bomb in bombs)
            {
                if (bombs.Contains(button.Name))
                {
                    button.BackColor = Color.Red;
                    MessageBox.Show("Mayına Bastınız");
                    gamereset();
                    return;
                }
                else
                {
                    button.BackColor = Color.Green;
                    button.Enabled = false;

                }





            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void bombcheck()
        {
            
            
            string bomb = "button" + rnd.Next(0, 100).ToString();
            if (!bombs.Contains(bomb))
            { 
                bombs.Add(bomb);
            }
            else {
                bombcheck();
            }

        }
        private void bombpicker() {
            for (int i = 0; i < 20; i++)
            {
                bombcheck();
            }
            Console.WriteLine(bombs.ToString());
        
        }
        private void buttonplacer ()
        {

            int top = 35;
            for (int i = 0; i < 10; i++)
            {
                int left = 35;
                for (int j = 0; j < 10; j++)
                {
                    string temp = i.ToString() + j.ToString();
                    int name = Convert.ToInt32(temp);
                    Button button = new Button();
                    button.Name = "button" + name.ToString();
                    //button.Text = name.ToString();
                    Console.WriteLine(button.Name.ToString());
                    button.BackColor = Color.White;
                    button.Width = 30;
                    button.Height = 30;
                    button.Left = left;
                    button.Top = top;
                    button.Click += new EventHandler(buttonevent);
                    this.Controls.Add(button);
                    left = left + 35;
                }
                top = top + 35;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            buttonplacer();
            bombpicker();

        }
        private void Resetbutton_Click(object sender, EventArgs e)
        {
            gamereset();

        }

        private void gamereset()
        {

            foreach (Button button in this.Controls)
            {
                button.Enabled = true;
                button.BackColor = Color.White;


            }
            Random newrnd = new Random();
            this.rnd = newrnd;

            bombs.Clear();
            bombpicker();
           
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
