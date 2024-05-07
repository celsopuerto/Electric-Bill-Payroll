using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semiFinalACT3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class print : ContentPage
    {
        public print()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            string status = $"{Application.Current.Properties["status"]}";
            int meter = int.Parse($"{Application.Current.Properties["data"]}");

            var data = await App.db.SearchAsync(meter);
            if (data != null)
            {
                if(status == "add")
                {
                    await DisplayAlert("Success", "Data Passed and Added Successfully", "OK");
                    printData.ItemsSource = new List<table> { data };
                }
                else if(status == "update")
                {
                    await DisplayAlert("Success", "Data Passed and Updated Successfully", "OK");
                    printData.ItemsSource = new List<table> { data };
                }
                else if(status == "delete")
                {
                    await DisplayAlert("Success", "Data Deleted Successfully", "OK");
                    printData.ItemsSource = new List<table> { data };
                    await App.db.DeleteAsync(data);
                }
            }
            else
            {
                await DisplayAlert("Notice!", "Data Doesn't Exist!", "OK");
            }


        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}