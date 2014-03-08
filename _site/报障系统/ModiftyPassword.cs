using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DALProfile;
using BLL;
using System.Configuration;
namespace 报障系统
{
    public partial class modiftypassword : Form
    {

        private string username;
        public modiftypassword()
        {
            InitializeComponent();
        }

        public modiftypassword(string username1)
        {
            InitializeComponent();
            username = username1;
        }


        private void 修改密码_Load(object sender, EventArgs e)
        {

        }

        private void modifty_Click(object sender, EventArgs e)
        {
            if (oldpassword.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请填写旧密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (newpassword.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("请填写新密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (checkpassword.Text.ToString().Trim() == "")
                    {
                        MessageBox.Show("请再次输入新密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (checkpassword.Text.ToString().Trim() != newpassword.Text.ToString().Trim())
                        {
                            MessageBox.Show("两次输入的密码不一致，请重新输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            checkpassword.Text = "";
                            newpassword.Text = "";
                        }
                        else
                        {
                            
                             string result= ModiftyPassword(username, Function.PasswordMD5(oldpassword.Text.ToString().Trim()), Function.PasswordMD5(newpassword.Text.ToString().Trim()));
                             if (result == "原密码不正确")
                             {
                                 MessageBox.Show("原密码不正确，请重新输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 oldpassword.Text = "";
                                 newpassword.Text = "";
                                 checkpassword.Text = "";
                             }
                             else
                             {
                                 MessageBox.Show("恭喜您！密码修改成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 this.Close();
                             }
                        }
                    }
                }
            }
        }


        private string ModiftyPassword(string username, string oldpassword, string newpassword)
        {
            Encryption ecry=new Encryption();
            SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(ConfigurationManager.AppSettings["connectionString"]));
            conn.Open();
            string sqlcheckold = "select Password from Users where UserName=@UserName";
            SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@UserName",username)
            };

            SqlCommand cmd = new SqlCommand(sqlcheckold, conn);
            cmd.Parameters.AddRange(Parameter);
            string password =cmd.ExecuteScalar().ToString();

            if (password == oldpassword)
            {
                try
                {
                    string sqlupdate = "update Users set Password=@Password where UserName=@UserName";
                    SqlParameter[] Parameter1 = new SqlParameter[]
                    {
                        new SqlParameter("@Password",newpassword),
                        new SqlParameter("@UserName",username)
                    };
                    SqlCommand cmd1 = new SqlCommand(sqlupdate,conn);
                    cmd1.Parameters.AddRange(Parameter1);
                    cmd1.ExecuteNonQuery();
                    return "修改成功";
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //return "";
                }
            }
            else
            {
                return "原密码不正确";
               
            }
            
        }

        private void closepassword_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}