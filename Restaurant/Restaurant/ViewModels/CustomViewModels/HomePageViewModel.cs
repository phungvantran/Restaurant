using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Restaurant.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Restaurant.Views.CustomViews;

namespace Restaurant.ViewModels.CustomViewModels
{
   public class HomePageViewModel:BaseViewModel
    {
        private FoodViewModel _selectedFood;
        private IFoodStore _foodStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<FoodViewModel> Foods { get; private set; }
             = new ObservableCollection<FoodViewModel>();

        public FoodViewModel SelectedFood
        {
            get { return _selectedFood; }
            set { SetValue(ref _selectedFood, value); }
        }

        //khai báo các Command

        public ICommand LoadDataCommand { get; private set; }
        public ICommand SelectFoodCommand { get; set; }
        public ICommand WatchCartCommand { get; set; }
//================================================================================================

        //Hàm khởi tạo
        public HomePageViewModel(IFoodStore foodStore ,IPageService pageService)
        {
            _foodStore = foodStore;
            _pageService = pageService;
            LoadDataCommand = new Command(async () => await LoadData());
            SelectFoodCommand = new Command<FoodViewModel>(async p => await SelectFood(p));
            WatchCartCommand = new Command(async () => await WatchCart());
        }

        private async Task WatchCart()
        {
            await _pageService.PushAsync(new CartPage());
        }

        //================================================================================================

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var foods = await _foodStore.GetFoodsAsync();

            foreach (var c in foods)
                Foods.Add(new FoodViewModel(c));
        }
        public async Task SelectFood(FoodViewModel food)
        {
           
            if (food == null)
            {
              return;
            }
              

            SelectedFood = null;

            await _pageService.PushAsync(new DetailAndOrderPage(food));
        }



    }
}
