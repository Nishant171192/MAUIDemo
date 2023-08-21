using com.kpmgus.linkworkforcemobile.Shared.Common;
using Microsoft.Identity.Client;

namespace com.kpmgus.linkworkforcemobile;

public partial class App : Application
{
    public static object ParentWindow { get; set; }
    public static IPublicClientApplication PCA = null;
    public string RedirectURL { get; set; }


    public App()
	{
		InitializeComponent();
        string Enviorment = "dev";
        #region MSAL Code
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            switch (Enviorment)
            {
               
                case "dev":
                   RedirectURL = BuildConstants.RedirectURLAndroid;
                    break;
                default:
                    RedirectURL = BuildConstants.RedirectURLAndroid;
                    break;
            }
        }
        else
        {
            switch (Enviorment)
            {
                case "dev":
                    RedirectURL = BuildConstants.RedirectURLiOS;
                    break;
                default:
                    RedirectURL = BuildConstants.RedirectURLiOS;
                    break;
            }
        }

        switch (Enviorment)
        {
           
            case "dev":
                PCA = PublicClientApplicationBuilder.Create(BuildConstants.DEV_ClientID)
                    .WithRedirectUri(RedirectURL ?? $"msal{BuildConstants.DEV_ClientID}://auth")
                    .WithIosKeychainSecurityGroup(AppInfo.PackageName)
                    .WithTenantId(BuildConstants.DEV_TenantID)
                    .Build();
                break;
            default:
                PCA = PublicClientApplicationBuilder.Create(BuildConstants.DEV_ClientID)
                    .WithRedirectUri(RedirectURL ?? $"msal{BuildConstants.DEV_ClientID}://auth")
                    .WithIosKeychainSecurityGroup(AppInfo.PackageName)
                    .WithTenantId(BuildConstants.DEV_TenantID)
                    .Build();
                break;
        }
        #endregion
        MainPage = new MainPage();
    }
}

