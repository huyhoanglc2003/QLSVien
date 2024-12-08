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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageCourses_Click(object sender, RoutedEventArgs e)
        {
            QuanLyMonHoc qlmh = new QuanLyMonHoc();
            qlmh.Show();
        }

        private void EnterStudentGrades_Click(object sender, RoutedEventArgs e)
        {
            ThongTinSinhVien ttsv = new ThongTinSinhVien();
            ttsv.Show();
        }

        private void ManageClassCredits_Click(object sender, RoutedEventArgs e)
        {
            QuanLyTinChi qltc = new QuanLyTinChi();
            qltc.Show();
        }
    }
}
