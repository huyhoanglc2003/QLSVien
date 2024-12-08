using Microsoft.Data.SqlClient;
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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btn_Dangnhap_Click(object sender, RoutedEventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Password;
            if (Login(tenDangNhap, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công !");
                MainWindow menu = new MainWindow();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại !");
            }
        }

        private void btn_Thoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private bool Login(string tdn, string mk)
        {
            string connectionString = "Data Source=Hoang-TUF\\SQLEXPRESS;Initial Catalog=qlsvien;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from giaovien where magv=@tdn and matkhau=@mk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tdn", tdn);
                cmd.Parameters.AddWithValue("@mk", mk);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
