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
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            var pageService = new PageService();
            ViewModel = new CartViewModel(pageService);
            
        }

        public CartViewModel ViewModel
        {
            get { return BindingContext as CartViewModel; }
            set { BindingContext = value; }
        }
    }
}