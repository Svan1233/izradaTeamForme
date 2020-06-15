using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnirAsistentModel.Models;

namespace TurnirAsistentModel.DataAccess
{
    public interface IDataConnection
    {
        NagradaModel NapraviNagradu(NagradaModel model);
        OsobaModel IzradiOsobu(OsobaModel model);
        List<OsobaModel> GetPeople1_All();

    }
}
