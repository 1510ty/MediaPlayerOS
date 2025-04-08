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
        private int StartStopProgressValue;
        public MainWindow()
        {
            InitializeComponent();
            StartMenu.Visibility = Visibility.Collapsed;
            this.WindowStyle = WindowStyle.None;      // タイトルバー非表示
            this.ResizeMode = ResizeMode.NoResize;    // リサイズ不可
            this.WindowState = WindowState.Maximized; // 最大化（画面いっぱい)
            StartingMediaPlayerOS();


        }

        private async void StartingMediaPlayerOS()
        {

            StartingorShutdownText.Content = "Starting...";
            await Task.Delay(1000);
            StartStop.Visibility = Visibility.Visible;
            StartStopProgressValue = 0;
            StartStopProgress.Value = 0;

            for (int i = 0; i < 20; i++)
            {
                StartStopProgressValue += 5;
                StartStopProgress.Value = StartStopProgressValue;

                await Task.Delay(100); // 0.3秒ずつ待つ → 合計3秒のアニメーション
            }

            StartStop.Visibility = Visibility.Collapsed;

            // 少し待ってから終了したい場合
            Main.Visibility = Visibility.Visible;
        }

        private async void ShutdownMediaPlayerOS()
        {
            StartingorShutdownText.Content = "Shutdonw...";
            Main.Visibility = Visibility.Collapsed;
            StartStop.Visibility = Visibility.Visible;
            StartStopProgressValue = 0;
            StartStopProgress.Value = 0;

            for (int i = 0; i < 20; i++)
            {
                StartStopProgressValue += 5;
                StartStopProgress.Value = StartStopProgressValue;
                await Task.Delay(100);
            }

            // 画面全体をフェードアウト
            var fadeOut = new System.Windows.Media.Animation.DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(500)));
            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            await Task.Delay(700); // フェードアウト完了まで待機

            Application.Current.Shutdown();
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
            ShutdownMediaPlayerOS();
        }

    }
}