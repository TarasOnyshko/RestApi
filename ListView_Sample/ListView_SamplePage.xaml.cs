using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListView_Sample.Model;
using System.Linq;

namespace ListView_Sample
{
    public partial class ListView_SamplePage : ContentPage
    {
        List<Item> ListItems;


        public ListView_SamplePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListItems = await App.MYitemsManager.GetTasksAsync();
            myListView.ItemsSource = ListItems;
            //myListView.ItemsSource = await App.MYitemsManager.GetTasksAsync();
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
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                myListView.ItemsSource = ListItems;
            }

            else
            {
                myListView.ItemsSource = ListItems.Where(x => x.title.StartsWith(e.NewTextValue));
            }
        }
    }
}
