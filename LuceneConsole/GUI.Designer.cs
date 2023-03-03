namespace LuceneConsole
{
    partial class GUI
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
            OptionsPanel = new Panel();
            FolderGroupBox = new GroupBox();
            TxtFolder = new TextBox();
            PanelFolderButtons = new Panel();
            BtnLoad = new Button();
            BtnSelectFolder = new Button();
            TypeOfSourceGroupBox = new GroupBox();
            CustomSourceButton = new RadioButton();
            DefaultSourceButton = new RadioButton();
            TxtSearch = new TextBox();
            TemporalShowResults = new RichTextBox();
            OptionsPanel.SuspendLayout();
            FolderGroupBox.SuspendLayout();
            PanelFolderButtons.SuspendLayout();
            TypeOfSourceGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(FolderGroupBox);
            OptionsPanel.Controls.Add(TypeOfSourceGroupBox);
            OptionsPanel.Dock = DockStyle.Top;
            OptionsPanel.Location = new Point(0, 0);
            OptionsPanel.Margin = new Padding(3, 2, 3, 2);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(700, 55);
            OptionsPanel.TabIndex = 0;
            // 
            // FolderGroupBox
            // 
            FolderGroupBox.Controls.Add(TxtFolder);
            FolderGroupBox.Controls.Add(PanelFolderButtons);
            FolderGroupBox.Dock = DockStyle.Fill;
            FolderGroupBox.Location = new Point(163, 0);
            FolderGroupBox.Margin = new Padding(3, 2, 3, 2);
            FolderGroupBox.Name = "FolderGroupBox";
            FolderGroupBox.Padding = new Padding(3, 2, 3, 2);
            FolderGroupBox.Size = new Size(537, 55);
            FolderGroupBox.TabIndex = 1;
            FolderGroupBox.TabStop = false;
            FolderGroupBox.Text = "Select a folder and load";
            // 
            // TxtFolder
            // 
            TxtFolder.Dock = DockStyle.Fill;
            TxtFolder.Location = new Point(3, 18);
            TxtFolder.Margin = new Padding(3, 2, 3, 2);
            TxtFolder.Name = "TxtFolder";
            TxtFolder.ReadOnly = true;
            TxtFolder.Size = new Size(424, 23);
            TxtFolder.TabIndex = 3;
            // 
            // PanelFolderButtons
            // 
            PanelFolderButtons.Controls.Add(BtnLoad);
            PanelFolderButtons.Controls.Add(BtnSelectFolder);
            PanelFolderButtons.Dock = DockStyle.Right;
            PanelFolderButtons.Location = new Point(427, 18);
            PanelFolderButtons.Margin = new Padding(3, 2, 3, 2);
            PanelFolderButtons.Name = "PanelFolderButtons";
            PanelFolderButtons.Size = new Size(107, 35);
            PanelFolderButtons.TabIndex = 2;
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(40, 0);
            BtnLoad.Margin = new Padding(3, 2, 3, 2);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(64, 25);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "Load";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // BtnSelectFolder
            // 
            BtnSelectFolder.BackgroundImage = Properties.Resources.search;
            BtnSelectFolder.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSelectFolder.Location = new Point(3, 0);
            BtnSelectFolder.Margin = new Padding(3, 2, 3, 2);
            BtnSelectFolder.Name = "BtnSelectFolder";
            BtnSelectFolder.Size = new Size(32, 25);
            BtnSelectFolder.TabIndex = 0;
            BtnSelectFolder.UseVisualStyleBackColor = true;
            BtnSelectFolder.Click += BtnSelectFolder_Click;
            // 
            // TypeOfSourceGroupBox
            // 
            TypeOfSourceGroupBox.Controls.Add(CustomSourceButton);
            TypeOfSourceGroupBox.Controls.Add(DefaultSourceButton);
            TypeOfSourceGroupBox.Dock = DockStyle.Left;
            TypeOfSourceGroupBox.Location = new Point(0, 0);
            TypeOfSourceGroupBox.Margin = new Padding(3, 2, 3, 2);
            TypeOfSourceGroupBox.Name = "TypeOfSourceGroupBox";
            TypeOfSourceGroupBox.Padding = new Padding(3, 2, 3, 2);
            TypeOfSourceGroupBox.Size = new Size(163, 55);
            TypeOfSourceGroupBox.TabIndex = 0;
            TypeOfSourceGroupBox.TabStop = false;
            TypeOfSourceGroupBox.Text = "Select a source";
            // 
            // CustomSourceButton
            // 
            CustomSourceButton.AutoSize = true;
            CustomSourceButton.Dock = DockStyle.Top;
            CustomSourceButton.Location = new Point(3, 37);
            CustomSourceButton.Margin = new Padding(3, 2, 3, 2);
            CustomSourceButton.Name = "CustomSourceButton";
            CustomSourceButton.Size = new Size(157, 19);
            CustomSourceButton.TabIndex = 1;
            CustomSourceButton.TabStop = true;
            CustomSourceButton.Text = "Custom source";
            CustomSourceButton.UseVisualStyleBackColor = true;
            // 
            // DefaultSourceButton
            // 
            DefaultSourceButton.AutoSize = true;
            DefaultSourceButton.Dock = DockStyle.Top;
            DefaultSourceButton.Location = new Point(3, 18);
            DefaultSourceButton.Margin = new Padding(3, 2, 3, 2);
            DefaultSourceButton.Name = "DefaultSourceButton";
            DefaultSourceButton.Size = new Size(157, 19);
            DefaultSourceButton.TabIndex = 0;
            DefaultSourceButton.TabStop = true;
            DefaultSourceButton.Text = "Default source";
            DefaultSourceButton.UseVisualStyleBackColor = true;
            // 
            // TxtSearch
            // 
            TxtSearch.Dock = DockStyle.Top;
            TxtSearch.Location = new Point(0, 55);
            TxtSearch.Margin = new Padding(3, 2, 3, 2);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Insert your query here";
            TxtSearch.Size = new Size(700, 23);
            TxtSearch.TabIndex = 1;
            TxtSearch.Visible = false;
            TxtSearch.KeyDown += TxtSearch_KeyDown;
            // 
            // TemporalShowResults
            // 
            TemporalShowResults.Dock = DockStyle.Fill;
            TemporalShowResults.Location = new Point(0, 78);
            TemporalShowResults.Margin = new Padding(3, 2, 3, 2);
            TemporalShowResults.Name = "TemporalShowResults";
            TemporalShowResults.Size = new Size(700, 260);
            TemporalShowResults.TabIndex = 2;
            TemporalShowResults.Text = "";
            TemporalShowResults.Visible = false;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(TemporalShowResults);
            Controls.Add(TxtSearch);
            Controls.Add(OptionsPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GUI";
            Text = "Form1";
            OptionsPanel.ResumeLayout(false);
            FolderGroupBox.ResumeLayout(false);
            FolderGroupBox.PerformLayout();
            PanelFolderButtons.ResumeLayout(false);
            TypeOfSourceGroupBox.ResumeLayout(false);
            TypeOfSourceGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel OptionsPanel;
        private GroupBox FolderGroupBox;
        private GroupBox TypeOfSourceGroupBox;
        private RadioButton CustomSourceButton;
        private RadioButton DefaultSourceButton;
        private Button BtnLoad;
        private Button BtnSelectFolder;
        private TextBox TxtFolder;
        private Panel PanelFolderButtons;
        private TextBox TxtSearch;
        private RichTextBox TemporalShowResults;
    }
}