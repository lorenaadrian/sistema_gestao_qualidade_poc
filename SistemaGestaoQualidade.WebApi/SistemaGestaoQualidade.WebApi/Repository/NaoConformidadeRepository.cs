using Dapper;
using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{

    public class NaoConformidadeRepository : RepositoryAsync<NaoConformidade>, INãoConformidadeRepository
    {
        private readonly string table_name = "TBL_NAO_CONFORMIDADE";

        public NaoConformidadeRepository(IDatabaseAccess databaseOptions) : base(databaseOptions)
        {
        }

        public NaoConformidadeRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected override string InsertQuery => $"INSERT INTO {table_name} " +
                "([dataNC]" +                                 //obrigatório
                   ",[emitenteNC]" +                          //obrigatório
                   ",[idCausaNC]" +                           //obrigatório
                   ",[idEstadoNC]" +                          //obrigatório
                   ",[idIdentificacaoNC]" +                   //obrigatório
                   ",[idIntensidadeNC]" +                     //obrigatório
                   ",[idRequisitoNC]" +                       //obrigatório
                   ",[descricaoNC]" +                         //obrigatório
                   ",[abrangenciaNC]" +                       //obrigatório
                   ",[acaoImediata]" +                        //não obrigatório - update
                   ",[dataAcaoImediata]" +                    //não obrigatório - update
                   ",[responsavelAcaoImediata]" +             //não obrigatório - update
                   ",[temAnaliseCR] " +                       //não obrigatório - update
                   ",[cancelouNC]) " +                        //não obrigatório - update
                   $" VALUES(@{nameof(NaoConformidade.dataNC)},@{nameof(NaoConformidade.emitenteNC)},@{nameof(NaoConformidade.idCausaNC)}," +
                   $"@{nameof(NaoConformidade.idEstadoNC)},@{nameof(NaoConformidade.idIdentificacaoNC)},@{nameof(NaoConformidade.idIntensidadeNC)}," +
                   $"@{nameof(NaoConformidade.idRequisitoNC)},@{nameof(NaoConformidade.descricaoNC)},@{nameof(NaoConformidade.abrangenciaNC)}," +
                   $"@{nameof(NaoConformidade.acaoImediata)},@{nameof(NaoConformidade.dataAcaoImediata)},@{nameof(NaoConformidade.responsavelAcaoImediata)}," +
                   $"@{nameof(NaoConformidade.temAnaliseCR)},@{nameof(NaoConformidade.cancelouNC)});";

        protected override string InsertQueryReturnInserted => $"INSERT INTO {table_name} " +
                "([dataNC]" +                                 //obrigatório
                   ",[emitenteNC]" +                          //obrigatório
                   ",[idCausaNC]" +                           //obrigatório
                   ",[idEstadoNC]" +                          //obrigatório
                   ",[idIdentificacaoNC]" +                   //obrigatório
                   ",[idIntensidadeNC]" +                     //obrigatório
                   ",[idRequisitoNC]" +                       //obrigatório
                   ",[idTipoRequisito]" +                       //obrigatório
                   ",[descricaoNC]" +                         //obrigatório
                   ",[abrangenciaNC]" +                       //obrigatório
                   ",[acaoImediata]" +                        //não obrigatório - update
                   ",[dataAcaoImediata]" +                    //não obrigatório - update
                   ",[responsavelAcaoImediata]" +             //não obrigatório - update
                   ",[temAnaliseCR] " +                       //não obrigatório - update
                   ",[cancelouNC]) " +                        //não obrigatório - update
                   $" VALUES(@{nameof(NaoConformidade.dataNC)},@{nameof(NaoConformidade.emitenteNC)},@{nameof(NaoConformidade.idCausaNC)}," +
                   $"@{nameof(NaoConformidade.idEstadoNC)},@{nameof(NaoConformidade.idIdentificacaoNC)},@{nameof(NaoConformidade.idIntensidadeNC)}," +
                   $"@{nameof(NaoConformidade.idRequisitoNC)},@{nameof(NaoConformidade.idTipoRequisito)},@{nameof(NaoConformidade.descricaoNC)}," +
                   $"@{nameof(NaoConformidade.abrangenciaNC)},@{nameof(NaoConformidade.acaoImediata)},@{nameof(NaoConformidade.dataAcaoImediata)}," +
                   $"@{nameof(NaoConformidade.responsavelAcaoImediata)},@{nameof(NaoConformidade.temAnaliseCR)},@{nameof(NaoConformidade.cancelouNC)});" +
            $"SELECT @@IDENTITY";
        protected override string UpdateByIdQuery => $"UPDATE {table_name} SET " +
                    $"  acaoImediata = @{nameof(NaoConformidade.acaoImediata)}" +
                    $", dataAcaoImediata = @{nameof(NaoConformidade.dataAcaoImediata)}" +
                    $", responsavelAcaoImediata = @{nameof(NaoConformidade.responsavelAcaoImediata)}" +
                    $", temAnaliseCR = @{nameof(NaoConformidade.temAnaliseCR)}" +
                    $"  WHERE id = @{nameof(NaoConformidade.id)}";

        protected override string DeleteByIdQuery => $"UPDATE {table_name} SET " +
                    $" cancelouNC = 1" +
                    $"  WHERE id = @{nameof(NaoConformidade.id)}";
        protected override string SelectByIdQuery => $"SELECT * FROM {table_name} WHERE id = @{nameof(NaoConformidade.id)}";

        protected override string SelectAllQuery => $"SELECT * FROM {table_name} WHERE cancelouNC = 0";

        public async Task<IEnumerable<NaoConformidade>> GetByFilter(NaoConformidade objSearch)
        {
            string query = $"SELECT * FROM {table_name} WHERE  cancelouNC = 0 ";
            if (objSearch.id > 0)
                query += " and id = " + objSearch.id;
            if(!string.IsNullOrEmpty(objSearch.dataNC))
                query += " and dataNC = '" + objSearch.dataNC + "'";
            return await dbConn.QueryAsync<NaoConformidade>(new CommandDefinition(query));
        }
    }
}
