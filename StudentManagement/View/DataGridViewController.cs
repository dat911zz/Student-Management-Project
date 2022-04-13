using StudentManagement.Data.Database;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.View
{
    /// <summary>
    /// DataGridView controller
    /// </summary>
    public class DGVController
    {
        public void BindDataGridView(DataGridView dgv)
        {
            var db = new SQL();
            db.FillGrid(dgv);
            AutoFillCountCol(dgv);
        }
        public void AutoFillCountCol(DataGridView dgv)
        {
            if (dgv.Rows.Count < 1)
            {
                throw new Exception("ERROR: Rows.Count must be greater than 1!");
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    dgv.Rows[i].Cells[0].Value = i + 1;
                }
            }
        }
        public void ScoreCustoms(DataGridView grid, SinhVien item)
        {
            for (int i = 0; i < item.CTHP.DSMH.Count; i++)
            {
                if (int.Parse(grid.Rows[i].Cells[3].Value.ToString()) < 5)
                {
                    grid.Rows[i].Cells[3].Style.BackColor = Color.Red;
                }
                if (int.Parse(grid.Rows[i].Cells[4].Value.ToString()) < 5)
                {
                    grid.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
                if (grid.Rows[i].Cells[5].Value.ToString() == "Trượt")
                {
                    grid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }

            }

            grid.Columns[0].Width = 50;//Chỉnh độ rộng của cột STT
            grid.Columns[2].Width = 50;//Chỉnh độ rộng cột số tiết
            grid.Columns[4].Width = 110;//Chỉnh độ rộng cột điểm thành phần
        }
    }
}
