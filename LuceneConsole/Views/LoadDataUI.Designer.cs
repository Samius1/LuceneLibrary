namespace LuceneConsole.Views
{
    partial class LoadDataUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDataUI));
            TxtFileLoading = new TextBox();
            ProgressBarIndex = new ProgressBar();
            BtnCloseUI = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TxtFileLoading
            // 
            TxtFileLoading.BorderStyle = BorderStyle.None;
            TxtFileLoading.Dock = DockStyle.Top;
            TxtFileLoading.Location = new Point(0, 0);
            TxtFileLoading.Name = "TxtFileLoading";
            TxtFileLoading.PlaceholderText = "Loading";
            TxtFileLoading.ReadOnly = true;
            TxtFileLoading.Size = new Size(800, 20);
            TxtFileLoading.TabIndex = 0;
            // 
            // ProgressBarIndex
            // 
            ProgressBarIndex.Location = new Point(12, 26);
            ProgressBarIndex.Name = "ProgressBarIndex";
            ProgressBarIndex.Size = new Size(776, 29);
            ProgressBarIndex.TabIndex = 1;
            // 
            // BtnCloseUI
            // 
            BtnCloseUI.Enabled = false;
            BtnCloseUI.Location = new Point(353, 3);
            BtnCloseUI.Name = "BtnCloseUI";
            BtnCloseUI.Size = new Size(94, 29);
            BtnCloseUI.TabIndex = 2;
            BtnCloseUI.Text = "Close";
            BtnCloseUI.UseVisualStyleBackColor = true;
            BtnCloseUI.Click += BtnCloseUI_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(BtnCloseUI, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 94);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 38);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // LoadDataUI
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 132);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(ProgressBarIndex);
            Controls.Add(TxtFileLoading);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(818, 150);
            Name = "LoadDataUI";
            ShowInTaskbar = false;
            Text = "Validating files";
            FormClosing += LoadDataUI_FormClosing;
            Load += LoadDataUI_Load;
            Shown += LoadDataUI_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtFileLoading;
        private ProgressBar ProgressBarIndex;
        private Button BtnCloseUI;
        private TableLayoutPanel tableLayoutPanel1;
    }
}