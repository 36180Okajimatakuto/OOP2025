using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace CustomerApp.Data
{
    internal class Customer {

        [PrimaryKey,AutoIncrement]

        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// 画像
        /// </summary>
        public byte[] Picture { get; set; }
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string Postcode { get; set; } = string.Empty;



        [Ignore]
        public BitmapImage ImageSource => Picture != null && Picture.Length > 0 ? ToBitmapImage(Picture) : null;

        private BitmapImage ToBitmapImage(byte[] bytes) {
            using var ms = new MemoryStream(bytes);
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();
            return image;
        }
    }

}



