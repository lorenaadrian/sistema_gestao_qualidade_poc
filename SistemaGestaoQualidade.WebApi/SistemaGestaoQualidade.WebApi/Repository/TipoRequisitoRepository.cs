using Dapper;
using NaoConformidadeModule.WebApi.Models;
using NaoConformidadeModule.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Repository
{
    public class TipoRequisitoRepository : RepositoryAsync<TipoRequisito>, ITipoRequisitoRepository
    {
        private readonly string table_name = "TBL_REQUISITO";

        public TipoRequisitoRepository(IDatabaseAccess databaseOptions) : base(databaseOptions)
        {
        }

        public TipoRequisitoRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected override string SelectByIdQuery => $"SELECT * FROM {table_name} WHERE id = @{nameof(TipoRequisito.id)}";

        protected override string SelectAllQuery => $"SELECT * FROM {table_name}";

        public async Task<IEnumerable<TipoRequisito>> GetListByIdTipo(object idTipo)
        {
            string query = $"SELECT * FROM {table_name} WHERE idTipo = "+ idTipo;
            return await dbConn.QueryAsync<TipoRequisito>(query, transaction: dbTransaction);
        }
    }
}
