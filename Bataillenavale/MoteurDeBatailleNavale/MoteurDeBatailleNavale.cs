namespace MoteurDeBatailleNavale
{
    /// <summary>
    /// Enumration des resultat des tirer de jour 
    /// </summary>
    public enum RésultatDeTir
    {
        Inconnu,
        Raté,
        Touché,
        TouchéCoulé,
        TouchéCouléFinal,
    }
    /// <summary>
    /// Classe représente 
    /// les coordonnées sur une grille de bataille navale 
    ///  utilisée pour localiser la position des sections de navire ainsi qu’à exprimer les 
    /// emplacements des tirs.
    /// </summary>
    public class CoordonnéesDeBatailleNavale
    {
        /// <summary>
        // "Une propriété « Colonne » de type char afin de stocker
        // une valeur comprise entre ‘A’ à 
        // ‘J’ en lecture uniquement(public)"
        // 
        // Pour info :  public char Colone { get; }
        // == private char Colone;
        // == public char colone{ get {return this.Colone;}}
        ///
        /// </summary>
        public char Colone { get; }

        /// <summary>
        /// Une propriété « Ligne » de type byte afin de stocker une valeur de 1 à 10 en lecture 
        /// publique uniquement.
        /// </summary>
        public byte Ligne { get; set; }


        /// <summary>
        /// Le constructeur par défaut
        /// </summary>
        /// <param name="colone"></param>
        /// <param name="ligne"></param>
        public CoordonnéesDeBatailleNavale(char colone, byte ligne)
        {
            List<char> liste = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            if (!(liste.Contains(colone)) || (ligne < 1 && ligne > 10)) 
            { throw new ArgumentOutOfRangeException(); }

            this.Colone = colone;
            this.Ligne = ligne;

        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is CoordonnéesDeBatailleNavale coo)
                {
                    if (this.Colone == coo.Colone && this.Ligne == coo.Ligne)
                    {
                        return true;
                    }

                }
            }
            return false;
        }


        public interface IContratDuJoueurDeBatailleNavale
        {
            public string Pseudo { get; set; }

            public void PréparerLaBataille();
            public CoordonnéesDeBatailleNavale AttaquantChoisirLesCoordonnéesDeTir();

            public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coo);
   

            public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coo, RésultatDeTir result);

        }




    }
}