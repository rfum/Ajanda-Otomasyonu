using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ajanda
{
    class vt
    {
        public static string  sifre;
        public static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ajanda.accdb ; Jet OLEDB:Database Password="+ sifre +";";
       
        public static bool cikis_kontrol;
        public static bool guncel_kontrol;
        public static bool hatirlatma_kontrol;
       
    }
}
