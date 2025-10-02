using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows;
using System;

namespace ConverterApp {
    public partial class MainWindow : Window {
        private const string DECIMAL = @"[\+\-]?\d+(?:\.\d+)?";

        public MainWindow() {
            InitializeComponent();
            InitializeUnits();
        }

        private void InitializeUnits() {
            // MetricUnit と ImperialUnit に表示する単位リスト
            MetricUnit.Items.Add("m");
            MetricUnit.Items.Add("kg");
            MetricUnit.Items.Add("mm");
            MetricUnit.Items.Add("℃");
            MetricUnit.SelectedIndex = 0;

            ImperialUnit.Items.Add("ft");
            ImperialUnit.Items.Add("lb");
            ImperialUnit.Items.Add("in");
            ImperialUnit.Items.Add("℉");
            ImperialUnit.SelectedIndex = 0;
        }

        // Imperial ComboBox 選択時または値変更時に評価して表示する
        private void ImperialUnit_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                // 入力式を取得（メトリック側を優先して評価）
                string input = MetricValue.Text?.Trim();
                if (string.IsNullOrEmpty(input)) {
                    // もしメトリック側が空ならインペリアル側の式を評価して表示
                    input = ImperialValue.Text?.Trim();
                    if (string.IsNullOrEmpty(input)) return;
                    string eval = Calculation(input);
                    ImperialValue.Text = FormatNumberString(eval);
                    return;
                }

                // 数式を評価
                string evaluated = Calculation(input);
                if (string.IsNullOrWhiteSpace(evaluated)) return;

                if (!double.TryParse(evaluated, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double metricVal)) {
                    // ロケール依存の数値が入っている場合のフォールバック
                    if (!double.TryParse(evaluated, out metricVal)) return;
                }

                // 単位に応じて変換を実行
                string mUnit = MetricUnit.SelectedItem as string ?? "m";
                string iUnit = ImperialUnit.SelectedItem as string ?? "ft";

                double converted = ConvertMetricToImperial(metricVal, mUnit, iUnit);

                ImperialValue.Text = converted.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                // 失敗時は静かに無視（必要ならログや UI 表示を追加）
            }
        }

        // ▲ ボタン: インペリアル -> メトリック（ImperialValue を評価して MetricValue に反映）
        private void ImperialUnitToMetric_Click(object sender, RoutedEventArgs e) {
            try {
                string input = ImperialValue.Text?.Trim();
                if (string.IsNullOrEmpty(input)) return;

                string evaluated = Calculation(input);
                if (string.IsNullOrWhiteSpace(evaluated)) return;

                if (!double.TryParse(evaluated, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double impVal)) {
                    if (!double.TryParse(evaluated, out impVal)) return;
                }

                string iUnit = ImperialUnit.SelectedItem as string ?? "ft";
                string mUnit = MetricUnit.SelectedItem as string ?? "m";

                double converted = ConvertImperialToMetric(impVal, iUnit, mUnit);

                MetricValue.Text = converted.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
            }
        }

        // ▼ ボタン: メトリック -> インペリアル（MetricValue を評価して ImperialValue に反映）
        private void MetricToImperialUnit_Click(object sender, RoutedEventArgs e) {
            try {
                string input = MetricValue.Text?.Trim();
                if (string.IsNullOrEmpty(input)) return;

                string evaluated = Calculation(input);
                if (string.IsNullOrWhiteSpace(evaluated)) return;

                if (!double.TryParse(evaluated, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double metricVal)) {
                    if (!double.TryParse(evaluated, out metricVal)) return;
                }

                string mUnit = MetricUnit.SelectedItem as string ?? "m";
                string iUnit = ImperialUnit.SelectedItem as string ?? "ft";

                double converted = ConvertMetricToImperial(metricVal, mUnit, iUnit);

                ImperialValue.Text = converted.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
            }
        }

        // 単位変換: Metric -> Imperial
        private double ConvertMetricToImperial(double value, string mUnit, string iUnit) {
            // サポート例: m <-> ft, mm <-> in, kg <-> lb, ℃ <-> ℉
            if (mUnit == "m" && iUnit == "ft") return value * 3.28084;
            if (mUnit == "mm" && iUnit == "in") return value / 25.4;
            if (mUnit == "kg" && iUnit == "lb") return value * 2.2046226218;
            if (mUnit == "℃" && iUnit == "℉") return (value * 9.0 / 5.0) + 32.0;

            // 既定: 同じ単位または未対応はそのまま返す
            return value;
        }

        // 単位変換: Imperial -> Metric
        private double ConvertImperialToMetric(double value, string iUnit, string mUnit) {
            if (iUnit == "ft" && mUnit == "m") return value / 3.28084;
            if (iUnit == "in" && mUnit == "mm") return value * 25.4;
            if (iUnit == "lb" && mUnit == "kg") return value / 2.2046226218;
            if (iUnit == "℉" && mUnit == "℃") return (value - 32.0) * 5.0 / 9.0;

            return value;
        }

        // 数式を評価して数値文字列を返す（元の Calculation ロジックを統合）
        public static string Calculation(string calcStr) {
            if (calcStr == null) return "";
            string result = Regex.Replace(calcStr, @"\s", "");
            result = OperatorOrganize(result);
            result = BracketsOrganize(result);
            result = ProcFunction(result);
            result = CalculationBrackets(result);
            result = NormalCalculation(result);
            result = Regex.Replace(result, @"^\+", "");
            return result;
        }

        private static string OperatorOrganize(string s) {
            if (string.IsNullOrEmpty(s)) return s;
            s = Regex.Replace(s, @"\+\+", "+");
            s = Regex.Replace(s, @"\-\-", "+");
            s = Regex.Replace(s, @"\+\-", "-");
            s = Regex.Replace(s, @"\-\+", "-");
            return s;
        }

        private static string BracketsOrganize(string s) {
            if (string.IsNullOrEmpty(s)) return s;
            // 連続した余分な括弧を単純削除する簡易処理
            while (Regex.IsMatch(s, @"\(\)")) s = Regex.Replace(s, @"\(\)", "");
            return s;
        }

        private static string ProcFunction(string s) {
            if (string.IsNullOrEmpty(s)) return s;
            // sqrt, sin, cos などを実装する場合はここに追加
            // 例: sqrt(9) -> 3
            var rxSqrt = new Regex(@"sqrt\((" + DECIMAL + @")\)", RegexOptions.IgnoreCase);
            s = rxSqrt.Replace(s, m => {
                double v = double.Parse(m.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                return Math.Sqrt(v).ToString(System.Globalization.CultureInfo.InvariantCulture);
            });
            return s;
        }

        private static string CalculationBrackets(string s) {
            if (string.IsNullOrEmpty(s)) return s;
            var rx = new Regex(@"\(([^()]+)\)");
            while (true) {
                var m = rx.Match(s);
                if (!m.Success) break;
                string inner = m.Groups[1].Value;
                string innerEval = NormalCalculation(inner);
                s = s.Substring(0, m.Index) + innerEval + s.Substring(m.Index + m.Length);
            }
            return s;
        }

        private static string NormalCalculation(string s) {
            if (string.IsNullOrEmpty(s)) return s;
            // 乗除優先
            s = CalcBinaryOperators(s, @"(" + DECIMAL + @")([\*/])(" + DECIMAL + @")");
            // 加減
            s = CalcBinaryOperators(s, @"(" + DECIMAL + @")([+\-])(" + DECIMAL + @")");
            return s;
        }

        private static string CalcBinaryOperators(string input, string pattern) {
            string s = input;
            var rx = new Regex(pattern);
            while (true) {
                var m = rx.Match(s);
                if (!m.Success) break;
                double a = double.Parse(m.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                string op = m.Groups[2].Value;
                double b = double.Parse(m.Groups[3].Value, System.Globalization.CultureInfo.InvariantCulture);
                double r = 0;
                switch (op) {
                    case "*": r = a * b; break;
                    case "/": r = a / b; break;
                    case "+": r = a + b; break;
                    case "-": r = a - b; break;
                }
                string rStr = r.ToString(System.Globalization.CultureInfo.InvariantCulture);
                s = s.Substring(0, m.Index) + rStr + s.Substring(m.Index + m.Length);
            }
            return s;
        }

        private static string FormatNumberString(string s) {
            if (string.IsNullOrWhiteSpace(s)) return s;
            if (double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double v)) {
                return v.ToString("G12", System.Globalization.CultureInfo.InvariantCulture);
            }
            return s;
        }
    }
}