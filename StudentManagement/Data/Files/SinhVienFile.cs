using Newtonsoft.Json;
using StudentManagement.Models;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Files
{
    public class SinhVienFile
    {
        private string _folderPath;
        private string _filePath;
        public SinhVienFile()
        {
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FilesData");
            _filePath = Path.Combine(_folderPath, "student.json");
        }
        public void Add(SinhVien student)
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(student) });
        }

        public List<SinhVien> GetAll()
        {
            var result = new List<SinhVien>();
            if (File.Exists(_filePath))
            {
                var studentStr = File.ReadAllLines(_filePath);
                foreach (var item in studentStr)
                {
                    result.Add(JsonConvert.DeserializeObject<SinhVien>(item));
                }
            }
            return result;
        }
    }
}
