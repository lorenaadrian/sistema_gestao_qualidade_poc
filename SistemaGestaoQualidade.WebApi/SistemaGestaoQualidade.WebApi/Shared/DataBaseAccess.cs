using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using SistemaGestaoQualidade.WebApi.Shared;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public class DataBaseAccess: IDatabaseAccess
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public DataBaseAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("ConexaoBD").Value;
        }

        public IDbConnection GetDbConnection => new SqlConnection(this._connectionString);
        /*
public int InsertBD(string query)
{
int retorno = 0;
try
{
using (var con = new SqlConnection(_connectionString))
{
try
{
con.Open();
retorno = con.Execute(query, null, null, null, System.Data.CommandType.Text);
}
catch (Exception) { retorno = 99; }
finally
{
con.Close();
}
}
}
catch (Exception ex)
{
retorno = 99;
}
return retorno;
}

public List<TEntity> ReadBD(string query)
{
List<T> lista;
try
{
using (var con = new SqlConnection(_connectionString))
{
try
{
con.Open();
lista = con.Query<T>(query).ToList();
}
catch (Exception ex)
{
return null;
}
finally
{
con.Close();
}
}
}
catch (Exception) { return null; }
return lista;
}
*/
    }
}
