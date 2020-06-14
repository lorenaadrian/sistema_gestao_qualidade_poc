using Dapper;
using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public class AcaoCorretivaRepository : RepositoryAsync<AcaoCorretiva>, IAcaoCorretivaRepository
    {
        private readonly string table_name = "TBL_ACAO_CORRETIVA";

        public AcaoCorretivaRepository(IDatabaseAccess databaseOptions) : base(databaseOptions)
        {
        }

        public AcaoCorretivaRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected override string SelectByIdQuery => $"SELECT * FROM {table_name} WHERE id = (@{nameof(AcaoCorretiva.id)})";

        protected override string SelectAllQuery => $"SELECT * FROM {table_name} ";

        public async Task<IEnumerable<AcaoCorretiva>> GetAcaoByCR(int idCR)
        {
            string query = $"SELECT * FROM {table_name} WHERE idCR= " + idCR;
            return await dbConn.QueryAsync<AcaoCorretiva>(new CommandDefinition(query));
        }
    }
}
