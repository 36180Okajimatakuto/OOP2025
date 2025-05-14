namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            int Count = int.Parse(Console.ReadLine());
            Console.Write("カウントしたい数値" + Count);
        }

        static int Count(int num) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = 0;
            foreach (var n in numbers) {
                if(n == num) {
                    count++;

                }

            }
            return count;
        }
    }
}
