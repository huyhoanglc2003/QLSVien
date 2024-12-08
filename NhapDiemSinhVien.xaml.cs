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
    /// Interaction logic for NhapDiemSinhVien.xaml
    /// </summary>
    public partial class NhapDiemSinhVien : Window
    {
        public NhapDiemSinhVien()
        {
            InitializeComponent();
        }
        QlsvienContext context = new QlsvienContext();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addMaloptcTextBox.Text) || string.IsNullOrWhiteSpace(addMamhTextBox.Text) || string.IsNullOrWhiteSpace(addMasvTextBox.Text) || string.IsNullOrWhiteSpace(addDiemTextBox.Text)) 
            {
                MessageBox.Show("Vui lòng điền vào các trường.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Sinhvien student = context.Sinhviens.SingleOrDefault(s => s.Masv.Equals(addMasvTextBox.Text));
            Monhoc course = context.Monhocs.SingleOrDefault(m => m.Mamh.Equals(addMamhTextBox.Text));

            if (student == null || course == null)
            {
                MessageBox.Show("Học sinh hoặc mã môn học không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if the grade already exists
            Diem existingGrade = context.Diems.SingleOrDefault(d => d.Masv.Equals(addMasvTextBox.Text) && d.Mamh.Equals(addMamhTextBox.Text));

            if (existingGrade != null)
            {
                MessageBox.Show("Không hợp lệ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new grade and save it to the database
            Diem newGrade = new Diem
            {
                Masv = addMasvTextBox.Text,
                Mamh = addMamhTextBox.Text,
                Diem1 = decimal.Parse(addDiemTextBox.Text)
            };

            context.Diems.Add(newGrade);
            context.SaveChanges();

            MessageBox.Show("Thêm điểm thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
