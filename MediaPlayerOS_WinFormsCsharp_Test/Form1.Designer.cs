namespace MediaPlayerOS_WinFormsCsharp_Test
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartMediOS = new Label();
            Csharp_WinForms_TestEdition = new Label();
            StartingProgress = new ProgressBar();
            panel1 = new Panel();
            panel2 = new Panel();
            Shutdown = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // StartMediOS
            // 
            StartMediOS.AutoSize = true;
            StartMediOS.Font = new Font("Yu Gothic UI", 30F);
            StartMediOS.Location = new Point(3, 16);
            StartMediOS.Name = "StartMediOS";
            StartMediOS.Size = new Size(582, 67);
            StartMediOS.TabIndex = 0;
            StartMediOS.Text = "Starting MediaPlayerOS...";
            // 
            // Csharp_WinForms_TestEdition
            // 
            Csharp_WinForms_TestEdition.AutoSize = true;
            Csharp_WinForms_TestEdition.Font = new Font("Yu Gothic UI", 20F);
            Csharp_WinForms_TestEdition.Location = new Point(19, 92);
            Csharp_WinForms_TestEdition.Name = "Csharp_WinForms_TestEdition";
            Csharp_WinForms_TestEdition.Size = new Size(400, 46);
            Csharp_WinForms_TestEdition.TabIndex = 1;
            Csharp_WinForms_TestEdition.Text = "C# WinForms Test Edition";
            // 
            // StartingProgress
            // 
            StartingProgress.Location = new Point(3, 394);
            StartingProgress.Name = "StartingProgress";
            StartingProgress.Size = new Size(773, 29);
            StartingProgress.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(StartMediOS);
            panel1.Controls.Add(StartingProgress);
            panel1.Controls.Add(Csharp_WinForms_TestEdition);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(Shutdown);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 426);
            panel2.TabIndex = 3;
            // 
            // Shutdown
            // 
            Shutdown.Location = new Point(3, 394);
            Shutdown.Name = "Shutdown";
            Shutdown.Size = new Size(94, 29);
            Shutdown.TabIndex = 0;
            Shutdown.Text = "シャットダウン";
            Shutdown.UseVisualStyleBackColor = true;
            Shutdown.Click += Shutdown_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "MainForm";
            Text = "Starting MediaPlayerOS...";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label StartMediOS;
        private Label Csharp_WinForms_TestEdition;
        private ProgressBar StartingProgress;
        private Panel panel1;
        private Panel panel2;
        private Button Shutdown;
    }
}
