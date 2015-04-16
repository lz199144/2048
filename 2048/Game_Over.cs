using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2048
{
    public partial class Game_Over : Form
    {
        public Game_Over()
        {
            InitializeComponent();
        }
        public int g { get; set;}
        public int bg { get; set; }


        private void Game_Over_Load(object sender, EventArgs e)
        {
            label2.Text += g;
            label3.Text += bg;
            this.TopLevel = true;
            
        }
    }
}
