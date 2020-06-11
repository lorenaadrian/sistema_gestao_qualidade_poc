using NaoConformidadeModule.WebApi.Shared;
using NaoConformidadeModule.WebApi.Models;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Operations;
using Dapper;

namespace NaoConformidadeModule.WebApi.Repository
{
    public class ClassificacaoNaoConformidadeRepository : RepositoryAsync<ClassificacaoNaoConformidade>, IClassificacaoNaoConformidadeRepository
    {
        private readonly string table_name = "TBL_DOMINIO_NC";

        public ClassificacaoNaoConformidadeRepository(IDatabaseAccess databaseOptions) : base(databaseOptions)
        {
        }

        public ClassificacaoNaoConformidadeRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected override string SelectByIdQuery => $"SELECT * FROM {table_name} WHERE tipoDominio = (@{nameof(ClassificacaoNaoConformidade.tipoDominio)})";

        public async Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByIds(string ids)
        {
            string query = string.Format("SELECT * FROM {0} WHERE id in({1})", table_name, ids);
            CommandDefinition cd = new CommandDefinition(query);
            var obj = await dbConn.QueryAsync<ClassificacaoNaoConformidade>(cd);
            return obj;
        }
        public async Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByDominio(string dominio)
        {            
            string query = string.Format("SELECT distinct tipoDominio, textoDominio FROM {0} where dominioAplicacao = '{1}'", table_name, dominio);
            return await dbConn.QueryAsync<ClassificacaoNaoConformidade>(new CommandDefinition(query));
        }

        public async Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByTipoDominio(string tipoDominio)
        {
            string query = string.Format("SELECT id, descricao, tipoDominio FROM {0} WHERE tipoDominio = '{1}'", table_name, tipoDominio);
            return await dbConn.QueryAsync<ClassificacaoNaoConformidade>(new CommandDefinition(query));
        }
    }
}