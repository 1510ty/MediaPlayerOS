using System.Diagnostics;
using System.Printing.IndexedProperties;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        private async void ShutdownMediaPlayerOS(string Exitcode)
        {
            StartingorShutdownText.Content = "Shutdown...";
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

            if (Exitcode == "1")
            {
                Process.Start(@"MediaPlayerOS Csharp_WPF Test Edition.exe");
                Application.Current.Shutdown();
            }
            else
            {
                Application.Current.Shutdown();
            }
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
            ShutdownMediaPlayerOS("0");
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            RestartMediaPlayerOS();
        }

        private void RestartMediaPlayerOS()
        {
            ShutdownMediaPlayerOS("1");
        }

        private void DengenButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartMenu_DengenGrid.Visibility == Visibility.Visible)
            {
                StartMenu_DengenGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                StartMenu_DengenGrid.Visibility = Visibility.Visible;
            }
        }

        private void CrashButton_Click(object sender, RoutedEventArgs e)
        {
            int zero = 0;
            int result = 1 / zero; // DivideByZeroException が発生 → 未処理例外 → アプリがクラッシュ
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowserWindowViewButton_Click(object sender, RoutedEventArgs e)
        {
            var browserWindow = new BrowserWindow();
            Canvas.SetLeft(browserWindow, 100);
            Canvas.SetTop(browserWindow, 100);
            MainCanvas.Children.Add(browserWindow);

        }
    }
}