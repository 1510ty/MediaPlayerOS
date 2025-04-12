using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;

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

            var settings = new CefSettings
            {
                BrowserSubprocessPath = System.IO.Path.Combine(AppContext.BaseDirectory, @"runtimes\win-x64\native\CefSharp.BrowserSubprocess.exe")
            };
            Cef.Initialize(settings);

            base.OnStartup(e);

        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("MediaPlayerOSがクラッシュしました。ご迷惑をおかけしまして、申し訳ございません。\n\n" + e.Exception.Message, "MediaPlayerOS - アプリケーションエラー", MessageBoxButton.OK, MessageBoxImage.Error);
            Current.Shutdown();

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show("バックグラウンドスレッドがクラッシュしたため、終了します。ご迷惑をおかけしまして、申し訳ございません。\n\n" + ex.Message, "MediaPlayerOS - アプリケーションエラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Current.Shutdown();
        }
    }


}
