using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareClub : IStocareClub
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Club> GetCluburi()
        {
            var result = new List<Club>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from cluburi_ProiectBN", CommandType.Text);

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Club(linieDB));
            }
            return result;
        }

        public Club GetClub(int id)
        {
            Club result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from cluburi_ProiectBN where IdClub = :IdClub", CommandType.Text,
                new OracleParameter(":IdClub", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Club(linieDB);
            }
            return result;
        }
        public Club FindClub(string numeClub)
        {
            Club result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from cluburi_ProiectBN where numeClub = :numeClub", CommandType.Text,
                new OracleParameter(":numeClub", OracleDbType.NVarchar2, numeClub, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Club(linieDB);
            }
            return result;
        }


        public bool AddClub(Club comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO cluburi_ProiectBN VALUES (seq_cluburi_ProiectBN.nextval, :NumeClub, :NumeManager, 1)", CommandType.Text,
                new OracleParameter(":NumeClub", OracleDbType.NVarchar2, comp.numeClub, ParameterDirection.Input),
                new OracleParameter(":NumeManager", OracleDbType.NVarchar2, comp.numeManager, ParameterDirection.Input));
        }

        public bool UpdateClub(Club comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE cluburi_ProiectBN set numeClub = :numeClub, numeManager = :numeMananger where idClub = :idClub", CommandType.Text,
                new OracleParameter(":numeClub", OracleDbType.NVarchar2, comp.numeClub, ParameterDirection.Input),
                new OracleParameter(":numeManager", OracleDbType.NVarchar2, comp.numeManager, ParameterDirection.Input),
                new OracleParameter(":idClub", OracleDbType.Int32, comp.idClub, ParameterDirection.Input));
        }

        public bool DeleteClub(int idClub)
        {
            //stergem mai intai echipele si jucatorii ce apartin de club
            bool stergeJucatori = SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM jucatori_ProiectBN j WHERE idEchipa = (SELECT idEchipa FROM echipe_ProiectBN e, cluburi_ProiectBN c WHERE e.idClub = c.idClub AND e.idEchipa = j.idEchipa AND c.idClub = :idClub)", CommandType.Text,
                new OracleParameter(":idClub", OracleDbType.Int32, idClub, ParameterDirection.Input));

            bool stergeEchipe = SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM echipe_ProiectBN WHERE idClub = :idClub", CommandType.Text,
                new OracleParameter(":idClub", OracleDbType.Int32, idClub, ParameterDirection.Input));

            bool stergeClub = SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM cluburi_ProiectBN WHERE idClub = :idClub", CommandType.Text,
                new OracleParameter(":idClub", OracleDbType.Int32, idClub, ParameterDirection.Input));
            return stergeJucatori || stergeEchipe || stergeClub;
        }
        public bool AscundeClub(int idClub)
        {
            bool ascundeJucatori = SqlDBHelper.ExecuteNonQuery(
                "UPDATE jucatori_ProiectBN j set vizibil = 0 WHERE idEchipa = (SELECT idEchipa FROM echipe_ProiectBN e, cluburi_ProiectBN c WHERE e.idClub = c.idClub AND e.idEchipa = j.idEchipa AND c.idClub = :idClub)", CommandType.Text,
                new OracleParameter(":idClub", OracleDbType.Int32, idClub, ParameterDirection.Input));
            bool ascundeEchipe = SqlDBHelper.ExecuteNonQuery(
                "UPDATE echipe_ProiectBN set vizibil = 0 where idClub = :idClub", CommandType.Text,
                new OracleParameter(":idClub", OracleDbType.Int32, idClub, ParameterDirection.Input));
            bool ascundeClub = SqlDBHelper.ExecuteNonQuery(
                "UPDATE cluburi_ProiectBN set vizibil = 0 where idClub = :idClub", CommandType.Text,
                new OracleParameter(":idJucator", OracleDbType.Int32, idClub, ParameterDirection.Input));
            return ascundeClub || ascundeEchipe || ascundeJucatori;
        }
    }
}
