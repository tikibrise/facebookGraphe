using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class SommetPersonne
    {
        SommetPersonne(string Nom,string Prenom,string Mail)
        {
            Contacts = new List<ArreteRelation>();
            _nom = Nom;
            _prénom = Prenom;
            _email = Mail;
            _currnum++;
            _num=_currnum;

        }
        List<ArreteRelation> Contacts;
        readonly int _num;
        string _nom;
        string _prénom;
        string _email;

        static int _currnum;
    }
}
