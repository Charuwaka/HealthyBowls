using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using plant.Models;
using Xamarin.Forms;

namespace plant.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private int count = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Food> _FoodList;
        public ObservableCollection<Food> FoodList
        {
            get { return _FoodList; }
            set { if (value != null) { _FoodList = value;  NotifyPropertyChanged("FoodList"); } }
        }

        private ObservableCollection<Calories> _CaloriesList;
        public ObservableCollection<Calories> CaloriesList
        {
            get { return _CaloriesList; }
            set { if (value != null) { _CaloriesList = value; NotifyPropertyChanged("CaloriesList"); } }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FoodViewModel()
        {
            FoodList = new ObservableCollection<Food>();
            FoodList.Add(new Food { Name = "Salmon bowl", Price = "$24" ,Src="plate1.png"});
            FoodList.Add(new Food { Name = "Spring bowl", Price = "$34", Src = "plate2.png" });
            FoodList.Add(new Food { Name = "Avacado bowl", Price = "$54", Src = "plate3.png" });
            FoodList.Add(new Food { Name = "Berry bowl", Price = "$14", Src = "plate4.png" });
            FoodList.Add(new Food { Name = "Oats bowl", Price = "$51", Src = "plate5.png" });
            FoodList.Add(new Food { Name = "Panner bowl", Price = "$14", Src = "plate6.png" });

            CaloriesList = new ObservableCollection<Calories>();
            CaloriesList.Add(new Calories { Name = "WEIGHT", ValueType = "300G" });
            CaloriesList.Add(new Calories { Name = "CALORIES", ValueType = "240" });
            CaloriesList.Add(new Calories { Name = "VITAMINS", ValueType = "A,B6" });
            CaloriesList.Add(new Calories { Name = "AMINOS", ValueType = "VALINE" });
            CaloriesList.Add(new Calories { Name = "WEIGHT", ValueType = "300G" });
            CaloriesList.Add(new Calories { Name = "CALORIES", ValueType = "240" });
            CaloriesList.Add(new Calories { Name = "VITAMINS", ValueType = "A,B6" });
            CaloriesList.Add(new Calories { Name = "AMINOS", ValueType = "VALINE" });


            Messenger.Default.Register<Food>
            (
                 this,
                 (e) => UpdateCart(e)
            );
        }

        private void UpdateCart(Food e)
        {
            count++;
            CartCount = Convert.ToString(count);

        }

        private string _CartCount;

        public string CartCount

        {

            get { return _CartCount; }

            set { _CartCount = value; NotifyPropertyChanged("CartCount"); }

        }

        private RelayCommand _Checkout;
        public RelayCommand  Checkout
        {
            get
            {
                return _Checkout ??
                    (
                      _Checkout = new RelayCommand
                        (
                            () =>
                            {
                                Application.Current.MainPage.Navigation.PushModalAsync(new DetailsPage());
                            }

                        )
                    );
            }
        }


    }
}

