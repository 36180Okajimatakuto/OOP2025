using System.IO;
using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var filePath = "./Greeting.txt";
   
            //10.4 先頭のN行を取り出す
            var lines = File.ReadLines(filePath)
                .Take(10)
                .ToArray();

            //10.5　条件に一致した行数をカウントする
            var count = File.ReadLines(filePath).Count(s=>s.Contains("C#"));

            //10.6　条件に一致した行だけを取り出す
            var liness = File.ReadLines(filePath)
                .Where(s=> !String.IsNullOrWhiteSpace(s))
            .ToArray();

            //10.7　条件に一致した行が存在しているか調べる
            var exists = File.ReadLines(filePath)
                .Where(s=> !String.IsNullOrEmpty(s))
                .Any(s=> s.All(c=>Char.IsDigit(c)));

            //10.8　重複行を取り除き並べ替える
            var linesss = File.ReadLines(filePath)
                .Distinct()
                .OrderBy(s=> s.Length)
                .ToArray();

            //10.9　行ごとに何らかの変換処理をする
            var linessss = File.ReadLines(filePath)
                .Select((s,ix) => $"(ix + 1,4): {s}");
            foreach (var line  in lines) {
                Console.WriteLine(line);

            }
        }
    }
}






