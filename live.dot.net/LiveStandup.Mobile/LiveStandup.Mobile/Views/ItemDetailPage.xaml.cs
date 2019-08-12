using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LiveStandup.Mobile.Models;
using LiveStandup.Mobile.ViewModels;
using LiveStandup.Shared.Models;
using Xamarin.Essentials;

namespace LiveStandup.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var uri = viewModel.Item.Url;
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private async void CommunityLinks_Clicked(object sender, EventArgs e)
        {
            string uri = viewModel.Item.CommunityLinksUrl;
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}