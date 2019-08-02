namespace spliter
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_selAtlas = new System.Windows.Forms.Button();
            this.button_selData = new System.Windows.Forms.Button();
            this.button_operation = new System.Windows.Forms.Button();
            this.label_atlas = new System.Windows.Forms.Label();
            this.label_data = new System.Windows.Forms.Label();
            this.openFileDialog_selAtlas = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_selData = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_selOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_atlasPath = new System.Windows.Forms.TextBox();
            this.textBox_dataPath = new System.Windows.Forms.TextBox();
            this.label_output_path = new System.Windows.Forms.Label();
            this.textBox_outputPath = new System.Windows.Forms.TextBox();
            this.button_selOutput = new System.Windows.Forms.Button();
            this.label_introduce = new System.Windows.Forms.Label();
            this.label_authorInfo = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label_version = new System.Windows.Forms.Label();
            this.progressBar_operation = new System.Windows.Forms.ProgressBar();
            this.button_clean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_selAtlas
            // 
            this.button_selAtlas.Location = new System.Drawing.Point(424, 41);
            this.button_selAtlas.Name = "button_selAtlas";
            this.button_selAtlas.Size = new System.Drawing.Size(75, 23);
            this.button_selAtlas.TabIndex = 2;
            this.button_selAtlas.Text = "选择图集";
            this.button_selAtlas.UseVisualStyleBackColor = true;
            this.button_selAtlas.Click += new System.EventHandler(this.button_selAtlas_Click);
            // 
            // button_selData
            // 
            this.button_selData.Location = new System.Drawing.Point(424, 105);
            this.button_selData.Name = "button_selData";
            this.button_selData.Size = new System.Drawing.Size(75, 23);
            this.button_selData.TabIndex = 4;
            this.button_selData.Text = "选择数据";
            this.button_selData.UseVisualStyleBackColor = true;
            this.button_selData.Click += new System.EventHandler(this.button_selData_Click);
            // 
            // button_operation
            // 
            this.button_operation.Location = new System.Drawing.Point(160, 236);
            this.button_operation.Name = "button_operation";
            this.button_operation.Size = new System.Drawing.Size(75, 23);
            this.button_operation.TabIndex = 0;
            this.button_operation.Text = "执行";
            this.button_operation.UseVisualStyleBackColor = true;
            this.button_operation.Click += new System.EventHandler(this.button_operation_Click);
            // 
            // label_atlas
            // 
            this.label_atlas.AutoSize = true;
            this.label_atlas.Location = new System.Drawing.Point(15, 15);
            this.label_atlas.Name = "label_atlas";
            this.label_atlas.Size = new System.Drawing.Size(77, 12);
            this.label_atlas.TabIndex = 3;
            this.label_atlas.Text = "导入图集文件";
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Location = new System.Drawing.Point(15, 81);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(77, 12);
            this.label_data.TabIndex = 4;
            this.label_data.Text = "导入数据文件";
            // 
            // openFileDialog_selAtlas
            // 
            this.openFileDialog_selAtlas.FileName = "选择图集";
            // 
            // openFileDialog_selData
            // 
            this.openFileDialog_selData.FileName = "选择数据";
            // 
            // textBox_atlasPath
            // 
            this.textBox_atlasPath.Location = new System.Drawing.Point(86, 43);
            this.textBox_atlasPath.Name = "textBox_atlasPath";
            this.textBox_atlasPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_atlasPath.TabIndex = 1;
            // 
            // textBox_dataPath
            // 
            this.textBox_dataPath.Location = new System.Drawing.Point(86, 107);
            this.textBox_dataPath.Name = "textBox_dataPath";
            this.textBox_dataPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_dataPath.TabIndex = 3;
            // 
            // label_output_path
            // 
            this.label_output_path.AutoSize = true;
            this.label_output_path.Location = new System.Drawing.Point(15, 145);
            this.label_output_path.Name = "label_output_path";
            this.label_output_path.Size = new System.Drawing.Size(53, 12);
            this.label_output_path.TabIndex = 4;
            this.label_output_path.Text = "输出目录";
            // 
            // textBox_outputPath
            // 
            this.textBox_outputPath.Location = new System.Drawing.Point(86, 171);
            this.textBox_outputPath.Name = "textBox_outputPath";
            this.textBox_outputPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_outputPath.TabIndex = 5;
            // 
            // button_selOutput
            // 
            this.button_selOutput.Location = new System.Drawing.Point(424, 169);
            this.button_selOutput.Name = "button_selOutput";
            this.button_selOutput.Size = new System.Drawing.Size(75, 23);
            this.button_selOutput.TabIndex = 6;
            this.button_selOutput.Text = "选择目录";
            this.button_selOutput.UseVisualStyleBackColor = true;
            this.button_selOutput.Click += new System.EventHandler(this.button_selOutput_Click);
            // 
            // label_introduce
            // 
            this.label_introduce.AutoSize = true;
            this.label_introduce.Location = new System.Drawing.Point(10, 308);
            this.label_introduce.Name = "label_introduce";
            this.label_introduce.Size = new System.Drawing.Size(365, 12);
            this.label_introduce.TabIndex = 8;
            this.label_introduce.Text = "说明：白鹭图集软件TextureMerger的反向解析工具，方便二次修改.";
            // 
            // label_authorInfo
            // 
            this.label_authorInfo.AutoSize = true;
            this.label_authorInfo.Location = new System.Drawing.Point(298, 341);
            this.label_authorInfo.Name = "label_authorInfo";
            this.label_authorInfo.Size = new System.Drawing.Size(101, 12);
            this.label_authorInfo.TabIndex = 9;
            this.label_authorInfo.Text = "如有问题联系作者";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(403, 341);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://kktoo.com";
            // 
            // label_version
            // 
            this.label_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(12, 341);
            this.label_version.Name = "label_version";
            this.label_version.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_version.Size = new System.Drawing.Size(41, 12);
            this.label_version.TabIndex = 11;
            this.label_version.Text = "v1.0.0";
            this.label_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar_operation
            // 
            this.progressBar_operation.Location = new System.Drawing.Point(12, 277);
            this.progressBar_operation.Name = "progressBar_operation";
            this.progressBar_operation.Size = new System.Drawing.Size(510, 6);
            this.progressBar_operation.TabIndex = 12;
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(300, 236);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 13;
            this.button_clean.Text = "清空";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.progressBar_operation);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_authorInfo);
            this.Controls.Add(this.label_introduce);
            this.Controls.Add(this.button_selOutput);
            this.Controls.Add(this.textBox_outputPath);
            this.Controls.Add(this.textBox_dataPath);
            this.Controls.Add(this.label_output_path);
            this.Controls.Add(this.textBox_atlasPath);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.label_atlas);
            this.Controls.Add(this.button_operation);
            this.Controls.Add(this.button_selData);
            this.Controls.Add(this.button_selAtlas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texture Spliter";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_selAtlas;
        private System.Windows.Forms.Button button_selData;
        private System.Windows.Forms.Button button_operation;
        private System.Windows.Forms.Label label_atlas;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.OpenFileDialog openFileDialog_selAtlas;
        private System.Windows.Forms.OpenFileDialog openFileDialog_selData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_selOutput;
        private System.Windows.Forms.TextBox textBox_atlasPath;
        private System.Windows.Forms.TextBox textBox_dataPath;
        private System.Windows.Forms.Label label_output_path;
        private System.Windows.Forms.TextBox textBox_outputPath;
        private System.Windows.Forms.Button button_selOutput;
        private System.Windows.Forms.Label label_introduce;
        private System.Windows.Forms.Label label_authorInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.ProgressBar progressBar_operation;
        private System.Windows.Forms.Button button_clean;
    }
}

