using System;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using System.Collections.Generic;

namespace InterfataUtilizator
{
    public partial class FormaJucator : Form
    {
        private const bool SUCCES = true;

        private const int PRIMA_COLOANA = 0;


        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareClub stocareCluburi = (IStocareClub)new StocareFactory().GetTipStocare(typeof(Club));
        IStocareEchipa stocareEchipe = (IStocareEchipa)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareJucator stocareJucatori = (IStocareJucator)new StocareFactory().GetTipStocare(typeof(Jucator));

        public FormaJucator()
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
            IncarcaJucatori();
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
        
        
        private void IncarcaJucatori()
        {
            try
            {
                //pentru a putea insera 2 jucatori unul dupa altul, fara sa trebuiasca reselectat cmbbox-ul!
                var selectedItem = cmbEchipe.SelectedItem;

                //se elimina itemii deja adaugati
                cmbEchipe.Items.Clear();

 
                

                var echipe = stocareEchipe.GetEchipe();
                if (echipe != null && echipe.Any())
                {
                    foreach (var echipa in echipe)
                    {
                        cmbEchipe.Items.Add(new ComboItem(echipa.numeEchipa, (Int32)echipa.idEchipa));
                    }
                }

                if (selectedItem != null)
                {
                    cmbEchipe.SelectedItem = selectedItem;
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
            try
            {
                string mesajValidare = ValidareDateJucator();
                if(mesajValidare != null)
                {
                    MessageBox.Show(mesajValidare);
                    return;
                }

                var rezultat = stocareJucatori.AddJucator(new Jucator(txtNumeJucator.Text,txtPrenumeJucator.Text,txtRolJucator.Text,dtpNastere.Value,float.Parse(txtSalariuJucator.Text), ((ComboItem)cmbEchipe.SelectedItem).Value));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucator adaugat");
                    IncarcaJucatori();
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare jucator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }


/*        private void label6_Click(object sender, EventArgs e)
        {

        }*/

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            string mesajValidare = ValidareDateJucator();
            if (mesajValidare != null)
            {
                MessageBox.Show(mesajValidare);
                return;
            }

            int currentRowIndex = dataGridJucatori.CurrentCell.RowIndex;
            int idJucator = Int32.Parse(dataGridJucatori[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            try
            {
                var jucator = new Jucator(txtNumeJucator.Text, txtPrenumeJucator.Text, txtRolJucator.Text, dtpNastere.Value, float.Parse(txtSalariuJucator.Text), ((ComboItem)cmbEchipe.SelectedItem).Value,idJucator);

                var rezultat = stocareJucatori.UpdateJucator(jucator);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucator actualizat!");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare jucator!");
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
                var jucatori = stocareJucatori.GetJucatori();
                //debugging
                //List<Jucator> jucatori = new List<Jucator>();
                //jucatori.Add(new Jucator("Hagi","Cristi","atacant",35,13500,666));

                if (jucatori!= null && jucatori.Any())
                {
                    var afisareJucatori = jucatori.Where(m => m.vizibil == true).ToList();
                    //prin ascunderea logica, se afiseaza doar acele elemente care au vizibil = true!
                    dataGridJucatori.DataSource = afisareJucatori.Select(m => new {ID = m.idJucator, NUME = m.numeJucator + " " + m.prenumeJucator,VARSTA = m.varstaJucator,ROL = m.rolJucator,SALARIU = m.salariuJucator,ECHIPA = stocareEchipe.GetEchipa(m.idEchipa).numeEchipa }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridCluburi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int currentRowIndex = dataGridEchipe.CurrentCell.RowIndex;
            string idEchipa = dataGridEchipe[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Echipa c = stocareEchipe.GetEchipa(Int32.Parse(idEchipa));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeJucator.Text = c.numeEchipa;
                    txtPrenumeJucator.Text = c.oras;
                    txtRolJucator.Text = c.numeAntrenor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridJucatori.CurrentCell.RowIndex;
                string idJucator = dataGridJucatori[PRIMA_COLOANA, currentRowIndex].Value.ToString();

                stocareEchipe.DecrNrMembri(stocareJucatori.GetJucator(int.Parse(idJucator)).idEchipa);
                var rezultat = stocareJucatori.DeleteJucator(int.Parse(idJucator));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucator sters!");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Nu s-a putut sterge jucatorul!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dataGridEchipe_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRowIndex = dataGridJucatori.CurrentCell.RowIndex;
            string idJucator = dataGridJucatori[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Jucator c = stocareJucatori.GetJucator(Int32.Parse(idJucator));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeJucator.Text = c.numeJucator;
                    txtPrenumeJucator.Text = c.prenumeJucator;
                    txtRolJucator.Text = c.rolJucator;
                    txtSalariuJucator.Text = c.salariuJucator.ToString();
                    //txtVarstaJucator.Text = c.varstaJucator.ToString();
                    dtpNastere.Value = c.dataNastereJucator;

                    //repair: selectare corecta
                    string numeEchipa = stocareEchipe.GetEchipa(c.idEchipa).numeEchipa;
                    foreach (var echipa in cmbEchipe.Items)
                    {
                        if (echipa.ToString() == numeEchipa)
                        {
                            cmbEchipe.SelectedItem = echipa;
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

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            var jucatorCautat = stocareJucatori.FindJucator(txtNumeJucatorFind.Text);
            if (jucatorCautat != null && jucatorCautat.Any())
            {
                dataGridJucatori.DataSource = jucatorCautat.Select(m => new { ID =  m.idJucator, NUME = m.numeJucator, ROL = m.rolJucator, SALARIU = m.salariuJucator }).ToList();
            }
        }

        private void btnAscunde_Click(object sender, EventArgs e)
        {
            try
            {
                int currentRowIndex = dataGridJucatori.CurrentCell.RowIndex;
                int idJucator = int.Parse(dataGridJucatori[PRIMA_COLOANA, currentRowIndex].Value.ToString());
                var jucatorSelectat = stocareJucatori.GetJucator(idJucator);

                var rezultat = stocareJucatori.AscundeJucator(jucatorSelectat);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucatorul a fost sters din lista de afisare!...");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Nu s-a putut ascunde jucatorul!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonCautaJuc_Click(object sender, EventArgs e)
        {
            try
            {
                var jucatori = stocareJucatori.GetJucatoriClub(txtJucatoriClub.Text);
                //debugging
                //cluburi.Add(new Club(1, "Hlochti", "Umberto"));

                if (jucatori != null && jucatori.Any())
                {
                    dataGridJucatori.DataSource = jucatori.Select(m => new { m.idJucator, m.numeJucator, m.rolJucator, m.salariuJucator}).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        string ValidareDateJucator()
        {
            string mesaj = null;

            //verificare ca numele sa nu contina cifre
            if(!txtNumeJucator.Text.All(char.IsLetter) || !txtPrenumeJucator.Text.All(char.IsLetter) || txtNumeJucator.Text.Length < 2 || txtPrenumeJucator.Text.Length < 2)
            {
                mesaj += "Nume la adaugare incorect! ";
            }
            if(!txtRolJucator.Text.All(char.IsLetter) || txtRolJucator.Text.Length < 3)
            {
                mesaj += "Rolul unui jucator poate fi alcatuit doar din litere! ";
            }
            if(dtpNastere.Value > DateTime.Now || dtpNastere.Value.Year < 5)
            {
                mesaj += "Data de nastere invalida! ";
            }
            if(!txtSalariuJucator.Text.All(char.IsDigit))
            {
                mesaj += "Format invalid! la salariu!";
            }
            else
            {
                if (float.Parse(txtSalariuJucator.Text) < 1)
                {
                    mesaj += "Salariul nu poate fi negativ!";
                }
            }
            if(cmbEchipe.SelectedItem == null)
            {
                mesaj += "Ati uitat sa selectati echipa!";
            }
            return mesaj;

        }
    }
}
