using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Info_Erettsegi_Emelt2017
{
    class Tesztverseny
    {
        //BCCCDBBBBCDAAA
        public string Aonosito;
        public string Valasz;   
        public Tesztverseny(string sor)
        {
            var dbok = sor.Split(' ');
            this.Aonosito = dbok[0];
            this.Valasz = dbok[1];
            
        }
    }
}
