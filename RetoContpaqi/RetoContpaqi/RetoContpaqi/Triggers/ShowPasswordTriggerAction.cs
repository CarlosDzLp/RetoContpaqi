using RetoContpaqi.Helpers;
using System.ComponentModel;

namespace RetoContpaqi.Triggers
{
    public class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        private FontImageSource ShowIcon { get; set; } = new FontImageSource
        {
            Color = Color.Parse("#000000"),
            Size = 25,
            FontFamily = "FProSolid",
            Glyph = FontAwesome.ShowEye
        };

        private FontImageSource HideIcon { get; set; } = new FontImageSource
        {
            Color = Color.Parse("#000000"),
            Size = 25,
            FontFamily = "FProSolid",
            Glyph = FontAwesome.HideEye
        };

        bool _hidePassword = true;

        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }

            get => _hidePassword;
        }

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
