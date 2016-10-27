using System;
using Xamarin.Forms;

namespace HelloXmarinForm
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage()
		{
			Label label = new Label();
			label.Text = "Greeting, Xamarin.Form";
			Content = label;

			//including padding just for iOS
			Padding = Device.OnPlatform<Thickness>(new Thickness(0,20,0,0),
													new Thickness(0,0,0,0),
													new Thickness(0,0,0,0));
		}
	}
}
