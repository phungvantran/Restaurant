using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Restaurant.ViewModels
{
   public class FoodDetailViewModel
    {
        private readonly IFoodStore _foodStore;
        private readonly IPageService _pageService;

        public Food Food { get; private set; }

        public ICommand SaveCommand { get; private set; }


        public FoodDetailViewModel(FoodViewModel v,IFoodStore foodStore,IPageService pageService)
        {

            if (v == null)
                throw new ArgumentNullException(nameof(v));

            _foodStore = foodStore;
            _pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Food = new Food
            {
                Id = v.Id,
                Name = v.Name,
                ImageUrl = v.ImageUrl,
                Price = v.Price,
                Amount = v.Amount,
                Description = v.Description,
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Food.Name))
            {
                await _pageService.Displayalert("Lỗi!", "Tên không được để trống", "Đã hiểu");
                return;
            }
            if (Food.Price==0)
            {
                await _pageService.Displayalert("Lỗi!", "Giá không được để trống", "Đã hiểu");
                return;
            }
            if (Food.Amount == 0)
            {
                await _pageService.Displayalert("Lỗi!", "Số lượng không được để trống", "Đã hiểu");
                return;
            }
            
            if (Food.Id == 0)
            {
                await _foodStore.AddFood(Food);

                MessagingCenter.Send(this, Events.FoodAdded, Food);
            }
            else
            {
                await _foodStore.UpdateFood(Food);

                MessagingCenter.Send(this, Events.FoodUpdated, Food);
            }

            await _pageService.PopAsync();
        }
    }
}
