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
        public List<ArreteRelation> Contacts;
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
            else if (profondeur > 1)
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
            {
                if (actuel == but)
                    return 0;
                return -1;
            }
            Pparcourus.Add(actuel);
            if (actuel == but)
                return 0;
            int profondeur = -1;
            int profondeurtmp = -1;
            foreach (ArreteRelation a in actuel.Contacts)
            {
                profondeurtmp = ChercherContactRec(a.Dest, but, Pparcourus);
                if (profondeurtmp != -1)
                {
                    if (profondeur == -1)
                        profondeur=profondeurtmp ;
                    else if (profondeurtmp < profondeur)
                        profondeur = profondeurtmp;
                }
            }
            if (profondeur >= 0)
                return profondeur + 1;
            return profondeur;
        }
        public string ListerContacts(List<SommetPersonne> contacts, List<int> Profondeurs)
        {
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
            if (actuel == this)
                return;
            if (contacts.Contains(actuel))
            {
                int idx= contacts.IndexOf(actuel);
                if (Profondeurs[idx] > profondeurActuelle)
                {
                    Profondeurs[idx] = profondeurActuelle;
                }
                return;
            }

            contacts.Add(actuel);
            Profondeurs.Add(profondeurActuelle);
            foreach (ArreteRelation a in actuel.Contacts)
            {
                ListerContactsRec(a.Dest, profondeurActuelle+1, contacts, Profondeurs);
            }            
        }
        public unsafe string ChercherParDijkstra(SommetPersonne but)
        {
            if (Contacts.Count == 0)
                return "Vous n'avez pas de contacts";
            List<Chemin> chemins = new List<Chemin>();
            chemins.Add(new Chemin());
            int cheminSolution=-1;
            int index=0;

            ChercherParDijkstraRec(this, but, chemins, index, &cheminSolution);
            if (cheminSolution!=-1)
            return string.Format("Cette personne ({0} {1}) est en contact avec vous ({2} {3}) d'une profondeur de {4}.", but.Prenom, but.Nom, _prenom, _nom, chemins[cheminSolution].pointsParcourus.Count-1);

            return string.Format("Cette personne ({0} {1}) n'est pas en contact avec vous ({2} {3}).", but.Prenom, but.Nom, _prenom, _nom);
        }


        public unsafe void ChercherParDijkstraRec(SommetPersonne actuel, SommetPersonne but, List<Chemin> chemins, int indexCheminActuel,  int* cheminSolution)
        {
            chemins[indexCheminActuel].pointsParcourus.Add(actuel);
            if (actuel == but)
            {
                Chemin chem = chemins[indexCheminActuel];
                *cheminSolution = indexCheminActuel;
                return;
            }
            int nbChemins = chemins.Count;
            if (actuel.Contacts.Count == 1 && actuel!=this)
            {
                chemins[indexCheminActuel].deadend = true;
                int g = 0;
                while (g < nbChemins)
                {
                    if (chemins[indexCheminActuel].pointsParcourus.Count >= chemins[g].pointsParcourus.Count)
                    {
                        if (!chemins[g].deadend)
                        {
                            indexCheminActuel = g;
                            break;
                        }
                    }
                    g++;
                }
            }
            else if (actuel.Contacts.Count > 1)
            {
                if (nbChemins > 1)
                {
                    int j = 0;
                    while (j < nbChemins)
                    {
                        if (chemins[indexCheminActuel].pointsParcourus.Count > chemins[j].pointsParcourus.Count)
                        {
                            if (!chemins[j].deadend)
                            {
                                indexCheminActuel = j;
                                break;
                            }
                        }
                        j++;
                    }
                }
            }
            int nbBranches = actuel.Contacts.Count;

            int countValidBranches = 0;            
            
            for (int i = 0; i < nbBranches; i++ )
            {
                if (!chemins[indexCheminActuel].pointsParcourus.Contains(actuel.Contacts[i].Dest))
                {
                    for (int k=0; k < nbChemins; k++)
                    {
                        if (k != indexCheminActuel)
                        {
                            if (chemins[k].pointsParcourus.Contains(actuel.Contacts[i].Dest))
                            {
                                if (chemins[k].pointsParcourus.IndexOf(actuel.Contacts[i].Dest) > chemins[indexCheminActuel].pointsParcourus.Count + 1)
                                {
                                    if (countValidBranches == 0)
                                    {
                                        chemins[k].deadend = true;
                                    }
                                    countValidBranches++;
                                }
                            }



                        }
                    }
                    if (countValidBranches == 0)
                    {
                        ChercherParDijkstraRec(actuel.Contacts[i].Dest, but, chemins, indexCheminActuel, cheminSolution);
                        if (*cheminSolution != -1)
                            return;
                    }
                    else
                    {
                        chemins.Add(new Chemin());
                        chemins[chemins.Count-1].pointsParcourus.AddRange(chemins[indexCheminActuel].pointsParcourus);
                        ChercherParDijkstraRec(actuel.Contacts[i].Dest, but, chemins, indexCheminActuel, cheminSolution);

                    }
                    countValidBranches++;

                }
                chemins[indexCheminActuel].deadend = true;  
            } 
        }
        static int _currnum;
    }

    public class Chemin
    {
        public Chemin()
        {
            pointsParcourus = new List<SommetPersonne>();
        }
       public readonly List<SommetPersonne> pointsParcourus;
        public bool deadend;
    }
}
