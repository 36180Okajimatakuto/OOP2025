using static System.Reflection.Metadata.BlobBuilder;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {



            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine(books.Average(x => x.Price));

            //本のページ合計を表示
            Console.WriteLine(books.Sum(n => n.Pages));



            //金額の安い書籍名と金額を表示

            //Containsを使った文                                                 ↓Firstがないとタイトルや値段を指定できない
            var saiyasune = books.Where(b => b.Price == books.Min(b=>b.Price)).First();
            Console.WriteLine(saiyasune.Title + ":" + saiyasune.Price);



            //OrderByで解決しちゃおうのやつ
            //var saiyasune = books.OrderBy(s => s.Price).First();
            //Console.WriteLine(saiyasune.Title +":"+ saiyasune.Price + "円");



            //ページが多い書籍名とページ数を表示
            var tapage = books.Where(b => b.Pages == books.Max(b => b.Pages)).First();
            Console.WriteLine(tapage.Title + ":" + tapage.Pages);



            //タイトルに「物語」が含まれている書籍名をすべて表示
            var kensaku = books.Where(b => b.Title.Contains("物語"));
            foreach (var hon in kensaku) {                     //汎用席が高いお手本文
                Console.WriteLine(hon.Title);

            }



        }
    }
}
