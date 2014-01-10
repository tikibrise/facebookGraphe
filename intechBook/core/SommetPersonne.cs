using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class SommetPersonne
    {
        public SommetPersonne(string Nom, string Prenom, string Mail)
        {
            Contacts = new List<ArreteRelation>();
            _nom = Nom;
            _prenom = Prenom;
            _email = Mail;
            _currnum++;
            _num = _currnum;

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

        public void AddContact(SommetPersonne contact, TypeRelation trelation = TypeRelation.AMI)
        {
            var relation = new ArreteRelation(this, contact, trelation);
            Contacts.Add(relation);

        }

        public string ChercherContact(SommetPersonne but)
        {
            List<SommetPersonne> Pparcourus = new List<SommetPersonne>();
            int profondeur = ChercherContactRec(this, but, Pparcourus);
            string phrase;
            if (profondeur == -1)
                phrase = string.Format("Cette personne ({0} {1}) n'est pas en contact direct ou indirect avec vous ({2} {3}).", but.Prenom, but.Nom, _prenom, _nom);
            else if (profondeur == 1)
                phrase = string.Format("Cette personne ({0} {1}) est en contact direct avec vous ({2} {3}).", but.Prenom, but.Nom, _prenom, _nom);
            else if (profondeur >= 1)
                phrase = string.Format("Cette personne ({0} {1}) est en contact indirect avec vous ({2} {3}) avec une profondeur de {4}.", but.Prenom, but.Nom, _prenom, _nom, profondeur);
            else if (profondeur == 0)
                phrase = string.Format("Cette personne ({0} {1}) est vous-même.", but.Prenom, but.Nom);
            else
                phrase = string.Format("WTF ?", but.Prenom, but.Nom, _prenom, _nom);
            return phrase;
        }
        public int ChercherContactRec(SommetPersonne actuel, SommetPersonne but, List<SommetPersonne> Pparcourus)
        {
            if (Pparcourus.Contains(actuel))
                return -1;
            Pparcourus.Add(actuel);
            if (actuel == but)
                return 0;
            int profondeur = -1;
            foreach (ArreteRelation a in actuel.Contacts)
            {
                profondeur = ChercherContactRec(a.Dest, but, Pparcourus);
            }
            if (profondeur >= 0)
                return profondeur + 1;
            return profondeur;
        }
        public string ListerContacts()
        {
            List<SommetPersonne> contacts = new List<SommetPersonne>();
            List<int> Profondeurs = new List<int>();
            foreach (ArreteRelation a in this.Contacts)
            {
                ListerContactsRec(a.Dest, 1, contacts, Profondeurs);
            }    
            if (contacts.Count!= Profondeurs.Count)
                return string.Format("!!!!?");

            return string.Format("Vous avez {0} contacts.", contacts.Count);
        }
        public void ListerContactsRec(SommetPersonne actuel, int profondeurActuelle, List<SommetPersonne> contacts, List<int> Profondeurs)
        {
            if (contacts.Contains(actuel))
                return;
            contacts.Add(actuel);
            Profondeurs.Add(profondeurActuelle);
            foreach (ArreteRelation a in actuel.Contacts)
            {
                ListerContactsRec(a.Dest, profondeurActuelle+1, contacts, Profondeurs);
            }            
        }
        static int _currnum;
    }
}
