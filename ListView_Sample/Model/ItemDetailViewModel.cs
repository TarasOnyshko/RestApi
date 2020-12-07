using System;
using System.Collections.Generic;
using System.Text;

namespace ListView_Sample.Model
{
    class ItemDetailViewModel
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            //title = item?.title;
            Item = item;
        }
    }
}
