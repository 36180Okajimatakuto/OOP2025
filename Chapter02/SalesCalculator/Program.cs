﻿
namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {;
            var sales = new SalesCounter (@"data\sales.csv");

            var amountsPerStore = sales.GetPerStoreSales();

            foreach (var obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }

    

















        ////売上データを読み込み、Saleオブジェクトのリストを返す
        //static List<Sale> ReadSales(string filePath) {
        //    //売上データを入れるリストオブジェクトを生成
        //    List<Sale> sales = new List<Sale>();
        //    //ファイルを一気に読み込み
        //    string[] lines = File.ReadAllLines(filePath);
        //    //読み込んだ行数分繰り返し
        //    foreach (string line in lines) {
        //        string[] items = line.Split(',');
        //        //Saleオブジェクトを生成
        //        Sale sale = new Sale() { 
        //        ShopName = items[0],
        //        ProductCategory = items[1],
        //        Amount = int.Parse(items[2]),
        //            };
        //        sales.Add(sale);

        //    }

        //    return sales;

    }
}
