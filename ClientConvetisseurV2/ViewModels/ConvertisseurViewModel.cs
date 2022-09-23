using ClientConvetisseurV2.Models;
using ClientConvetisseurV2.Services;
using ClientConvetisseurV2.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvetisseurV2.ViewModels
{
    internal abstract class ConvertisseurViewModel:ObservableObject
    {
        private ObservableCollection<Devise> devises;
        public IRelayCommand BtnSetConversion { get; }
        private string montantSource;
        private Devise selectedDevise;
        private string montantTarget;

        public Devise SelectedDevise
        {
            get
            {
                return selectedDevise;
            }
            set
            {
                selectedDevise = value;
                OnPropertyChanged();
            }
        }
        public string MontantSource
        {
            get
            {
                return montantSource;
            }
            set
            {
                montantSource = value;
                OnPropertyChanged();
            }
        }

        public string MontantTarget
        {
            get
            {
                return montantTarget;
            }
            set
            {
                montantTarget = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set
            {
                devises = value;
                OnPropertyChanged();
            }
        }

        public ConvertisseurViewModel()
        {
            ActionGetData();
            this.BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private async void ActionGetData()
        {
            var result = await WSService.GetInstance().GetAllDevisesAsync();
            Devises = new ObservableCollection<Devise>(result);
        }

        private async void ActionSetConversion()
        {
            if (SelectedDevise == null || MontantSource == null)
            {
                await Dialog.DisplayDialogAsync("Conversion impossible", "Veuillez saisir une devise et un montant", "Ok");
                return;
            }

            double result = 0;

            if (!double.TryParse(MontantSource, out result))
            {
                await Dialog.DisplayDialogAsync("Conversion impossible", "Le montant saisi n'est pas un nombre", "Ok");
                return;
            }
            else
            {
                result = CalculMontant();
                MontantTarget = result.ToString();
            }

        }

        protected abstract double CalculMontant();
    }
}
