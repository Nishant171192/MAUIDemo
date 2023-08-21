using com.kpmgus.linkworkforcemobile.Shared.Helpers;

namespace com.kpmgus.linkworkforcemobile;

public partial class MainPage : ContentPage
{
	int count = 0;
    AuthenticationService authenticationService = new AuthenticationService();

    public MainPage()
	{
		InitializeComponent();
        authenticationService = new AuthenticationService();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        
        var authResult = await authenticationService.AcquireTokenAsync();

        // Handle the authentication result as needed
        if (authResult != null && authResult?.Account != null)
        {
            // User is authenticated successfully
            // Proceed with app functionality
        }
    }

   private async void LogoutBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            await authenticationService.SignOutAsync();
        }
        catch (Exception ex)
        {

        }
       
    }
}


