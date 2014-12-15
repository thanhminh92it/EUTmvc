using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Office.Interop.Word;

namespace EUTmvc.Utils
{
    public class ConvertToHtml
    {
        public static void Convert(string path, string wordName)
        {

            var dirInfo = new DirectoryInfo(path);
            const WdSaveFormat format = WdSaveFormat.wdFormatFilteredHTML;

            FileInfo[] wordFiles = dirInfo.GetFiles(wordName);
            if (wordFiles.Length == 0)
            {
                return;
            }

            object oMissing = System.Reflection.Missing.Value;
            var word = new Application();
            try
            {
                word.Visible = false;
                word.ScreenUpdating = false;
                foreach (var wordFile in wordFiles)
                {
                    var filename = (Object)wordFile.FullName;
                    var doc = word.Documents.Open(ref filename, ref oMissing,
                                                       ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                       ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                       ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    try
                    {
                        doc.Activate();
                        object outputFileName = wordFile.FullName.Replace(".docx", ".html");
                        object fileFormat = format;
                        doc.SaveAs(ref outputFileName,
                                   ref fileFormat, ref oMissing, ref oMissing,
                                   ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                   ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                   ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    }
                    finally
                    {
                        object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                        ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
                        doc = null;
                    }
                }

            }
            finally
            {
                ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
                word = null;
            }
        }
        public static string RemoveTagsRegex(string source)
        {
            string str = StripTagsCharArray(source);
            return Regex.Replace(str, "<.*?>", string.Empty);
        }
        public static string StripTagsCharArray(string str)
        {
            string array = "";
            bool inside = true;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<')
                {
                    // tag <p>
                    if (str[i + 1] != '/')
                    {
                        if (str[i + 1] == 'p')
                        {
                            inside = false;
                            array += str[i++];
                            array += str[i];
                            continue;
                        }
                        //tag <span>
                        if (str[i + 1] == 's' && str[i + 2] == 'p' && str[i + 3] == 'a' && str[i + 4] == 'n')
                        {
                            array += str[i++];
                            array += str[i++];
                            array += str[i++];
                            array += str[i++];
                            array += str[i];
                            inside = false;
                            continue;
                        }
                        //tag <table>
                        if (str[i + 1] == 't' && str[i + 2] == 'a' && str[i + 3] == 'b' && str[i + 4] == 'l' && str[i + 5] == 'e')
                        {
                            array += str[i++];
                            array += str[i++];
                            array += str[i++];
                            array += str[i++];
                            array += str[i++];
                            array += str[i];
                            inside = false;
                            continue;
                        }
                        //tag <td>
                        if (str[i + 1] == 't' && str[i + 2] == 'd')
                        {
                            array += str[i++];
                            array += str[i++];
                            array += str[i];
                            inside = false;
                            continue;
                        }
                    }

                }
                if (str[i] == '>')
                {
                    inside = true;
                    //continue;
                }
                if (inside)
                {
                    char let = str[i];
                    if (System.Convert.ToInt32(let) == 160)
                    {
                        let = ' ';
                    }
                    array += let;
                }
            }
            return array;
        }
    }
}