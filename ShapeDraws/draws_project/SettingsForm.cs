using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draws
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtDefaultPath.Text = Properties.Settings.Default.DefaultSavePath;
            colorDialog.Color = ColorTranslator.FromHtml(Properties.Settings.Default.DefaultColor);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // 显示文件夹浏览对话框
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 用户选择了一个文件夹，更新文本框内容
                txtDefaultPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            // 用户点击“选择颜色”按钮，打开颜色选择对话框
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 更新颜色显示，例如通过背景色或文本
                pnlColorPreview.BackColor = colorDialog.Color;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // 用户点击“保存”按钮，保存设置
            Properties.Settings.Default.DefaultSavePath = txtDefaultPath.Text;
            Properties.Settings.Default.DefaultColor = ColorTranslator.ToHtml(colorDialog.Color);
            Properties.Settings.Default.Save();

            this.Close(); // 关闭窗体

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭窗体
        }
    }
}
