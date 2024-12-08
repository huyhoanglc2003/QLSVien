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
    /// Interaction logic for QuanLyTinChi.xaml
    /// </summary>
    public partial class QuanLyTinChi : Window
    {
        public QuanLyTinChi()
        {
            InitializeComponent();
        }
        QlsvienContext a = new QlsvienContext();
        private void View1()
        {
            var b = from c in a.Loptinchis
                    select new
                    {
                        c.Maloptc,c.Tenloptc,c.Nienkhoa,c.Hocki,c.SoSvtoithieu,c.Thoikhoabieu,c.Magv,c.Mamh
                    };
            CreditsDataGrid.ItemsSource= b.ToList();
        }    
        private void AddCredits_Click(object sender, RoutedEventArgs e)
        {
            ThemLopTinChi addCre = new ThemLopTinChi();
            addCre.Show();
        }

        private void EditCredits_Click(object sender, RoutedEventArgs e)
        {
            SuaLopTinChi editCre=new SuaLopTinChi(); 
            editCre.Show();
        }

        private void DeleteCredits_Click(object sender, RoutedEventArgs e)
        {
            XoaLopTinChi deleteCre = new XoaLopTinChi();
            deleteCre.Show();
        }

        private void Window_Loaded1(object sender, RoutedEventArgs e)
        {
            View1();
        }
    }
}
