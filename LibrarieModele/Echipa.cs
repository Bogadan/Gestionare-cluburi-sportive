using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Echipa
    {
        public int idEchipa { get; set; }
        public string numeEchipa { get; set; }
        public string oras { get; set; }
        public int nrMembri { get; set; }
        public string numeAntrenor { get; set; }
        public int idClub { get; set; }
        public bool vizibil { get; set; }
        public Echipa() { }
        public Echipa(string _nume, string _oras, string _numeAntr, int _idClub, int _id=0)
        {
            idEchipa = _id;
            numeEchipa = _nume;
            oras = _oras;
            //nrMembri = _nrMem;
            numeAntrenor = _numeAntr;
            idClub = _idClub;
        }
        public Echipa(DataRow linieDB)
        {
            //idClub = Convert.ToInt32(linieDB["idClub"].ToString());
            idEchipa = int.Parse(linieDB["idEchipa"].ToString());
            numeEchipa = linieDB["numeEchipa"].ToString();
            oras = linieDB["oras"].ToString();
            nrMembri = int.Parse(linieDB["nrMembri"].ToString());
            numeAntrenor = linieDB["numeAntrenor"].ToString();
            idClub = int.Parse(linieDB["idClub"].ToString());
            vizibil = Convert.ToBoolean(int.Parse(linieDB["vizibil"].ToString()));
        }
    }
}
