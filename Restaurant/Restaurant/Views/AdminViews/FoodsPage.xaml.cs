using Restaurant.Persistence;
using Restaurant.Services;
using Restaurant.ViewModels;
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
    public partial class FoodsPage : ContentPage
    {
        public FoodsPage()
        {
            var foodStore= new SQLiteFoodStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new FoodsPageViewModel(foodStore, pageService);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //ViewModel.InsertData();
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectFoodCommand.Execute(e.SelectedItem);
        }
        public FoodsPageViewModel ViewModel
        {
            get { return BindingContext as FoodsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}