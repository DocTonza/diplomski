using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonzaDiplomski {

    // interface koje mora svaki novi graf implementirati
    public interface IGraf {
        string naslov { get; set; }
        int verzija { get; }
        List<PodatakZaGraf> podaci { get; set; }
    }
}
