using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //テキストファイルをIEbumerable<string>として扱う
            var filePath = "./Greeting.txt";
            var lines = File.ReadLines(filePath);
            foreach (var line in lines) {
                Console.WriteLine(line);

            }
        }
    }
}






