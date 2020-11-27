using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe27._11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exe8();
            Exe10();
        }

        private static void Exe10()
        {

            #region Creazione Liste
            var personList = new List<Persona>
            {
                new Persona {ID = 1, Nome = "Anna", Cognome = "Rossi", Nazione = "Italia"},
                new Persona {ID = 2, Nome = "Fabrizio",  Cognome = "Bianchi", Nazione = "Italia"},
                new Persona {ID = 3, Nome = "Mario",  Cognome = "Rossi", Nazione = "Italia"},
                new Persona {ID = 4, Nome = "Anna",  Cognome = "Verdi", Nazione = "Italia"},
                new Persona {ID = 5, Nome = "Charlie",  Cognome = "Williams", Nazione = "UK"},
                new Persona {ID = 6, Nome = "John",  Cognome = "Smith", Nazione = "USA"}
            };

            var carList = new List<Veicolo>
            {
                new Veicolo {ID = 1, Colore = "Rosso", Massa = 2000, Prezzo = 10000, Targa = "ABC123", IDProprietario = 1},
                new Veicolo {ID = 2, Colore = "Blu", Massa = 1500, Prezzo = 15000, Targa = "ABC223", IDProprietario = 1},
                new Veicolo {ID = 3, Colore = "Rosso", Massa = 2000, Prezzo = 14000, Targa = "ABC323", IDProprietario = 3},
                new Veicolo {ID = 4, Colore = "Nero", Massa = 2200, Prezzo = 130000, Targa = "ABC423", IDProprietario = 3},
                new Veicolo {ID = 5, Colore = "Nero", Massa = 2100, Prezzo = 350000, Targa = "ABC523", IDProprietario = 3},
                new Veicolo {ID = 6, Colore = "Giallo", Massa = 2000, Prezzo = 100000, Targa = "ABC623", IDProprietario = 4},
                new Veicolo {ID = 7, Colore = "Rosso", Massa = 1900, Prezzo = 40000, Targa = "ABC723", IDProprietario = 5},
                new Veicolo {ID = 8, Colore = "Rosso", Massa = 1800, Prezzo = 30000, Targa = "ABC823", IDProprietario = 6},
            }; 
            #endregion

            #region Contare il numero di veicoli per colore
            var sumByColour
                    = carList
                    .GroupBy(c => c.Colore)
                    .Select(list => new
                    {
                        colore = list.Key,
                        num = list.Count()
                    });

            foreach (var item in sumByColour)
            {
                Console.WriteLine($"Ci sono {item.num} veicoli di colore {item.colore}");
            }

            #endregion

            #region Peso complessivo e Prezzo Medio dei Veicoli posseduti da ciascuna Persona
            var groupjoin1 =
                    from c in carList
                    group c by c.IDProprietario
                    into gr
                    select new
                    {
                        idProprietario = gr.Key,
                        prezzoMedio = gr.Average(c => c.Prezzo),
                        massaTot = gr.Sum(c => c.Massa)
                    }
                    into gr1
                    join p in personList
                    on gr1.idProprietario equals p.ID
                    select new { p.Nome, p.Cognome, gr1.prezzoMedio, gr1.massaTot };

            Console.WriteLine("\n\n");
            foreach (var item in groupjoin1)
            {
                Console.WriteLine($"{item.Nome} {item.Cognome} possiede veicoli con prezzo medio: {item.prezzoMedio} e massa totale: {item.massaTot} kg");
            }
            #endregion

            #region Scrivere un extension method della classe Persona ( VeicoliPosseduti(List<Veicoli> elencoVeicoli) ) che restituisca l’elenco dei veicoli posseduti (campi: ID, Targa, Prezzo)
            Persona p1 = new Persona { ID = 1, Nome = "Anna", Cognome = "Rossi", Nazione = "Italia" };

            List<VeicoloPosseduto> veicoliPossiduti = p1.VeicoliPosseduti(carList);

            var numVeicoli_p1 = veicoliPossiduti.Count;
            Console.WriteLine($"\n \n Il proprietario {p1.ID} ha {numVeicoli_p1} veicoli: \n");
            foreach (var v in veicoliPossiduti)
            {
                Console.WriteLine($"ID veicolo: {v.ID}, prezzo: {v.Prezzo} e a targa: {v.Targa}");

            } 
            #endregion

        }

        private static void Exe8()
        {
            // Creazione lista di persone 
            var personList = new List<Person>
            {
                new Person {FirstName = "Anna", LastName = "Rossi"},
                new Person {FirstName = "Fabrizio", LastName = "Bianchi"},
                new Person {FirstName = "Mario", LastName = "Rossi"},
                new Person {FirstName = "Anna", LastName = "Verdi"}
            };

            // Query Syntax 
            var filteredList =
                from p in personList
                where p.FirstName == "Anna" || p.FirstName == "Fabrizio"
                select new { Nome = p.FirstName, Cognome = p.LastName };

            // Stampa risultati
            foreach (var p in filteredList)
            {
                Console.WriteLine($"{p.Nome} - {p.Cognome}");
            }

            // Method Syntax
            var filteredList1 = personList
                .Where(p => p.FirstName == "Anna" || p.FirstName == "Fabrizio")
                .Select(p => new { Nome = p.FirstName, Cognome = p.LastName });

            // Stampa dei risultati
            Console.WriteLine("\n \n");
            foreach (var p in filteredList1)
            {
                Console.WriteLine($"{p.Nome} - {p.Cognome}");
            }
        }

    }
}
