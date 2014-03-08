using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text;
using System.Data.SqlClient;
using BLL;
using DALProfile;
using System.Configuration;

namespace 报障系统
{
    public partial class ModiftyPersonInfor : Form
    {

        private  string usernameup;
        public ModiftyPersonInfor()
        {
            InitializeComponent();
        }


        public ModiftyPersonInfor(string username)
        {
            InitializeComponent();
            Bind(username);
        }

        private void ModiftyPersonInfor_Load(object sender, EventArgs e)
        {   
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(truename.Text.ToString().Trim()=="")
            {
                MessageBox.Show("真实姓名不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            else
            {
                if(comboBox1.SelectedItem.ToString().Trim()=="")
                {
                    MessageBox.Show("性别不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
                else
                {
                    if(phone.Text.ToString().Trim()=="")
                    {
                        MessageBox.Show("性别不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    }
                    else
                    {
                        Updateuser();
                        //MessageBox.Show(comboBox1.SelectedItem.ToString());
                    }
                }
            }
        }


        private void Updateuser()
        {
            Encryption ecry = new Encryption();
            SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(ConfigurationManager.AppSettings["connectionString"].ToString()));
            conn.Open();
            string sql = "update Users set TrueName=@TrueName,sex=@sex,phone=@phone where UserName=@UserName";
            SqlParameter[] Parameter=new SqlParameter[]
            {
                new SqlParameter("@TrueName",truename.Text.ToString().Trim()),
                new SqlParameter("@sex",comboBox1.SelectedItem.ToString().Trim()),
                new SqlParameter("@phone",phone.Text.ToString().Trim()),
                new SqlParameter("@UserName",usernameup)
            };

            try
            {
                SqlCommand cmd=new SqlCommand(sql,conn);
                cmd.Parameters.AddRange(Parameter);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Bind(string username)
        {
            usernameup=username;
            Encryption ecry=new Encryption();
            SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(ConfigurationManager.AppSettings["connectionString"].ToString()));
            conn.Open();
            string sql = "select TrueName,sex,phone from Users where UserName=@UserName";
            SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@UserName",username)
            };
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(Parameter);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    truename.Text = dt.Rows[0]["TrueName"].ToString();
                    if (dt.Rows[0]["sex"].ToString().Trim() == "男")
                    {
                        this.comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        this.comboBox1.SelectedIndex = 1;
                    }
                    phone.Text = dt.Rows[0]["phone"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}