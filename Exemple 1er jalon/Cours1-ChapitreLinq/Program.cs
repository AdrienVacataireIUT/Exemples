using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_ChapitreLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TEST ICI
            ExemplesRequetes();
        }

        public static void ExempleUtilisationLinq()
        {
            // 1) déclarer la source de donnée
            int[] notes = new int[] { 4, 12, 18, 7, 11, 3, 15 };

            // 2) Définir la requête
            IEnumerable<int> notesQuery =
                from note in notes
                where note > 10
                select note;

            // 3) Exécuter la requête
            foreach(int i in notesQuery)
            {
                Console.Write(i + " ");
            }
        }

        public static void ExempleDifferentesSyntaxes()
        {
            int[] notes = new int[] { 4, 12, 18, 7, 11, 3, 15 };

            // syntaxe de requête pour récupérer les notes au dessus de 10 triée dans l'ordre croissant
            IEnumerable<int> notesQuery1 =
                from note in notes
                where note > 10
                orderby note
                select note;

            // syntaxe de méthode pour récupérer les notes au dessus de 10 triée dans l'ordre croissant
            IEnumerable<int> notesQuery2 = notes.Where(note => note > 10).OrderBy(note => note);
        }

        // Déclaration de mon délégué
        static bool PlusGrandQue10(int arg)
        {
            return (arg > 10);
        }

        public static void TestExpressionsLambda()
        {
            List<int> liste = new List<int> { 4, 12, 18, 7, 11, 3, 15 };

            // sans expressions lambda et avec la déclaration de la fonction PlusGrandQue10
            Func<int, bool> maFonctionDelegue = PlusGrandQue10;
            IEnumerable<int> resultat = liste.Where(maFonctionDelegue);
            foreach (var item in resultat)
            {
                Console.WriteLine("{0} ", item);
            }

            // avec expression lambda
            IEnumerable<int> resultat2= liste.Where(n => n > 10);
            foreach (var item in resultat2)
            {
                Console.WriteLine("{0} ", item);
            }
        }

        public static void ExemplesRequetes()
        {
            List<int> liste = new List<int> { 4, 12, 18, 7, 11, 3, 15, 4, 0, 19, 17, 12, 12, 9 };

            // compter le nombre de note au dessus de 10
            int nbNotePlus10 = liste.Where(n => n > 10).Count();
            Console.WriteLine("Nombre de note au dessus de 10 : {0} ", nbNotePlus10);

            // calculer la moyenne
            double moyenne = liste.Average(n => n);
            Console.WriteLine("Moyenne : {0} ", moyenne);

            //  trier les note par ordre croissant et prendre la plus faible et la plus grande
            int plusPetiteNote = liste.OrderBy(n => n).First();
            int plusPetiteNoteV2 = liste.Min(n => n);
            int plusGrandeNote = liste.OrderBy(n => n).Last();
            int plusGrandeNoteV2 = liste.Max(n => n);
            Console.WriteLine("Plus basse : {0} - Plus haute : {1} ", plusPetiteNote, plusGrandeNote);

            // déterminer si quelqu'un a eu 0
            bool laBulle = liste.Any(n => n == 0);
            Console.WriteLine("Des notes égales à 0 ? {0}", laBulle);
        }
    }
}
