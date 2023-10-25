using MoteurDeBatailleNavale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoteurDeBatailleNavale.CoordonnéesDeBatailleNavale;

namespace JouerUnePartieDeBatailleNavale
{
    internal class UnJoueurHumainDerrièreLaConsole: IContratDuJoueurDeBatailleNavale

    {
        public UnJoueurHumainDerrièreLaConsole()
        {
            Console.Write("Veuillez Entré votre nom Commandant \n");
            Pseudo = Console.ReadLine()??"Cmd.John Brodau";
        }

        public string Pseudo { get; set; }

        public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coo)
        {
            Console.Write($" votre adversaire a tire en {coo.Colone} {coo.Ligne}\n");
            Console.Write("Veuillez selectionner le resultat de tir\n");
            Console.Write("1=Inconnu \n"+
                         "2=Raté  \n"+
                        "3=Touché \n"+
                        "4=TouchéCoulé \n" +
                        "5=TouchéCouléFinal\n");
            int nb_result = int.Parse(Console.ReadLine() ?? "1");
            while(nb_result < 0 || nb_result> 6)
            {
                Console.Write("Veuillez selectionner le resultat de tir correct\n");
                Console.Write("1=Inconnu \n" +
                             "2=Raté  \n" +
                            "3=Touché \n" +
                            "4=TouchéCoulé \n" +
                            "5=TouchéCouléFinal\n");
                nb_result = int.Parse(Console.ReadLine() ?? "1");

            }
            switch (nb_result)
                {
                case 1:
                    return RésultatDeTir.Inconnu;
                case 2:
                    return RésultatDeTir.Raté ;
                case 3:
                    return RésultatDeTir.Touché;
                case 4:
                    return RésultatDeTir.TouchéCoulé;
                case 5:
                    return RésultatDeTir.TouchéCouléFinal;
                default:
                    return RésultatDeTir.Inconnu;
            }

        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coo, RésultatDeTir result)
        {
            Console.Write($"Vous avez {result} au coordonnée {coo.Colone} {coo.Ligne} ");
            Console.Write("Appuyer sur entré pour continuer ");
            var truc = Console.ReadLine() ?? null;

        }

        public void PréparerLaBataille()
        {
        
        }

        public CoordonnéesDeBatailleNavale AttaquantChoisirLesCoordonnéesDeTir()
        {
            Console.Write("Veuillez Entré Les coordonné de frappe Lattitude/Longitude \n");
            Console.Write("Longitude/ Colonne \n");
            List<char> liste = new List<Char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            bool b = false;
            char col = 'o';
            while (!b)
            {
                if (char.TryParse(Console.ReadLine(), out col) && liste.Contains(char.ToUpper(col))){
                    b = true;
                    Console.Write($"Votre lettre {col}\n");
                   
                    }
                else { Console.Write("Les coordonné ne sont pas correct donner une nouvelle Longitude/ Colonne \n"); }
            }

            Console.Write("Lattitude/ Ligne\n");
            byte ligne = Convert.ToByte(Console.ReadLine());
            while (ligne < 1 || ligne > 10)
            {
                Console.Write("Les coordonné ne sont pas correct donner une nouvelle Lattitude/ Ligne \n ");
                ligne= Convert.ToByte(Console.ReadLine());
            }
            return new CoordonnéesDeBatailleNavale(char.ToUpper(col), ligne);
        }
    }
}
