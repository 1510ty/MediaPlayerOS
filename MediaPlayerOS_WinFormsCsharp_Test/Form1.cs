using System;
using System.Windows.Forms;

namespace MediaPlayerOS_WinFormsCsharp_Test
{
    public partial class MainForm : Form
    {
        // System.Windows.Forms.Timerを明示的に使用
        private System.Windows.Forms.Timer progressTimer;
        private int progressCount = 0;

        public MainForm()
        {
            InitializeComponent();
            StartProgress();
        }

        private void StartProgress()
        {
            StartingProgress.Value = 0;  // プログレスバーを初期化
            progressCount = 0;           // カウンタリセット

            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 200; // 200ミリ秒（0.2秒ごと）
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            StartingProgress.Value += 5; // 10ずつ増加
            progressCount++;

            // 10回実行したら
            if (progressCount >= 20)
            {
                progressTimer.Stop();
                // panel1を非表示、panel2を表示する
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            MessageBox.Show("終了します");
            Application.Exit();
        }
    }
}
