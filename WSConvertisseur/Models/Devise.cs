using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Devise
    {
		private int id;
        /// <summary>
        /// Identifier of the devise
        /// </summary>
        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string? nom;

        /// <summary>
        /// Name of the devise
        /// </summary>
        [Required]
		public string? Nom
		{
			get { return nom; }
			set { nom = value; }
		}

		private double taux;
        /// <summary>
        /// Taux of the devise
        /// </summary>
        public double Taux
		{
			get { return taux; }
			set { taux = value; }
		}

        /// <summary>
        /// Base constructor of the devise
        /// </summary>
        public Devise()
		{

		}

        /// <summary>
        /// Augmented constructor of the devise
        /// </summary>
        public Devise(int id, string nom, double taux)
		{
			this.Id = id;
			this.Nom = nom;	
			this.Taux = taux;
		}

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Devise d = (Devise)obj;
            return (Id == d.Id) && (Nom == d.Nom) && (Taux == d.Taux);    
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
	}
}
