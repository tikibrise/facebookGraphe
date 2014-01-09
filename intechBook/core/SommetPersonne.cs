using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class SommetPersonne
    {
        public SommetPersonne(string Nom,string Prenom,string Mail)
        {
            Contacts = new List<ArreteRelation>();
            _nom = Nom;
            _prenom = Prenom;
            _email = Mail;
            _currnum++;
            _num=_currnum;

        }
        List<ArreteRelation> Contacts;
        readonly int _num;
        string _nom;
        string _prenom;
        string _email;

        public int Num { get { return _num; } }
        public string Nom { get { return _nom; } }
        public string Prenom { get { return _prenom; } }
        public string Email { get { return _email; } }

        public void AddContact(SommetPersonne contact, TypeRelation trelation=TypeRelation.AMI)
        {
            var relation = new ArreteRelation(this, contact, trelation);
            Contacts.Add(relation);

        }


        static int _currnum;
    }
}
