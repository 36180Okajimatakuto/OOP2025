using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator
{
    //売上集計クラス
    class SalesCounter
    {
        private readonly List<Sale> _sales;

        //コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;

        }
        //店舗別売上を求める
        public Dictionary<string, int> GetPerStreSales() {
            var dict = new Dictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName)) dict[sale.ShopName] += sale.Amount;
                else
                    dict[sale.ShopName] = sale.Amount;

            }
            return dict;
        }

    }
}
