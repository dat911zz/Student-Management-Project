using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace StudentManagement.Data.Database
{
    /// <summary>
    /// Interacting with SQL Databse 
    /// </summary>
    public class SQL
    {
        //---log test server name : DESKTOP-GUE0JS7
        SqlCommand cmd = new SqlCommand();
        Utilites.DatabaseHelper unt = new Utilites.DatabaseHelper();
        //Khởi tạo kết nối tới CSDL
        public SqlConnection GetConnection(string datasource, string database, string username, string password)
        {
            SqlConnection conn = new SqlConnection(unt.GenerateConnectionString(datasource, database, username, password));
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
        ////Lấy thông tin từ bảng DSSV
        //public void extractDSSVTable(string query, ref List<SinhVien> list)
        //{
        //    cmd.CommandText = query;
        //    using (DbDataReader reader = cmd.ExecuteReader())
        //    {
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                string mssv = reader.GetString(0);
        //                string tensv = reader.GetString(1);
        //                string gioitinh = reader.GetString(2);
        //                DateTime ngaysinh = reader.GetDateTime(3);
        //                string lop = reader.GetString(4);
        //                string khoa = reader.GetString(5);
        //                SinhVien sv = new SinhVien(mssv, tensv, gioitinh, ngaysinh, lop, khoa);
        //                list.Add(sv);
        //            }
        //        }
        //    }
        //}
        ////Lấy thông tin từ bảng DKHP
        //public void extractDKHPTable(string query, ref List<SinhVien> list_sv, ref List<MonHoc> list_mh)
        //{
        //    cmd.CommandText = query;
        //    using (DbDataReader reader = cmd.ExecuteReader())
        //    {
        //        int i = 0;
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                List<MonHoc> tmp = new List<MonHoc>(list_mh.ToArray());
        //                //-------------INPUT DATA----------------
        //                for (int mh_i = 0; mh_i < reader.FieldCount; mh_i++)
        //                {
        //                    if (reader.GetInt32(mh_i) == 1)
        //                    {
        //                        //========Deep copy========= 
        //                        var c = tmp[mh_i].Clone();
        //                        list_sv[i].MHDK.Add((MonHoc)c);
        //                    }
        //                }
        //                i++;
        //            }
        //        }
        //    }
        //}
        ////Lấy thông tin từ bảng MonHoc
        //public void extractMonHocTable(string query, ref List<MonHoc> list)
        //{
        //    cmd.CommandText = query;
        //    using (DbDataReader reader = cmd.ExecuteReader())
        //    {
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                string monhoc = reader.GetString(0);
        //                int sotiet = reader.GetInt32(1);
        //                MonHoc mh = new MonHoc(monhoc, sotiet);
        //                list.Add(mh);
        //            }
        //        }
        //    }
        //}
        //Lấy toàn bộ thông tin từ CSDL
        public void Extract(ref List<SinhVien> list_sv, ref List<MonHoc> list_mh)
        {
            string query1 = "SELECT * FROM SinhVien";
            string query2 = "SELECT * FROM MonHoc";
            string query3 = "SELECT * FROM dkhp";

            Console.WriteLine("Getting Connection ...");
            SqlConnection conn = GetConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Connection successful!");
                Console.ResetColor();
                cmd.Connection = conn;
                //-------------------------------------
                //extractDSSVTable(query1, ref list_sv);
                //extractMonHocTable(query2, ref list_mh);
                //extractDKHPTable(query3, ref list_sv, ref list_mh);
                //-------------------------------------
                conn.Close();
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Error: " + e.Message);
                Console.ResetColor();
            }
            Console.Read();
        }
    }
}
