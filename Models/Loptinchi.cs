using System;
using System.Collections.Generic;

namespace QuanLySinhVien.Models;

public partial class Loptinchi
{
    public string Maloptc { get; set; } = null!;

    public string? Tenloptc { get; set; }

    public string? Nienkhoa { get; set; }

    public int? Hocki { get; set; }

    public int? SoSvtoithieu { get; set; }

    public string? Thoikhoabieu { get; set; }

    public string Magv { get; set; } = null!;

    public string Mamh { get; set; } = null!;

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual Giaovien MagvNavigation { get; set; } = null!;

    public virtual Monhoc MamhNavigation { get; set; } = null!;
}
