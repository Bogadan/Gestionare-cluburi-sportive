using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Jucator
    {
        public int idJucator { get; set; }
        public string numeJucator { get; set; }
        public string prenumeJucator { get; set; }
        public string rolJucator { get; set; }
        public int varstaJucator { get; set; }
        public DateTime dataNastereJucator { get; set; }
        public float salariuJucator { get; set; }
        public int idEchipa { get; set; }

        public bool vizibil { get; set; }

        //pentru stergere logica, trebuie implementat si in constructor!
        public Jucator() { }
        public Jucator(string _nume, string _prenume, string _rol, DateTime _dataNastere, float _salariu, int _idEchipa, int _id=0)
        {
            idJucator = _id;
            numeJucator = _nume;
            prenumeJucator = _prenume;
            rolJucator = _rol;
            dataNastereJucator = _dataNastere;

            var today = DateTime.Today;
            var age = today.Year - dataNastereJucator.Year;
            if (_dataNastere.Date > today.AddYears(-age)) age--;
            varstaJucator = age;

            salariuJucator = _salariu;
            idEchipa = _idEchipa;
        }

        public Jucator(DataRow linieDB)
        {
            //idClub = Convert.ToInt32(linieDB["idClub"].ToString());
            idJucator = int.Parse(linieDB["idJucator"].ToString());
            numeJucator = linieDB["numeJucator"].ToString();
            prenumeJucator = linieDB["prenumeJucator"].ToString();
            rolJucator = linieDB["rolJucator"].ToString();
            salariuJucator = float.Parse(linieDB["salariuJucator"].ToString());
            idEchipa = int.Parse(linieDB["idEchipa"].ToString());
            vizibil = Convert.ToBoolean( int.Parse(linieDB["vizibil"].ToString()) );


            dataNastereJucator = DateTime.Parse(linieDB["dataNastereJucator"].ToString());

            var today = DateTime.Today;
            var age = today.Year - dataNastereJucator.Year;
            if (dataNastereJucator.Date > today.AddYears(-age)) age--;
            varstaJucator = age;
            //  varstaJucator = int.Parse();
        }
    }
}
