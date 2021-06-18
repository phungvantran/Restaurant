using Restaurant.Services;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Restaurant.ViewModels.CustomViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private IPageService _pageService;

        private static ObservableCollection<FoodViewModel> _listCart = new ObservableCollection<FoodViewModel>();
        private static float _money;
        private bool IsVisible { get; set; }
        public float Money
        {
            get { return _money; }
            set { SetValue(ref _money, value); }
        }
       
        public ObservableCollection<FoodViewModel> ListCast
        {
            get { return _listCart; }
            set
            {
                SetValue(ref _listCart,value);
                OnPropertyChanged();
            }
        }
       
        //khai báo command
        public ICommand ContinueCommand { get; private set; }
        //hàm khởi tạo
        public CartViewModel(IPageService pageService)
        {
            _pageService = pageService;
            Money = CaulatorMoney();

            ContinueCommand = new Command(async () =>await Continue());

        }

        private async Task Continue()
        {
            await _pageService.PushAsync(new HomePage());
        }

        public void Add(FoodViewModel f)
        {
            Isi
            if (ListCast.Count == 0) { ListCast.Add(f); }
            else
            {
                int tg = 0;
                for (int i=0; i < ListCast.Count; i++)
                {
                   
                    if (ListCast[i].Id == f.Id)
                    {
                        ListCast[i].Amount += f.Amount;
                        tg++;
                    }
                }
                if (tg == 0)
                {
                    ListCast.Add(f);
                }
            }
        }
        //Hàm tính tổng tiền
        public float CaulatorMoney()
        {
            float t= 0;
            for(int i = 0; i < ListCast.Count; i++)
            {
                t += ListCast[i].Amount * ListCast[i].Price;
            }
            return t;
        }
    }
}
