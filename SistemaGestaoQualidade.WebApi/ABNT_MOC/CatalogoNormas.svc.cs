using System;
using System.IO;

namespace NORMAS_MOC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Normas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Normas.svc or Normas.svc.cs at the Solution Explorer and start debugging.
    public class CatalogoNormas : ICatalogoNormas
    {
        public string GetNorma(string nomeNorma)
        {
            string path = string.Format(@"{0}{1}\{2}.pdf",
                AppDomain.CurrentDomain.BaseDirectory.ToString(), "Files", nomeNorma);
            string retorno = Convert.ToBase64String(File.ReadAllBytes(path));
            return retorno;
        }

    }
}
