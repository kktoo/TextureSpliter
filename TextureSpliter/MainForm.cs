using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace spliter
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮事件-选择图集文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_selAtlas_Click(object sender, EventArgs e)
        {
            openFileDialog_selAtlas.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//"E:/wkrm_donet/input/";
            openFileDialog_selAtlas.Filter = "图集文件|*.png";
            openFileDialog_selAtlas.RestoreDirectory = false;
            if (openFileDialog_selAtlas.ShowDialog() == DialogResult.OK)
            {
                string atlasFilePath = System.IO.Path.GetFullPath(openFileDialog_selAtlas.FileName);
                string atlasFileNameWithoutExtension = Path.GetFileNameWithoutExtension(openFileDialog_selAtlas.FileName);
                textBox_atlasPath.Text = atlasFilePath;
                //预测数据文件在同目录下，文件名相同
                //if (string.IsNullOrEmpty(textBox_dataPath.Text))
                {
                    textBox_dataPath.Text = this.CutEndStr(atlasFilePath, ".png", ".json");
                }
                //预测输出在同目录下的output子目录下
                //if (string.IsNullOrEmpty(textBox_outputPath.Text))
                {
                    textBox_outputPath.Text = System.IO.Path.GetDirectoryName(atlasFilePath) + "\\" + atlasFileNameWithoutExtension + "_output";
                }
            }
        }

        /// <summary>
        /// 按钮事件-选择json数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_selData_Click(object sender, EventArgs e)
        {
            openFileDialog_selData.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//"E:/wkrm_donet/input/";
            openFileDialog_selData.Filter = "json文件|*.json";
            openFileDialog_selData.RestoreDirectory = false;
            if (openFileDialog_selData.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = Path.GetFullPath(openFileDialog_selData.FileName);
                textBox_dataPath.Text = jsonFilePath;
            }
        }

        /// <summary>
        /// 按钮事件-选择输出目标文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_selOutput_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_selOutput.ShowDialog() == DialogResult.OK)
            {
                string aimPath = this.folderBrowserDialog_selOutput.SelectedPath.Trim();
                if (aimPath != "")
                {
                    textBox_outputPath.Text = aimPath;
                }
            }
        }

        /// <summary>
        /// 按钮事件-解析并输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_operation_Click(object sender, EventArgs e)
        {
            this.DoParseOperation(textBox_atlasPath.Text, textBox_dataPath.Text, textBox_outputPath.Text);
        }

        /// <summary>
        /// 按钮事件-清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox_atlasPath.Text = textBox_dataPath.Text = textBox_outputPath.Text = string.Empty;
        }

        /// <summary>
        /// 载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            //设置版本号显示内容
            label_version.Text = "版本" + Application.ProductVersion;

            //设置初始状态
            this.SetCanOperation(true);
        }

        /// <summary>
        /// 执行解析操作
        /// </summary>
        private void DoParseOperation(string atlasPath, string dataPath, string aimFolderPath)
        {
            int invalidCode = 0;
            string invalidInfo = "";

            //检查合法性
            do
            {
                if (string.IsNullOrEmpty(atlasPath))
                {
                    invalidCode = 1;
                    invalidInfo = "图集路径不可为空";
                    break;
                }
                if (string.IsNullOrEmpty(dataPath))
                {
                    invalidCode = 2;
                    invalidInfo = "数据路径不可为空";
                    break;
                }
                if (string.IsNullOrEmpty(aimFolderPath))
                {
                    invalidCode = 3;
                    invalidInfo = "输出路径不可为空";
                    break;
                }

                //检查目标目录是否存在，不存在则创建
                try
                {
                    if (!Directory.Exists(aimFolderPath))
                    {
                        Directory.CreateDirectory(aimFolderPath);
                    }
                }
                catch (Exception folderException)
                {
                    invalidCode = 4;
                    break;
                }

                break;

            } while (true);


            if (0 != invalidCode)
            {
                string info = "哦豁~出错了." + invalidInfo + "\r\n" + "错误码：" + invalidCode;
                MessageBox.Show(info, "提示", MessageBoxButtons.OK);
                return;
            }

            //禁用解析操作，避免等待期连续点击
            this.SetCanOperation(false);

            int successNum = 0;
            int failedNum = 0;
            using (StreamReader file = File.OpenText(dataPath))
            {
                JsonSerializer se = new JsonSerializer();
                JsonData jsonData = se.Deserialize(file, typeof(JsonData)) as JsonData;
                int processMaxNum = jsonData.frames.Count;
                foreach (var item in jsonData.frames)
                {
                    JsonFrameData curFrameData = item.Value as JsonFrameData;
                    //如果json中的frame name有扩展名，则替换扩展名格式
                    string outImgName = this.CutEndStr(item.Key, "_png", ".png");
                    //如果json中的frame name没有扩展名，则追加扩展名
                    if (!outImgName.EndsWith(".png"))
                    {
                        outImgName += ".png";
                    }
                    bool rst = ClipImage(atlasPath, aimFolderPath + "\\" + outImgName, curFrameData.x, curFrameData.y, curFrameData.w, curFrameData.h);
                    if (rst)
                    {
                        ++successNum;
                    }
                    else
                    {
                        ++failedNum;
                    }
                    //更新进度条数据 TODO:改成异步方式
                    int percentNum = 0;
                    if (processMaxNum > 0)
                    {
                        percentNum = (int)(((float)(successNum + failedNum) / (float)processMaxNum) * 100);
                    }
                    this.SetOperationProcess(percentNum);
                }
            }

            string parseMsg = "";
            if (failedNum <= 0)
            {
                parseMsg = "解析成功！";
            }
            else
            {
                parseMsg = "解析成功" + successNum + "条，失败" + failedNum + "条";
            }
            if (successNum > 0)
            {
                parseMsg += "\r\n是否打开输出文件夹？";
            }

            DialogResult msgboxRst = MessageBox.Show(parseMsg, "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == msgboxRst)
            {
                this.SetCanOperation(true);

                if (successNum > 0)
                {
                    //调用文件管理器打开目标文件夹
                    System.Diagnostics.Process.Start("explorer.exe", aimFolderPath);
                }
            }
            else if (DialogResult.No == msgboxRst)
            {
                this.SetCanOperation(true);
            }
        }

        /// <summary>
        /// 设置是否可以执行解析操作
        /// </summary>
        /// <param name="isEnable"></param>
        private void SetCanOperation(Boolean isEnable)
        {
            button_operation.Enabled = isEnable;
            progressBar_operation.Visible = !isEnable;
            this.SetOperationProcess(0);
        }

        /// <summary>
        /// 设置进度条显示值
        /// </summary>
        /// <param name="curValue"></param>
        private void SetOperationProcess(int curValue)
        {
            progressBar_operation.Value = curValue;
        }

        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="fromImagePath">来源图片地址</param>        
        /// <param name="offsetX">从偏移X坐标位置开始截取</param>
        /// <param name="offsetY">从偏移Y坐标位置开始截取</param>
        /// <param name="toImagePath">保存图片地址</param>
        /// <param name="width">保存图片的宽度</param>
        /// <param name="height">保存图片的高度</param>
        /// <returns></returns>
        private bool ClipImage(string fromImagePath, string toImagePath, int offsetX, int offsetY, int width, int height)
        {
            bool rst = false;
            try
            {
                Bitmap src = new Bitmap(fromImagePath);
                Bitmap output = src.Clone(new Rectangle(offsetX, offsetY, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
                output.Save(toImagePath, ImageFormat.Png);
                output.Dispose();
                src.Dispose();

                rst = true;
            }
            catch (Exception)
            {
                rst = false;
            }

            return rst;
        }


        /// <summary>  
        /// 替换末尾位置中指定的文件扩展名  
        /// </summary>  
        /// <param name="sourceStr">源串</param>  
        /// <param name="searchStr">查找的串</param>  
        /// <param name="replaceStr">替换的目标串</param>  
        private string CutEndStr(string sourceStr, string searchStr, string replaceStr)
        {
            var result = sourceStr;
            try
            {
                if (string.IsNullOrEmpty(result))
                {
                    return result;
                }
                if (sourceStr.Length < searchStr.Length)
                {
                    return result;
                }
                if (sourceStr.IndexOf(searchStr, sourceStr.Length - searchStr.Length, searchStr.Length, StringComparison.Ordinal) > -1)
                {
                    result = sourceStr.Substring(0, sourceStr.Length - searchStr.Length);
                    result += replaceStr;
                }

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }
    }


}
