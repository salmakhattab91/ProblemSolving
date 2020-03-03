using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            Console.WriteLine(MostCommonWord(text.ToLower(), banned));
            Console.Read();
        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            string value = "";
            Dictionary<string, int> list = new Dictionary<string, int>();
            char[] c = { '!','?', '\'', ',',';','.'};
            for(int i = 0; i<c.Length; i++)
            {
                if (paragraph.Contains(c[i]))
                {
                    paragraph = paragraph.Replace(c[i], ' ');
                }
            }
            string[] str = paragraph.Split(' ');
            
            for(int i = 0; i< str.Length; i++)
            {
                if(str[i] != "")
                {
                    if (!list.ContainsKey(str[i]) && !banned.Contains(str[i]))
                    {
                        list.Add(str[i], 1);
                    }
                    else
                    {
                        if (list.ContainsKey(str[i]))
                        list[str[i]] = (int)list[str[i]] + 1;
                    }

                }
                
            }
            int Maxcount = list.Values.Max();
            
            value =list.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return value;
        }
    }
}
