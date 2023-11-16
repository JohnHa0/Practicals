namespace Draws
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            txtDefaultPath = new TextBox();
            label2 = new Label();
            colorDialog = new ColorDialog();
            buttonOK = new Button();
            buttonCancel = new Button();
            btnBrowse = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            btnChooseColor = new Button();
            pnlColorPreview = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 68);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 0;
            label1.Text = "默认存储路径";
            // 
            // txtDefaultPath
            // 
            txtDefaultPath.Location = new Point(131, 65);
            txtDefaultPath.Name = "txtDefaultPath";
            txtDefaultPath.Size = new Size(208, 23);
            txtDefaultPath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 121);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 2;
            label2.Text = "绘图颜色";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(83, 179);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "保存";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(202, 179);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(357, 65);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "选择路径";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnChooseColor
            // 
            btnChooseColor.Location = new Point(202, 118);
            btnChooseColor.Name = "btnChooseColor";
            btnChooseColor.Size = new Size(75, 23);
            btnChooseColor.TabIndex = 6;
            btnChooseColor.Text = "选择颜色";
            btnChooseColor.UseVisualStyleBackColor = true;
            btnChooseColor.Click += btnChooseColor_Click;
            // 
            // pnlColorPreview
            // 
            pnlColorPreview.Location = new Point(135, 120);
            pnlColorPreview.Name = "pnlColorPreview";
            pnlColorPreview.Size = new Size(46, 18);
            pnlColorPreview.TabIndex = 7;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 271);
            Controls.Add(pnlColorPreview);
            Controls.Add(btnChooseColor);
            Controls.Add(btnBrowse);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label2);
            Controls.Add(txtDefaultPath);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "参数定义";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDefaultPath;
        private Label label2;
        private ColorDialog colorDialog;
        private Button buttonOK;
        private Button buttonCancel;
        private Button btnBrowse;
        private FolderBrowserDialog folderBrowserDialog;
        private Button btnChooseColor;
        private Panel pnlColorPreview;
    }
}