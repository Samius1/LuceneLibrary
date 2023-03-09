﻿using System.Diagnostics;

namespace LuceneConsole.Views.Components
{
    public partial class ResultComponent : UserControl
    {
        private string FilePath;

        public ResultComponent()
        {
            InitializeComponent();
        }

        public void SetAuthor(string author)
        {
            TxtAuthor.Text = author;
        }

        public void SetTitle(string title)
        {
            TxtTitle.Text = title;
        }

        public void SetHighlight(string html)
        {
            WbHighlight.DocumentText = html;
        }

        public void SetPath(string path)
        {
            FilePath = path;
        }

        private void TxtTitle_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "There was an error opening the file with notepad.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WbHighlight_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Height = TxtAuthor.Height + TxtTitle.Height + SeparatorLine.Height + WbHighlight.Document.Body.ScrollRectangle.Height;
        }
    }
}
