using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWeWebSite
{
    public class ResourceUtil
    {
        public string OutputLangNameString(string code)
        {
            switch (code)
            {
                case "zh-TW":
                    return Resources.Resource.TraditionalChineseString;
                case "zh-CHT":
                case "zh-CHS":
                case "zh-CN":
                case "zh-HK":
                    return Resources.Resource.SimplifiedChineseString;
                case "ja-JP":
                    return Resources.Resource.JapaneseString;
                default:
                    return Resources.Resource.EnglishString;
            }
        }
        public int OutputLangNameNumber(string code)
        {
            switch (code)
            {
                case "zh-TW":
                    return 0;
                case "zh-CHT":
                case "zh-CHS":
                case "zh-CN":
                case "zh-HK":
                    return 1;
                case "ja-JP":
                    return 3;
                default:
                    return 2;
            }
        }
        public string OutputLangNameToAttrName(string code)
        {
            switch (code)
            {
                case "zh-TW":
                    return "Name";
                case "zh-CHT":
                case "zh-CHS":
                case "zh-CN":
                case "zh-HK":
                    return "CnName";
                case "ja-JP":
                    return "JpName";
                default:
                    return "EngName";
            }
        }
    }
}