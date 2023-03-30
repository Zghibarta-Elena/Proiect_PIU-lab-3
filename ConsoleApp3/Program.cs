using System;
using System.Configuration;
namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Farmacie farmacie = new Farmacie();
            Medicament medicament;
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareMedicamente_Fisier adminMedicamente  = new AdministrareMedicamente_Fisier(numeFisier);
            int nrMedicamente = 0;

            string optiune;
            do
            {
                Console.WriteLine("I. Introducere informatii medicament");
                Console.WriteLine("A. Afisare medicamente");
                Console.WriteLine("F. Afisare medicamente din fisier");
                Console.WriteLine("S. Salvare medicament in fisier");
                Console.WriteLine("C. Cautare medicament dupa nume");
                Console.WriteLine("T. Cautare medicament dupa id");
                Console.WriteLine("R. Cautare medicament dupa cantitate");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        int idMedicament = nrMedicamente + 1;
                        string nume = "";
                        Console.WriteLine("Introduceti numele medicamentului: ",idMedicament);
                        nume = Console.ReadLine();

                        int cantitate = 0;
                        Console.WriteLine("Introduceti cantitate medicamentului: ",idMedicament);
                        Int32.TryParse(Console.ReadLine(),out cantitate);
                        medicament = new Medicament(idMedicament, nume, cantitate);
                        nrMedicamente++;
                        farmacie.AdaugMed(medicament);

                        break;
                    case "A":
                        farmacie.Afisare_Lista_Medicamente();
                        break;
                    case "F":
                        Medicament[] medicamente = adminMedicamente.GetMedicamente(out nrMedicamente);
                        AfisareMedicamente(medicamente, nrMedicamente);
                        break;
                    case "S":
                        idMedicament = nrMedicamente + 1;
                        nrMedicamente++;
                        medicament = new Medicament(idMedicament, "Aspirina", 6);
                        adminMedicamente.AddMedicament(medicament);
                        break;
                    case "C":
                        string Nume_de_cautat = "";
                        Console.WriteLine("Introduceti numele medicamentului: ");
                        Nume_de_cautat = Console.ReadLine();
                        farmacie.Cauta_Medicament_Dupa_Nume(Nume_de_cautat); break;
                    case "T":
                        int id_de_cautat=0;
                        Console.WriteLine("Introduceti id-ul medicamentului: ");
                        Int32.TryParse(Console.ReadLine(), out id_de_cautat);
                        farmacie.Cauta_Medicament_Dupa_Id(id_de_cautat); break;
                    case "R":
                        int cantitate_de_cautat = 0;
                        Console.WriteLine("Introduceti cantitatea medicamentului: ");
                        Int32.TryParse(Console.ReadLine(), out cantitate_de_cautat);
                        farmacie.Cauta_Medicament_Dupa_Cantitate(cantitate_de_cautat); break;
                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }
            } while (optiune.ToUpper() != "X");


            /// f1.AdaugMed("Paracetamol", 3);
            ///f1.AdaugMed("Nurofen", 2);
            ///f1.AdaugMed("Aspenter", 10);
            ///f1.AdaugMed("Aspirina", 30);
            // Utilizare valori din fisierul de configurari
            string titlu =
            ConfigurationManager.AppSettings.Get("TitluAplicatie");


            Console.WriteLine(titlu);
            farmacie.AfisareListaMed();



            Console.ReadKey();
        }
        public static void AfisareMedicamente(Medicament[] medicamente, int nrMedicament)
        {
            Console.WriteLine("Medicamentele sunt:");
            for(int contor=0; contor<nrMedicament;contor++)
            {
                string infoMedicament = string.Format("Medicamentul cu id-ul #{0} are numele: {1}{2}",
                    medicamente[contor].GetIdMedicament(),
                    medicamente[contor].GetNumeMedicament() ?? "Necunoscut",
                    medicamente[contor].GetCantitate());
                Console.WriteLine(infoMedicament);
            }
        }
    }
}
