﻿using Restaurant.Services;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Restaurant.ViewModels
{
    public class FoodsPageViewModel:BaseViewModel
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
        public ICommand AddFoodCommand { get; private set; }
        public ICommand SelectFoodCommand { get; private set; }
        public ICommand DeleteFoodCommand { get; private set; }

        //Hàm khởi tạo
        public FoodsPageViewModel(IFoodStore foodStore, IPageService pageService)
        {
            _foodStore = foodStore;
            _pageService = pageService;

            // Because LoadData is an async method and returns Task, we cannot
            // pass its name as an Action to the constructor of the Command. 
            // So, we need to define an inline function using a lambda expression
            // and manually call it using await. 
            LoadDataCommand = new Command(async () => await LoadData());
            AddFoodCommand = new Command(async () => await AddFood());
            SelectFoodCommand = new Command<FoodViewModel>(async c => await SelectFood(c));
            DeleteFoodCommand = new Command<FoodViewModel>(async c => await DeleteFood(c));

            //Đăng kí nhận sự kiện
            MessagingCenter.Subscribe<FoodDetailViewModel, Food>
                (this, Events.FoodAdded, OnFoodAdded);

            MessagingCenter.Subscribe<FoodDetailViewModel, Food>
            (this, Events.FoodUpdated, OnFoodUpdated);
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var foods = await _foodStore.GetFoodsAsync();

            foreach (var c in foods)
                Foods.Add(new FoodViewModel(c));
        }

        private async Task AddFood()
        {
            await _pageService.PushAsync(new FoodDetailPage(new FoodViewModel()));
        }

        private async Task SelectFood(FoodViewModel food)
        {
            if (food == null)
                return;

            SelectedFood = null;

            await _pageService.PushAsync(new FoodDetailPage(food));
        }

        private async Task DeleteFood(FoodViewModel f)
        {
            if (await _pageService.DisplayAlert("Cảnh báo!", $"Xác nhận xóa {f.Name}?", "Xóa", "Hủy"))
            {
                Foods.Remove(f);

                var food = await _foodStore.GetFood(f.Id);
                await _foodStore.DeleteFood(food);
            }
        }

        private void OnFoodAdded(FoodDetailViewModel source, Food food)
        {
            Foods.Add(new FoodViewModel(food));
        }

        private void OnFoodUpdated(FoodDetailViewModel source, Food food)
        {
            var foodInList = Foods.Single(f => f.Id == food.Id);
            foodInList.Id = food.Id;
            foodInList.Name = food.Name;
            foodInList.ImageUrl = food.ImageUrl;
            foodInList.Price = food.Price;
            foodInList.Amount = food.Amount;
            foodInList.Description = food.Description;
        }
        //Hàm chèn nội dung vào CSDL
        public void InsertData()
        {
            Food f1 = new Food
            {
                Name = "Bánh đa cua",
                ImageUrl = "https://timeoutvietnam.com/files/2018/04/27/nhung-hang-banh-da-cua-ngon-nuc-tieng-ha-noi-1.jpg",
                Price = 30000,
                Amount = 36,
                Description = "Bánh đa cua món ăn tưởng chừng mộc mạc, giản dị nhưng lại mang sức hút ẩm thực mạnh mẽ",
            };
            Food f2 = new Food
            {
                Name = "Thịt kho tàu",
                ImageUrl = "https://image-us.eva.vn/upload/3-2018/images/2018-07-30/ava-1532942175-858-width640height480.jpg",
                Price = 50000,
                Amount = 91,
                Description = "Hương vị truyền thống, thơm ngon bổ dưỡng",
            };
            Food f3 = new Food
            {
                Name = "Bò sốt vang",
                ImageUrl = "https://nld.mediacdn.vn/thumb_w/540/2019/5/3/photo-1-1556873681461735552395.jpg",
                Price = 30000,
                Amount = 23,
                Description = "Bò sốt vang là món ăn vô cùng thơm ngon, bổ dưỡng đem lại cảm giác ngon miệng cho cả nhà",
            };
            Food f4 = new Food
            {
                Name = "Gà kho gừng",
                ImageUrl = "https://cdn.cet.edu.vn/wp-content/uploads/2018/04/lam-ga-kho-gung.jpg",
                Price = 75000,
                Amount = 10,
                Description = "Món gà kho với cách làm đơn giản nhưng cực kỳ hấp dẫn",
            };
            Food f5 = new Food
            {
                Name = "Bánh mỳ cá mòi",
                ImageUrl = "https://images.foody.vn/res/g102/1015167/prof/s640x400/foody-upload-api-foody-mobile-banhmi-200326100731.jpg",
                Price = 30000,
                Amount = 99,
                Description = "Cá mòi được lấy từ biển, hương vị tuyệt vời",
            };
            Food f6= new Food
            {
                Name = "Trứng ốp la",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-3.jpg",
                Price = 16000,
                Amount = 788,
                Description = "Trứng ốp la ăn với muối tiêu hoặc nước tương, dùng kèm bánh mì hoặc cơm",
            };
            Food f7 = new Food
            {
                Name = "Bánh tôm chiên giòn",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-4.jpg",
                Price = 89994,
                Amount = 990,
                Description = "món ăn này chế biến tại nhà vừa ngon miệng vừa không quá đắt",
            };
            Food f8 = new Food
            {
                Name = "Cháo ăn liền",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-5.JPG",
                Price = 30000,
                Amount = 36,
                Description = "Món ăn đơn giản có phần hơi khô khan nhưng tại tiết kiệm đặc biệt là không bỏ phí phần cơm lỡ nấu quá nhiều từ hôm trước",
            };
            Food f9 = new Food
            {
                Name = "Cơm chiên trứng lạp xưởng",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-7.jpg",
                Price = 30000,
                Amount = 90,
                Description = "Cơm chiên trứng lạp xường có thể ăn kèm nước tương dầm ớt nếu ai chuộng sự đậm đà",
            };
            Food f10 = new Food
            {
                Name = "Bánh tôm chiên giòn",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-4.jpg",
                Price = 30000,
                Amount = 90,
                Description = "Món bánh tôm chiên giòn ăn ngon với xà lách xoong và cà chua",
            };
            _foodStore.AddFood(f1);
            _foodStore.AddFood(f2);
            _foodStore.AddFood(f3);
            _foodStore.AddFood(f4);
            _foodStore.AddFood(f5);
            _foodStore.AddFood(f6);
            _foodStore.AddFood(f7);
            _foodStore.AddFood(f8);
            _foodStore.AddFood(f9);
            _foodStore.AddFood(f10);
        }

    }
}
