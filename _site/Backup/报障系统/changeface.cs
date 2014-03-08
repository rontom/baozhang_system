using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BLL;
using System.Configuration;
using System.Data.SqlClient;
using DALProfile;

namespace 报障系统
{
    public partial class changeface : Form
    {

        public static byte[] imgBytesIn;  //用来存储图片的二进制数
        public static int Ima_n = 0;
        private static string username;
        Encryption ecry = new Encryption();
        private string connectionstring = ConfigurationManager.AppSettings["connectionString"].ToString();
        UsersManage umg = new UsersManage();
        public changeface()
        {
            InitializeComponent();
        }

        public changeface(string username1)
        {
            InitializeComponent();
            username = username1;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog1, pictureBox1);
        }



        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)  //
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";   //指定OpenFileDialog控件打开的文件格式
            if (openF.ShowDialog(this) == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);  //将图片文件存入到PictureBox控件中
                    string strimg = openF.FileName.ToString();  //记录图片的所在路径
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //umg.ModiftyFace(username, imgBytesIn);
                SqlConnection conn = DBHelper.getConnection(ecry.Decrypto(connectionstring));
                string sql = "update Users set face=@face where UserName=@UserName ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] Parameter = new SqlParameter[]
            {
                new SqlParameter("@face",imgBytesIn),
                new SqlParameter("@UserName",username)
            };
                cmd.Parameters.AddRange(Parameter);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("头像已成功更换", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}