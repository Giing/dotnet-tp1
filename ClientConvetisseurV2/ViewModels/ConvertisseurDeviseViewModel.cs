using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvetisseurV2.ViewModels
{
    internal class ConvertisseurDeviseViewModel:ConvertisseurViewModel
    {
        protected override double CalculMontant()
        {
            return double.Parse(MontantSource) / SelectedDevise.Taux;
        }
    }
}
