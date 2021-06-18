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
    public partial class AdminShellPage : Xamarin.Forms.Shell
    {
        public AdminShellPage()
        {
            InitializeComponent();
        }

        private async void OnLogoutClick(object sender, EventArgs e)
        {
            if(await this.DisplayAlert("Đăng xuất", "Bạn có chăc muốn đăng xuất?", "Đúng", "Hủy")){
                await Shell.Current.Navigation.PopToRootAsync();
                Application.Current.MainPage = new CustomShellPage();
            }
        }
    }
}