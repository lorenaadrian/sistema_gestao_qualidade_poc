using Dapper;
using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public class CausaRaizRepository : RepositoryAsync<CausaRaiz>, ICausaRaizRepository
    {
        private readonly string table_name = "TBL_ANALISE_CR";

        public CausaRaizRepository(IDatabaseAccess databaseOptions) : base(databaseOptions)
        {
        }

        public CausaRaizRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected override string InsertQueryReturnInserted => $"INSERT INTO {table_name} " +
                                                "(idNC,p1,descricaoP1,p2,descricaoP2,p3,descricaoP3,p4,descricaoP4,p5,descricaoP5,p6,descricaoP6)" +
                                                $"values(@{nameof(CausaRaiz.idNC)},"+
                                                $"@{nameof(CausaRaiz.p1)},@{nameof(CausaRaiz.descricaoP1)}," +
                                                $"@{nameof(CausaRaiz.p2)},@{nameof(CausaRaiz.descricaoP2)}," +
                                                $"@{nameof(CausaRaiz.p3)},@{nameof(CausaRaiz.descricaoP3)}," +
                                                $"@{nameof(CausaRaiz.p4)},@{nameof(CausaRaiz.descricaoP4)}," +
                                                $"@{nameof(CausaRaiz.p5)},@{nameof(CausaRaiz.descricaoP5)}," +
                                                $"@{nameof(CausaRaiz.p6)},@{nameof(CausaRaiz.descricaoP6)});";

        protected override string SelectByIdQuery => $"SELECT * FROM {table_name} WHERE id = (@{nameof(CausaRaiz.id)})";

        protected override string SelectAllQuery => $"SELECT * FROM {table_name} ";

        public async Task<CausaRaiz> GetCausaRaizByNC(int idNC)
        {
            string query = $"SELECT * FROM {table_name} WHERE idNC= " + idNC;
            var obj = await dbConn.QueryAsync<CausaRaiz>(new CommandDefinition(query));
            return obj.FirstOrDefault();
        }
    }
}
