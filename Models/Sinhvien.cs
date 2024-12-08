using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Models;

public partial class Sinhvien
{
    public string Masv { get; set; } = null!;

    public string? Tensv { get; set; }

    public string? Matkhau { get; set; }

    public string? Lophanhchinh { get; set; }

    public string? Khoa { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();
}
