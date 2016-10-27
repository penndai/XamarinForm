using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloXmarinForm
{
	public class ReflectedColoursPage:ContentPage
	{
		public ReflectedColoursPage() {
			// stack layout set to horizontal
			//StackLayout stackLayout = new StackLayout { BackgroundColor= Color.Blue, Orientation= StackOrientation.Horizontal};
			StackLayout stackLayout = new StackLayout { BackgroundColor = Color.Blue};
			foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
			{
				if(info.GetCustomAttribute<ObsoleteAttribute>() != null)
				{
					continue;
				}

				if(info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
				{
					stackLayout.Children.Add(CreateColourLabel(((Color)info.GetValue(null)),info.Name));
				}
			}

			foreach (PropertyInfo info in typeof(Color).GetRuntimeProperties())
			{
				MethodInfo methodInfo = info.GetMethod;

				if (methodInfo.IsPublic && methodInfo.IsStatic && methodInfo.ReturnType == typeof(Color))
				{
					stackLayout.Children.Add(CreateColourLabel(((Color)info.GetValue(null)), info.Name));
				}
			}

			Padding = new Thickness(5, Device.OnPlatform(20,5,5),5,5);
			// the scroll view horizontal
			//Content = new ScrollView { Content = stackLayout, BackgroundColor=Color.Red, Orientation= ScrollOrientation.Horizontal};
			Content = new ScrollView { Content = stackLayout, BackgroundColor = Color.Red};
		}

		private Label CreateColourLabel(Color color, string name)
		{
			Color backgroundColor = Color.Default;
			if (color != backgroundColor) {
				double luminance = 0.3 * color.R + 0.59 * color.G + 0.11 * color.B;
				backgroundColor = luminance > 0.5 ? Color.Black : Color.White;
			}

			return new Label {
				Text = name,
				TextColor = color,
				BackgroundColor = backgroundColor,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))				
			};
		}
	}
}
