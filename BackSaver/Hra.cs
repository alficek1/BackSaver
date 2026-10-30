using System;
using System.Collections.Generic;
using System.Text;

namespace BackSaver
{
    public class Hra
    {
        public string NazevHry { get; set; }
        public string PlnaCestaExe { get; set; }
        public string SaveDirHry { get; set; }
        public string CestaZalohy { get; set; }

        public Hra()
        {
        }

        public Hra(string nazevHry, string plnaCestaExe, string saveDirHry, string cestaZalohy)
        {
            NazevHry = nazevHry;
            PlnaCestaExe = plnaCestaExe;
            SaveDirHry = saveDirHry;
            CestaZalohy = cestaZalohy;
        }

        public override string ToString()
        {
            return NazevHry;
        }

    }
}
