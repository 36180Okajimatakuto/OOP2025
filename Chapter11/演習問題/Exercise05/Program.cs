using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise05 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadLines("sample.html");
            var sb = new StringBuilder();

            foreach (var line in lines) {
                // タグ名を小文字に変換
                var s = Regex.Replace(line, @"<(/?)([A-Z][A-Z0-9]*)([^>]*)>", m => {
                    string slash = m.Groups[1].Value;
                    string tagName = m.Groups[2].Value.ToLower();
                    string rest = m.Groups[3].Value;
                    return $"<{slash}{tagName}{rest}>";
                });

                sb.AppendLine(s);
            }

            File.WriteAllText("sampleOut.html", sb.ToString());
        }
    }
}
