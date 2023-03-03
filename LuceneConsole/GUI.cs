using LuceneConsole.DomainServices;
using LuceneConsole.Views;

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
            if (Directory.Exists(TxtFolder.Text))
            {
                ShowLoadingUI();

            }
            else
            {
                MessageBox.Show("The selected folder doesn't exists. Select a real folder.",
                    "Nonexistent folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoadingUI()
        {
            var folderPath = TxtFolder.Text;

            var modalUI = new LoadDataUI();
            modalUI.FolderPath = folderPath;
            modalUI.UseDefaultData = DefaultSourceButton.Checked;

            var result = modalUI.ShowDialog();

            if (result == DialogResult.OK)
            {
                TxtSearch.Visible = true;
                TemporalShowResults.Visible = true;
            }
            else
            {
                TxtSearch.Text = string.Empty;
                TemporalShowResults.Text = string.Empty;
                TxtSearch.Visible = false;
                TemporalShowResults.Visible = false;
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TemporalShowResults.Text = Environment.NewLine;

                var results = LuceneService.GetResults(TxtFolder.Text, TxtSearch.Text);

                foreach (var result in results)
                {
                    TemporalShowResults.Text += result + Environment.NewLine;
                }
            }
        }
    }
}