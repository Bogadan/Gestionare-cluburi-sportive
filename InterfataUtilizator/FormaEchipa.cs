using System;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace InterfataUtilizator
{
    public partial class FormaEchipa : Form
    {
        private const bool SUCCES = true;

        private const int PRIMA_COLOANA = 0;


        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareClub stocareCluburi = (IStocareClub)new StocareFactory().GetTipStocare(typeof(Club));
        IStocareEchipa stocareEchipe = (IStocareEchipa)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareJucator stocareJucatori = (IStocareJucator)new StocareFactory().GetTipStocare(typeof(Jucator));

        public FormaEchipa()
        {
            InitializeComponent();
            if(stocareEchipe == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        #region handlere ale evenimentelor formei
        private void FormaAdaugare_Load(object sender, EventArgs e)
        {
            IncarcaCluburi();
            AfiseazaCatalog();
        }

        private void FormaAdaugare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region handlere ale evenimentelor controalelor de pe forma (butoane)
        /// <summary>
        /// Adauga informatiile despre o masina in tabelul catalog_DEV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        
        private void btnAdaugaMasina_Click(object sender, EventArgs e)
        { 
           
        }
        

        /// <summary>
        /// Adauga o companie in tabelul companii_DEV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdaugaComp_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormaAfisare f = new FormaAfisare();
            this.Hide();
        }

        #endregion

        #region metode helper

        /// <summary>
        /// Afiseaza companiile din tabelul companii_DEV in controlul de tip combobox
        /// </summary>
        
        
        private void IncarcaCluburi()
        {
            try
            {
                var selectedItem = cmbCluburi.SelectedItem; 
                //se elimina itemii deja adaugati
                cmbCluburi.Items.Clear();

                var cluburi = stocareCluburi.GetCluburi();
                if (cluburi != null && cluburi.Any())
                {
                    foreach (var club in cluburi)
                    {
                        cmbCluburi.Items.Add(new ComboItem(club.numeClub, (Int32)club.idClub));
                    }
                }
                if (selectedItem != null)
                {
                    cmbCluburi.SelectedItem = selectedItem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        private void btnAdaugaClub_Click(object sender, EventArgs e)
        {
            string mesajValidare = ValidareDateEchipa();
            if(mesajValidare!=null)
            {
                MessageBox.Show(mesajValidare);
                return;
            }

            try
            {
                var rezultat = stocareEchipe.AddEchipa(new Echipa(txtNumeEchipa.Text,txtOras.Text,txtAntrenor.Text, ((ComboItem)cmbCluburi.SelectedItem).Value));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Echipa adaugata");
                    IncarcaCluburi();
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare echipa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            string mesajValidare = ValidareDateEchipa();
            if (mesajValidare != null)
            {
                MessageBox.Show(mesajValidare);
                return;
            }

            int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
            int idEchipa = Int32.Parse(dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            try
            {
                var echipa = new Echipa(txtNumeEchipa.Text, txtOras.Text, txtAntrenor.Text, ((ComboItem)cmbCluburi.SelectedItem).Value,idEchipa);

                var rezultat = stocareEchipe.UpdateEchipa(echipa);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Echipa actualizata!");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare echipa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void AfiseazaCatalog()
        {
            try
            {
                var echipe = stocareEchipe.GetEchipe();
                //debugging
                //List<Echipa> echipe = new List<Echipa>();
                //echipe.Add(new Echipa("Echipa campionilor", "Iasi", "Popescu", 3, 1));

                if (echipe != null && echipe.Any())
                {
                    var echipeAfisate = echipe.Where(m => m.vizibil == true).ToList();
                    //dataGridEchipe.DataSource = echipeAfisate.SelectMany(echipa => (echipa,club) new { m.idEchipa, m.numeEchipa, m.oras, m.nrMembri, m.numeAntrenor }).ToList();
                    //dataGridEchipe.DataSource = echipeAfisate.Select(m => new {m.idEchipa, m.numeEchipa, m.oras, m.nrMembri, m.numeAntrenor }).ToList();
                    dataGridEchipe.DataSource = echipeAfisate.Select(m => new { ID = m.idEchipa,NUME = m.numeEchipa,ORAS = m.oras,MEMBRI = m.nrMembri,ANTRENOR = m.numeAntrenor, CLUB = stocareCluburi.GetClub(m.idClub).numeClub}).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridCluburi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
            string idEchipa = dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Echipa c = stocareEchipe.GetEchipa(Int32.Parse(idEchipa));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeEchipa.Text = c.numeEchipa;
                    txtOras.Text = c.oras;
                    txtAntrenor.Text = c.numeAntrenor;


                    //cmbCluburi.SelectedIndex = c.idClub -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbEchipe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridEchipe_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
            string idEchipa = dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Echipa c = stocareEchipe.GetEchipa(int.Parse(idEchipa));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeEchipa.Text = c.numeEchipa;
                    txtOras.Text = c.oras;
                    txtAntrenor.Text = c.numeAntrenor;
                    //DE REVENIT! ADAUGA COMBOBOX!
                    //cmbCluburi.SelectedIndex = c.idClub - 1;

                    //repair: selectare corecta
                    string numeClub = stocareCluburi.GetClub(c.idClub).numeClub;
                    foreach (var club in cmbCluburi.Items)
                    {
                        if (club.ToString() == numeClub)
                        {
                            cmbCluburi.SelectedItem = club;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

/*        private void button1_Click(object sender, EventArgs e)
        {
            var echipaCautat = stocareEchipe.FindEchipa(txtNumeEchipaFind.Text);
            if (echipaCautat != null && echipaCautat.Any())
            {
                dataGridEchipe.DataSource = echipaCautat.Select(m => new { m.idEchipa, m.numeEchipa, m.oras, m.nrMembri, m.numeAntrenor }).ToList();
            }
        }*/

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            try
            {
                var decizie = MessageBox.Show("Atentie! Stergerea echipei presupune si stergerea tuturor jucatorilor ce apartin de aceasta. Continuati?", "ATENTIE", MessageBoxButtons.YesNo);

                if(decizie == DialogResult.Yes)
                {
                    int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
                    string idEchipa = dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString();

                    var rezultat = stocareEchipe.DeleteEchipa(int.Parse(idEchipa));
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Echipa stearsa");
                        AfiseazaCatalog();
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut sterge echipa!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonAscunde_Click(object sender, EventArgs e)
        {
            try
            {
                var decizie = MessageBox.Show("Atentie! Ascunderea echipei presupune si ascunderea tuturor jucatorilor ce apartin de aceasta. Continuati?", "ATENTIE", MessageBoxButtons.YesNo);

                if(decizie == DialogResult.Yes)
                {
                    int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
                    int idEchipa = int.Parse(dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString());

                    var rezultat = stocareEchipe.AscundeEchipa(idEchipa);
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Echipa a fost ascunsa!...");
                        AfiseazaCatalog();
                    }
                    else
                    {
                        MessageBox.Show("Operatia de ascundere nerealizata!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCautaNume_Click(object sender, EventArgs e)
        {
            if(txtNumeEchipaFind.Text.Length < 3)
            {
                MessageBox.Show("Nume prea scurt!");
            }
            var echipaCautat = stocareEchipe.FindEchipa(txtNumeEchipaFind.Text);
            if (echipaCautat != null && echipaCautat.Any())
            {
                dataGridEchipe.DataSource = echipaCautat.Select(m => new { ID = m.idEchipa, NUME = m.numeEchipa, ORAS = m.oras, MEMBRI = m.nrMembri, ANTRENOR = m.numeAntrenor, CLUB = stocareCluburi.GetClub(m.idClub).numeClub }).ToList();
            }
        }

        private void btnCautaClub_Click(object sender, EventArgs e)
        {
            if (txtClubFind.Text.Length < 3 || !txtClubFind.Text.All(char.IsLetter))
            {
                MessageBox.Show("Nume club invalid!");
            }
            var echipaCautat = stocareEchipe.FindEchipe(txtClubFind.Text);
            if (echipaCautat != null && echipaCautat.Any())
            {
                dataGridEchipe.DataSource = echipaCautat.Select(m => new { ID = m.idEchipa, NUME = m.numeEchipa, ORAS = m.oras, MEMBRI = m.nrMembri, ANTRENOR = m.numeAntrenor, CLUB = stocareCluburi.GetClub(m.idClub).numeClub }).ToList();
            }
        }

        string ValidareDateEchipa()
        {
            string mesaj = null;

            //verificare ca numele sa nu contina cifre
            if (txtNumeEchipa.Text.Length < 3)
            {
                mesaj += "Numele echipei prea mic! ";
            }
            if (!txtOras.Text.All(char.IsLetter))
            {
                mesaj += "Nume oras invalid! ";
            }
            if (txtAntrenor.Text.All(char.IsDigit))
            {
                mesaj += "Nume antrenor invalid!";
            }
            if (cmbCluburi.SelectedItem == null)
            {
                mesaj += "Ati uitat sa selectati un club! ";
            }
            return mesaj;

        }
    }
}
