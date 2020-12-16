using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListView_Sample.Model;

namespace ListView_Sample
{
    public partial class ListView_SamplePage : ContentPage
    {
        
        public ListView_SamplePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            myListView.ItemsSource = await App.MYitemsManager.GetTasksAsync();
            await DisplayAlert("Done", "Yes" + (myListView.ItemsSource as List<Item>).Count, "Ok");
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //DisplayAlert("Selected item", "you selected the Item ( " + (e.SelectedItem as Item).title +" )" ,"Ok");
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetail(new ItemDetailViewModel(item)));

        }
    }
}
