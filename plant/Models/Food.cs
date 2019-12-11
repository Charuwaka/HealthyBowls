using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace plant.Models
{
    public class Food 
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Src { get; set; }

        private RelayCommand<Food> _AddToCart;
        public RelayCommand<Food> AddToCart
        {
            get
            {
                return _AddToCart ??
                    (
                      _AddToCart = new RelayCommand<Food>
                        (
                            (e) =>
                            {
                                if (e != null)
                                {
                                    Messenger.Default.Send<Food>(this);
                                }
                            }

                        )
                    );
            }
        }
    }
}

