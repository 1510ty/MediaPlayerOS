using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayerOS_Csharp_WPF_Test_Edition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;      // タイトルバー非表示
            this.ResizeMode = ResizeMode.NoResize;    // リサイズ不可
            this.WindowState = WindowState.Maximized; // 最大化（画面いっぱい)
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartMenu.Visibility == Visibility.Visible)
            {
                StartMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                StartMenu.Visibility = Visibility.Visible;
            }
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WinRestartButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "shutdown.exe",
                Arguments = "/r /t 0",      // /r = 再起動, /t 0 = 待ち時間ゼロ
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        private void WinShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "shutdown.exe",
                Arguments = "/s /t 0",      // /r = 再起動, /t 0 = 待ち時間ゼロ
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }
    }
}