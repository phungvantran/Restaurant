using Restaurant.Services;
using Restaurant.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Restaurant.ViewModels.CustomViewModels
{
    public class DetailAndOrderViewModel:BaseViewModel
    {
        private readonly IPageService _pageService;

        private int _numBer;
        public int Number
        {
            get { return _numBer; }
            set
            {
                SetValue(ref _numBer, value);
            }
        }
        public FoodViewModel Food { get; private set; }
        public FoodViewModel FoodtoCart { get; private set; }

        //Command
        public ICommand WatchCartCommand { get; private set; }
        public ICommand AddToCartCommand { get; private set; }

        public DetailAndOrderViewModel(FoodViewModel v ,IPageService pageService)
        {
            if (v == null)
                throw new ArgumentNullException(nameof(v));
            _pageService = pageService;

            Food = new FoodViewModel
            {
                Id=v.Id,
                Name = v.Name,
                Price = v.Price,
                Amount = v.Amount,
                ImageUrl = v.ImageUrl,
                Description = v.Description,
            };

            AddToCartCommand = new Command(async () =>await AddToCart());
            WatchCartCommand = new Command(async () => await WatchCart());
        }

        private async Task WatchCart()
        {
            await _pageService.PushAsync(new CartPage());
        }

        private async Task AddToCart()
        {
            if (Number == 0)
            {
                await _pageService.Displayalert("Thêm không thành công!", "Vui lòng nhập số lượng sản phẩm", "Đã hiêu");
                return;
            }
            FoodtoCart = new FoodViewModel
            {
                Id = Food.Id,
                Name = Food.Name,
                ImageUrl = Food.ImageUrl,
                Price = Food.Price,
                Description = Food.Description,
                Amount = Number
            };
            var obj = new CartPage();
            obj.ViewModel.Add(FoodtoCart);
            await _pageService.Displayalert("Thông báo", $"Đã thêm {FoodtoCart.Amount} {FoodtoCart.Name} vào giỏ hàng", "Đồng ý");
        }
    }
}
