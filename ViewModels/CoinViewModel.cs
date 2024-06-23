using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoinFlip.Models;
using Microsoft.Maui.Controls;

namespace CoinFlip.ViewModels
{
    public class CoinViewModel : INotifyPropertyChanged
    {
        private string _imageSource;
        private string _resultText;
        private string _selectedChoice;
        private readonly Random _random = new Random();

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ResultText
        {
            get => _resultText;
            set
            {
                if (_resultText != value)
                {
                    _resultText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedChoice
        {
            get => _selectedChoice;
            set
            {
                if (_selectedChoice != value)
                {
                    _selectedChoice = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand FlipCommand { get; }

        public CoinViewModel()
        {
            FlipCommand = new Command(OnFlipCoin);
        }

        private void OnFlipCoin()
        {
            int coin = _random.Next(2);
            string side = coin == 0 ? "cara" : "coroa";
            ImageSource = coin == 0 ? "cara.jfif" : "coroa.jpg";

            if (SelectedChoice == side)
            {
                ResultText = "Você venceu";
            }
            else
            {
                ResultText = "Você perdeu";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
