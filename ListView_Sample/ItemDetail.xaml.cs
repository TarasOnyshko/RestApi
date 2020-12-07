using ListView_Sample.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListView_Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetail : ContentPage
    {

        private ItemDetailViewModel viewModel;
        public Item Item { get; set; }

        public ItemDetail(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetail()
        {
            InitializeComponent();

            var item = new Item
            {
                title = "Item blabla",
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}