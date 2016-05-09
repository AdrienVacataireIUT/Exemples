using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours1_Chapitre2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TEST ICI
            TestCollection();
        }

        public static void TestTableaux()
        {
            // Déclaration d'un tableau unidemensionnel d'entier
            int[] array1 = new int[5];

            // Déclaration d'un tableau unidimensionnel d'entier avec assignation de valeur
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
            int[] array3 = { 1, 3, 5, 7, 9 };

            // Déclaration d'un tableau multidimensionnel d'entier
            int[,] multiDimensionalArray1 = new int[2, 3];

            // Déclaration d'un tableau multidimensionnel d'entier avec assignation de valeur
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // parcourir un tableau unidimensionnel
            foreach (int i in array2)
            {
                System.Console.Write("{0} ", i);
            }
            // Sortie: 1 3 5 7 9

            // parcourir un tableau multidimensionnel
            foreach (int i in multiDimensionalArray2)
            {
                System.Console.Write("{0} ", i);
            }
            // Output: 1 2 3 4 5 6
        }

        public static void TestCollection()
        {
            // Test avec une liste d'entier
            List<int> listeEntier = new List<int>();
            listeEntier.Add(1);
            int valeur = listeEntier.ElementAt(0);
            Console.WriteLine("ElementAt : {0}", valeur);
            listeEntier.Remove(1);

            // test avec une stack d'entier
            Stack<int> stackEntier = new Stack<int>();
            stackEntier.Push(1); // insère un élément en haut
            stackEntier.Push(2);
            int jeton = stackEntier.Peek(); // Retourne l'objet situé en haut sans le supprimer
            Console.WriteLine("Peek : {0}", jeton);
            jeton = stackEntier.Pop(); // Supprime et retourne l'objet en haut
            Console.WriteLine("Pop : {0}", jeton);
            jeton = stackEntier.Pop();
            Console.WriteLine("Pop : {0}", jeton);

            // test avec une queue d'entier
            Queue<int> queueEntier = new Queue<int>();
            queueEntier.Enqueue(1); // Ajoute un objet à la fin
            queueEntier.Enqueue(2);
            int queueValeur = queueEntier.Dequeue(); // Supprime et retourne l'objet en haut
            Console.WriteLine("Dequeue : {0}", queueValeur);
            queueValeur = queueEntier.Dequeue();
            Console.WriteLine("Pop : {0}", queueValeur);

            // test avec un dictionnaire
            Dictionary<int, string> listeCoureur = new Dictionary<int, string>();
            listeCoureur.Add(12, "Dupont Jean");
            listeCoureur.Add(19, "Gary Rémy");
            string nomCoureurDossard12 = string.Empty;
            listeCoureur.TryGetValue(12, out nomCoureurDossard12);
            Console.WriteLine("Dossard 12 = {0}", nomCoureurDossard12);

            // foreach sur dictionnaire
            foreach(KeyValuePair<int, string> vp in listeCoureur)
            {
                Console.WriteLine("Dossard {0} = {1}", vp.Key, vp.Value);
            }
        }

        public static void TestMethodeExtension()
        {
            string s = "J'adore le C#";
            int mots = s.CompterLesMots();
            System.Console.Write("Nombre de mots : {0} ", mots);
            // Sortie : Nombre de mots : 3
        }

        public static void TestEnumeration()
        {
            Droit monDroit = Droit.ALL;
            switch (monDroit) // Switch ou If
            {
                case Droit.ALL:
                    System.Console.Write("Droit maximal : {0} ", monDroit.ToString());
                    break;
                default:
                    System.Console.Write("Vous n'avez pas tous les droits");
                    break;
            }
            // Sortie : Droit maximal : ALL

            int codeMonDroit = (int)monDroit;
            System.Console.Write("Code de mon droit : {0} ", codeMonDroit);
            // Sortie : Code de mon droit : 3
        }
    }

    // Classe d'extension statique
    public static class MyExtension
    {
        // fonction d'extension pour compter les mots
        public static int CompterLesMots(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    // énumération
    public enum Droit : int
    {
        NON = 0,
        LECTURE_SEULEMENT,
        LECTURE_ECRITURE,
        ALL
    }
}
