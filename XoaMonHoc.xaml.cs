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
    /// Interaction logic for XoaMonHoc.xaml
    /// </summary>
    public partial class XoaMonHoc : Window
    {
        public XoaMonHoc()
        {
            InitializeComponent();
        }
        QlsvienContext a = new QlsvienContext();

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var monh = a.Monhocs.SingleOrDefault(m => m.Mamh.Equals(DeleteMamh.Text));

            if (monh != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xoá không? ","Thông báo",MessageBoxButton.YesNoCancel);
                // Xóa môn học khỏi danh sách Monhocs
                if(rs==MessageBoxResult.Yes) 
                {
                    a.Monhocs.Remove(monh);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    a.SaveChanges();

                    // Hiển thị thông báo xóa thành công
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo");
                }
               
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học cần xóa.", "Thông báo");
            }
        }
    }
}
