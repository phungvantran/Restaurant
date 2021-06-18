using Restaurant.Services;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Restaurant.ViewModels
{
   public class LoginViewModel:BaseViewModel
    {
        private IPageService _pageService;
        private string _userName;
        private string _pass;

        public string UserName
        {
            get { return _userName; }
            set
            {
                SetValue(ref _userName, value);
                OnPropertyChanged();
            }
        }
        public string Pass
        {
            get { return _pass; }
            set
            {
                SetValue(ref _pass, value);
                OnPropertyChanged();
            }
        }

        //command
        public ICommand LoginCommand { get; private set; }
        public LoginViewModel(IPageService pageService)
        {
            _pageService = pageService;
            LoginCommand = new Command(async () => await Login());

        }

        private async Task Login()
        {
            if(UserName=="admin" || Pass == "1234")
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
                Application.Current.MainPage = new AdminShellPage();
            }
            //if (String.IsNullOrWhiteSpace(UserName) && String.IsNullOrWhiteSpace(Pass))
            //{
            //   await _pageService.Displayalert("Lỗi", "Vui lòng nhập đầy đủ tên và mật khẩu", "Đã hiểu");
            //}
            //else
            //{
            //    await _pageService.Displayalert("Lỗi", "Sai tên hoặc mật khẩu","Đã hiểu");
            //}
        }
    }
}
