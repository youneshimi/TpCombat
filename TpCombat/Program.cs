using System;

class Personnage
{
    public string Nom { get; set; }
    public int PointsDeVie { get; set; }
    public int PointsAttaque { get; set; }
    public int PointsDefense { get; set; }
    public int PointsAgilite { get; set; }
    public int PointsPotionMagique { get; set; }

    public Personnage(string nom, int pointsDeVie, int pointsAttaque, int pointsDefense, int pointsAgilite, int pointsPotionMagique)
    {
        Nom = nom;
        PointsDeVie = pointsDeVie;
        PointsAttaque = pointsAttaque;
        PointsDefense = pointsDefense;
        PointsAgilite = pointsAgilite;
        PointsPotionMagique = pointsPotionMagique;
    }

    // Méthodes d'actions (à implémenter)
    public void Attaquer(Ennemi ennemi)
    {
        // Logique d'attaque
    }

    public void UtiliserPotionMagique()
    {
        // Logique d'utilisation de potion magique
    }

    public bool Fuir()
    {
        // Logique de fuite
        return false;
    }
}

class Ennemi
{
    public string Nom { get; set; }
    public int PointsDeVie { get; set; }
    public int PointsAttaque { get; set; }
    public int PointsDefense { get; set; }
    public int PointsAgilite { get; set; }

    public Ennemi(string nom, int pointsDeVie, int pointsAttaque, int pointsDefense, int pointsAgilite)
    {
        Nom = nom;
        PointsDeVie = pointsDeVie;
        PointsAttaque = pointsAttaque;
        PointsDefense = pointsDefense;
        PointsAgilite = pointsAgilite;
    }
}

class Program
{
    static void Main()
    {
        // Initialisation du jeu
        Console.WriteLine("Bienvenue dans le jeu de combat de personnages !");

        // Création du personnage du joueur
        Console.WriteLine("Choisissez votre personnage :");
        Console.WriteLine("1. Guerrier");
        Console.WriteLine("2. Archer");
        Console.WriteLine("3. Magicien");
        int choixPersonnage = int.Parse(Console.ReadLine());

        Personnage joueur;
        string nomJoueur;

        switch (choixPersonnage)
        {
            case 1:
                joueur = new Personnage("Guerrier", 500, 50, 80, 10, 0);
                break;
            case 2:
                joueur = new Personnage("Archer", 350, 90, 30, 50, 0);
                break;
            case 3:
                joueur = new Personnage("Magicien", 600, 20, 50, 25, 200);
                break;
            default:
                joueur = new Personnage("Inconnu", 0, 0, 0, 0, 0);
                break;
        }

        Console.Write("Donnez un nom à votre personnage : ");
        nomJoueur = Console.ReadLine();
        joueur.Nom = nomJoueur;

        // Création de l'ennemi (génération aléatoire)
        Random random = new Random();
        int choixEnnemi = random.Next(1, 4);
        Ennemi ennemi;

        switch (choixEnnemi)
        {
            case 1:
                ennemi = new Ennemi("Orque", 400, 40, 70, 20);
                break;
            case 2:
                ennemi = new Ennemi("Loup", 300, 30, 15, 40);
                break;
            case 3:
                ennemi = new Ennemi("Zombi", 600, 15, 15, 5);
                break;
            default:
                ennemi = new Ennemi("Inconnu", 0, 0, 0, 0);
                break;
        }

        Console.WriteLine($"Votre adversaire sera un {ennemi.Nom}.");

        Console.WriteLine("La bataille commence !");
        Console.WriteLine($"{joueur.Nom} ({joueur.PointsDeVie} PV, {joueur.PointsPotionMagique} PM) vs {ennemi.Nom} ({ennemi.PointsDeVie} PV)");

        // Boucle de jeu principale
        while (joueur.PointsDeVie > 0 && ennemi.PointsDeVie > 0)
        {
            Console.WriteLine("\nNouveau tour :");

            // Actions du joueur
            Console.WriteLine("Choisissez une action :");
            Console.WriteLine("1. Attaquer");
            Console.WriteLine("2. Fuir");
            Console.WriteLine("3. Utiliser une potion magique");

            int choixAction = int.Parse(Console.ReadLine());

            switch (choixAction)
            {
                case 1:
                    joueur.Attaquer(ennemi);
                    break;
                case 2:
                    bool fuiteReussie = joueur.Fuir();
                    if (fuiteReussie)
                    {
                        Console.WriteLine("Vous avez réussi à fuir ! La partie est terminée.");
                        return;
                    }
                    break;
                case 3:
                    if (joueur.PointsPotionMagique >= 50)
                    {
                        joueur.UtiliserPotionMagique();
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas assez de potion magique pour vous soigner.");
                    }
                    break;
                default:
                    Console.WriteLine("Action non reconnue.");
                    break;
            }

            // Action de l'ennemi (simplement une attaque dans cet exemple)
            int degatsEnnemi = random.Next(ennemi.PointsAttaque / 2, ennemi.PointsAttaque);
            int defenseJoueur = joueur.PointsDefense / 5;
            int degatsReels = Math.Max(0, degatsEnnemi - defenseJoueur);
            joueur.PointsDeVie -= degatsReels;

            // Affichage de l'état du jeu
            Console.WriteLine($"{joueur.Nom} ({joueur.PointsDeVie} PV, {joueur.PointsPotionMagique} PM) vs {ennemi.Nom} ({ennemi.PointsDeVie} PV)");
        }


        // Fin de la partie
        if (joueur.PointsDeVie <= 0)
        {
            Console.WriteLine("Vous avez perdu !");
        }
        else
        {
            Console.WriteLine("Vous avez gagné !");
        }

        Console.WriteLine("Merci d'avoir joué !");
    }
}
