using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurnirAsistentModel;
using TurnirAsistentModel.Models;

namespace AsistentGUI
{
    public partial class DodavanjeEkipe : Form
    {
        private List<OsobaModel> dostupniIgraciEkipe = new List<OsobaModel>();
        private List<OsobaModel> izabraniIgraciEkipe = new List<OsobaModel>();
        public DodavanjeEkipe()
        {
            InitializeComponent();

            //CreateSimpleData();

            WireUpLists();
        }
        private void CreateSimpleData()
        {
            dostupniIgraciEkipe.Add(new OsobaModel { Ime = "Svan", Prezime = "Tipurić" });
            dostupniIgraciEkipe.Add(new OsobaModel { Ime = "Jacky", Prezime = "Corey" });

            izabraniIgraciEkipe.Add(new OsobaModel { Ime = "Ruth", Prezime = "Under" });
            izabraniIgraciEkipe.Add(new OsobaModel { Ime = "Vancuver", Prezime = "Stones" });
        }

        private void WireUpLists()
        {
            comboBox1.DataSource = dostupniIgraciEkipe;
            comboBox1.DisplayMember = "PunoIme";

            lstIgrači.DataSource = izabraniIgraciEkipe;
            lstIgrači.DisplayMember = "PunoIme";
        }
        private void DodavanjeEkipe_Load(object sender, EventArgs e)
        {

        }

        private void lblDodajNovogIgraca_Click(object sender, EventArgs e)
        {

        }

        private void lblImeEkipe_Click(object sender, EventArgs e)
        {

        }

        private void btnIzradiIgrača_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                OsobaModel p = new OsobaModel();
                p.Ime = textBox2.Text;
                p.Prezime = textBox3.Text;
                p.EmailAdresa = textBox4.Text;
                p.BrojMobitela = textBox5.Text;

                GlobalConfig.Connection.IzradiOsobu(p);

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja.");
            }
        }

        private bool ValidateForm()
        {
            if(textBox2.Text.Length == 0)
            {
                return false;
            }
            if (textBox3.Text.Length == 0)
            {
                return false;
            }
            if (textBox4.Text.Length == 0)
            {
                return false;
            }
            if (textBox5.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void lstIgrači_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
