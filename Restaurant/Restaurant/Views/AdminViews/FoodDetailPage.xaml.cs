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
    public partial class FoodDetailPage : ContentPage
    {
        public FoodDetailPage(FoodViewModel f)
        {
            InitializeComponent();
            var foodStore = new SQLiteFoodStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            // Note that I've pushed the responsibility of creating a 
            // ContactDetailViewModel into this page. This simplifies the code 
            // in the consumer of this page (ContactsPageViewModel). So, every time
            // we create a new ContactDetailPage, we don't have to worry about 
            // instantiating the underlying view model. 

            BindingContext = new FoodDetailViewModel(
                f ?? new FoodViewModel(), foodStore, pageService);
        }
    }
}