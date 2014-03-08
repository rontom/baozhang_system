using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using BLL;
using DALProfile;
using System.Runtime.InteropServices;

namespace 报障系统
{
    public partial class Tips : Form
    {
        private string connecctionstring = ConfigurationManager.AppSettings["connectionString"].ToString();
        private Encryption ecry = new Encryption();
        private DataSet ds = new DataSet();
        private int recordcurrent = 1;
        private int recordcount = 0;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCATION = 0x0002;
        public Tips()
        {
            InitializeComponent();
            bind();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tips_Load(object sender, EventArgs e)
        {
            
           // this.Top=Screen
            //this.Left = 0;

            Rectangle r = Screen.GetWorkingArea(this);
            this.Location = new Point(r.Right - this.Width, r.Bottom - this.Height);
        }


        private void bind()
        {
            try
            {
                SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(connecctionstring));
                conn.Open();
                string sql = "select PhoneNumber,MessageContent,ReceivedDate from GuZhangFirst where isnewsest=1";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //DataSet ds = new DataSet();
                da.Fill(ds);
               
                    recordcount = ds.Tables[0].Rows.Count;
                label2.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                label3.Text = Function.ReplaceGarbled(ds.Tables[0].Rows[0]["MessageContent"].ToString());
                label4.Text = ds.Tables[0].Rows[0]["ReceivedDate"].ToString();
                label5.Text = recordcurrent.ToString() + "/" +recordcount.ToString();
                conn.Close();
                if (recordcount == 1)
                {
                    pictureBox2.Enabled = false;
                    pictureBox3.Enabled = false;
                }
                else
                {
                    pictureBox2.Enabled = false;
                    pictureBox3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.Enabled = true;
            label2.Text = ds.Tables[0].Rows[recordcurrent]["PhoneNumber"].ToString();
            label3.Text = Function.ReplaceGarbled(ds.Tables[0].Rows[recordcurrent]["MessageContent"].ToString());
            label4.Text = ds.Tables[0].Rows[recordcurrent]["ReceivedDate"].ToString();
            recordcurrent++;
            label5.Text = recordcurrent.ToString() + "/" + recordcount.ToString();
            if (recordcurrent ==recordcount)
            {
                pictureBox3.Enabled = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2.Text = ds.Tables[0].Rows[recordcurrent-2]["PhoneNumber"].ToString();
            label3.Text = Function.ReplaceGarbled(ds.Tables[0].Rows[recordcurrent-2]["MessageContent"].ToString());
            label4.Text = ds.Tables[0].Rows[recordcurrent-2]["ReceivedDate"].ToString();
            recordcurrent--;
            label5.Text = recordcurrent.ToString() + "/" + recordcount.ToString();
            if (recordcurrent == 1)
            {
                pictureBox2.Enabled = false;
                pictureBox3.Enabled = true;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCATION, 0);
        }

       

        
    }
}