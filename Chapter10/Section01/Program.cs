using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //10.13　文字列の配列を一気にファイルに出力する
            var names = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berin", "Canberra" ,"Hongkong", };
            var filePath = "./Example/Cities.txt";
            File.WriteAllLines(filePath, names.Where(s => s.Length > 5));



        }
    }
}








