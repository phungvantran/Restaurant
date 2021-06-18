using Restaurant.Services;
using Restaurant.ViewModels;
using Restaurant.ViewModels.CustomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailAndOrderPage : ContentPage
    {
        public DetailAndOrderPage()
        {
        }

        public DetailAndOrderPage(FoodViewModel f)
        {
            InitializeComponent();
            var pageService = new PageService();
            BindingContext = new DetailAndOrderViewModel(f ?? new FoodViewModel(), pageService);
        }
    }
}