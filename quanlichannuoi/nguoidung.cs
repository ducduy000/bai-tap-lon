﻿using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using quanlichannuoi.DAO;
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

namespace quanlichannuoi
{
    public partial class nguoidung : Form
    {
        public nguoidung()
        {
            InitializeComponent();
        }
        public nguoidung(string name)
        {
            InitializeComponent();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen FROM  dbo.NguoiDung WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ten = reader["HoTen"].ToString();
                            labelUserName.Text = ten;
                        }
                    }

                }

            }
        }
        private void nguoidung_Load(object sender, EventArgs e)
        {
            menu1.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            menu1.Visible = true;
            menu1.BringToFront();
        }
    }
}
