﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Song {
        //2.1.1                                     = string.Empty;があるとより良い 
        //アーティスト名
        public string ArtistName { get; set; }
        //歌のタイトル
        public string Title { get; set; }
        //演奏時間
        public int Length { get; set; }


        //2.1.2
                //コンストラクタ
        //public  Song(string title, string artistName, int length) {
        //    this.Title = title;
        //    this.ArtistName = artistName;
        //    this.Length = length;

        //}
        //thisいらない






    }
}
