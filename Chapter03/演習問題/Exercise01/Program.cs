using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);


            void Exercise1(List<int> numbers) {
                var exists = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);
                if (exists)
                    Console.WriteLine("存在しています");
                else
                    Console.WriteLine("存在していません");
            }
            void Exercise2(List<int> numbers) {
                numbers.ForEach(s => Console.WriteLine(s / 2));

            }
            void Exercise3(List<int> numbers) {

            }

            void Exercise4(List<int> numbers) {

            }
        }
    }
}
    
            




    
