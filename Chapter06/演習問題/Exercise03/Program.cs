
using System;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion

        }

        private static void Exercise6(string text) {

            var str = text.ToLower();

            var alphDicCount = Enumerable.Range('a', 26).ToDictionary(num => ((char)num).ToString(), num => 0);

            foreach (var alph in str) {
                //alphDicCount[alph.ToString()]++; //お手本１


            }
            foreach (var item in alphDicCount) {
                Console.WriteLine(item.Key + ":" + item.Value);

            }

            //******************************************************
            var array = Enumerable.Repeat(0,26).ToString();
            foreach (var alph in str) {
               

            }

            for (char ch = 'a'; ch < 'z'; ch++) {
                Console.WriteLine(ch + ":" + array[ch - 'a']);

            }

            //***************************************************
            //aから順にカウントして出力
            for (char ch = 'a'; ch < 'z'; ch++) {
                Console.WriteLine(ch + ":" + text.Count(tc => tc == ch));
            }

        




            //var counts = text.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            //var seiri = text.OrderBy(g => g);                                     //チャットGPTのやつ
            //foreach (var pair in counts) {
            //    Console.WriteLine(pair.Key +":" +pair.Value +"個");
            //}

            //　　↓アルファベットにするために必要
            
            //for (char te = 'a'; te <= 'z'; te++) {
            //    int count = text.Count(t => char.ToLower(t) == te);
           
            //        Console.WriteLine(te + " : " + count);                自作
                
            //}
        }

        private static void Exercise1(string text) {

            //var spases = text.Count(c=>c ==  ' ');

            
            int count = text.Count(c => c == ' ');

            Console.WriteLine($"空白の数: " + count);
        }


        private static void Exercise2(string text) {
            var newtext = text.Replace("big", "small");


            Console.WriteLine(newtext);
        }



        private static void Exercise3(string text) {

            var array = text.Split(' ');
            var sb = new StringBuilder();


             string str = "";
            foreach (var word in array.Skip(0)) {
                sb.Append(" ");
                sb.Append(word);
               

            }
            Console.WriteLine(sb + ".");
    
        }
        


       


        private static void Exercise4(string text) {
            
            //int count = text.Count(c => c == ' ');
                                                                      // オリジナル
            //Console.WriteLine("単語数は:" + (1 + count));


            var count = text.Split(' ').Length;
            Console.WriteLine("単語数：" + count);//  模範解答

        }　

            

        

        private static void Exercise5(string text) {
            //var tangocount = text.Where(c => c < 4);
            //Console.WriteLine(tangocount);


            var words = text.Split(' ');

            foreach (var word in words) {         //gpt
                if (word.Length <= 4) {
                    System.Console.WriteLine(word);
                }

            }
        }
    }
}


