using Microsoft.VisualBasic;

namespace testcsv1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Déclaration des variables
            string reponseUtilisateurCsv, reponseUtilisateurRecommencer, cheminFichierCsvLu;

            //Recommence tant que l'utilisateur répond oui
            do
            {
                //Affichage de l'entête grâce à la fonction AfficherEntete
                AfficherEntete("Lecture et calcule d'un fichier CSV");

                //Demande à l'utilisateur le chemin du fichier Csv
                cheminFichierCsvLu = LireCheminAcces("Veuillez spécifier le chemin d'accès du fichier CSV : ");

                //Demande à l'utilisateur si il souhaite lire les valeurs du fichier CSV grâce à la fonction lireTexte
                reponseUtilisateurCsv = LireTexteOuiNon("Souhaitez vous lire le contenu du fichier csv ? (Répondez par oui ou non) : ");

                //Lecture du fichier.csv grâce à la fonction AfficherCsv en fonction du choix de l'utilisateur
                LectureCsv(reponseUtilisateurCsv, cheminFichierCsvLu);

                //Demande à l'utilisateur si il souhaite calculer les valeurs du fichier CSV grâce à la fonction LireTexte
                reponseUtilisateurCsv = LireTexteOuiNon("Souhaitez vous calculer le contenu du fichier csv ? (Répondez par oui ou non) : ");

                //Lecture et calcule du fichier.csv grâce à la fonction LireCsv en fonction du choix de l'utilisateur
                CalculerCsv(reponseUtilisateurCsv, cheminFichierCsvLu);

                //Demande à l'utilisateur si il souhaite recommencer
                reponseUtilisateurRecommencer = LireTexteOuiNon("Souhaitez vous recommencer ? (Répondez par oui ou non) : ");

            }
            while (reponseUtilisateurRecommencer == "oui");

            //Affichage du message de fin du programme en fonction de la réponse de l'utilisateur
            Console.Clear();
            AfficherEntete("Lecture et calcule d'un fichier CSV");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fin du programme");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("************************************************************************************************************************");

            //Suppression du message de fin
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ReadKey();
        }

        //Création des fonctions 

        //Fonction AfficherEntete
        private static void AfficherEntete(string messageEntete)
        {
            //Affichage entête
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("************************************************************************************************************************");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine($"{messageEntete,77}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("************************************************************************************************************************");
            Console.WriteLine();
        }

        //Fonction LireCheminAcces
        private static string LireCheminAcces(string message)
        {
            //Déclaration des variables
            string reponseLu;
            bool fichierAccessible;

            //Demande d'une valeur string
            Console.Clear();
            AfficherEntete("Lecture et calcule d'un fichier CSV");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(message);
            reponseLu = Console.ReadLine() ?? "0";
            reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
            Console.WriteLine();

            //Vérification de l'existance du fichier spécifier
            fichierAccessible = File.Exists(reponseLu);

            if (fichierAccessible == false)
            {
                //Vérification de la valeur string lu (Null + oui ou non)
                while (fichierAccessible == false) 
                {
                    Console.Clear();
                    AfficherEntete("Lecture et calcule d'un fichier CSV");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Le chemin spécifié ne correspond à aucun fichier, veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    reponseLu = Console.ReadLine() ?? "0";
                    reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en supprimant les espaces du début et fin
                    fichierAccessible = File.Exists(reponseLu);
                }
            }

            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.Write("Chemin d'accès correcte (Entrée pour continuer) ");
            Console.ReadKey();

            return reponseLu;
        }

        //Fonction LireTexteOuiNon
        private static string LireTexteOuiNon(string message)
        {
            //Déclaration des variables
            string reponseLu;

            //Demande d'une valeur string
            Console.Clear();
            AfficherEntete("Lecture et calcule d'un fichier CSV");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(message);
            reponseLu = Console.ReadLine() ?? "0";
            reponseLu = reponseLu.Trim().ToLower().Replace(" ", ""); //Convertire la réponse de l'utilisateur en minuscule et retirer les espaces 

            //Vérification de la valeur string lu (Null + oui ou non)
            while (reponseLu != "oui" && reponseLu != "non")
            {
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Réponse incorrecte, veuillez répondre par oui ou non : ");
                Console.ForegroundColor= ConsoleColor.Green;
                reponseLu = Console.ReadLine() ?? "0";
                reponseLu = reponseLu.Trim().ToLower().Replace(" ", ""); //Convertire la réponse de l'utilisateur en minuscule et retirer les espaces 
            }

            return reponseLu;
        }

        //Fonction LectureCsv
        private static void LectureCsv(string reponseUtilisateur, string cheminFichierCsv)
        {
            //Exécution ou non en fonction de la réponse de l'utilisateur
            if (reponseUtilisateur == "oui")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Lecture en cours... :");

                //Lecture du fichier CSV avec une boucle For Each
                foreach (string ligne in File.ReadLines(cheminFichierCsv))
                {
                    //Création du tableau et de la séparation pour la lecture
                    string[] colonnes = ligne.Split(';');

                    string hauteur = (colonnes[0]);
                    string rayon = (colonnes[1]);

                    //Affichage du contenu du fichier Csv
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{hauteur,6}{rayon,6}");
                    System.Threading.Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Lecture terminée (Entrée pour continuer) ");
                Console.ReadKey();
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
            }

           
        }

        //Fonction CalculerCsv
        private static void CalculerCsv(string reponseUtilisateur, string cheminFichierCsv )
        {
            //Déclaration des constantes
            const double PI = Math.PI;

            //Déclaration des variables
            double volumeCone;
            int iteration = 0;

            //Exécution ou non en fonction de la réponse de l'utilisateur
            if (reponseUtilisateur == "oui")
            {
                //Lecture du fichier CSV avec une boucle For Each
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Calcule en cours... : ");

                foreach (string ligne in File.ReadLines(cheminFichierCsv).Skip(1))
                {
                    //Stockage du nombre d'itération 
                    iteration += 1;

                    //Création du tableau et de la séparation pour la lecture
                    string[] colonnes = ligne.Split(';');

                    //Conversion des valeur dans le fichier Csv de string à double
                    double hauteur = double.Parse(colonnes[0]);

                    double rayon = double.Parse(colonnes[1]);

                    //Calcule du volume du cône en fonction des données du fichier csv
                    volumeCone = (1.0 / 3.0) * PI * (rayon * rayon) * hauteur;

                    //Affichage des résultats
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{"Volume du Cône,"} {iteration,1} : ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{volumeCone,9:F2}");
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(500);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Calcule terminé (Entrée pour continuer)");
                Console.ReadKey();
                Console.WriteLine();
            }

            
        }
        
    }
}
