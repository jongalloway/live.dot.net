using System;

using LiveStandup.Mobile.Models;
using LiveStandup.Shared.Models;

namespace LiveStandup.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Show Item { get; set; }
        public ItemDetailViewModel(Show item = null)
        {
            Title = item?.Title;
            Item = item;
        }

        public ItemDetailViewModel()
        {

        }
    }
}
