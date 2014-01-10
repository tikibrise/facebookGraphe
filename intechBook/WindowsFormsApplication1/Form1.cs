using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            UserList = new List<string>();
            Init = new core.init();
            InitializeComponent();
            Fill_User_List();
        }
        public core.init Init;
        public List<string> UserList;

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox3.Items.Clear();
                List<core.SommetPersonne> contacts = new List<core.SommetPersonne>();
                List<int> Profondeurs = new List<int>();
                Init.listP[listBox1.SelectedIndex].ListerContacts(contacts, Profondeurs);


                for (int i = 0; i<contacts.Count; i++)
                {
                    listBox3.Items.Add(string.Format("{0} : {1} {2}, profondeur : {3}", contacts[i].Num.ToString(), contacts[i].Prenom, contacts[i].Nom, Profondeurs[i].ToString())); 
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            listBox3.Items.Clear();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            if (listBox1.SelectedItem != null)
            {
                
               foreach (core.ArreteRelation relation in Init.listP[listBox1.SelectedIndex].Contacts)
               {
                listBox4.Items.Add(string.Format("{0} : {1} {2}", relation.Dest.Num.ToString(), relation.Dest.Prenom, relation.Dest.Nom));
                }
            }
        }
        public void Fill_User_List()
        {
            UserList.Clear();
            foreach (core.SommetPersonne user in Init.listP)
            {
                UserList.Add(string.Format("{0} : {1} {2}", user.Num.ToString(), user.Prenom, user.Nom));
            }
            listBox1_FillList();
            listBox2_FillList();
        }

        public void listBox1_FillList()
        {
            listBox1.Items.Clear();
            foreach (core.SommetPersonne user in Init.listP)
            {
               listBox1.Items.Add(string.Format("{0} : {1} {2}", user.Num.ToString(), user.Prenom, user.Nom));
            }
        }
        public void listBox2_FillList()
        {
            listBox2.Items.Clear();
            foreach (core.SommetPersonne user in Init.listP)
            {
                listBox2.Items.Add(string.Format("{0} : {1} {2}", user.Num.ToString(), user.Prenom, user.Nom));
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if (listBox1.SelectedItem != null && listBox2.SelectedItem!=null)
            {
              label4.Text= Init.listP[listBox1.SelectedIndex].ChercherContact(Init.listP[listBox2.SelectedIndex]);
            }
        }

    }
}
