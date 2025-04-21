﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    //商品クラス
    public class Product {
        //商品コード
        public int Code { get; set; }           //プロパティ
        //商品名
        public string Name { get; set; }
        //商品価格（税抜き）
        public int Price { get; set; }

        

        //消費税率は10%
        private readonly double _taxRate = 0.1;  //フィールド
                //↑読み取り専用

        //消費税額を求める
        public int GetTax() {                    //メソッド
            return (int)(Price * _taxRate);
        }

        //コンストラクター
        public  Product(int code, string name, int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;

        }

        //税込み価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}
