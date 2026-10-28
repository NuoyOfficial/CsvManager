namespace CSV_MANAGERV1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Déclaration des constantes
            const string MESSAGE_LIRE_CHOIX = "Votre choix : ";

            //Déclaration des variables
            string choixUtilisateurMenuPrincipal = "", choixUtilisateurMenuFichier = "", cheminFichierLu;

            do
            {
                //Menu Principale
                //Affichage de l'entête du menu grâce à la fonction EnteteMenuPrincipal et demande le choix à l'utilisateur entre 1 et 4
                EnteteMenuPrincipal();
                choixUtilisateurMenuPrincipal = LireChoixMenuPrincipal(MESSAGE_LIRE_CHOIX);

                //Action en fonction du choix de l'utilisateur

                //Menu fichier choisi (Option 2 ou 3)
                if (choixUtilisateurMenuPrincipal == "2" || choixUtilisateurMenuPrincipal == "3")
                {
                    do
                    {
                        //L'utilisateur souhaite ouvrir un nouveau fichier
                        if (choixUtilisateurMenuPrincipal == "2")
                        {
                            //Demande à l'utilisateur le chemin du fichier à ouvrir et vérifier si tout est correcte grâce à la fonction LireCheminAcces
                            cheminFichierLu = LireCheminAcces("Veuillez spécifier le chemin d'accès du fichier : ");

                            //Affichage du Menu Fichier
                            EnteteMenuFichier(cheminFichierLu);

                            //Demande à l'utilisateur son choix de 1 à 8
                            choixUtilisateurMenuFichier = LireChoixMenuFichier(MESSAGE_LIRE_CHOIX, cheminFichierLu);

                            //L'utilisateur souhaite lire le contenue du fichier
                            if (choixUtilisateurMenuFichier == "1")
                            {
                                //Tant que l'utilisateur ne choisi pas une autre option, lire le contenue continuera
                                while (choixUtilisateurMenuFichier == "1")
                                {
                                    //Lecture du fichier fourni par l'utilisateur
                                    LectureCsv(cheminFichierLu);
                                    choixUtilisateurMenuFichier = LireChoixMenuFichier(MESSAGE_LIRE_CHOIX, cheminFichierLu);

                                }
                                
                            }


                        }
                    }
                    //Tant que l'utilisateur ne décide pas de revenir au menu principal
                    while (choixUtilisateurMenuFichier != "8");

                }

            }
            //tant que l'utilisateur ne décide pas de quitter le programme
            while (choixUtilisateurMenuPrincipal != "4");

            //Suppression du message de fin
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        //Création des fonctions : 

        //Fonction EnteteMenuPrincipal
        private static void EnteteMenuPrincipal()
        {
            //Affichage de l'entête et des choix pour l'utilisateur
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"{"Csv Manager",29}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Crée un nouveau fichier");
            Console.WriteLine("2. Ouvrir un nouveau fichier");
            Console.WriteLine("3. Ouvrir un fichier sauvegardé");
            Console.WriteLine("4. Quitter");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();

        }

        //Fonction EnteteMenuFichier
        private static void EnteteMenuFichier(string cheminFichier)
        {
            //Déclaration des variables
            string nomFichier;

            //Récupération du nom du fichier
            nomFichier = Path.GetFileName(cheminFichier);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($" {"Fichier actuel : "}{nomFichier}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Afficher le contenu ");
            Console.WriteLine("2. Ajouter une ligne");
            Console.WriteLine("3. Supprimer une ligne");
            Console.WriteLine("4. Modifier une ligne");
            Console.WriteLine("5. sauvegarder");
            Console.WriteLine("6. Exporter une copie");
            Console.WriteLine("7. supprimer le fichier");
            Console.WriteLine("8. Retour au menu principal");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Fonction LireChoixMenuPrincipal
        private static string LireChoixMenuPrincipal(string message)
        {
            //Déclaration des variables
            string choixLu;

            //Demande à l'utilisateur son choix et vérification de celui-ci
            Console.Clear();
            EnteteMenuPrincipal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor= ConsoleColor.White;
            choixLu = Console.ReadLine() ?? "0";
            choixLu = choixLu.Trim();

            //Redemande à l'utilisateur tant que sa réponse n'est pas correcte
            while (choixLu != "1" && choixLu != "2" && choixLu != "3" && choixLu != "4")
            {
                Console.Clear();
                EnteteMenuPrincipal();
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write("Erreur : Veuillez entrer une valeur comprise entre 1-4 : ");
                Console.ForegroundColor=ConsoleColor.White;
                choixLu = Console.ReadLine() ?? "0";
                choixLu= choixLu.Trim();
                Console.ResetColor();
            }

            return choixLu;

        }

        //Fonction LireChoixMenuFichier
        private static string LireChoixMenuFichier(string message, string cheminFichier)
        {
            //Déclaration des variables
            string choixLu, nomFichier;

            //Récupération du nom du fichier
            nomFichier = Path.GetFileName(cheminFichier);

            //Demande à l'utilisateur son choix et vérification de celui-ci
            Console.Clear();
            EnteteMenuFichier(nomFichier);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White; 
            choixLu = Console.ReadLine() ?? "0";
            choixLu = choixLu.Trim();

            //Redemande à l'utilisateur tant que sa réponse n'est pas correcte
            while (choixLu != "1" && choixLu != "2" && choixLu != "3" && choixLu != "4" && choixLu != "5" && choixLu != "6" && choixLu != "7" && choixLu != "8")
            {
                Console.Clear();
                EnteteMenuFichier(nomFichier);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erreur : Veuillez entrer une valeur comprise entre 1-8 : ");
                Console.ForegroundColor = ConsoleColor.White;
                choixLu = Console.ReadLine() ?? "0";
                choixLu = choixLu.Trim();
                Console.ResetColor();
            }

            return choixLu;

        }

        //Fonction LireCheminAcces
        private static string LireCheminAcces(string message)
        {
            //Déclaration des variables
            string reponseLu;
            bool fichierExiste, fichierCsv, fichierLisible, fichierCorrecte = false, contenuFichierCsv;

            //Demande d'une valeur string
            Console.Clear();
            EnteteMenuPrincipal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            reponseLu = Console.ReadLine() ?? "0";
            reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
            Console.WriteLine();

            //Vérification de l'existance du fichier spécifier, si il termine avec le .csv, si il est lisible, si son contenue est correcte et si l'utilisateur à l'autorisation 
            fichierExiste = File.Exists(reponseLu);
            fichierCsv = reponseLu.EndsWith(".csv", StringComparison.OrdinalIgnoreCase); //Vérifie si le fichier et en .csv et compare du texte sans tenir compte des majuscules et des minuscules.
            fichierLisible = VerifierLisibiliteFichier(reponseLu); //Vérifie si le fichier est lisible et si l'utilisateur posséde les droits de l'ouvrir
            contenuFichierCsv = VerifierContenuFichier(reponseLu);

            while (fichierCorrecte == false)
            {
                //Vérification de l'existance du fichier spécifier, si il termine avec le .csv, si il est lisible, si son contenue est correcte et si l'utilisateur à l'autorisation
                fichierExiste = File.Exists(reponseLu);
                fichierCsv = reponseLu.EndsWith(".csv", StringComparison.OrdinalIgnoreCase); //permet de comparer du texte sans tenir compte des majuscules et des minuscules.
                fichierLisible = VerifierLisibiliteFichier(reponseLu); //Vérifie si le fichier est lisible et si l'utilisateur posséde les droits de l'ouvrir
                contenuFichierCsv = VerifierContenuFichier(reponseLu);

                if (fichierExiste == false)
                {
                    Console.Clear();
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Le chemin spécifié ne correspond à aucun fichier existant. Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    reponseLu = Console.ReadLine() ?? "0";
                    reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en supprimant les espaces du début et fin
                    
                }

                else if (fichierCsv == false)
                {
                    Console.Clear();
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Le fichier spécifié ne possède pas l'extension .csv. Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    reponseLu = Console.ReadLine() ?? "0";
                    reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en supprimant les espaces du début et fin
           
                }

                else if (fichierLisible == false)
                {
                    Console.Clear();
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Impossible d'ouvrir ce fichier en lecture. Vérifiez vos droits d'accès et réessayez : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    reponseLu = Console.ReadLine() ?? "0";
                    reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en supprimant les espaces du début et fin

                }

                else if (contenuFichierCsv == false)
                {
                    Console.Clear();
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Le fichier spécifier est vide ou ne contient pas de csv. Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    reponseLu = Console.ReadLine() ?? "0";
                    reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en supprimant les espaces du début et fin

                }

                else
                    fichierCorrecte = true;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Fichier trouvé. Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

            return reponseLu;
        }

        //Fonction VerifierLisibiliteFichier
        private static bool VerifierLisibiliteFichier(string cheminFichier)
        {
            try
            {
                using (FileStream fichier = File.OpenRead(cheminFichier))
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }

        }

        //Fonction VerifierContenuFichier
        private static bool VerifierContenuFichier(string cheminFichier)
        {
            try
            {
                return File.ReadLines(cheminFichier).Any(ligne => !string.IsNullOrWhiteSpace(ligne));
            }
            catch
            {
                return false;
            }
        }

        //Fonction LectureCsv
        private static void LectureCsv(string cheminFichier)
        {
            //Déclaration des variables
            string nomFichier;

            //Récupération du nom du fichier
            nomFichier = Path.GetFileName(cheminFichier);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            EnteteMenuFichier(nomFichier);

            //Lecture du fichier CSV avec une boucle For Each
            foreach (string ligne in File.ReadLines(cheminFichier)) //Lis toutes les lignes jusqu'à ce qu'il n'y en est plus 
            {
                //Création du tableau et de la séparation pour la lecture
                string[] colonnes = ligne.Split(';');

                //Affichage du contenu du fichier Csv
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int i = 0; i < colonnes.Length; i++) //tant qu'il reste des colonnes, cette boucle affiche le contenue
                {

                    Console.Write($"{colonnes[i],-10}");

                }

                Console.WriteLine();

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}
