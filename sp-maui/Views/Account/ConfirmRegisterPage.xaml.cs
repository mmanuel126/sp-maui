namespace sp_maui.Views.Account;

public partial class ConfirmRegisterPage : ContentPage
{
	public ConfirmRegisterPage()
	{
		InitializeComponent();
        this.Title = App.AppSettings.AppName;

        string compName = App.AppSettings.AppName;
        string email = Preferences.Get("RegisteredEmail","");

        lblInstruction.Text = "Thank you for signing up on " + compName + "! A confirmation email was sent to " +
            " you at " + email + ". Please check your email and click on the confirmation link in the email " +
            "to complete your registration. Then return here and tap the 'Return to Login Screen' " +
            "link below to Log in using your new credentials";

        //when you touch return to login screen label
        var register_confirm_tap = new TapGestureRecognizer();
        register_confirm_tap.Tapped += register_confirm_tap_Tapped;
        ReturnToLogin.GestureRecognizers.Add(register_confirm_tap);
    }

    private async void register_confirm_tap_Tapped(object sender, EventArgs e)
    {
        var loginPage = new LoginPage();
        await Navigation.PushModalAsync(new NavigationPage(loginPage));
    }
}
