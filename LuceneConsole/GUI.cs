using LuceneConsole.DomainServices;
using LuceneConsole.Views;
using LuceneConsole.Views.Components;

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
                ActivateResultsSection(false);
                ResetResultPanel();
                if (CreateOrResetIndex(TxtFolder.Text))
                {
                    ShowLoadingUI();
                }
                else
                {
                    ActivateResultsSection(true);
                }
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
                ActivateResultsSection(true);
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ResetResultPanel();
                var results = LuceneService.GetResults(TxtFolder.Text, TxtSearch.Text);

                foreach (var result in results.Reverse())
                {
                    var resultComponent = new ResultComponent
                    {
                        Dock = DockStyle.Top
                    };
                    resultComponent.SetAuthor(result.Author);
                    resultComponent.SetTitle(result.Title);
                    resultComponent.SetHighlight(CompoundHtmlText(result.Hightlights));
                    resultComponent.SetPath(result.FilePath);
                    PanelResults.Controls.Add(resultComponent);
                }
            }
        }

        private void ResetResultPanel()
        {
            for (int i = PanelResults.Controls.Count - 1; i >= 0; i--)
            {
                PanelResults.Controls.RemoveAt(i);
            }
        }

        private void ActivateResultsSection(bool activate)
        {
            TxtSearch.Text = string.Empty;
            PanelSearchResult.Visible = activate;
            TxtSearch.Visible = activate;
        }

        private static string CompoundHtmlText(IEnumerable<string> highlights)
        {
            var finalHtml = string.Empty;
            var lastHightlight = highlights.Any() ? highlights.ElementAt(highlights.Count() - 1) : string.Empty;
            foreach (var highlight in highlights)
            {
                var separatorText = highlight != lastHightlight ? "<hr>" : string.Empty;
                finalHtml = string.Concat(finalHtml, highlight, separatorText);
            }

            return finalHtml;
        }

        private static bool CreateOrResetIndex(string folderPath)
        {
            var indexFolder = folderPath + "\\index";
            if (File.Exists(indexFolder + "\\_0.cfs") && File.Exists(indexFolder + "\\_1.cfs"))
            {
                return MessageBox.Show("Click on \"Ok\" to create a new index or \"Cancel\" to reuse the old one.", "Create a new index", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            }

            return true;
        }
    }
}