using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareClub : IStocareFactory
    {
        List<Club> GetCluburi();
        Club GetClub(int id);
        Club FindClub(string numeClub);
        bool DeleteClub(int idClub);
        bool AscundeClub(int idClub);
        bool AddClub(Club c);

        bool UpdateClub(Club c);
    }
}
