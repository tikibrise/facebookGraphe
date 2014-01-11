using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class init
    {
        public init()
        {
            listP = new List<SommetPersonne>();
            listP.Add( new SommetPersonne("vvv", "bb", "aaa@aa"));
           listP.Add(  new SommetPersonne("aaa", "zz", "aaa@aa"));
           listP.Add(  new SommetPersonne("vvp", "bb", "aaa@aa"));
           listP.Add(  new SommetPersonne("aap", "zz", "aaa@aa"));
           listP.Add(new SommetPersonne("aar", "zz", "aaa@aa"));
           listP.Add(new SommetPersonne("arr", "zz", "aaa@aa"));

           listP[0].AddContact(listP[1]);
           listP[1].AddContact(listP[0]);

           listP[2].AddContact(listP[1]);
           listP[1].AddContact(listP[2]);

           listP[3].AddContact(listP[1]);
           listP[1].AddContact(listP[3]);

           listP[3].AddContact(listP[4]);
           listP[4].AddContact(listP[3]);

           listP[0].AddContact(listP[3]);
           listP[3].AddContact(listP[0]);

           listP.Add(new SommetPersonne("qvv", "bb", "aaa@aa"));
           listP.Add(new SommetPersonne("qaa", "zz", "aaa@aa"));
           listP.Add(new SommetPersonne("qvp", "bb", "aaa@aa"));
           listP.Add(new SommetPersonne("qap", "zz", "aaa@aa"));
           listP.Add(new SommetPersonne("qar", "zz", "aaa@aa"));
           listP.Add(new SommetPersonne("qrr", "zz", "aaa@aa"));

           listP[6].AddContact(listP[2]);
           listP[2].AddContact(listP[6]);

           listP[6].AddContact(listP[7]);
           listP[7].AddContact(listP[6]);

           listP[8].AddContact(listP[7]);
           listP[7].AddContact(listP[8]);

           listP[8].AddContact(listP[3]);
           listP[3].AddContact(listP[8]);

           listP[8].AddContact(listP[9]);
           listP[9].AddContact(listP[8]);

           listP[10].AddContact(listP[9]);
           listP[9].AddContact(listP[10]);

           listP[10].AddContact(listP[11]);
           listP[11].AddContact(listP[10]);

           listP[11].AddContact(listP[7]);
           listP[7].AddContact(listP[11]);

        }

        public List<SommetPersonne> listP;
        

    }
}
