using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvetisseurV2.Models
{
    internal class Devise
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
    }
}
