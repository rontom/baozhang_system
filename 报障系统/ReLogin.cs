using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DALProfile;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 报障系统
{
    public partial class ReLogin : Form
    {
        private string username;
        public ReLogin()
        {
            InitializeComponent();
        }

        public ReLogin(string username1)
        {
            InitializeComponent();
            username = username1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (relog(textBox1.Text.ToString(), username))
            {
                MessageBox.Show("登录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                MessageBox.Show("您输入的密码有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
            }
        }


        private bool relog(string password,string username1)
        {
            Encryption ecry=new Encryption();
            SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(ConfigurationManager.AppSettings["connectionString"].ToString()));
            conn.Open();
            string sql = "select Password from Users where UserName=@UserName";
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
                    if (dt.Rows[0]["Password"].ToString() == Function.PasswordMD5(password))
                    {
                        string sqlsetonline = "update Users set Status='在线' where UserName=@UserName";
                        SqlParameter[] Parameterup = new SqlParameter[]
                        {
                            new SqlParameter("@UserName",username1)
                        };
                        SqlCommand cmdup = new SqlCommand(sqlsetonline, conn);
                        cmdup.Parameters.AddRange(Parameterup);
                        cmdup.ExecuteNonQuery();
                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                conn.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}