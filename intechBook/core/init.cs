using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    class init
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


        }

        public List<SommetPersonne> listP;
        

    }
}
