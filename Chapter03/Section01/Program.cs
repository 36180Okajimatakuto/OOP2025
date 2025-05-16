using System.Security.Cryptography.X509Certificates;

namespace Section01 {
    internal class Program {

        


        static void Main(string[] args) {



            //Console.WriteLine("カウントしたい数値");
            //int num = int.Parse(Console.ReadLine());

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };


            Console.WriteLine(Count(numbers, delegate(int n){return n % 2 == 0; }));
            ;

            //Console.Write("カウントしたい数値" + Count);      汎用性が低い
        }



            static int Count(int[] numbers, Predicate<int> judge) {
                var count = 0;
                foreach (var n in numbers) {
                    if (judge(n) == true) {
                        count++;

                    }

                }
                return count;
            }
        
    }
}
