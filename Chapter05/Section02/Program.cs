namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            var appVer = new AppVersion(5, 1, 3);
            Console.WriteLine(appVer);
        }


        //プライマリーコンストラクタを使ったクラス定義
        public class AppVersion (int m,int mi,int b = 0,int r = 0){
            public int Major { get; init; }
            public int Minor { get; init; }
            public int Build { get; init; }
            public int Revision { get; init; }


            public override string ToString() =>
                $"{Major}.{Minor}.{Build}.{Revision}";

        }






        //public AppVersion(int major, int minor)
        //    : this(major, minor, 0, 0) {  //- 引数4つのコンストラクターを呼び出す
        //}

        //public AppVersion(int major, int minor, int build)
        //    : this(major, minor, build, 0) {  //- 引数4つのコンストラクターを呼び出す
        //}

        //public AppVersion(int major, int minor, int build, int revision) {
        //    Major = major;
        //    Minor = minor;
        //    Build = build;
        //    Revision = revision;
        //}





        ////                                                   ↓オプション引数を使ったコンストラクタを使わない決め方
        ////public AppVersion(int major, int minor, int build = 0, int revision = 0) {


    }
}
