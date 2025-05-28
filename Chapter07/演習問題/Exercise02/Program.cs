
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
    new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
    new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
    new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
    new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
    new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
    new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
    new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
};

            Console.WriteLine("7.2.1");
            Exercise1(books);

            Console.WriteLine("7.2.2");
            Exercise2(books);

            Console.WriteLine("7.2.3");
            Exercise3(books);

            Console.WriteLine("7.2.4");
            Exercise4(books);

            Console.WriteLine("7.2.5");
            Exercise5(books);

            Console.WriteLine("7.2.6");
            Exercise6(books);

            Console.WriteLine("7.2.7");
            Exercise7(books);
        }

        private static void Exercise1(List<Book> books) {
            var wandahuru = books.Where(b => b.Title.Contains("ワンダフル・C#ライフ"));
            foreach (var hon in wandahuru) {                     //汎用席が高いお手本文
                Console.WriteLine(hon.Price + "円:" + hon.Pages + "ページ");

            }
        }


        private static void Exercise2(List<Book> books) {
            var kensaku = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(kensaku);
        }

        private static void Exercise3(List<Book> books) {
            var heikin = books.Where(book => book.Title.Contains("C#")).Average(book => book.Pages);
            Console.WriteLine("平均ページ:" + heikin);
        }

        private static void Exercise4(List<Book> books) {
            var nedan = books.Where(b => b.Price >4000).Select(books => books.Title).First();
            Console.WriteLine(nedan);

        }

        private static void Exercise5(List<Book> books) {


        }

        private static void Exercise6(List<Book> books) {


        }

        private static void Exercise7(List<Book> books) {


        }
    }
}
