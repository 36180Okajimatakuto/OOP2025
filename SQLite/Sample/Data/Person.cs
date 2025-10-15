using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample.Data
{
    class Person
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; } = String.Empty;

        public override string ToString() {
            return $"{Id}{Name}{Phone}";
        }
    }
}
