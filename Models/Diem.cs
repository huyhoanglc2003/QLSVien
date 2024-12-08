using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Models;

public partial class Diem
{
    public string Maloptc { get; set; } = null!;

    public string Mamh { get; set; } = null!;

    public string Masv { get; set; } = null!;

    public decimal? Diem1 { get; set; }

    public virtual Loptinchi MaloptcNavigation { get; set; } = null!;

    public virtual Monhoc MamhNavigation { get; set; } = null!;

    public virtual Sinhvien MasvNavigation { get; set; } = null!;
}
