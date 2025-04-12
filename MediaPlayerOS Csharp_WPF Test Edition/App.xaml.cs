using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace MediaPlayerOS_Csharp_WPF_Test_Edition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // UIスレッドの未処理例外
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // 非UIスレッドの未処理例外
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            base.OnStartup(e);

        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("クラッシュしたため、再起動します。ご迷惑をおかけしまして、申し訳ございません。\n\n" + e.Exception.Message, "MediaPlayerOS - アプリケーションエラー", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true; // これを true にするとアプリはそのまま動き続ける
            Process.Start(@"MediaPlayerOS Csharp_WPF Test Edition.exe");
            Application.Current.Shutdown();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show("バックグラウンドスレッドがクラッシュしたため、再起動します。ご迷惑をおかけしまして、申し訳ございません。\n\n" + ex.Message, "MediaPlayerOS - アプリケーションエラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Process.Start(@"MediaPlayerOS Csharp_WPF Test Edition.exe");
            Application.Current.Shutdown();
        }
    }


}
