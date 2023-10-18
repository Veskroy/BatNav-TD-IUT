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
            Console.Write("Veuillez Entré votre nom Commandant");
            Pseudo = Console.ReadLine()??"Cmd.John Brodau";
        }

        public string Pseudo { get; set; }

        public CoordonnéesDeBatailleNavale AttaquantChoisirLesCoordonnéesDeTir()
        {
            throw new NotImplementedException();
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coo, RésultatDeTir result)
        {
            throw new NotImplementedException();
        }

        public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coo)
        {
            throw new NotImplementedException();
        }

        public void PréparerLaBataille()
        {
            throw new NotImplementedException();
        }


        public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            Console.Write("Veuillez Entré Les coordonné de frappe Lattitude/Longitude");
            Console.Write("Longitude/ Colonne");
            char col = char.Parse(Console.ReadLine()??"A");
            Console.Write("Lattitude/ Ligne");
            byte ligne =byte.Parse(Console.ReadLine()??"1");
            return new CoordonnéesDeBatailleNavale(col, ligne);


        }

    }
}
