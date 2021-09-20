using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.c-sharpcorner.com/UploadFile/9b86d4/getting-started-with-html-agility-pack/");
            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//div[@class='PaddingLeft5']//p"))
            {
                text += link.InnerText;
            }
            
            Console.OutputEncoding = System.Text.Encoding.Default;
                Dictionary<char, int> OdinS = new Dictionary<char, int>();

                char[] chrM = text.ToCharArray();
                for (int k = 0; k < chrM.Length; k++)
                {
                    if (!OdinS.ContainsKey(chrM[k]))
                    {
                        OdinS.Add(chrM[k], 1);
                    }
                    else
                    {
                        OdinS[chrM[k]] += 1;
                    }
                }
                double sum=0;
                double all=0;
                foreach (KeyValuePair<char, int> keyValue in OdinS.OrderBy(pair => pair.Value))
                {
                    all += keyValue.Value;
                }
                foreach (KeyValuePair<char, int> keyValue in OdinS.OrderBy(pair => pair.Value))
                {
                    double pi = keyValue.Value / all;
                    sum += pi * Math.Log(pi, 2);
                    if (keyValue.Key == '\n')
                    {
                        Console.WriteLine("\\n" + " - " + keyValue.Value + "; Частота - " + pi);    
                    }
                    else if (keyValue.Key == '\r')
                    {
                        Console.WriteLine("\\r" + " - " + keyValue.Value + "; Частота - " + pi);
                    }
                    else
                    {
                        Console.WriteLine(keyValue.Key + " - " + keyValue.Value + "; Частота - " + pi);
                    }
                    
                }

                Console.WriteLine("Количество символов - " + all);
                Console.WriteLine("Количество информации - " + sum*(-1));
            
        }
    }
}