
using System.Runtime.InteropServices;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<String> names) {
            Console.WriteLine("都市名を入力。空行で終了");


            while ((true)) {



                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break;

                int index = names.FindIndex(s => s.Equals(name));
                Console.WriteLine(index);

            }
        }

        private static void Exercise2_2(List<String> names) {
            var Count = names.Count(s => s.Contains('o'));
            Console.WriteLine(Count);
        }

        private static void Exercise2_3(List<String> names) {
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in selected) {
                Console.WriteLine(name);

            }
        }

        private static void Exercise2_4(List<String> names) {
            var obj = names.Where(s => s.StartsWith('B')).Select(s => new { s, s.Length });

            foreach (var data in obj) {
                Console.WriteLine(data.s + ":" + data.Length + "文字");

            }
            //.Select(s => s.ToUpper());
        }
    }
}
