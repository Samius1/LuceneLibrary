namespace LuceneConsole.Views.Components
{
    partial class ResultComponent
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            WbHighlight = new WebBrowser();
            TxtAuthor = new TextBox();
            TxtTitle = new TextBox();
            SeparatorLine = new Label();
            SuspendLayout();
            // 
            // WbHighlight
            // 
            WbHighlight.AllowNavigation = false;
            WbHighlight.AllowWebBrowserDrop = false;
            WbHighlight.Dock = DockStyle.Fill;
            WbHighlight.IsWebBrowserContextMenuEnabled = false;
            WbHighlight.Location = new Point(0, 63);
            WbHighlight.Name = "WbHighlight";
            WbHighlight.ScriptErrorsSuppressed = true;
            WbHighlight.ScrollBarsEnabled = false;
            WbHighlight.Size = new Size(926, 139);
            WbHighlight.TabIndex = 0;
            WbHighlight.WebBrowserShortcutsEnabled = false;
            WbHighlight.DocumentCompleted += WbHighlight_DocumentCompleted;
            // 
            // TxtAuthor
            // 
            TxtAuthor.BackColor = SystemColors.Window;
            TxtAuthor.BorderStyle = BorderStyle.None;
            TxtAuthor.Dock = DockStyle.Top;
            TxtAuthor.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            TxtAuthor.Location = new Point(0, 34);
            TxtAuthor.Name = "TxtAuthor";
            TxtAuthor.ReadOnly = true;
            TxtAuthor.Size = new Size(926, 29);
            TxtAuthor.TabIndex = 1;
            TxtAuthor.Text = "Author";
            // 
            // TxtTitle
            // 
            TxtTitle.BackColor = SystemColors.Window;
            TxtTitle.BorderStyle = BorderStyle.None;
            TxtTitle.Cursor = Cursors.Hand;
            TxtTitle.Dock = DockStyle.Top;
            TxtTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            TxtTitle.ForeColor = SystemColors.HotTrack;
            TxtTitle.Location = new Point(0, 0);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.ReadOnly = true;
            TxtTitle.Size = new Size(926, 34);
            TxtTitle.TabIndex = 2;
            TxtTitle.Text = "Title";
            TxtTitle.MouseClick += TxtTitle_MouseClick;
            // 
            // SeparatorLine
            // 
            SeparatorLine.BorderStyle = BorderStyle.Fixed3D;
            SeparatorLine.Dock = DockStyle.Bottom;
            SeparatorLine.Location = new Point(0, 199);
            SeparatorLine.Name = "SeparatorLine";
            SeparatorLine.Size = new Size(926, 3);
            SeparatorLine.TabIndex = 3;
            // 
            // ResultComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(SeparatorLine);
            Controls.Add(WbHighlight);
            Controls.Add(TxtAuthor);
            Controls.Add(TxtTitle);
            MinimumSize = new Size(800, 50);
            Name = "ResultComponent";
            Size = new Size(926, 202);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private WebBrowser WbHighlight;
        private TextBox TxtAuthor;
        private TextBox TxtTitle;
        private Label SeparatorLine;
    }
}
