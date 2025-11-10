namespace Section02 {
    internal class Program {
        static void Main(string[] args) {


            var filePath = "./Example/いろは歌.txt";
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            using var reader = new StreamReader(stream);
            using var writer = new StreamWriter(stream);

            string texts = reader.ReadToEnd();
            stream.Position = 0;
            writer.WriteLine("挿入する新しい行１");
            writer.WriteLine("挿入する新しい行2");
            writer.WriteLine(texts);
        }
    }
}
