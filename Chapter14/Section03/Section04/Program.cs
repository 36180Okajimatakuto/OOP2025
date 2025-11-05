namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hc = new HttpClient();
            await GetHtmlExample(hc);
        }

        static async Task GetHtmlExample(HttpClient httpCliant) {
            var url = "https://chatgpt.com";
            var text = await httpCliant.GetStreamAsync(url);
            Console.WriteLine(text);
        }
    }
}
