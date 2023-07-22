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
    public class AdministrareJucator: IStocareJucator
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Jucator> GetJucatori()
        {
            var result = new List<Jucator>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from jucatori_ProiectBN", CommandType.Text);

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Jucator(linieDB));
            }
            return result;
        }
        public List<Jucator> GetJucatoriClub(string club)
        {
            var result = new List<Jucator>();
            /*var dsCompanii = SqlDBHelper.ExecuteDataSet("SELECT* FROM jucatori_ProiectBN WHERE idEchipa = (SELECT e.idEchipa FROM echipe_ProiectBN e, cluburi_ProiectBN c WHERE e.idClub = c.idClub AND c.numeClub = :numeClub); ", CommandType.Text,
            new OracleParameter(":numeClub", OracleDbType.NVarchar2, club, ParameterDirection.Input));*/

            var dsCompanii = SqlDBHelper.ExecuteDataSet("SELECT * FROM jucatori_ProiectBN j WHERE idEchipa = (SELECT idEchipa FROM echipe_ProiectBN e, cluburi_ProiectBN c WHERE e.idEchipa = j.idEchipa AND e.idClub = c.idClub AND c.numeClub = :numeClub)", CommandType.Text,
            new OracleParameter(":numeClub", OracleDbType.NVarchar2, club, ParameterDirection.Input));

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Jucator(linieDB));
            }
            return result;

            
        }
        public Jucator GetJucator(int id)
        {
            Jucator result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from jucatori_ProiectBN where idJucator = :idJucator", CommandType.Text,
                new OracleParameter(":idJucator", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Jucator(linieDB);
            }
            return result;
        }
        //public Jucator GetJucator(string )

        public bool AddJucator(Jucator comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO jucatori_ProiectBN VALUES (seq_jucatori_ProiectBN.nextval, :numeJucator, :prenumeJucator, :rolJucator, :dataNastereJucator, :salariuJucator, :idEchipa, 1)", CommandType.Text,
                new OracleParameter(":numeJucator", OracleDbType.NVarchar2, comp.numeJucator, ParameterDirection.Input),
                new OracleParameter(":prenumeJucator", OracleDbType.NVarchar2, comp.prenumeJucator, ParameterDirection.Input),
                new OracleParameter(":rolJucator", OracleDbType.NVarchar2, comp.rolJucator, ParameterDirection.Input),
                new OracleParameter(":dataNastereJucator", OracleDbType.Date, comp.dataNastereJucator, ParameterDirection.Input),
                //new OracleParameter(":varstaJucator", OracleDbType.Int32, comp.varstaJucator, ParameterDirection.Input),
                new OracleParameter(":salariuJucator", OracleDbType.Decimal, comp.salariuJucator, ParameterDirection.Input),
                new OracleParameter(":idEchipa", OracleDbType.Int32, comp.idEchipa, ParameterDirection.Input))
                &&
                SqlDBHelper.ExecuteNonQuery(
                "UPDATE echipe_ProiectBN SET nrMembri = nrMembri+1 WHERE idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, comp.idEchipa, ParameterDirection.Input));
        }

        public bool UpdateJucator(Jucator comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE jucatori_ProiectBN set numeJucator = :numeJucator, prenumeJucator = :prenumeJucator, rolJucator = :rolJucator, dataNastereJucator = :dataNastereJucator, salariuJucator = :salariuJucator, idEchipa = :idEchipa where idJucator = :idJucator", CommandType.Text,
                new OracleParameter(":numeJucator", OracleDbType.NVarchar2, comp.numeJucator, ParameterDirection.Input),
                new OracleParameter(":prenumeJucator", OracleDbType.NVarchar2, comp.prenumeJucator, ParameterDirection.Input),
                new OracleParameter(":rolJucator", OracleDbType.NVarchar2, comp.rolJucator, ParameterDirection.Input),
                new OracleParameter(":dataNastereJucator", OracleDbType.Date, comp.dataNastereJucator, ParameterDirection.Input),
                new OracleParameter(":salariuJucator", OracleDbType.Decimal, comp.salariuJucator, ParameterDirection.Input),
                new OracleParameter(":idEchipa", OracleDbType.Int32, comp.idEchipa, ParameterDirection.Input),
                new OracleParameter(":idJucator", OracleDbType.Int32, comp.idJucator, ParameterDirection.Input));
        }
        public List<Jucator> FindJucator(string numeJucator)
        {
            var result = new List<Jucator>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from jucatori_ProiectBN WHERE numeJucator = :numeJucator", CommandType.Text,
                new OracleParameter(":numeJucator", OracleDbType.NVarchar2, numeJucator, ParameterDirection.Input));

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Jucator(linieDB));
            }
            return result;
        }
        public bool DeleteJucator(int idJucator)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM jucatori_ProiectBN WHERE idJucator = :idJucator", CommandType.Text,
                new OracleParameter(":idJucator", OracleDbType.Int32, idJucator, ParameterDirection.Input));
        }
        public bool AscundeJucator(Jucator comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE jucatori_ProiectBN set vizibil = 0 where idJucator = :idJucator", CommandType.Text,
                new OracleParameter(":idJucator", OracleDbType.Int32, comp.idJucator, ParameterDirection.Input));
        }
    }
}
