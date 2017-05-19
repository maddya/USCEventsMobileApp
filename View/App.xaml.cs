using Xamarin.Forms;

namespace USCEvents
{
	public partial class App : Application
	{

		public static string accessToken;
		public static bool loginComplete = false;
		public static UserInfo me;

		public App()
		{
			InitializeComponent();

			if (loginComplete)
			{
				MainPage = new USCEventsPage();
			}
			else
			{
				MainPage = new NavigationPage(new LoginPage());
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}