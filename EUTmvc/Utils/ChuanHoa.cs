using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EUTmvc.Utils
{
    /// <summary>
    /// Summary description for ChuanHoa
    /// </summary>
    public class ChuanHoa
    {
        public static string ChuanHoaXau(string s)
        {
            s = s.Trim();
            s = s.ToLower();
            while (s.Contains("  "))
            {
                s = s.Replace("  ", " ");
            }
            char[] charArr = s.ToCharArray();
            charArr[0] = Char.ToUpper(charArr[0]);
            for (int i = 1; i < s.Length-1; i++)
            {
                if (charArr[i] == ' ')
                {
                    charArr[i + 1] = Char.ToUpper(charArr[i + 1]);
                }
            }
            return new String(charArr);
        }

        public static string ChuanHoaHTML(string s)
        {
            string str = ChuanHoaXau(s);
            while (str.Contains("&nbsp;&nbsp;"))
            {
                str = str.Replace("&nbsp;&nbsp;", "&nbsp;");
            }
            return str;
        }
        public string ConvertToUnSign(string text)
        {
            text = text.Trim();
            text = text.ToLower();
            var regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(NormalizationForm.FormD);
            char[] charA= regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (!kiemtrakt(charA[i]))
                {
                    charA[i] = ' ';
                }
            }
            text = new String(charA);
            text = text.Trim();
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            text = text.Replace(" ", "_");
            return text;
        }
        public bool kiemtrakt(char a)
        {
            var k = ((int)a);
            if (k>=48 && k<=57)
            {
                return true;
            }
            if (k >= 97 && k <= 122)
            {
                return true;
            }
            if (k >= 65 && k <= 90)
            {
                return true;
            }
            return false;
        }
        public string Date(DateTime _date)
        {
            var date = Convert.ToDateTime(_date);
            return date.ToString("dd/MM/yyyy");
        }
        public static string ChuoiNkitu(string s, int length)
        {
            s += "";
            s = ChuanHoaHTML(s);
            var sb = new StringBuilder();
            sb.Append("");
            if (s.Length > 0)
            {
                var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (words[0].Length <= length)
                {

                    foreach (var word in words)
                    {
                        if ((sb + word).Length > length)
                            return string.Format("{0}...", sb.ToString().TrimEnd(' '));
                        sb.Append(word + " ");
                    }
                }
            }
            return string.Format("{0}...", sb.ToString().TrimEnd(' '));
        }
    }
}