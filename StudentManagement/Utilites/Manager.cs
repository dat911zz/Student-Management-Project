using StudentManagement.Data.Database;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utilites
{
    public class Manager
    {
        public void AutoWork(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            AutoDKHP(ref list_sv, list_mh);
            AutoImportScore(list_sv);
        }
        public void AutoDKHP(ref List<SinhVien> list_sv, List<MonHoc> list_mh)
        {
            SQL db = new SQL();
            db.AutoImportMonHocForAllList(ref list_sv, list_mh);
        }
        public void AutoImportScore(List<SinhVien> list_sv)
        {
            Random score1 = new Random();
            Random score2 = new Random();
            DiemService ds = new DiemService();

            for (int i = 0; i < list_sv.Count; i++)
            {
                for (int j = 0; j < list_sv[i].CTHP.DSMH.Count; j++)
                {
                    ds.setDiem(list_sv[i].CTHP.DSMH[j].CTDiem, score1.Next(0, 10), score2.Next(2, 10));
                }
            }
        }
        public void GetInfoForm(List<SinhVien> list_sv)
        {
            KetQuaService kqs = new KetQuaService();
            foreach (var item in list_sv)
            {
                Console.WriteLine($"- Sinh Viên {item.TenSV}");
                for (int i = 0; i < item.CTHP.DSMH.Count; i++)
                {
                    
                    Console.WriteLine();
                }
            }
        }

        public void GetAllListInfo(List<SinhVien> list_sv)
        {
            KetQuaService kqs = new KetQuaService();
            list_sv.ForEach(x => {
                Console.WriteLine($"- Sinh Viên {x.TenSV}");
                for (int i = 0; i < x.CTHP.DSMH.Count; i++)
                {
                    kqs.GetInfoAll(x.CTHP.DSMH[i++]);
                }
            });
            //GetInfoForm(list_sv, () => kqs.GetInfoAll(item.CTHP.DSMH[i++]);)
        }
        public void GetAllMonHoc_SV(List<SinhVien> list_sv)
        {
            KetQuaService kqs = new KetQuaService();          
            list_sv.ForEach(x => {
                Console.WriteLine($"- Sinh Viên {x.TenSV}");
                for (int i = 0; i < x.CTHP.DSMH.Count; i++)
                {
                    kqs.GetInfoMonHoc(x.CTHP.DSMH[i++]);
                }
            });
        }
        public DataTable UploadMonHocSVIntoDGV(SinhVien sv)
        {
            int stt = 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Tên MH", typeof(string));
            dt.Columns.Add("Số tiết", typeof(int));

            foreach (var item in sv.CTHP.DSMH)
            {
                dt.Rows.Add(stt, item.CTMH.tenMH , item.CTMH.soTiet);

            }
            return dt;
        }
        public DataTable UploadDiemSVIntoDGV(SinhVien sv)
        {
            int stt = 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Tên MH", typeof(string));
            dt.Columns.Add("Số tiết", typeof(int));
            dt.Columns.Add("Điểm quá trình", typeof(int));
            dt.Columns.Add("Điểm thành phần", typeof(int));

            foreach (var item in sv.CTHP.DSMH)
            {
                dt.Rows.Add(stt, item.CTMH.tenMH, item.CTMH.soTiet, item.CTDiem.diemQT, item.CTDiem.diemTP);           
            }
            return dt;
        }
    }
}
