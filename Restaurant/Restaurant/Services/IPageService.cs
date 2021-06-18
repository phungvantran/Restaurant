using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurant.Services
{
	public interface IPageService
	{
		Task PushAsync(Page page);
		Task<Page> PopAsync();

		Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
		Task Displayalert(string title, string message, string ok);
	}
}
