using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.ViewModels
{
   public class FoodViewModel:BaseViewModel
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
                OnPropertyChanged();
            }
        }
        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                SetValue(ref _imageUrl, value);
                OnPropertyChanged();
            }
        }
        private float _price;
        public float Price
        {
            get { return _price; }
            set
            {
                SetValue(ref _price, value);
                OnPropertyChanged();
            }
        }
        public int Amount { get; set; }
        public string Description { get; set; }

        //Khởi tạo
        public FoodViewModel() { }
        public FoodViewModel(Food food)
        {
            Id = food.Id;
            Name = food.Name;
            ImageUrl = food.ImageUrl;
            Amount = food.Amount;
            Description = food.Description;
            Price = food.Price;
        }
    }
}
