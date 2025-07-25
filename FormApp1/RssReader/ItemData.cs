using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader {
    public class ItemData {
        public required string? Title { get; set; }
        public required string? Link { get; set; }

        public class ListItem {
            public string DisplayName { get; }
            public string Url { get; }
            public object Name { get; internal set; }

            public ListItem(string d, string u) { DisplayName = d; Url = u; }
            public override string ToString() => DisplayName;

        }
    }
}
