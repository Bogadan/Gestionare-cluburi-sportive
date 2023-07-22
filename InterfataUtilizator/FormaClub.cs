using System;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace InterfataUtilizator
{
    public partial class FormaClub : Form
    {
        private const bool SUCCES = true;

        private const int PRIMA_COLOANA = 0;


        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareClub stocareCluburi = (IStocareClub)new StocareFactory().GetTipStocare(typeof(Club));
        IStocareEchipa stocareEchipe = (IStocareEchipa)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareJucator stocareJucatori = (IStocareJucator)new StocareFactory().GetTipStocare(typeof(Jucator));

        public FormaClub()
        {
            InitializeComponent();
            if(stocareCluburi == null)
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
                //se elimina itemii deja adaugati
                //cmbCluburi.Items.Clear();

                var cluburi = stocareCluburi.GetCluburi();
                if (cluburi != null && cluburi.Any())
                {
 /*                   foreach (var club in cluburi)
                    {
                        cmbCluburi.Items.Add(new ComboItem(club.numeClub, (Int32)club.idClub));
                    }*/
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
            string mesajValidare = ValidareDateClub();
            if(mesajValidare!=null)
            {
                MessageBox.Show(mesajValidare);
                return;
            }

            try
            {
                var rezultat = stocareCluburi.AddClub(new Club(txtNumeClubAdd.Text, txtNumeManagerAdd.Text));
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Club adaugat!");
                    IncarcaCluburi();
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare club!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

       /* private void label6_Click(object sender, EventArgs e)
        {

        }*/

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            string mesajValidare = ValidareDateClub();
            if (mesajValidare != null)
            {
                MessageBox.Show(mesajValidare);
                return;
            }

            int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
            int idClub = Int32.Parse(dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            try
            {
                var club = new Club(
                    txtNumeClubAdd.Text,
                    txtNumeManagerAdd.Text,
                    idClub);

                var rezultat = stocareCluburi.UpdateClub(club);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Club actualizat!");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare club!");
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
                var cluburi = stocareCluburi.GetCluburi();
                //debugging
                //cluburi.Add(new Club(1, "Hlochti", "Umberto"));

                if (cluburi != null && cluburi.Any())
                {
                    var cluburiAfisate = cluburi.Where(m => m.vizibil == true).ToList();
                    dataGridCluburi.DataSource = cluburiAfisate.Select(m => new { m.idClub, m.numeClub, m.numeManager }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridCluburi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
            string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Club c = stocareCluburi.GetClub(Int32.Parse(idClub));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeClubAdd.Text = c.numeClub;
                    txtNumeClubEdit.Text = c.numeClub;
                    txtNumeClubFind.Text = c.numeClub;
                    txtNumeManagerAdd.Text = c.numeManager;
                    txtNumeManagerEdit.Text = c.numeManager;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }

        private void dataGridCluburi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           /* int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
            string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Club c = stocareCluburi.GetClub(Int32.Parse(idClub));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeClubAdd.Text = c.numeClub;
                    txtNumeClubEdit.Text = c.numeClub;
                    txtNumeClubFind.Text = c.numeClub;
                    txtNumeManagerAdd.Text = c.numeManager;
                    txtNumeManagerEdit.Text = c.numeManager;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }

        private void dataGridCluburi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
            string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Club c = stocareCluburi.GetClub(Int32.Parse(idClub));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeClubAdd.Text = c.numeClub;
                    txtNumeClubEdit.Text = c.numeClub;
                    txtNumeClubFind.Text = c.numeClub;
                    txtNumeManagerAdd.Text = c.numeManager;
                    txtNumeManagerEdit.Text = c.numeManager;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }

        private void dataGridCluburi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
            string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Club c = stocareCluburi.GetClub(Int32.Parse(idClub));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    txtNumeClubAdd.Text = c.numeClub;
                    txtNumeClubFind.Text = c.numeClub;
                    txtNumeManagerAdd.Text = c.numeManager;                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            if(!txtNumeClubFind.Text.All(char.IsLetter) || txtNumeClubFind.Text.Length < 1)
            {
                MessageBox.Show("Numelui clubului introdus este invalid!");
                return;
            }

            var tmp = stocareCluburi.FindClub(txtNumeClubFind.Text);
            List<Club> clubCautat = new List<Club>();
            clubCautat.Add(tmp);
            if (clubCautat != null)
            {

                dataGridCluburi.DataSource = clubCautat.Select(m => new { m.idClub, m.numeClub, m.numeManager}).ToList();
            }
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            try
            {
                var decizie = MessageBox.Show("Atentie! Stergerea clubului presupune si stergerea tuturor echipelor si jucatorilor ce apartin de acesta. Continuati?", "ATENTIE", MessageBoxButtons.YesNo);

                if(decizie == DialogResult.Yes)
                {
                    int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
                    string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

                    var rezultat = stocareCluburi.DeleteClub(int.Parse(idClub));
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Club sters!");
                        AfiseazaCatalog();
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut sterge clubul!");
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
                var decizie = MessageBox.Show("Atentie! Ascunderea clubului presupune si ascunderea tuturor echipelor si jucatorilor ce apartin de acesta. Continuati?", "ATENTIE", MessageBoxButtons.YesNo);

                if(decizie == DialogResult.Yes)
                {
                    int currentRowIndex = dataGridCluburi.CurrentCell.RowIndex;
                    string idClub = dataGridCluburi[PRIMA_COLOANA, currentRowIndex].Value.ToString();

                    var rezultat = stocareCluburi.AscundeClub(int.Parse(idClub));
                    if (rezultat == SUCCES)
                    {
                        MessageBox.Show("Club ascuns!");
                        AfiseazaCatalog();
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut ascunde clubul!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        string ValidareDateClub()
        {
            string mesaj = null;

            //verificare ca numele sa nu contina cifre
            if (txtNumeClubAdd.Text.All(char.IsDigit) || txtNumeClubAdd.Text.Length < 3)
            {
                mesaj += "Nume club invalid! ";
            }
            if(txtNumeManagerAdd.Text.All(char.IsDigit))
            {
                mesaj += "Nume manager invalid!";
            }

            return mesaj;

        }
    }
}
