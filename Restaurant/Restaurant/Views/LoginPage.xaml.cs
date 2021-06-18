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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var pageService = new PageService();
            ViewModel = new LoginViewModel(pageService);
            this.BindingContext = ViewModel;
            InitializeComponent();
            
        }
        public LoginViewModel ViewModel
        {
            get { return BindingContext as LoginViewModel; }
            set { BindingContext = value; }
        }
    }
}