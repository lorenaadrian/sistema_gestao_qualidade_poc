using System.Data;

namespace NaoConformidadeModule.WebApi.Shared
{
    public interface IDatabaseAccess
    {
        IDbConnection GetDbConnection { get; }


    }
}