using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 报障系统
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoGenerateColumns = false;
            //SqlConnection conn = DBHelper.getConnection();
            
            //conn.Open();
            ////if (conn.State == close)
            ////{
            ////    MessageBox.Show("数据库连接失败");
            ////}
            ////else
            ////{
            
            //string sql = "select top 20 * from news";
            //SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            //ds.Dispose();
            //conn.Close();
            //}
            
        }

        private void Bind()
        {
            //SqlConnection conn = DBHelper.getConnection();
            //conn.Open();
            //string sql = "select top 20 * from news";
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            //ds.Dispose();
            //conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string action =dataGridView1.Columns[e.ColumnIndex].Name;//操作类型
            //SqlConnection conn = DBHelper.getConnection();
            //conn.Open();
            //switch (action)
            //{
            //    case "update":
            //        //获取相应列的数据ID,弹出加载了该ID数据详细信息的Form,用以修改

            //        break;
            //    case "删除":
            //        if (MessageBox.Show("确定删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //        {
            //            string sql = "delete from news where id=" + Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) + "";
            //            SqlCommand cmd = new SqlCommand(sql, conn);
            //            cmd.ExecuteNonQuery();
            //            Bind();

            //        }
            //        break;
            //    default:
            //        break;
            //}


        }

       
    }
}