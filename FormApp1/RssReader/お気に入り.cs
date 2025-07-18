using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace RssReader
{
    public partial class お気に入り : Form {
        public お気に入り() {
            InitializeComponent();
        }

        private void お気に入り_Load(object sender, EventArgs e) {

        }

        private string historyFilePath = "search_history.txt";

        # region 履歴を保存&読み込み
        // 履歴を保存（キーワード＋結果）
        public void SaveSearchResult(string keyword, string result) {
            string entry = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss}\tキーワード: {keyword}\n結果:\n{result}\n--------------------------\n";
            File.AppendAllText(historyFilePath, entry);
        }

        // 履歴を全部読み込む
        public string LoadAllHistory() {
            if (!File.Exists(historyFilePath))
                return "履歴はまだありません。";

            return File.ReadAllText(historyFilePath);
        }
        #endregion

        private お気に入り historyManager = new お気に入り();

        private void button2_Click(object sender, EventArgs e) {
            string keyword = historyManager.Text;

            // ここに検索処理を書く（例：Webから情報取得など）
            string searchResult = "検索結果の例テキスト";

            // 検索結果を保存
            historyManager.SaveSearchResult(keyword, searchResult);

            // 結果表示
            historyManager.Text = searchResult;
        }
    }

}
