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

        private void LoadDataUI_Load(object sender, EventArgs e)
        {
            Text = "Validating files";
        }

        private void LoadDataUI_Shown(object sender, EventArgs e)
        {
            CleanUpFiles();

            if (ValidateFiles())
            {
                Text = "Creating Index";
                ProgressBarIndex.Value = 0;
                if (UseDefaultData)
                {
                    LuceneService.InitializeIndex(FolderPath, ProgressBarIndex);
                }
                else
                {
                    LuceneService.InitializeCustomIndex(FolderPath, ProgressBarIndex);
                }
                Succesfull = true;
            }
            else
            {
                Succesfull = false;
            }
            BtnCloseUI.Enabled = true;
        }

        private void CleanUpFiles()
        {
            var indexPath = Path.Combine(FolderPath, "index");
            var directoryInfo = new DirectoryInfo(indexPath);
            try
            {
                foreach (var file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception exception)
            {
            }
        }

        private bool ValidateFiles()
        {
            var invalidFiles = string.Empty;
            var files = Directory.GetFiles(FolderPath);
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
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void LoadDataUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("This action is restricted. Try to click the \"Close\" button.", "Action forbidden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
