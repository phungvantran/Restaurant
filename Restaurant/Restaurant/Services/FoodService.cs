using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Services
{
   public class FoodService
    {
        public List<Food> GetListFood()
        {
            return new List<Food>
            {
                new Food()
                {
                      Name = "Bánh đa cua",
                ImageUrl = "https://timeoutvietnam.com/files/2018/04/27/nhung-hang-banh-da-cua-ngon-nuc-tieng-ha-noi-1.jpg",
                Price = 30000,
                Amount = 36,
                Description = "Bánh đa cua món ăn tưởng chừng mộc mạc, giản dị nhưng lại mang sức hút ẩm thực mạnh mẽ",
                },
                new Food()
            {
                Name = "Thịt kho tàu",
                ImageUrl = "https://image-us.eva.vn/upload/3-2018/images/2018-07-30/ava-1532942175-858-width640height480.jpg",
                Price = 50000,
                Amount = 91,
                Description = "Hương vị truyền thống, thơm ngon bổ dưỡng",
            },
            new Food()
            {
                Name = "Bò sốt vang",
                ImageUrl = "https://nld.mediacdn.vn/thumb_w/540/2019/5/3/photo-1-1556873681461735552395.jpg",
                Price = 30000,
                Amount = 23,
                Description = "Bò sốt vang là món ăn vô cùng thơm ngon, bổ dưỡng đem lại cảm giác ngon miệng cho cả nhà",
            },
            new Food
            {
                Name = "Gà kho gừng",
                ImageUrl = "https://cdn.cet.edu.vn/wp-content/uploads/2018/04/lam-ga-kho-gung.jpg",
                Price = 75000,
                Amount = 10,
                Description = "Món gà kho với cách làm đơn giản nhưng cực kỳ hấp dẫn",
            },
            new Food()
            {
                Name = "Bánh mỳ cá mòi",
                ImageUrl = "https://images.foody.vn/res/g102/1015167/prof/s640x400/foody-upload-api-foody-mobile-banhmi-200326100731.jpg",
                Price = 30000,
                Amount = 99,
                Description = "Cá mòi được lấy từ biển, hương vị tuyệt vời",
            },
            new Food()
            {
                Name = "Trứng ốp la",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-3.jpg",
                Price = 16000,
                Amount = 788,
                Description = "Trứng ốp la ăn với muối tiêu hoặc nước tương, dùng kèm bánh mì hoặc cơm",
            },
            new Food()
            {
                Name = "Bánh tôm chiên giòn",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-4.jpg",
                Price = 89994,
                Amount = 990,
                Description = "món ăn này chế biến tại nhà vừa ngon miệng vừa không quá đắt",
            },
            new Food()
            {
                Name = "Cháo ăn liền",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-5.JPG",
                Price = 30000,
                Amount = 36,
                Description = "Món ăn đơn giản có phần hơi khô khan nhưng tại tiết kiệm đặc biệt là không bỏ phí phần cơm lỡ nấu quá nhiều từ hôm trước",
            },
             new Food
            {
                Name = "Cơm chiên trứng lạp xưởng",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-7.jpg",
                Price = 30000,
                Amount = 90,
                Description = "Cơm chiên trứng lạp xường có thể ăn kèm nước tương dầm ớt nếu ai chuộng sự đậm đà",
            },
           new Food()
            {
                Name = "Bánh tôm chiên giòn",
                ImageUrl = "https://pastaxi-manager.onepas.vn/content/uploads/articles/nguyendoan/anh-blog/6-mon-an-sang/6-mon-an-sang-nhanh-gon-4.jpg",
                Price = 30000,
                Amount = 90,
                Description = "Món bánh tôm chiên giòn ăn ngon với xà lách xoong và cà chua",
            },
        };
        }
    }
}
