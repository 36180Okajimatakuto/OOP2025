using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //10.12　文字列の配列を一気にファイルに出力する
            var lines = new[] { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", };
            var filePath = "./Example/Cities.txt";
            File.WriteAllLines(filePath,lines);

        }
    }
}








