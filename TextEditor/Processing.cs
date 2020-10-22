using System.Text.RegularExpressions;


namespace TextEditor
{
    internal static class Processing { 

        static public string DeleteWord(this string s, int minLen)
        {
            return Regex.Replace(s, @"\w+", delegate (Match match)
            {
                string v = match.ToString();
                string res = v.Substring(0);
                if (v.Length >= minLen)
                    return res;

                return null; 
            });
        }
    }
}
