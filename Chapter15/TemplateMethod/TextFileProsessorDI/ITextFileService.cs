using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProsessorDI {
    public interface ITextFileService {
        void Intialize(string fname);
        void Excute(string line);
        void Terminate();
    }
}
