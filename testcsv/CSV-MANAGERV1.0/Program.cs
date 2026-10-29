namespace CSV_MANAGERV1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Déclaration des constantes
            const string MESSAGE_LIRE_CHOIX = "Votre choix : ";

            //Déclaration des variables
            string choixUtilisateurMenuPrincipal = "", choixUtilisateurMenuFichier = "", FichierLu, CheminFichierLu;

            do
            {
                //Menu Principale
                //Affichage de l'entête du menu grâce à la fonction EnteteMenuPrincipal et demande le choix à l'utilisateur entre 1 et 4
                EnteteMenuPrincipal();
                choixUtilisateurMenuPrincipal = LireChoixMenuPrincipal(MESSAGE_LIRE_CHOIX);

                //Action en fonction du choix de l'utilisateur

                //Option 1 choisi du Menu Principal (Créer un nouveau fichier) - Reste dans le Menu Principal
                if (choixUtilisateurMenuPrincipal == "1")
                {

                    CheminFichierLu = LireCheminFichier("Veuillez spécifier le répertoire où le fichier sera créé : ");
                    CreeFichierCsv(CheminFichierLu, "Veuillez spécifier le nom du fichier : ");

                }

                //Option 2 choisi du Menu Principal (Ouvrir nouveau fichier) - Ouvre le Menu Fichier
                if (choixUtilisateurMenuPrincipal == "2")
                {
                    //Demande à l'utilisateur le chemin du fichier à ouvrir et vérifier si tout est correcte grâce à la fonction LireCheminAcces
                    FichierLu = LireFichier("Veuillez spécifier le chemin d'accès du fichier : ");

                    do
                    {
                        //Affichage du Menu Fichier
                        EnteteMenuFichier(FichierLu);

                        //Demande à l'utilisateur son choix de 1 à 9
                        choixUtilisateurMenuFichier = LireChoixMenuFichier(MESSAGE_LIRE_CHOIX, FichierLu);

                        //Option 1 Choisi du Menu Fichier (Lire le contenue du fichier)
                        if (choixUtilisateurMenuFichier == "1")
                        {
                            //Lecture du fichier fourni par l'utilisateur
                            LectureCsv(FichierLu);

                        }

                        //Option 2 Choisi du Menu Fichier (Ajouter une ligne dans le csv)
                        if (choixUtilisateurMenuFichier == "2")
                        {
                            AjouterLigneCsv("");
                        }



                    }
                    //Tant que l'utilisateur ne décide pas de revenir au menu principal (Option 9)
                    while (choixUtilisateurMenuFichier != "9");

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
            Console.WriteLine($"{"CSV-MANAGER V1.0",30}");
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
            Console.WriteLine("5. Sauvegarder");
            Console.WriteLine("6. Exporter une copie");
            Console.WriteLine("7. Supprimer le fichier");
            Console.WriteLine("8. Renommer le fichier") ;
            Console.WriteLine("9. Retour au menu principal");
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
        private static string LireChoixMenuFichier(string message, string Fichier)
        {
            //Déclaration des variables
            string choixLu, nomFichier;

            //Récupération du nom du fichier
            nomFichier = Path.GetFileName(Fichier);

            //Demande à l'utilisateur son choix et vérification de celui-ci
            Console.Clear();
            EnteteMenuFichier(nomFichier);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White; 
            choixLu = Console.ReadLine() ?? "0";
            choixLu = choixLu.Trim();

            //Redemande à l'utilisateur tant que sa réponse n'est pas correcte
            while (choixLu != "1" && choixLu != "2" && choixLu != "3" && choixLu != "4" && choixLu != "5" && choixLu != "6" && choixLu != "7" && choixLu != "8" && choixLu != "9")
            {
                Console.Clear();
                EnteteMenuFichier(nomFichier);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erreur : Veuillez entrer une valeur comprise entre 1-9 : ");
                Console.ForegroundColor = ConsoleColor.White;
                choixLu = Console.ReadLine() ?? "0";
                choixLu = choixLu.Trim();
                Console.ResetColor();
            }

            return choixLu;

        }

        //Fonction LireFichier
        private static string LireFichier(string message)
        {
            //Déclaration des variables
            string reponseLu;
            bool fichierExiste, fichierCsv, fichierLisible, fichierCorrecte = false ;

            //Demande d'une valeur string
            Console.Clear();
            EnteteMenuPrincipal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            reponseLu = Console.ReadLine() ?? "0";
            reponseLu = reponseLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
            Console.WriteLine();

            while (fichierCorrecte == false)
            {
                //Vérification de l'existance du fichier spécifier, si il termine avec le .csv, si il est lisible, si son contenue est correcte et si l'utilisateur à l'autorisation
                fichierExiste = File.Exists(reponseLu);
                fichierCsv = reponseLu.EndsWith(".csv", StringComparison.OrdinalIgnoreCase); //permet de comparer du texte sans tenir compte des majuscules et des minuscules.
                fichierLisible = VerifierLisibiliteFichier(reponseLu); //Vérifie si le fichier est lisible et si l'utilisateur posséde les droits de l'ouvrir

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

                else
                {

                    fichierCorrecte = true;

                }
                    
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Fichier trouvé. Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

            return reponseLu;
        }

        //Fonction LireCheminFichier
        private static string LireCheminFichier(string message)
        {
            //Déclaration des variables
            string cheminLu;
            bool cheminCorrecte = false, dossierExiste, testCheminFichierLu;

            //Demande le chemin d'accès à l'utilisateur
            EnteteMenuPrincipal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            cheminLu = Console.ReadLine() ?? "0";
            cheminLu = cheminLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin

            while (cheminCorrecte == false)
            {

                //Vérifie si le chemin est valide
                testCheminFichierLu = TestCheminFichierLu(cheminLu);
                dossierExiste = Directory.Exists(cheminLu);


                //Vérifie si le chemin est valide
                if (testCheminFichierLu == false)
                {
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Votre répertoire est invalide. Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    cheminLu = Console.ReadLine() ?? "0";
                    cheminLu = cheminLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
                }

                else if (dossierExiste == false)
                {
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Le répertoire spécifier n'éxiste pas. Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    cheminLu = Console.ReadLine() ?? "0";
                    cheminLu = cheminLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
                }

                else
                {
                    cheminCorrecte = true;
                }

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Dossier trouvé. Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

            return cheminLu ;
        }

        //Fonction LireNomFichier
        private static string LireNomFichier(string message, string cheminFichier)
        {
            //Déclaration des variables
            string nomLu, cheminComplet;
            bool nomFichierCorrecte = false, fichierExiste, extensionCorrecte;

            //Demande le nom du fichier à l'utilisateur
            EnteteMenuPrincipal();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            nomLu = Console.ReadLine() ?? "0";
            nomLu = nomLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
            cheminComplet = Path.Combine(cheminFichier, nomLu); //Combine le dossier plus le nom du fichier

            while (nomFichierCorrecte == false)
            {
                try
                {
                    fichierExiste = File.Exists(cheminComplet);
                    extensionCorrecte = cheminComplet.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);

                    //Vérifie si le nom est valide
                    if (fichierExiste == true)
                    {

                        EnteteMenuPrincipal();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Erreur : Un fichier existe déjà avec ce nom. Veuillez réessayer : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        nomLu = Console.ReadLine() ?? "0";
                        nomLu = nomLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
                        cheminComplet = Path.Combine(cheminFichier, nomLu); //Combine le dossier plus le nom du fichier

                    }

                    else if (extensionCorrecte == false)
                    {
                        EnteteMenuPrincipal();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Erreur : Le nom spécifier ne possède pas l'extension.csv . Veuillez réessayer : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        nomLu = Console.ReadLine() ?? "0";
                        nomLu = nomLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
                        cheminComplet = Path.Combine(cheminFichier, nomLu); //Combine le dossier plus le nom du fichier
                    }

                    else
                    {
                        nomFichierCorrecte = true;
                    }
                }
                catch (Exception)
                {
                    EnteteMenuPrincipal();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Erreur : Votre nom est incorrecte . Veuillez réessayer : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    nomLu = Console.ReadLine() ?? "0";
                    nomLu = nomLu.Trim(); //Convertire la réponse de l'utilisateur en retirant les espaces du début et fin
                    cheminComplet = Path.Combine(cheminFichier, nomLu); //Combine le dossier plus le nom du fichier
                }
                



            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nom valide. Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

            return nomLu;
        }

        //Fonction TestFichierCorrecteLu
        private static bool TestCheminFichierLu(string cheminFichier)
        {
            //Déclaration des variables
            string cheminFichierCorrecte;

            try
            {
                cheminFichierCorrecte = Path.GetFullPath(cheminFichier);

                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
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
            bool contenuFichierCsv;

            //Récupération du nom du fichier
            nomFichier = Path.GetFileName(cheminFichier);

            contenuFichierCsv = VerifierContenuFichier(cheminFichier); 

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            EnteteMenuFichier(nomFichier);

            if (contenuFichierCsv == false)
            {
                Console.WriteLine("Le fichier csv est vide");
            }
            else
            {
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
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Appuyez sur Entrée pour continuer.");
            Console.ResetColor();
            Console.ReadKey();

        }

        //Fonction CreeFichierCsv
        private static void CreeFichierCsv(string cheminFichier, string message)
        {
            //Déclaration des variables
            string nomFichier, cheminComplet, nomRepertoire;

            //Demande à l'utilisateur un nom pour le fichier
            nomFichier = LireNomFichier(message, cheminFichier);

            cheminComplet = Path.Combine(cheminFichier, nomFichier);

            nomRepertoire = Path.GetFileName(Path.GetDirectoryName(cheminComplet)) ?? "0"; //Récupération du nom du répétoire utilisé

            //Essaye de crée le fichier, si erreur, renvoi message erreur
            try
            {
                //Création du fichier Csv avec les information founis par l'utilisateur
                using (FileStream fichierCsv = new FileStream(cheminComplet, FileMode.CreateNew))
                {
                }

                EnteteMenuPrincipal();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Création de");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {nomFichier} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("vers");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {nomRepertoire} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("réussi. Appuyez sur Entrée pour continuer.");
                Console.ResetColor();
                Console.ReadKey();

            }
            catch (Exception)
            {

                EnteteMenuPrincipal();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Erreur : Un problème est survenu lors de la création de");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {nomFichier} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("vers");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {nomRepertoire} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("(Vérifiez l'absences de charactères spéciaux). Appuyez sur Entrée pour continuer.");
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        //Fonction AjouterLigneCsv
        private static void AjouterLigneCsv(string message)
        {

        }
    }
}
