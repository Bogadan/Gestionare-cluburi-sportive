using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareEchipa : IStocareFactory
    {
        List<Echipa> GetEchipe();
        Echipa GetEchipa(int id);
        List<Echipa> FindEchipa(string numeEchipa);
        List<Echipa> FindEchipe(string numeClub);
        bool DecrNrMembri(int idEchipa);
        bool DeleteEchipa(int idEchipa);
        bool AscundeEchipa(int idEchipa);
        bool AddEchipa(Echipa c);
        bool UpdateEchipa(Echipa c);
    }
}
