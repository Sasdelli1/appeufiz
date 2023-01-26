using appeufiz.Models;
using appeufiz.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace appeufiz.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
            gettinglocaldevice();


        }

        private readonly Geocoder _geocoder = new Geocoder();

        async private void Pesquisaendereco_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(entry.Text);

                var positions = await _geocoder.GetPositionsForAddressAsync(entry.Text);


                if (result.Any())
                    resultLocation.Text = $"lat: {result.FirstOrDefault()?.Latitude}, long: {result.FirstOrDefault()?.Longitude}";

                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromMeters(1)));

                Pin pin = new Pin
                {
                    Label = "entry.Text",
                    Address = "entry.Text",
                    Type = PinType.Place,
                    Position = new Position(result.FirstOrDefault().Latitude, result.FirstOrDefault().Longitude)
                };
                myMap.Pins.Add(pin);

            }
            catch (Exception)
            {
                // TODO: Do something useful
            }

            //var positions = await _geocoder.GetPositionsForAddressAsync(result);
        }

        private async void gettinglocaldevice()
        {
            try
            {

                CancellationTokenSource cts = new CancellationTokenSource();
    
                var Request= new GeolocationRequest(GeolocationAccuracy.Medium,TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(Request,cts.Token); 


                Position position = new Position(location.Latitude, location.Longitude);
                IEnumerable<string> possibleAddresses = await _geocoder.GetAddressesForPositionAsync(position);
                string address = possibleAddresses.FirstOrDefault();
                entry.Text = address;   

                var result = await Geocoding.GetLocationsAsync(address);

                var positions = await _geocoder.GetPositionsForAddressAsync(address);


                if (result.Any())
                    resultLocation.Text = $"lat: {result.FirstOrDefault()?.Latitude}, long: {result.FirstOrDefault()?.Longitude}";

                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromMeters(1)));

                if (location != null)
                {
                    Console.WriteLine($"latitude {location.Latitude} longitude {location.Longitude} altitude{location.Altitude}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}