using Dapper;
using StudentManagement.Interface.IData;
using StudentManagement.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentManagement.Data.ORM
{
    /// <summary>
    /// Class for Dapper Library
    /// </summary>
    public class Dapper : ISinhVienData, IMonHocData, ICTHocPhanData
    {
        private readonly string connectionString;
        public Dapper(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> list_sv = new List<SinhVien>();
            string sql = "SELECT * FROM SinhVien";
            using (var conn = new SqlConnection(connectionString))
            {
                list_sv = conn.Query<SinhVien>(sql).AsList();
            }
            return list_sv;
        }
        public List<MonHoc> GetAllMH()
        {
            List<MonHoc> list_mh = new List<MonHoc>();
            string sql = "SELECT * FROM MonHoc";
            using (var conn = new SqlConnection(connectionString))
            {
                list_mh = conn.Query<MonHoc>(sql).AsList();
            }
            return list_mh;
        }
        public void GetAllCTHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            string sql = "SELECT * FROM dkhp";
            using (var conn = new SqlConnection(connectionString))
            {
                int i = 0;
                List<DKHP> list_dkhp = conn.Query<DKHP>(sql).AsList();
                foreach (var sv in list_sv)
                {
                    List<int> tmp1 = new List<int>(list_dkhp[i++].ToArray());
                    List<MonHoc> tmp = new List<MonHoc>(list_mh.ToArray());
                    for (int j = 0; j < tmp1.Count; j++)
                    {
                        if (tmp1[j] == 1)
                        {
                            MonHoc c = new MonHoc(tmp[j]);
                            sv.CTHP.DSMH.Add(new KetQua(new MonHoc(c), new Diem()));
                        }
                    }
                }              
            }
        }

        public void Add(CTHocPhan cthp)
        {
            throw new System.NotImplementedException();
        }
        public void Add(SinhVien sv)
        {
            throw new System.NotImplementedException();
        }
        public void Add(MonHoc sv)
        {
            throw new System.NotImplementedException();
        }
    }
    /// <summary>
    /// Class phụ để map tới bảng DKHP trong DB
    /// </summary>
    public class DKHP
    {
        //Props
        public virtual int C1 { get; set; }
        public virtual int C2 { get; set; }
        public virtual int C3 { get; set; }
        public virtual int C4 { get; set; }
        public virtual int C5 { get; set; }
        public virtual int C6 { get; set; }
        public virtual int C7 { get; set; }
        public virtual int C8 { get; set; }
        public virtual int C9 { get; set; }
        public virtual int C10 { get; set; }
        //Method
        public int[] ToArray()
        {
            return new int[] { C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 };
        }
    }
}