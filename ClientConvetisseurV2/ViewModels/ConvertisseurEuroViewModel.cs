using ClientConvetisseurV2.Models;
using ClientConvetisseurV2.Services;
using ClientConvetisseurV2.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;

namespace ClientConvetisseurV2.ViewModels
{
	internal class ConvertisseurEuroViewModel : ConvertisseurViewModel
    {
		protected override double CalculMontant()
		{
			return double.Parse(MontantSource) * SelectedDevise.Taux;
		}
    }
}
