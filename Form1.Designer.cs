namespace TetrisRemake
{
    partial class Form1
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
            GamePanel = new Panel();
            BoardPanel = new Panel();
            GamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.BackColor = Color.Black;
            GamePanel.Controls.Add(BoardPanel);
            GamePanel.Dock = DockStyle.Fill;
            GamePanel.Location = new Point(0, 0);
            GamePanel.Margin = new Padding(4, 6, 4, 6);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(960, 540);
            GamePanel.TabIndex = 0;
            // 
            // BoardPanel
            // 
            BoardPanel.BackColor = Color.Red;
            BoardPanel.Location = new Point(0, 0);
            BoardPanel.Name = "BoardPanel";
            BoardPanel.Size = new Size(0,0);
            BoardPanel.TabIndex = 0;
            BoardPanel.Paint += GridPanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            Controls.Add(GamePanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 6, 4, 6);
            Name = "Form1";
            Text = "Tetris";
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            GamePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel GamePanel;
        private Panel BoardPanel;
        private Panel panel1;
    }
}
