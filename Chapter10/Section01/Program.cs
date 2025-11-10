using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //10.11　既存テキストファイルの末尾に行を追加する
            var lines = new[] { "===", "京の夢", "大阪の夢", };
            var filePath = "./Example/いろは歌.txt";
            using (var writer = new StreamWriter(filePath, append: true)) {
                foreach (var line in lines) {
                    writer.WriteLine(line);

                }
            }
        }
    }
}






