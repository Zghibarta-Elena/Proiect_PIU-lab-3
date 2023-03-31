using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    class Farmacie
    {
        public string numeFarmacie;
        public List<Medicament> medicamente = new List<Medicament>();

        public void AdaugMed(string numeMedicament, int cantitate, int idMedicament)
        {
            Medicament new_medicament = new Medicament(idMedicament, numeMedicament, cantitate);

            medicamente.Add(new_medicament);

        }
        public void AdaugMed(Medicament medicament)
        {
            medicamente.Add(medicament);

        }


        public void AfisareListaMed()
        {
            for (int i = 0; i < medicamente.Count; i++)
            {
                Console.WriteLine($"NUME: {medicamente[i].numeMedicament},CANTITATE: {medicamente[i].cantitate}");

            }
        }

        public void Afisare_Lista_Medicamente()
        {
            foreach (Medicament medicam in this.medicamente)
            {
                Console.WriteLine($"{medicam.idMedicament},{medicam.numeMedicament},{medicam.cantitate}");
            }
        }

        public void Cauta_Medicament_Dupa_Nume(string numeMedicament)
        {
            foreach (Medicament med in this.medicamente)
            {
                if (med.numeMedicament.Equals(numeMedicament, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{med.idMedicament},{med.numeMedicament},{med.cantitate}");
                    return;
                }
            }
            Console.WriteLine("Nu s-a gasit acest medicament!");

        }
        public void Cauta_Medicament_Dupa_Cantitate(int cantitate)
        {
            foreach (Medicament med in this.medicamente)
            {
                if (med.cantitate == cantitate)
                {
                    Console.WriteLine($"{med.idMedicament},{med.numeMedicament},{med.cantitate}");
                    return;
                }
            }
            Console.WriteLine("Nu s-a gasit acest medicament!");

        }
        public void SalvareMedicamenteInFisier(string NumeFisier)
        {
            using (StreamWriter StreamWriterFisier = new StreamWriter(NumeFisier, false))
            {
                foreach (Medicament medicament in this.medicamente)
                {
                    StreamWriterFisier.WriteLine(medicament.ConversieLaSir_PentruFisier());
                }
            }
        }
        public int IncarcareMedicamenteInFisier(string NumeFisier)
        {
            int nr_medicamente_adaugate = 0;

            using (StreamReader streamReader = new StreamReader(NumeFisier))
            {
                string linieFisier;

                /* citeste cate o linie si creaza un obiect de tip Person
                pe baza datelor din linia citita */

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    if (linieFisier.Length == 0) continue;

                    this.medicamente.Add(new Medicament(linieFisier));
                    nr_medicamente_adaugate++;
                }
            }
            return nr_medicamente_adaugate;
        }
    }
}
