using System.Data;

namespace SistemaGestaoQualidade.WebApi.Shared
{
    public interface IDatabaseAccess
    {
        IDbConnection GetDbConnection { get; }


    }
}