using System.Text;
using System.Text.RegularExpressions;

namespace Exercise05 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadLines("sample.html");
            var sb = new StringBuilder();
            foreach (var line in lines) {
                var s = Regex.Replace(line, @"<(/?)([A-Z][A-Z0-9]*)(.*)>",
                    m => {
                        string.Format(m.Groups[1].Value,
                            m.Groups[2].Value.ToLower(),
                            m.Groups[3].Value)}
                        "<$1$2$3">};



            }
            File.WriteAllText("sampleOut.html", sb.ToString());
        }
    }
}
