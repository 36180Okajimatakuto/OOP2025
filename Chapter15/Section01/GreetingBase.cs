using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    interface IGreeting {//インターフェースにするとvartualやpublicが含まれているから書かなくてよくなる
        string GetMessage() => "";
    }
}
