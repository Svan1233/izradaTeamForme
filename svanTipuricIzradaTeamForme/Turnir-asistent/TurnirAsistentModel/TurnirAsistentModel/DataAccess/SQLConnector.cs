using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnirAsistentModel.Models;

//@PlaceNumber int,
//	@PlaceName nvarchar(30),
//	@PrizeAmount money,
//    @PrizePercentage float,
//	@id int = 0 output

namespace TurnirAsistentModel.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        public List<OsobaModel> GetOsoba_All()
        {
            throw new NotImplementedException();
        }

        public OsobaModel IzradiOsobu(OsobaModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("TurnirAsisstent")))
            {
                var p = new DynamicParameters();
                p.Add("@Ime", model.Ime);
                p.Add("@Prezime", model.Prezime);
                p.Add("@EmailAdresa", model.EmailAdresa);
                p.Add("@BrojMobitela", model.BrojMobitela);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople1_Insert", p, commandType: CommandType.StoredProcedure);

                model.ID = p.Get<int>("@id");

                return model;

            }
        }

        // TODO - Izradi NapraviNagradu metodu koju sacuva u bazu
        /// <summary>
        /// spremi novu nagradu u bazu podataka
        /// </summary>
        /// <param name="model">info o nagradama</param>
        /// <returns>info o nagradama, ukljucujuci posebni indetifikator</returns>
        public NagradaModel NapraviNagradu(NagradaModel model)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("TurnirAsisstent")))
            {
                var p = new DynamicParameters();
                p.Add("@Mjesto", model.Mjesto);
                p.Add("@NazivMjesta", model.NazivMjesta);
                p.Add("@IznosNagrade", model.IznosNagrade);
                p.Add("@PostotakNagrade", model.PostotakNagrade);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);
                
                model.ID = p.Get<int>("@id");

                return model;

            }
        }

        public List<OsobaModel> GetPeople1_All()
        {
            List<OsobaModel> output;
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                output = connection.Query<OsobaModel>("dbo.spPeople1_GetAll").ToList();
            }

            return output;
        }

    }
}
