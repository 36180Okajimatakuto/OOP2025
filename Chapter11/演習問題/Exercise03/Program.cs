using System.Text.RegularExpressions;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            ];

            // ⬅️ 大文字小文字を無視して "time" を検索する正規表現
            //Regex regex = new Regex("time", RegexOptions.IgnoreCase);

            foreach (var line in texts) {//↓すべてを合体させてあるやつ
                var matches = Regex.Matches(line, @"\btime\b", RegexOptions.IgnoreCase);

                if (matches.Count > 0) {
                    foreach (Match match in matches) {
                        Console.WriteLine($"\"{line}\" {match.Index}");
                    }
                }
            }
        }
    }
}
