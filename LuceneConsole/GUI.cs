using LuceneConsole.DomainServices;

namespace LuceneConsole
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            var folderPath = ConfigurationService.GetLastFolder();

            DefaultSourceButton.Select();
            TxtFolder.Text = folderPath;
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder where the data is stored";
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TxtFolder.Text = folderBrowserDialog.SelectedPath;
                ConfigurationService.UpdateLastFolder(TxtFolder.Text);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var folderPath = TxtFolder.Text;

            if (Directory.Exists(folderPath))
            {
                if (ValidateFiles(folderPath))
                {
                    if (DefaultSourceButton.Checked)
                    {
                        LuceneService.InitializeIndex(folderPath);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            else
            {
                MessageBox.Show("The selected folder doesn't exists. Select a real folder.",
                    "Nonexistent folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ValidateFiles(string folderPath)
        {
            var invalidFiles = string.Empty;
            foreach (var file in Directory.GetFiles(folderPath))
            {
                if (!file.EndsWith(".txt"))
                {
                    invalidFiles += file + Environment.NewLine;
                }
            }

            if (string.IsNullOrEmpty(invalidFiles))
            {
                return true;
            }

            MessageBox.Show("The following files are not valid." + Environment.NewLine + invalidFiles,
                "Invalid files", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }
    }
}