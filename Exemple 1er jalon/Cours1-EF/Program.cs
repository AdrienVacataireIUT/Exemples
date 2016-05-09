using Cours1_EF.ModeleDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Cours1_EF.ModeleFluent;

namespace Cours1_EF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestEFAvecFluent();
        }

        // permet de tester EF avec les DataAnnotations
        public static void TestEFAvecDataAnnotations()
        {
            // test du contexte avec data annotation
            ContextDA contexteDA = new ContextDA();

            // ajout d'un nouveau client avec un compte
            List<ModeleDA.CompteClient> comptes = new List<ModeleDA.CompteClient>();
            comptes.Add(new ModeleDA.CompteClient { NomBanque = "CA", NumeroCompte = "1234" });
            contexteDA.Clients.Add(new ModeleDA.Client { Nom = "TEST", Comptes = comptes });
            contexteDA.SaveChanges();

            // lecture des clients
            List<ModeleDA.Client> mesClients = contexteDA.Clients.Include(c => c.Comptes).ToList();
            Console.WriteLine("Liste de mes clients avec DA : ");
            foreach (ModeleDA.Client c in mesClients)
            {
                Console.WriteLine("Client n°{0} : {1}", c.Id, c.Nom);
                foreach (ModeleDA.CompteClient cc in c.Comptes)
                {
                    Console.WriteLine("|__ Compte n°{0}", cc.NumeroCompte);
                }
            }
            Console.WriteLine("...Fin...");
        }

        // permet de tester EF avec les l'API Fluent
        public static void TestEFAvecFluent()
        {
            // test du contexte avec api fluent
            ContextFluent contextFluent = new ContextFluent();

            // ajout d'un nouveau client avec un compte
            List<ModeleFluent.CompteClient> comptes = new List<ModeleFluent.CompteClient>();
            comptes.Add(new ModeleFluent.CompteClient { NomBanque = "CA", NumeroCompte = "1234" });
            contextFluent.Clients.Add(new ModeleFluent.Client { Nom = "TEST", Comptes = comptes });
            contextFluent.SaveChanges();

            // lecture des clients
            List<ModeleFluent.Client> mesAutresClients = contextFluent.Clients.Include(c => c.Comptes).ToList();
            Console.WriteLine("Liste de mes clients avec Fluent : ");
            foreach (ModeleFluent.Client c in mesAutresClients)
            {
                Console.WriteLine("Client n°{0} : {1}", c.Id, c.Nom);
                foreach (ModeleFluent.CompteClient cc in c.Comptes)
                {
                    Console.WriteLine("|__ Compte n°{0}", cc.NumeroCompte);
                }
            }
            Console.WriteLine("...Fin...");
        }
    }
}
