using System.Collections.Generic;

namespace spliter
{
    /// <summary>
    /// json数据中的frame部分数据体
    /// </summary>
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

    /// <summary>
    /// json数据中的数据体
    /// </summary>
    public class JsonData
    {
        public string file { get; set; }
        public Dictionary<string, JsonFrameData> frames { get; set; }
    }
}
