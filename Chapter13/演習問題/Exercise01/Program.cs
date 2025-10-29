
using System.Linq;
using System.Runtime.InteropServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();
            Console.ReadLine();

        }

        private static void Exercise1_2() {
            var hon = Library.Books.MaxBy(h => h.Price);
            Console.WriteLine(hon);
        }

        private static void Exercise1_3() {
            var results = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(b => b.Key)//並び替えにOrderBy
                .Select(b => new {//←匿名クラス　　設定したいやつの値をいれている
                    PublishedYear = b.Key,
                    Count = b.Count()});

            foreach (var item in results) {
                Console.WriteLine($"{item.PublishedYear}:{item.Count}");//設定したやつを入れる
            }
        }

        private static void Exercise1_4() {
            var matometesort = Library.Books.OrderByDescending(m => m.PublishedYear)
                .ThenByDescending(b => b.Price);
            foreach (var item in matometesort) {


                Console.WriteLine($"{item.PublishedYear}年{item.Price}円{item.Title}");
            }    

        }

        private static void Exercise1_5() {

            var itiran = Library.Books.Where(b => b.PublishedYear == 2022)
                        .Join(Library.Categories,
                        b => b.CategoryId,
                        c => c.Id,
                        (b, c) => new { c.Name })//joinを使った絞り込み↑
                        .Distinct();

            foreach (var name in itiran) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            var kobetu = Library.Books
                .Join(Library.Categories,
                    b => b.CategoryId,
                    c => c.Id,
                    (b,c) => new {
                        CategoryName = c.Name,
                        b.Title
                    })
                .GroupBy(x=>x.CategoryName)
                .OrderBy(x=>x.Key);

            foreach (var group in kobetu) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {//重ねることで２つ文を表現
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var groups = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books,
                    c => c.Id,
                    b => b.CategoryId,
                    (c, b) => new {
                        b.Title,
                        b.PublishedYear
                    })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key);
            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"{book.Title}");
                }

            }
                    
        }

        private static void Exercise1_8() {
           
        }
    }
}
