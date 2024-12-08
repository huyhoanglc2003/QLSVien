using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLySinhVien
{
    /// <summary>
    /// Interaction logic for ThemMonHoc.xaml
    /// </summary>
    public partial class ThemMonHoc : Window
    {
        public ThemMonHoc()
        {
            InitializeComponent();
        }
        QlsvienContext a = new QlsvienContext();
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            var b = a.Monhocs.SingleOrDefault(t=>t.Mamh.Equals(NewMaMHTextBox));
            if (b != null ) 
            {
                System.Windows.MessageBox.Show("Trùng môn học", "Thông báo");
            }
            else
            {
                Monhoc c = new Monhoc();
                c.Mamh=NewMaMHTextBox.Text;
                c.Tenmh=NewTenMHTextBox.Text;
                c.Sotietlythuyet = int.Parse(NewSotietlythuyetTextBox.Text);
                c.Sotietthucthanh = int.Parse(NewSotietthuchanhTextBox.Text);
                c.Sotinchi = int.Parse(NewSotinchiTextBox.Text);
                a.Monhocs.Add(c);
                a.SaveChanges();
                System.Windows.MessageBox.Show("Thêm thành công", "Thông báo");
            }    
        }
    }
}
