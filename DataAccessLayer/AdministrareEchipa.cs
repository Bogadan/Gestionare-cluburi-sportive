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
    public class AdministrareEchipa : IStocareEchipa
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Echipa> GetEchipe()
        {
            var result = new List<Echipa>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from echipe_ProiectBN", CommandType.Text);

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Echipa(linieDB));
            }
            return result;
        }

        public Echipa GetEchipa(int id)
        {
            Echipa result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from echipe_ProiectBN where IdEchipa = :IdEchipa ORDER BY idEchipa", CommandType.Text,
                new OracleParameter(":IdEchipa", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Echipa(linieDB);
            }
            return result;
        }
        public List<Echipa> FindEchipa(string numeEchipa)
        {
            var result = new List<Echipa>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from echipe_ProiectBN WHERE numeEchipa = :numeEchipa", CommandType.Text,
                new OracleParameter(":numeEchipa", OracleDbType.NVarchar2, numeEchipa, ParameterDirection.Input));

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Echipa(linieDB));
            }
            return result;
        }
        public List<Echipa> FindEchipe(string numeClub)
        {
            var result = new List<Echipa>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("SELECT * FROM echipe_ProiectBN e, cluburi_ProiectBN c WHERE e.idClub = c.idClub AND c.numeClub = :numeClub", CommandType.Text,
                new OracleParameter(":numeClub", OracleDbType.NVarchar2, numeClub, ParameterDirection.Input));

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Echipa(linieDB));
            }
            return result;
        }

        public bool AddEchipa(Echipa comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO echipe_ProiectBN VALUES (seq_echipe_ProiectBN.nextval, :numeEchipa, :oras, :nrMembri, :numeAntrenor, :idClub, 1)", CommandType.Text,
                new OracleParameter(":numeEchipa", OracleDbType.NVarchar2, comp.numeEchipa, ParameterDirection.Input),
                new OracleParameter(":oras", OracleDbType.NVarchar2, comp.oras, ParameterDirection.Input),
                new OracleParameter(":nrMembri", OracleDbType.Int32, comp.nrMembri, ParameterDirection.Input),
                new OracleParameter(":numeAntrenor", OracleDbType.NVarchar2, comp.numeAntrenor, ParameterDirection.Input),
                new OracleParameter(":idClub", OracleDbType.Int32, comp.idClub, ParameterDirection.Input));
        }
        public bool DecrNrMembri(int idEchipa)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE echipe_ProiectBN SET nrMembri = nrMembri-1 WHERE idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, idEchipa, ParameterDirection.Input));
        }
        public bool UpdateEchipa(Echipa comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE echipe_ProiectBN set numeEchipa = :numeEchipa, oras = :oras, nrMembri = :nrMembri, numeAntrenor = :numeAntrenor, idClub = :idClub where idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":numeEchipa", OracleDbType.NVarchar2, comp.numeEchipa, ParameterDirection.Input),
                new OracleParameter(":oras", OracleDbType.NVarchar2, comp.oras, ParameterDirection.Input),
                new OracleParameter(":nrMembri", OracleDbType.Int32, comp.nrMembri, ParameterDirection.Input),
                new OracleParameter(":numeAntrenor", OracleDbType.NVarchar2, comp.numeAntrenor, ParameterDirection.Input),
                new OracleParameter(":idClub", OracleDbType.Int32, comp.idClub, ParameterDirection.Input),
                new OracleParameter(":idEchipa", OracleDbType.Int32, comp.idEchipa, ParameterDirection.Input));
        }
        public bool DeleteEchipa(int idEchipa)
        {
            //se sterg mai intai toti jucatorii ce tin de echipa, urmat de echipa in sine
            bool stergereJucatori = SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM jucatori_ProiectBN WHERE idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, idEchipa, ParameterDirection.Input));

            bool stergereEchipe = SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM echipe_ProiectBN WHERE idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, idEchipa, ParameterDirection.Input));
            return stergereJucatori || stergereEchipe;
        }
        public bool AscundeEchipa(int idEchipa)
        {
            //se ascund mai intai toti jucatorii din echipa respectiva
            bool ascundereJucatori = SqlDBHelper.ExecuteNonQuery(
                "UPDATE jucatori_ProiectBN set vizibil = 0 where idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, idEchipa, ParameterDirection.Input));

            bool ascundereEchipa = SqlDBHelper.ExecuteNonQuery(
                "UPDATE echipe_ProiectBN set vizibil = 0 where idEchipa = :idEchipa", CommandType.Text,
                new OracleParameter(":idEchipa", OracleDbType.Int32, idEchipa, ParameterDirection.Input));

            return ascundereJucatori || ascundereEchipa;
        }
    }
}
