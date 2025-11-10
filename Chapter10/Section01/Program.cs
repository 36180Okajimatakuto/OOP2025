using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //一気に読み込む
            var filePath = "./Greeting.txt";
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in lines) {
                Console.WriteLine(line);

            }
        }
    }
}






