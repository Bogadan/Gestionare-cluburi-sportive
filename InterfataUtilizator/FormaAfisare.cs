using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using System.Drawing;

namespace InterfataUtilizator
{
    public partial class FormaAfisare : Form
    {
        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        //initializare obiecte utilizate pentru salvarea datelor in baza de date (sau alte medii de stocare...daca exista implementare corespunzatoare)
        IStocareClub stocareCluburi = (IStocareClub)new StocareFactory().GetTipStocare(typeof(Club));
        IStocareEchipa stocareEchipe = (IStocareEchipa)new StocareFactory().GetTipStocare(typeof(Echipa));
        public FormaAfisare()
        {
            InitializeComponent();
            if (stocareCluburi == null || stocareEchipe == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        #region handlere ale evenimentelor formei
        private void FormaAfisare_Load(object sender, EventArgs e)
        {
            AfiseazaCatalog();
            AfiseazaCatalogEchipe();
            IncarcaCompanii();
        }



        private void FormaAfisare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region handlere ale evenimentelor controalelor de pe forma (butoane, dataGrid)

        /// <summary>
        /// afiseaza informatiile despre masina selectata in controale ce permit editarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridMasini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridMasini.CurrentCell.RowIndex;
            string idClub = dataGridMasini[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Club c = stocareCluburi.GetClub(Int32.Parse(idClub));

                //incarcarea datelor in controalele de pe forma
                if (c != null)
                {
                    lblIdMasina.Text = c.idClub.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            groupBoxEditare.Visible = true;
        }

        /// <summary>
        /// Actualizeaza inregistrarea afisata spre editare din tabelul masini_DEV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridMasini.CurrentCell.RowIndex;
            int idClub = Int32.Parse(dataGridMasini[PRIMA_COLOANA, currentRowIndex].Value.ToString());
            try
            {
                var club = new Club(
                    txtClub.Text,
                    txtManager.Text,
                    idClub);

                var rezultat = stocareCluburi.UpdateClub(club);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Masina actualizata");
                    AfiseazaCatalog();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare masina");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void btnAfiseazaFormaAdaugare_Click(object sender, EventArgs e)
        {
            FormaClub f = new FormaClub();
            f.Show();
            //this.Hide();
        }

        #endregion

        #region metode helper

 
        private void AfiseazaCatalog()
        {
            try
            {
                var cluburi = stocareCluburi.GetCluburi();
                //debugging
                //cluburi.Add(new Club(1, "Hlochti", "Umberto"));

                if (cluburi != null && cluburi.Any())
                {
                    dataGridMasini.DataSource = cluburi.Select(m=> new { m.idClub, m.numeClub, m.numeManager}).ToList() ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AfiseazaCatalogEchipe()
        {
            try
            {
                var echipe = stocareEchipe.GetEchipe();

                //debugging
                //echipe.Add(new Echipa(1, "Hlochti", "Umberto"));

                if (echipe != null && echipe.Any())
                {
                    dataGridMasini.DataSource = echipe.Select(m => new { m.idEchipa, m.numeEchipa, m.oras, m.nrMembri,m.numeAntrenor,m.idClub}).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            FormaEchipa f = new FormaEchipa();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormaJucator f = new FormaJucator();
            f.Show();
        }

        private void focusIcon(object sender, EventArgs e)
        {
          //.  pictureBox3.BackColor = Color.FromArgb(214, 223, 235);
        }

        private void unfocusIcon(object sender, EventArgs e)
        {
          //  pictureBox3.BackColor = Color.White;
        }

        private void focusIconClub(object sender, EventArgs e)
        {
          //  pictureBox2.BackColor = Color.FromArgb(214, 223, 235);
        }

        private void unfocusIconClub(object sender, EventArgs e)
        {
          //  pictureBox2.BackColor = Color.White;
        }

        private void focusIconEchipe(object sender, EventArgs e)
        {
           // pictureBox4.BackColor = Color.FromArgb(214, 223, 235);
        }

        private void unfocusIconEchipe(object sender, EventArgs e)
        {
           // pictureBox4.BackColor = Color.White;
        }
    }
}
