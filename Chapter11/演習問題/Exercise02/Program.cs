using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            string filePath = "C:/Users/infosys/source/repos/OOP2025/Chapter11/演習問題/Exercise02/sample.txt";
            Pickup3DigitNumber(filePath); ;//↑パスを指定してファイル読み込みエラーを起こさないようにしている


            
        }
        private static void Pickup3DigitNumber(string filepath) {
            foreach (var line in File.ReadLines(filepath)) {
                var matches = Regex.Matches(line,@"\b\d{3,}\b");
                foreach (Match m in matches) {
                    //結果を出力
                    Console.WriteLine($"{m.Value}");

                }
            }
        }
    }
}
//Index={m.Index},Length={m.Length},