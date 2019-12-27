using AppMeal.Models;
using AppMeal.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppMeal.ViewModels
{
    public class MealViewModel: BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Meal> meal;
        #endregion

        #region Properties
        public ObservableCollection<Meal> Meal
        {
            get { return this.meal; }
            set { SetValue(ref this.meal, value); }
        }
        #endregion
        #region Constructor
        public MealViewModel()
        {
            this.apiService = new ApiService();
            this.LoadMeal();
        }

        #endregion
        #region Methods
        private async void LoadMeal()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet Error Connection",
                    connection.Message,
                    "Accept"
                    );
                return;
            }
            var response = await apiService.GetList<Meal>(
                "http://localhost:54700/",
                "api/",
                "Meal"
                );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Contacts Service Error",
                    response.Message,
                    "Accept"
                    );
                return;
            }
            MainViewModel main = MainViewModel.GetInstance();
            main.ListMeal = (List<Meal>)response.Result;
            this.Meal = new ObservableCollection<Meal>(ToMealCollect());
        }

        private IEnumerable<Meal> ToMealCollect()
        {
            ObservableCollection<Meal> collection = new ObservableCollection<Meal>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListMeal)
            {
                Meal meal = new Meal();
                meal.FoodID = lista.FoodID;
                meal.Food = lista.Food;
                meal.Drink = lista.Drink;
                meal.Accompaniment = lista.Accompaniment;
                meal.Extra = lista.Extra;
                collection.Add(meal);
            }
            return (collection);
        }
        #endregion

    }
}