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
                textBox_dataPath.Text = this.CutEndStr(atlasFilePath, ".png", ".json");
                //预测输出在同目录下的output子目录下
                textBox_outputPath.Text = System.IO.Path.GetDirectoryName(atlasFilePath) + "\\output";
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
            string aimFolderPath = textBox_outputPath.Text;
            if (aimFolderPath != "")
            {
                bool checkRst = false;

                //检查目标目录是否存在，不存在则创建
                try
                {
                    if (!Directory.Exists(aimFolderPath))
                    {
                        Directory.CreateDirectory(aimFolderPath);
                    }
                    checkRst = true;
                }
                catch (Exception folderException)
                {
                    checkRst = false;
                }

                if (!checkRst)
                {
                    MessageBox.Show("解析出错", "提示", MessageBoxButtons.OK);
                    return;
                }
                TextReader file = File.OpenText(textBox_dataPath.Text);
                JsonTextReader reader = new JsonTextReader(file);
                JObject obj = JToken.ReadFrom(reader) as JObject;
                string imgFileName = obj["file"].ToString();
                string framesStr = obj["frames"].ToString();

                Dictionary<string, JsonFrameData> frameDict = new Dictionary<string, JsonFrameData> { };
                frameDict = JsonConvert.DeserializeObject<Dictionary<string, JsonFrameData>>(framesStr);
                foreach (var item in frameDict)
                {
                    JsonFrameData curFrameData = item.Value as JsonFrameData;
                    string outImgName = this.CutEndStr(item.Key, "_png", ".png");
                    ClipImage(textBox_atlasPath.Text, aimFolderPath + "\\" + outImgName, curFrameData.x, curFrameData.y, curFrameData.w, curFrameData.h);
                }

                if (MessageBox.Show("解析成功！\r\n是否打开输出文件夹？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", aimFolderPath);
                }
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
        private void ClipImage(string fromImagePath, string toImagePath, int offsetX, int offsetY, int width, int height)
        {
            try
            {
                Bitmap src = new Bitmap(fromImagePath);
                Bitmap output = src.Clone(new Rectangle(offsetX, offsetY, width, height), System.Drawing.Imaging.PixelFormat.DontCare);
                output.Save(toImagePath, ImageFormat.Png);
                output.Dispose();
                src.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

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
}
