using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using CefSharp;

namespace MediaPlayerOS_Csharp_WPF_Test_Edition
{
    public partial class BrowserWindow
    {
        private bool _isDragging = false;
        private Point _startPoint;
        private double _originalLeft;
        private double _originalTop;

        // サイズ変更用
        private bool _isResizing = false;
        private Point _resizeStartPoint;
        private double _originalWidth;
        private double _originalHeight;

        public BrowserWindow()
        {
            InitializeComponent();
            Browser.AddressChanged += OnBrowserAddressChanged;
            Browser.Focus(); // IME（日本語入力）を安定させる
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            string url = AddressBar.Text.Trim();
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                Browser.Load(uri.ToString());
            }
            else
            {
                MessageBox.Show("正しいURLを入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parent = this.Parent as Canvas;
            if (parent != null)
            {
                _startPoint = e.GetPosition(parent);
                _originalLeft = Canvas.GetLeft(this);
                _originalTop = Canvas.GetTop(this);
                _isDragging = true;
                this.CaptureMouse();
            }
        }

        private void BrowserWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var parent = this.Parent as Canvas;
                if (parent != null)
                {
                    Point currentPos = e.GetPosition(parent);
                    double offsetX = currentPos.X - _startPoint.X;
                    double offsetY = currentPos.Y - _startPoint.Y;

                    Canvas.SetLeft(this, _originalLeft + offsetX);
                    Canvas.SetTop(this, _originalTop + offsetY);
                }
            }
        }

        private void BrowserWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            this.ReleaseMouseCapture();
        }

        // ↓↓↓ サイズ変更イベント ↓↓↓

        private void ResizeGrip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _resizeStartPoint = e.GetPosition(null);
            _originalWidth = this.Width;
            _originalHeight = this.Height;
            _isResizing = true;
            ResizeGrip.CaptureMouse();
        }

        private void ResizeGrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizing && e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPos = e.GetPosition(null);
                double offsetX = currentPos.X - _resizeStartPoint.X;
                double offsetY = currentPos.Y - _resizeStartPoint.Y;

                this.Width = Math.Max(100, _originalWidth + offsetX);
                this.Height = Math.Max(100, _originalHeight + offsetY);
            }
        }

        private void ResizeGrip_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isResizing = false;
            ResizeGrip.ReleaseMouseCapture();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Browser != null)
            {
                Browser.Dispose(); // これが超重要
                Browser = null;
            }

            var parent = this.Parent as Canvas;
            if (parent != null)
            {
                parent.Children.Remove(this);
            }
        }

        private void BrowserWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BringToFront();

            // ついでにドラッグ移動もやってるなら、ここでドラッグ開始処理などもOK
        }
        private void BringToFront()
        {
            var parent = this.Parent as Panel;
            if (parent == null) return;

            // すべての子要素のZIndexを確認して最大値を取得
            int maxZ = 0;
            foreach (UIElement child in parent.Children)
            {
                int z = Panel.GetZIndex(child);
                if (z > maxZ) maxZ = z;
            }

            // 自分のZIndexを最大値+1にする
            Panel.SetZIndex(this, maxZ + 1);
        }

        private void OnBrowserAddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // UI スレッドで TextBox を更新
            Dispatcher.Invoke(() =>
            {
                AddressBar.Text = e.NewValue as string;
            });
        }
    }
}
