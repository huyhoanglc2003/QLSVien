using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ThongTinSinhVien.xaml
    /// </summary>
    public partial class ThongTinSinhVien : Window
    {
        public ThongTinSinhVien()
        {
            InitializeComponent();
        }
        QlsvienContext a= new QlsvienContext();
        private void View2()
        {
            var b = from c in a.Diems
                    select new
                    {
                        c.Maloptc,c.Mamh,c.Masv,c.Diem1
                    };
            StudentsDataGrid.ItemsSource= b.ToList();
        }
        private void AddScore_Click(object sender, RoutedEventArgs e)
        {
            NhapDiemSinhVien addScore = new NhapDiemSinhVien();
            addScore.Show();
        }

        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            View2();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Diem> grades = a.Diems.ToList();

            string filePath = @"D:\student_grades.pdf";
            PDFGenerator.ExportGradesToPDF(grades, filePath);
            MessageBox.Show("Xuất ra file PDF thành công !", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
