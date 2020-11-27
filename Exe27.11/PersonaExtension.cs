using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exe27._11
{
    public static class PersonaExtension
    {

        public static List<VeicoloPosseduto> VeicoliPosseduti(this Persona proprietario, List<Veicolo> elencoVeicoli)
        {

            int id = proprietario.ID;

            var veicoli =
                (from v in elencoVeicoli
                 where v.IDProprietario == id
                 select new VeicoloPosseduto()
                 { 
                   ID = v.IDProprietario, 
                   Targa = v.Targa, 
                   Prezzo = v.Prezzo
                 }
                ).ToList();

            return veicoli;
        }
    }
}
