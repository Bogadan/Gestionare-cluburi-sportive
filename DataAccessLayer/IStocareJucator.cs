using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareJucator: IStocareFactory
    {
        List<Jucator> GetJucatori();
        List<Jucator> FindJucator(string numeJucator);
        bool DeleteJucator(int idJucator);
        bool AscundeJucator(Jucator comp);
        List<Jucator> GetJucatoriClub(string club);
        Jucator GetJucator(int id);
        bool AddJucator(Jucator c);
        bool UpdateJucator(Jucator c);
    }
}
