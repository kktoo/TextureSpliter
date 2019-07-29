namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_selAtlas
            // 
            this.button_selAtlas.Location = new System.Drawing.Point(424, 55);
            this.button_selAtlas.Name = "button_selAtlas";
            this.button_selAtlas.Size = new System.Drawing.Size(75, 23);
            this.button_selAtlas.TabIndex = 2;
            this.button_selAtlas.Text = "选择图集";
            this.button_selAtlas.UseVisualStyleBackColor = true;
            this.button_selAtlas.Click += new System.EventHandler(this.button_selAtlas_Click);
            // 
            // button_selData
            // 
            this.button_selData.Location = new System.Drawing.Point(424, 119);
            this.button_selData.Name = "button_selData";
            this.button_selData.Size = new System.Drawing.Size(75, 23);
            this.button_selData.TabIndex = 4;
            this.button_selData.Text = "选择数据";
            this.button_selData.UseVisualStyleBackColor = true;
            this.button_selData.Click += new System.EventHandler(this.button_selData_Click);
            // 
            // button_operation
            // 
            this.button_operation.Location = new System.Drawing.Point(234, 241);
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
            this.label_atlas.Location = new System.Drawing.Point(15, 29);
            this.label_atlas.Name = "label_atlas";
            this.label_atlas.Size = new System.Drawing.Size(77, 12);
            this.label_atlas.TabIndex = 3;
            this.label_atlas.Text = "导入图集文件";
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Location = new System.Drawing.Point(15, 95);
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
            this.textBox_atlasPath.Location = new System.Drawing.Point(86, 57);
            this.textBox_atlasPath.Name = "textBox_atlasPath";
            this.textBox_atlasPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_atlasPath.TabIndex = 1;
            // 
            // textBox_dataPath
            // 
            this.textBox_dataPath.Location = new System.Drawing.Point(86, 121);
            this.textBox_dataPath.Name = "textBox_dataPath";
            this.textBox_dataPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_dataPath.TabIndex = 3;
            // 
            // label_output_path
            // 
            this.label_output_path.AutoSize = true;
            this.label_output_path.Location = new System.Drawing.Point(15, 159);
            this.label_output_path.Name = "label_output_path";
            this.label_output_path.Size = new System.Drawing.Size(53, 12);
            this.label_output_path.TabIndex = 4;
            this.label_output_path.Text = "输出目录";
            // 
            // textBox_outputPath
            // 
            this.textBox_outputPath.Location = new System.Drawing.Point(86, 185);
            this.textBox_outputPath.Name = "textBox_outputPath";
            this.textBox_outputPath.Size = new System.Drawing.Size(332, 21);
            this.textBox_outputPath.TabIndex = 5;
            // 
            // button_selOutput
            // 
            this.button_selOutput.Location = new System.Drawing.Point(424, 183);
            this.button_selOutput.Name = "button_selOutput";
            this.button_selOutput.Size = new System.Drawing.Size(75, 23);
            this.button_selOutput.TabIndex = 6;
            this.button_selOutput.Text = "选择目录";
            this.button_selOutput.UseVisualStyleBackColor = true;
            this.button_selOutput.Click += new System.EventHandler(this.button_selOutput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "功能：将由白鹭TextureMerger打包的png文件和json文件解析出单个图片，方便二次修改。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "如有问题请联系作者";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(134, 325);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.kktoo.net";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Text = "TextureSpliter";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

