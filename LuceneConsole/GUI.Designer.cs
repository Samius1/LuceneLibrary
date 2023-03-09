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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
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
            PanelSearchResult = new Panel();
            PanelResults = new Panel();
            OptionsPanel.SuspendLayout();
            FolderGroupBox.SuspendLayout();
            PanelFolderButtons.SuspendLayout();
            TypeOfSourceGroupBox.SuspendLayout();
            PanelSearchResult.SuspendLayout();
            SuspendLayout();
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(FolderGroupBox);
            OptionsPanel.Controls.Add(TypeOfSourceGroupBox);
            OptionsPanel.Dock = DockStyle.Top;
            OptionsPanel.Location = new Point(0, 0);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(800, 73);
            OptionsPanel.TabIndex = 0;
            // 
            // FolderGroupBox
            // 
            FolderGroupBox.Controls.Add(TxtFolder);
            FolderGroupBox.Controls.Add(PanelFolderButtons);
            FolderGroupBox.Dock = DockStyle.Fill;
            FolderGroupBox.Location = new Point(186, 0);
            FolderGroupBox.Name = "FolderGroupBox";
            FolderGroupBox.Size = new Size(614, 73);
            FolderGroupBox.TabIndex = 1;
            FolderGroupBox.TabStop = false;
            FolderGroupBox.Text = "Select a folder and load";
            // 
            // TxtFolder
            // 
            TxtFolder.Dock = DockStyle.Fill;
            TxtFolder.Location = new Point(3, 23);
            TxtFolder.Name = "TxtFolder";
            TxtFolder.ReadOnly = true;
            TxtFolder.Size = new Size(486, 27);
            TxtFolder.TabIndex = 3;
            // 
            // PanelFolderButtons
            // 
            PanelFolderButtons.Controls.Add(BtnLoad);
            PanelFolderButtons.Controls.Add(BtnSelectFolder);
            PanelFolderButtons.Dock = DockStyle.Right;
            PanelFolderButtons.Location = new Point(489, 23);
            PanelFolderButtons.Name = "PanelFolderButtons";
            PanelFolderButtons.Size = new Size(122, 47);
            PanelFolderButtons.TabIndex = 2;
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(46, 0);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(73, 33);
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
            BtnSelectFolder.Name = "BtnSelectFolder";
            BtnSelectFolder.Size = new Size(37, 33);
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
            TypeOfSourceGroupBox.Name = "TypeOfSourceGroupBox";
            TypeOfSourceGroupBox.Size = new Size(186, 73);
            TypeOfSourceGroupBox.TabIndex = 0;
            TypeOfSourceGroupBox.TabStop = false;
            TypeOfSourceGroupBox.Text = "Select a source";
            // 
            // CustomSourceButton
            // 
            CustomSourceButton.AutoSize = true;
            CustomSourceButton.Dock = DockStyle.Top;
            CustomSourceButton.Location = new Point(3, 47);
            CustomSourceButton.Name = "CustomSourceButton";
            CustomSourceButton.Size = new Size(180, 24);
            CustomSourceButton.TabIndex = 1;
            CustomSourceButton.TabStop = true;
            CustomSourceButton.Text = "Custom source";
            CustomSourceButton.UseVisualStyleBackColor = true;
            // 
            // DefaultSourceButton
            // 
            DefaultSourceButton.AutoSize = true;
            DefaultSourceButton.Dock = DockStyle.Top;
            DefaultSourceButton.Location = new Point(3, 23);
            DefaultSourceButton.Name = "DefaultSourceButton";
            DefaultSourceButton.Size = new Size(180, 24);
            DefaultSourceButton.TabIndex = 0;
            DefaultSourceButton.TabStop = true;
            DefaultSourceButton.Text = "Default source";
            DefaultSourceButton.UseVisualStyleBackColor = true;
            // 
            // TxtSearch
            // 
            TxtSearch.Dock = DockStyle.Top;
            TxtSearch.Location = new Point(0, 0);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Insert your query here";
            TxtSearch.Size = new Size(800, 27);
            TxtSearch.TabIndex = 1;
            TxtSearch.Visible = false;
            TxtSearch.KeyDown += TxtSearch_KeyDown;
            // 
            // PanelSearchResult
            // 
            PanelSearchResult.Controls.Add(PanelResults);
            PanelSearchResult.Controls.Add(TxtSearch);
            PanelSearchResult.Dock = DockStyle.Fill;
            PanelSearchResult.Location = new Point(0, 73);
            PanelSearchResult.Name = "PanelSearchResult";
            PanelSearchResult.Size = new Size(800, 378);
            PanelSearchResult.TabIndex = 2;
            // 
            // PanelResults
            // 
            PanelResults.AutoScroll = true;
            PanelResults.Dock = DockStyle.Fill;
            PanelResults.Location = new Point(0, 27);
            PanelResults.Name = "PanelResults";
            PanelResults.Size = new Size(800, 351);
            PanelResults.TabIndex = 2;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(PanelSearchResult);
            Controls.Add(OptionsPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GUI";
            Text = "Lucene.NET Information Recovery System";
            WindowState = FormWindowState.Maximized;
            OptionsPanel.ResumeLayout(false);
            FolderGroupBox.ResumeLayout(false);
            FolderGroupBox.PerformLayout();
            PanelFolderButtons.ResumeLayout(false);
            TypeOfSourceGroupBox.ResumeLayout(false);
            TypeOfSourceGroupBox.PerformLayout();
            PanelSearchResult.ResumeLayout(false);
            PanelSearchResult.PerformLayout();
            ResumeLayout(false);
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
        private Panel PanelSearchResult;
        private Panel PanelResults;
    }
}