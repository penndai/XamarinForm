using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace HelloXmarinForm
{
	public class VerticalOptionDemoPage:ContentPage
	{
		public VerticalOptionDemoPage()
		{
			Color[] colors = { Color.Yellow, Color.Blue };
			int flipFlopper = 0;

			IEnumerable<Label> labels =
				from field in typeof(LayoutOptions).GetRuntimeFields()
				where field.IsPublic && field.IsStatic
				orderby ((LayoutOptions)field.GetValue(null)).Alignment
				select new Label
				{
					Text = "VerticalOptions = " + field.Name,
					VerticalOptions = (LayoutOptions)field.GetValue(null),
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.End,
					FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					TextColor = colors[flipFlopper],
					BackgroundColor = colors[flipFlopper=1-flipFlopper]
				};

			StackLayout stackLayout = new StackLayout();
			foreach(Label lbl in labels)
			{
				stackLayout.Children.Add(lbl);
			}

			Padding = new Thickness(0, Device.OnPlatform(20,0,0),0,0);
			Content = stackLayout;
		}
	}
}
