using com.kpmgus.linkworkforcemobile.Shared.Common;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace com.kpmgus.linkworkforcemobile.Shared.Helpers
{
    public class AuthenticationService
    {
        public AuthenticationService()
        {
            
        }

        public async Task<AuthenticationResult> AcquireTokenAsync()
        {
            Debug.WriteLine("Logged in");
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync().ConfigureAwait(false);
            try
            {
                try
                {
                    IAccount firstAccount = accounts.FirstOrDefault();
                    authResult = await App.PCA.AcquireTokenSilent(BuildConstants.Scopes, firstAccount)
                                            .ExecuteAsync()
                                            .ConfigureAwait(false);
                }
                catch (MsalUiRequiredException)
                {
                    try
                    {
                        Microsoft.Identity.Client.AcquireTokenInteractiveParameterBuilder builder;

                        if (DeviceInfo.Platform == DevicePlatform.iOS)
                        {
                             builder = App.PCA.AcquireTokenInteractive(BuildConstants.Scopes)
                                //.WithUseEmbeddedWebView(true)//MSAL
                                .WithPrompt(Prompt.ForceLogin)
                                .WithParentActivityOrWindow(App.ParentWindow);
                            if (DeviceInfo.Platform != DevicePlatform.WinUI)
                            {
                               // on Android and iOS, prefer to use the system browser, which does not exist on UWP
                                SystemWebViewOptions systemWebViewOptions = new SystemWebViewOptions()
                                {
                                    iOSHidePrivacyPrompt = true,
                                };

                                builder.WithSystemWebViewOptions(systemWebViewOptions);
                                builder.WithUseEmbeddedWebView(false);
                            }
                        }
                        else
                        {
                             builder = App.PCA.AcquireTokenInteractive(BuildConstants.Scopes)
                                .WithUseEmbeddedWebView(true)//MSAL
                                .WithPrompt(Prompt.ForceLogin)
                                .WithParentActivityOrWindow(App.ParentWindow);
                        }

                        authResult = await builder.ExecuteAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex2)
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            Debug.WriteLine("Access Token :" + authResult.AccessToken);
            return authResult;
            
        }

        public async Task SignOutAsync()
        {
            var accounts = await App.PCA.GetAccountsAsync();
            foreach (var account in accounts)
            {
                await App.PCA.RemoveAsync(account);
            }
        }
    }

}

