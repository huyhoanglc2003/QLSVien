using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Models;

public partial class Giaovien
{
    public string Magv { get; set; } = null!;

    public string? Tengv { get; set; }

    public string? Matkhau { get; set; }

    public string? Khoa { get; set; }

    public virtual ICollection<Loptinchi> Loptinchis { get; set; } = new List<Loptinchi>();
}
