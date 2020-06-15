using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnirAsistentModel.Models
{
     public class EkipaModel
    {
        /// <summary>
        /// svi clanovi ekipe
        /// </summary>
        public List<OsobaModel> ClanoviEkipe { get; set; } = new List<OsobaModel>();
        /// <summary>
        /// Ime ekipe koja ce sudjelovati u turniru
        /// </summary>
        public string ImeEkipe { get; set; }

    }
}
