using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string path = "text.txt";
            string text = "";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    text += line;
                }
            }

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
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value + "; Частота - " + pi);
                sum += pi * Math.Log(pi, 2);
            }
            Console.WriteLine("Количество символов - " + all);
            Console.WriteLine("Количество информации - " + sum*(-1));
        }
    }
}