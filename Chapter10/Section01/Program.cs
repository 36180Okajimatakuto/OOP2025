using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //一気に読み込む
            var filePath = "./Greeting.txt";
            if (File.Exists(filePath)) {
                using var reader = new StreamReader(filePath,Encoding.UTF8);
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                
                }



            }
        }
    }
}
