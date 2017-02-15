using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TP640
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = null;

            string dbPath =  "Data Source =" + "F:/王冠雄/T640/tp640.db";
            //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建

            //写入数据
            if (part_id.Text == null || part_id.Text=="")
            {
                MessageBox.Show("请输入零件号");
                return;
            }
            if (purch_id.Text == null)
                purch_id.Text = "\"\"";
            if (stand.Text == null)
                stand.Text = "\"\"";
            if (name.Text == null || name.Text == "") {
                MessageBox.Show("请输入名称");
                return;
            }
            if (sort.Text == null || sort.Text=="")
            {
                MessageBox.Show("请输入机床部位");
                return;
            }
            if (numb.Text == null)
                numb.Text = "\"\"";
            if (brand.Text == null)
                brand.Text = "\"\"";
            if (material.Text == null)
                material.Text = "\"\"";
            if (type.Text == null)
                type.Text = "\"\"";

            SQLiteCommand cmd = new SQLiteCommand(conn);

            string sql = "INSERT INTO 部件目录 (零件编号,外购编号,标准件规格,名称,品牌,材质,部件类型,是否使用,是否为标准件) VALUES('" + part_id.Text + "','" + purch_id.Text + "','" + stand.Text + "','" + name.Text + "','"  + brand.Text + "','" + material.Text + "'," + "'" + type.Text + "',1," + Convert.ToInt32(checkBox1.Checked).ToString() + ")";
            try
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                sql = "INSERT INTO sort1 (机床部位,零件号,数量) VALUES('" + sort.Text + "','" + part_id.Text + "','" + numb.Text + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //label11.Text = sql;
            //part_id.Text = sql;

            //查询数据
            sql = "select * from 部件目录";
            cmd.CommandText = sql;

            SQLiteDataReader reader = cmd.ExecuteReader();

            //读取数据
            while (reader.Read())
            {
                label11.Text = reader["零件编号"].ToString(); //label11.Text + "\r\n" + reader["零件编号"].ToString();
                //MessageBox.Show(reader["零件编号"].ToString());
            }
            //MessageBox.Show("OK");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
