using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Club
    {
        public int idClub { get; set; }
        public string numeClub { get; set; }
        public string numeManager { get; set; }
        public bool vizibil { get; set; }
        public Club()
        {}

        public Club(string _numeClub, string _numeManager, int _idClub = 0)
        {
            idClub = _idClub;
            numeClub = _numeClub;
            numeManager = _numeManager;
        }

        public Club(DataRow linieDB)
        {
            //idClub = Convert.ToInt32(linieDB["idClub"].ToString());
            idClub = int.Parse(linieDB["idClub"].ToString());
            numeClub = linieDB["numeClub"].ToString();
            numeManager = linieDB["numeManager"].ToString();
            vizibil = Convert.ToBoolean(int.Parse(linieDB["vizibil"].ToString()));
        }

    }
}
