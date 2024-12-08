using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Models;

public partial class Monhoc
{
    public string Mamh { get; set; } = null!;

    public string? Tenmh { get; set; }

    public int? Sotietlythuyet { get; set; }

    public int? Sotietthucthanh { get; set; }

    public int? Sotinchi { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual ICollection<Loptinchi> Loptinchis { get; set; } = new List<Loptinchi>();
}
