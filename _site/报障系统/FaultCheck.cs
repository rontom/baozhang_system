using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 报障系统
{
    public partial class FaultCheck : Form
    {
        public FaultCheck()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = true;
        }

        private void FaultCheck_Load(object sender, EventArgs e)
        {
            this.panel1.Visible =false;
            this.panel2.Visible = false;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}