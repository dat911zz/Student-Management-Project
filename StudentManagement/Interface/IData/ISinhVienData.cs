﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IData
{
    public interface ISinhVienData
    {
        List<SinhVien> GetAllSV();
        void Add(SinhVien sv);      
    }
}
