﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace HostelManagement
{
    public partial class Loading : MetroForm
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroProgressBar1.Value = metroProgressBar1.Value + 2;
            lblPercentage.Text = metroProgressBar1.Value + "%";
            if(metroProgressBar1.Value > 99)
            {
                timer1.Enabled = false;
                Login l = new Login();
                this.Hide();
                l.Show();
            }
        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
