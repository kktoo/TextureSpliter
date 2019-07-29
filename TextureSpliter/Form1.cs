using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        //选择图集文件
        private void button_selAtlas_Click(object sender, EventArgs e)
        {
            openFileDialog_selAtlas.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//"E:/wkrm_donet/input/";
            openFileDialog_selAtlas.Filter = "图集文件|*.png";
            openFileDialog_selAtlas.RestoreDirectory = false;
            if(openFileDialog_selAtlas.ShowDialog() == DialogResult.OK)
            {
                string atlasFilePath = System.IO.Path.GetFullPath(openFileDialog_selAtlas.FileName);
                textBox_atlasPath.Text = atlasFilePath;
                //预测数据文件在同目录下，文件名相同
                if (string.IsNullOrEmpty(textBox_dataPath.Text))
                {
                    textBox_dataPath.Text = this.CutEndStr(atlasFilePath, ".png", ".json");
                }
                //预测输出在同目录下的output子目录下
                if (string.IsNullOrEmpty(textBox_outputPath.Text))
                {
                    textBox_outputPath.Text = System.IO.Path.GetDirectoryName(atlasFilePath) + "\\output";
                }
            }
        }

        //选择json数据文件
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

        //选择输出目标文件夹
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

        //解析并输出
        private void button_operation_Click(object sender, EventArgs e)
        {
            string atlasPath = textBox_atlasPath.Text;
            string dataPath = textBox_dataPath.Text;
            string aimFolderPath = textBox_outputPath.Text;

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

            button_operation.Enabled = false;

            int successNum = 0;
            int failedNum = 0;
            using (StreamReader file = File.OpenText(dataPath))
            {
                JsonSerializer se = new JsonSerializer();
                JsonData jsonData = se.Deserialize(file, typeof(JsonData)) as JsonData;
                foreach (var item in jsonData.frames)
                {
                    JsonFrameData curFrameData = item.Value as JsonFrameData;
                    string outImgName = this.CutEndStr(item.Key, "_png", ".png");
                    bool rst = ClipImage(atlasPath, aimFolderPath + "\\" + outImgName, curFrameData.x, curFrameData.y, curFrameData.w, curFrameData.h);
                    if (rst)
                    {
                        ++successNum;
                    }
                    else
                    {
                        ++failedNum;
                    }
                }
            }

            string parseMsg = "";
            if(failedNum <= 0)
            {
                parseMsg = "解析成功！";
            }
            else
            {
                parseMsg = "解析成功" + successNum + "条，失败"+ failedNum + "条";
            }
            if (successNum > 0)
            {
                parseMsg += "\r\n是否打开输出文件夹？";
            }
            
            DialogResult msgboxRst = MessageBox.Show(parseMsg, "提示", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == msgboxRst)
            {
                button_operation.Enabled = true;

                if (successNum > 0)
                {
                    System.Diagnostics.Process.Start("explorer.exe", aimFolderPath);
                }
            }
            else if(DialogResult.No == msgboxRst)
            {
                button_operation.Enabled = true;
            }
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
        /// <param name="s">源串</param>  
        /// <param name="searchStr">查找的串</param>  
        /// <param name="replaceStr">替换的目标串</param>  
        private string CutEndStr(string s, string searchStr, string replaceStr)
        {
            var result = s;
            try
            {
                if (string.IsNullOrEmpty(result))
                {
                    return result;
                }
                if (s.Length < searchStr.Length)
                {
                    return result;
                }
                if (s.IndexOf(searchStr, s.Length - searchStr.Length, searchStr.Length, StringComparison.Ordinal) > -1)
                {
                    result = s.Substring(0, s.Length - searchStr.Length);
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

    public class JsonFrameData
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int offX { get; set; }
        public int offY { get; set; }
        public int sourceW { get; set; }
        public int sourceH { get; set; }

    }

    public class JsonData
    {
        public string file { get; set; }
        public Dictionary<string, JsonFrameData> frames { get; set; }
    }
}
