using StudentManagement.Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
