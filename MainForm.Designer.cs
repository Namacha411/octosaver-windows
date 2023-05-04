namespace octosaver_windows;

partial class MainForm
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
        title = new Label();
        SuspendLayout();
        // 
        // title
        // 
        title.AutoSize = true;
        title.Font = new Font("JetBrains Mono", 28.1999989F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        title.Location = new Point(392, 376);
        title.Name = "title";
        title.Size = new Size(167, 62);
        title.TabIndex = 0;
        title.Text = "title";
        title.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(title);
        FormBorderStyle = FormBorderStyle.None;
        Name = "MainForm";
        StartPosition = FormStartPosition.Manual;
        Text = "MainForm";
        Load += MainForm_Load;
        KeyPress += MainForm_KeyPress;
        MouseDown += MainForm_MouseClick;
        MouseMove += MainForm_MouseMove;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label title;
}
