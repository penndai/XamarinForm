using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloXmarinForm
{
	class ButtonClickPage:ContentPage
	{
		StackLayout layout = new StackLayout();
		
		public ButtonClickPage() {
			Button btn = new Button {Text="Log the tick time" };
			btn.Clicked += OnButtonClick;

			Padding = new Thickness(5, Device.OnPlatform(20,0,0), 5,0);

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Children = {
					new StackLayout {
						Padding=new Thickness(5),
						Spacing=10,					 
						Children = { btn }
					},			
					new ScrollView {
						IsClippedToBounds=true,
						Content = layout,						
						VerticalOptions = LayoutOptions.FillAndExpand,
						Padding=new Thickness(5,0)
					}				
				}
			};
		}

		private void OnButtonClick(object sender, EventArgs e)
		{
			layout.Children.Add(new Label {
				Text = string.Format("Button click at {0}", DateTime.Now.ToString("T")),
			});
		}
	}
}
