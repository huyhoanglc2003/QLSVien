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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLySinhVien
{
    /// <summary>
    /// Interaction logic for SuaMonHoc.xaml
    /// </summary>
    public partial class SuaMonHoc : Window
    {
        public SuaMonHoc()
        {
            InitializeComponent();
        }
        QlsvienContext a = new QlsvienContext();
        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            var c = a.Monhocs.SingleOrDefault(t => t.Mamh.Equals(EditMaMHTextBox));
            if (c != null)
            {
                c.Tenmh = EditTenMHTextBox.Text;
                c.Sotietlythuyet = int.Parse(EditSotietlythuyetTextBox.Text);
                c.Sotietthucthanh = int.Parse(EditSotietthuchanhTextBox.Text);
                c.Sotinchi = int.Parse(EditSotinchiTextBox.Text);
                a.Monhocs.Add(c);
                a.SaveChanges();
                System.Windows.MessageBox.Show("Sửa thành công", "Thông báo");
                
            }
            else
            {
                System.Windows.MessageBox.Show("Không trùng môn học", "Thông báo");
            }
        }
    }
}
