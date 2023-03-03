using LuceneConsole.DomainServices;

namespace LuceneConsole.Views
{
    public partial class LoadDataUI : Form
    {
        internal string FolderPath { get; set; }
        internal bool UseDefaultData { get; set; }
        private bool Succesfull { get; set; }

        public LoadDataUI()
        {
            InitializeComponent();
        }

        private void LoadDataUI_Shown(object sender, EventArgs e)
        {
            Refresh();
            if (ValidateFiles(FolderPath))
            {
                Thread.Sleep(1000);
                Text = "Creating Index";
                if (UseDefaultData)
                {
                    ProgressBarIndex.Value = 0;
                    LuceneService.InitializeIndex(FolderPath, ProgressBarIndex);
                }
                else
                {
                    throw new NotImplementedException();
                }
                Succesfull = true;
            }
            else
            {
                Succesfull = false;
            }
            BtnCloseUI.Enabled = true;
        }

        private bool ValidateFiles(string folderPath)
        {
            var invalidFiles = string.Empty;
            var files = Directory.GetFiles(folderPath);
            ProgressBarIndex.Maximum = files.Length;

            foreach (var file in files)
            {
                if (!file.EndsWith(".txt"))
                {
                    invalidFiles += file + Environment.NewLine;
                }
                ProgressBarIndex.Value++;
            }

            if (string.IsNullOrEmpty(invalidFiles))
            {
                return true;
            }

            MessageBox.Show("The following files are not valid." + Environment.NewLine + invalidFiles,
                "Invalid files", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private void BtnCloseUI_Click(object sender, EventArgs e)
        {
            if (Succesfull)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
