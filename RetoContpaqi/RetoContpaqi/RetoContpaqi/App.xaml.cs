using RetoContpaqi.Pages;

namespace RetoContpaqi
{
    public partial class App : Application
    {
        private readonly LoginPage loginPage;

        public App(LoginPage loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(loginPage));
        }
    }
}
