﻿using quanlichannuoi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace quanlichannuoi.Admin
{
    public partial class hienthicongtrinhcapnuoc : UserControl
    {
        public hienthicongtrinhcapnuoc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM CongTrinhNuocSach ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtName.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn tìm kiếm
                string query = "SELECT * FROM CongTrinhNuocSach WHERE TenCongTrinh LIKE @Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", searchName);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
        }
        string ten;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ten = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                
            }
            catch { }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM CongTrinhNuocSach WHERE TenCongTrinh = @Name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", ten));
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để xóa.");
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            chinhsuathongtinnuocsach thongtin= new chinhsuathongtinnuocsach(ten);
            thongtin.ShowDialog();
        }
    }
}
