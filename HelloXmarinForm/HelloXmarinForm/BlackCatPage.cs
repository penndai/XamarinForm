using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloXmarinForm
{
	class BlackCatPage:ContentPage
	{
		public BlackCatPage() {
			StackLayout mainlayout = new StackLayout();
			StackLayout textlayout = new StackLayout
			{
				Padding = new Thickness(5),
				Spacing = 10
			};

			for (int i = 0; i < 30; i++) {


				if (i == 0)
				{
					Label lbl = new Label
					{
						Text = string.Format("Title added at {0}", DateTime.Now.ToString("T")),
						TextColor = Color.Red
					};

					lbl.HorizontalOptions = LayoutOptions.Center;
					lbl.FontSize = Device.GetNamedSize(NamedSize.Large, lbl);
					lbl.FontAttributes = FontAttributes.Bold;

					mainlayout.Children.Add(lbl);
				}
				else
				{
					Label lbl = new Label
					{
						Text = string.Format("text added at {0}", DateTime.Now.ToString("T")),
						TextColor = Color.White
					};

					lbl.HorizontalOptions = LayoutOptions.Center;
					lbl.FontSize = Device.GetNamedSize(NamedSize.Large, lbl);
					lbl.FontAttributes = FontAttributes.None;

					textlayout.Children.Add(lbl);
				}
			}

			ScrollView scrollview = new ScrollView {
				Content = textlayout,
				IsClippedToBounds=true,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5,0)
			};

			mainlayout.Children.Add(scrollview);

			Content = mainlayout;
			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
		}
	}
}
