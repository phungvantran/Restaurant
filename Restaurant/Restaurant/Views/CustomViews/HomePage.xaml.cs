using Restaurant.Persistence;
using Restaurant.Services;
using Restaurant.ViewModels;
using Restaurant.ViewModels.CustomViewModels;
using Restaurant.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            var foodStore = new SQLiteFoodStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new HomePageViewModel(foodStore, pageService);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        public HomePageViewModel ViewModel
        {
            get { return BindingContext as HomePageViewModel; }
            set { BindingContext = value; }
        }

        private  void OnSelectFood(object sender, SelectionChangedEventArgs e)
        {
            var food = e.CurrentSelection.FirstOrDefault() as FoodViewModel;
            ViewModel.SelectFoodCommand.Execute(food);
        }
    }
}