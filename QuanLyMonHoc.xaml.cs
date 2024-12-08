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
    /// Interaction logic for QuanLyMonHoc.xaml
    /// </summary>
    public partial class QuanLyMonHoc : Window
    {
        public QuanLyMonHoc()
        {
            InitializeComponent();
        }
        QlsvienContext a = new QlsvienContext();
        private void View()
        {
            var b =from c in a.Monhocs
                  select new
                  {
                      c.Mamh,c.Tenmh,c.Sotietlythuyet,c.Sotietthucthanh,c.Sotinchi
                  };
            CoursesDataGrid.ItemsSource = b.ToList();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            ThemMonHoc add=new ThemMonHoc();
            add.Show();
        }

        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            SuaMonHoc edit = new SuaMonHoc();
            edit.Show();
        }

        private void DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            XoaMonHoc delete = new XoaMonHoc();
            delete.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            View();
        }
    }
}
