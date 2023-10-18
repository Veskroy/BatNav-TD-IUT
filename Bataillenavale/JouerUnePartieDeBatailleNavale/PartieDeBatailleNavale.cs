using MoteurDeBatailleNavale;
using static MoteurDeBatailleNavale.CoordonnéesDeBatailleNavale;

namespace JouerUnePartieDeBatailleNavale
{

    public class PartieDeBatailleNavale
    {
      
       public IContratDuJoueurDeBatailleNavale Défenseur { get; private set;} 
       public IContratDuJoueurDeBatailleNavale Attaquant { get; private set;}

        public IContratDuJoueurDeBatailleNavale Joueur1 { get; }
        public IContratDuJoueurDeBatailleNavale Joueur2 { get; }


        public PartieDeBatailleNavale(IContratDuJoueurDeBatailleNavale joueur1 , IContratDuJoueurDeBatailleNavale joueur2 )
        {
            if (joueur1 == null || joueur2== null)
            { throw new ArgumentNullException(); }

            Joueur1 = joueur1;
            Joueur2 = joueur2;

        }

        public IContratDuJoueurDeBatailleNavale GetDefenseur()
        {
            return Défenseur;
        }

        public void ChoisirLesRôlesDeDépartDesJoueurs()
        {
            var random=new Random();

            int valeur=random.Next(0, 100);
            if (valeur <=50)
            {
                Défenseur = Joueur1;
                Attaquant = Joueur2;
            }
            else
            {
                Défenseur = Joueur2;
                Attaquant = Joueur1;

            }

        }

        public void IntervertirLesRôlesDesJoueurs()
        {
            if(Défenseur == Joueur1 || Attaquant == Joueur2)
            {
                Défenseur = Joueur2;
                Attaquant = Joueur1;

            }
            if(Défenseur == Joueur2 || Attaquant == Joueur1)
            {
                Défenseur = Joueur1;
                Attaquant = Joueur2;
            }
        }

        public void PréparerLaBataille()
        {
            Attaquant.PréparerLaBataille();
            Défenseur.PréparerLaBataille();

        }

        public void JouerLaPartie()
        {
            RésultatDeTir result = RésultatDeTir.Inconnu;
            while (result != RésultatDeTir.TouchéCouléFinal)
            {
                IntervertirLesRôlesDesJoueurs();
                CoordonnéesDeBatailleNavale coo =Attaquant.AttaquantChoisirLesCoordonnéesDeTir();
                result = Défenseur.Défenseur_FournirLeRésultatDuTir(coo);
                Attaquant.Attaquant_GérerLeRésultatDuTir(coo,result);
            }
            Console.WriteLine($"Mission succes {Attaquant} it's time to back");
            Console.WriteLine($"{Défenseur} Back to base, We need to talk ");
        }


    }
}


