namespace TextFileProsessorDI {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineCounterService();
            var processor = new TextFileProsessor(service);
            Console.WriteLine("パスの入力:");
            processor.Run(Console.ReadLine());

        }
    }
}
