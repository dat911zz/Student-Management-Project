using StudentManagement.Interface.IData;
using StudentManagement.Models;
using StudentManagement.Utilites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagement.Data.Database
{
    /// <summary>
    /// Interacting with SQL Databse 
    /// </summary>
    public class SQL : ISinhVienData, IMonHocData, ICTHocPhanData
    {
        //---log test server name : DESKTOP-GUE0JS7
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlCommandBuilder builder;
        DataTable tb;
        //Khởi tạo kết nối tới CSDL
        public SqlConnection GetConnection(string datasource, string database, string username, string password)
        {
            SqlConnection conn = new SqlConnection(DatabaseHelper.GenerateConnectionString(datasource, database, username, password));
            return conn;

        }
        //Test kết nối với mẫu chuỗi kết nối
        public SqlConnection GetConnection()
        {
            string datasource = $@"";
            string database = "SinhVien";
            string username = "test01";
            string password = "1234";
            return GetConnection(datasource, database, username, password);
        }

        public DataTable SetDataSinhVien()
        {
            return SetDataTable("dataGridView1", "SELECT * FROM SinhVien");
        }
        public DataTable SetDataMonHoc()
        {
            return SetDataTable("dataGridView1", "SELECT * FROM MonHoc");
        }

        public DataTable SetDataTable(string datagridview, string query)
        {
            tb = new DataTable(datagridview);
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, GetConnection());
            builder = new SqlCommandBuilder(da);
            da.Fill(tb);
            return tb;
        }
        public void UpdateData(DataTable tb)
        {
            if (da != null && builder != null)
            {
                da.Update(tb);
            }
        }
        public void FillGrid(DataGridView dgv)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM SinhVien", conn);
            DataTable tbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl);
            dgv.DataSource = tbl;
            dgv.ReadOnly = true;
            conn.Close();
        }
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> list = new List<SinhVien>();
            SqlConnection conn = GetConnection();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM SinhVien", conn);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string mssv = reader.GetString(0);
                        string tensv = reader.GetString(1);
                        string gioitinh = reader.GetString(2);
                        DateTime ngaysinh = reader.GetDateTime(3);
                        string lop = reader.GetString(4);
                        string khoa = reader.GetString(5);
                        SinhVien sv = new SinhVien(mssv, tensv, gioitinh, ngaysinh, lop, khoa);
                        list.Add(sv);
                    }
                }
            }
            conn.Close();
            return list;
        }

        public List<MonHoc> GetAllMH()
        {
            List<MonHoc> list = new List<MonHoc>();
            SqlConnection conn = GetConnection();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM MonHoc", conn);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string ten = reader.GetString(0);
                        int sotiet = reader.GetInt32(1);
                        MonHoc sv = new MonHoc(ten, sotiet);
                        list.Add(sv);
                    }
                }
            }
            conn.Close();
            return list;
        }
        
        public void GetAllCTHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            List<MonHoc> list = new List<MonHoc>();
            SqlConnection conn = GetConnection();
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM DKHP", conn);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        List<MonHoc> tmp = new List<MonHoc>(list_mh.ToArray());
                        //-------------INPUT DATA----------------
                        for (int mh_i = 0; mh_i < reader.FieldCount; mh_i++)
                        {
                            if (reader.GetInt32(mh_i) == 1)
                            {
                                //========Deep copy========= 
                                MonHoc c = new MonHoc(tmp[mh_i]);
                                //list_sv[i].MHDK.Add((MonHoc)c);
                                list_sv[i].CTHP.DSMH.Add(new KetQua(new MonHoc(c), new Diem()));
                            }
                        }
                        i++;
                    }
                }
                Console.WriteLine();
            }
            conn.Close();
        }
        public void Add(SinhVien sv)
        {
            throw new NotImplementedException();
        }

        public void Add(MonHoc sv)
        {
            throw new NotImplementedException();
        }

        public void Add(CTHocPhan cthp)
        {
            throw new NotImplementedException();
        }
    }
}
