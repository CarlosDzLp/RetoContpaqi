using Maui.GoogleMaps;
using RetoContpaqi.Models;
using RetoContpaqi.ViewModels.Base;
using System.Collections.ObjectModel;

namespace RetoContpaqi.ViewModels.Pages
{
    public class DetailPageViewModel : BindableBase
    {
        #region Properties
        private UserModel User {  get; set; }
        public ObservableCollection<Pin> ListPin { get; set; }
        #endregion

        #region Constructor
        public DetailPageViewModel()
        {
            
        }
        #endregion

        #region Command

        #endregion

        #region CommandExecuted

        #endregion

        #region Methods
        private async Task LoadData()
        {
            try
            {
                ListPin = new ObservableCollection<Pin>();
                ListPin.Add(new Pin
                {
                    Address = User.Address.Street,
                    IsDraggable = false,
                    Position = new Position(User.Address.Geo.Latitude, User.Address.Geo.Longitude),
                });
            }
            catch(Exception ex)
            {

            }
        }

        public override Task OnNavigatedFrom(bool isForwardNavigation)
        {
            return base.OnNavigatedFrom(isForwardNavigation);
        }

        public override Task OnNavigatedTo()
        {
            _ = LoadData();
            return base.OnNavigatedTo();
        }

        public override Task OnNavigatingTo(object? parameter)
        {
            var user = parameter as UserModel;
            User = user;
            return base.OnNavigatingTo(parameter);
        }
        #endregion
    }
}
