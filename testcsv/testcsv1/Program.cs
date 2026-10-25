using Microsoft.VisualBasic;

namespace testcsv1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Déclaration des variables
            string reponseUtilisateurLecture = "", reponseUtilisateurCalcule = "";

            //Affichage de l'entête grâce à la fonction AfficherEntete
            AfficherEntete("Lecture et calcule d'un fichier CSV");

            //Demande à l'utilisateur si il souhaite lire les valeurs du fichier CSV grâce à la fonction lireTexte
            reponseUtilisateurLecture = LireTexteLecture("Réponse incorrecte, veuillez répondre par oui ou non : ");

            if (reponseUtilisateurLecture == "patrick" || reponseUtilisateurCalcule == "patrick")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fin du programme");

                //Suppression du message de fin
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.ReadKey();
            }
            else
            {
                //Lecture du fichier.csv grâce à la fonction AfficherCsv en fonction du choix de l'utilisateur
                LectureCsv(reponseUtilisateurLecture);

                //Demande à l'utilisateur si il souhaite calculer les valeurs du fichier CSV grâce à la fonction LireTexte
                reponseUtilisateurCalcule = LireTexteCalcule("Réponse incorrecte, veuillez répondre par oui ou non : ");

                //Lecture et calcule du fichier.csv grâce à la fonction LireCsv en fonction du choix de l'utilisateur
                CalculerCsv(reponseUtilisateurCalcule);




                //Affichage du message de fin du programme en fonction de la réponse de l'utilisateur
                if (reponseUtilisateurCalcule == "oui" || reponseUtilisateurCalcule == "non")
                {
                    Console.Clear();
                    AfficherEntete("Lecture et calcule d'un fichier CSV");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fin du programme");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("********************************************************************************");

                }

            //Suppression du message de fin
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ReadKey();
            }
        }

        //Création de la fonction AfficherEntete
        private static void AfficherEntete(string messageEntete)
        {
            //Affichage entête
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("********************************************************************************");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine($"{messageEntete,57}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
        }

        //Création de la fonction LireTexteCalcule
        private static string LireTexteCalcule(string messageErreur)
        {
            //Déclaration des variables
            string reponseLu;

            //Demande d'une valeur string
            Console.Clear();
            AfficherEntete("Lecture et calcule d'un fichier CSV");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Souhaitez vous calculer le fichier csv, (répondez par oui ou non) : ");
            reponseLu = Console.ReadLine() ?? "0";

            //Vérification de la valeur string lu (Null + min 3 charactères)
            if (reponseLu == "patrick")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("LES SOCIALOS NE SONT PAS ACCEPTÉS, veuillez foutre le camps");
            }
            else
            {
                while (reponseLu != "oui" && reponseLu != "non")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(messageErreur);
                    reponseLu = Console.ReadLine() ?? "0";
                }
            }

            return reponseLu;
        }

        //Création de la fonction LireTexteLecture
        private static string LireTexteLecture(string messageErreur)
        {
            //Déclaration des variables
            string reponseLu;

            //Demande d'une valeur string
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Souhaitez vous lire le contenu du fichier csv, (répondez par oui ou non) : ");
            reponseLu = Console.ReadLine() ?? "0";

            //Vérification de la valeur string lu (Null + min 3 charactères)
            if (reponseLu == "patrick")
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("LES SOCIALOS NE SONT PAS ACCEPTÉS, veuillez foutre le camps");
            }
            else
            {
                while (reponseLu != "oui" && reponseLu != "non")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(messageErreur);
                    reponseLu = Console.ReadLine() ?? "0";
                }
            }

            Console.WriteLine();
            return reponseLu;
        }

        //Création de la fonction CalculerCsv
        private static void CalculerCsv(string reponseUtilisateur)
        {
            //Déclaration des constantes
            const double PI = Math.PI;

            //Déclaration des variables
            string cheminFichierCsv = @"C:\Users\matis\Documents\Informatique\Programmation\C#\Visual Studio\ProjetPerso\LectureFichierCSV\hauteur_diametre.csv";
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
                    System.Threading.Thread.Sleep(1000);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Calcule terminé (Entrée pour continuer)");
                Console.ReadKey();
                Console.WriteLine();
            }

            
        }
        //Création de la fonction LectureCsv
        private static void LectureCsv(string reponseUtilisateur)
        {
            //Déclaration des variables
            string cheminFichierCsv = @"C:\Users\matis\Documents\Informatique\Programmation\C#\Visual Studio\ProjetPerso\LectureFichierCSV\hauteur_diametre.csv";


            //Exécution ou non en fonction de la réponse de l'utilisateur
            if (reponseUtilisateur == "oui")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
                Console.ForegroundColor= ConsoleColor.DarkGreen;
                Console.WriteLine("Lecture en cours... :");

                //Lecture du fichier CSV avec une boucle For Each
                foreach (string ligne in File.ReadLines(cheminFichierCsv))
                {
                    //Création du tableau et de la séparation pour la lecture
                    string[] colonnes = ligne.Split(';');

                    string hauteur = (colonnes[0]);
                    string rayon = (colonnes[1]);

                    //Affichage du contenu du fichier Csv
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine($"{hauteur,6}{rayon,6}");
                    System.Threading.Thread.Sleep(1000);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Lecture terminée (Entrée pour continuer)");
                Console.ReadKey();
                Console.Clear();
                AfficherEntete("Lecture et calcule d'un fichier CSV");
            }
        }
    }
}
