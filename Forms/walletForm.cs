﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRUS
{
    public partial class walletForm : Form
    {
        public walletForm()
        {
            InitializeComponent();
        }
        public void loadForm(object Form)
        {
            if (panel2.Controls.Count > 0) panel2.Controls.RemoveAt(0);
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            panel2.Tag = form;
            form.Show();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadForm(new weaponsForm());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            loadForm(new orderForm());
        }
    }
}
