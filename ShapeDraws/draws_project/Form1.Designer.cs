namespace Draws
{
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            textBoxCoords = new TextBox();
            label_cord = new Label();
            btnLoadFromFile = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            btnSettings = new Button();
            toolTip1 = new ToolTip(components);
            radioButtonPoint = new RadioButton();
            radioButtonLine = new RadioButton();
            radioButtonPolygon = new RadioButton();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxCoords
            // 
            resources.ApplyResources(textBoxCoords, "textBoxCoords");
            textBoxCoords.AllowDrop = true;
            textBoxCoords.Cursor = Cursors.IBeam;
            textBoxCoords.Name = "textBoxCoords";
            toolTip1.SetToolTip(textBoxCoords, resources.GetString("textBoxCoords.ToolTip"));
            textBoxCoords.TextChanged += textBoxCoords_TextChanged;
            // 
            // label_cord
            // 
            resources.ApplyResources(label_cord, "label_cord");
            label_cord.Name = "label_cord";
            toolTip1.SetToolTip(label_cord, resources.GetString("label_cord.ToolTip"));
            // 
            // btnLoadFromFile
            // 
            resources.ApplyResources(btnLoadFromFile, "btnLoadFromFile");
            btnLoadFromFile.Name = "btnLoadFromFile";
            toolTip1.SetToolTip(btnLoadFromFile, resources.GetString("btnLoadFromFile.ToolTip"));
            btnLoadFromFile.UseVisualStyleBackColor = true;
            btnLoadFromFile.Click += btnLoadFromFile_Click;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            toolTip1.SetToolTip(btnSave, resources.GetString("btnSave.ToolTip"));
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnLoadFromFile);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip1.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip1.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // btnSettings
            // 
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.Name = "btnSettings";
            toolTip1.SetToolTip(btnSettings, resources.GetString("btnSettings.ToolTip"));
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click_Click;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // radioButtonPoint
            // 
            resources.ApplyResources(radioButtonPoint, "radioButtonPoint");
            radioButtonPoint.Name = "radioButtonPoint";
            toolTip1.SetToolTip(radioButtonPoint, resources.GetString("radioButtonPoint.ToolTip"));
            radioButtonPoint.UseVisualStyleBackColor = true;
            radioButtonPoint.CheckedChanged += radioButtonPoint_CheckedChanged;
            // 
            // radioButtonLine
            // 
            resources.ApplyResources(radioButtonLine, "radioButtonLine");
            radioButtonLine.Checked = true;
            radioButtonLine.Name = "radioButtonLine";
            radioButtonLine.TabStop = true;
            toolTip1.SetToolTip(radioButtonLine, resources.GetString("radioButtonLine.ToolTip"));
            radioButtonLine.UseVisualStyleBackColor = true;
            // 
            // radioButtonPolygon
            // 
            resources.ApplyResources(radioButtonPolygon, "radioButtonPolygon");
            radioButtonPolygon.Name = "radioButtonPolygon";
            toolTip1.SetToolTip(radioButtonPolygon, resources.GetString("radioButtonPolygon.ToolTip"));
            radioButtonPolygon.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(radioButtonPolygon);
            groupBox2.Controls.Add(radioButtonLine);
            groupBox2.Controls.Add(radioButtonPoint);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip1.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSettings);
            Controls.Add(label2);
            Controls.Add(textBoxCoords);
            Controls.Add(btnSave);
            Controls.Add(label_cord);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Show;
            toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private TextBox textBoxCoords;
        private Label label_cord;
        private Button btnLoadFromFile;
        private Button btnSave;
        private GroupBox groupBox1;
        private Label label2;
        private Button btnSettings;
        private ToolTip toolTip1;
        private RadioButton radioButtonPoint;
        private RadioButton radioButtonLine;
        private RadioButton radioButtonPolygon;
        private GroupBox groupBox2;
    }
}