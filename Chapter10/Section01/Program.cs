using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {//10.10　テキストファイルに一行ずつ文字列を出力する
            var filePath = "./Example/いろは歌.txt";
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("色はにほへど　散りぬるを");
                writer.WriteLine("我が世たれぞ　常ならむ)");
                writer.WriteLine("有為の奥山　今日越えて");
                writer.WriteLine("浅き夢見じ　酢ひもせず");
            }
        }
    }
}






