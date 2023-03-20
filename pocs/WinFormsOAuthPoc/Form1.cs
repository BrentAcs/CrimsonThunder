using System.Security.Principal;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Abstractions;

namespace WinFormsOAuthPoc;

public partial class Form1 : Form
{
   private string[] scopes = new string[] { "user.read" };
   private const string ClientId = "63fe056e-a329-4a03-ab34-47eff3e0a5c9";
   private const string Tenant = "acd5fbae-2480-4871-bea0-2c512024a440";
   private const string Authority = "https://login.microsoftonline.com/" + Tenant;

   // The MSAL Public client app
   private static IPublicClientApplication _publicClientApp;

   private static string MSGraphURL = "https://graph.microsoft.com/v1.0/";
   private static AuthenticationResult authResult;
   private static IAccount _currentUserAccount;


   public Form1()
   {
      InitializeComponent();
   }

   private void Form1_Load(object sender, EventArgs e)
   {
      // Reference: https://cmatskas.com/modern-authentication-with-azure-ad-for-winforms-native-apps-2/

      // Application(client) ID: 63fe056e - a329 - 4a03 - ab34 - 47eff3e0a5c9
      // Object ID: 14fd876f - 713f - 4996 - 8360 - df7d306f48f7
      // Directory(tenant) ID: acd5fbae - 2480 - 4871 - bea0 - 2c512024a440

      // https://login.microsoftonline.com/common/oauth2/nativeclient


      // Initialize the MSAL library by building a public client application
      _publicClientApp = PublicClientApplicationBuilder.Create(ClientId)
         .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
         .WithAuthority(AzureCloudInstance.AzurePublic, Tenant)
         .WithRedirectUri("http://localhost")
         .Build();
      TokenCacheHelper.EnableSerialization(_publicClientApp.UserTokenCache);
      //loginButton.Enabled = _currentUserAccount is null;

   }

   private async Task<AuthenticationResult> Login()
   {
      AuthenticationResult authResult = null;
      var accounts = await _publicClientApp.GetAccountsAsync();
      var firstAccount = accounts.FirstOrDefault();

      try
      {
         authResult = await _publicClientApp.AcquireTokenSilent(scopes, firstAccount)
            .ExecuteAsync();
      }
      catch (MsalUiRequiredException ex)
      {
         // A MsalUiRequiredException happened on AcquireTokenSilent.
         // This indicates you need to call AcquireTokenInteractive to acquire a token
         System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

         try
         {
            authResult = await _publicClientApp.AcquireTokenInteractive(scopes)
               .WithAccount(accounts.FirstOrDefault())
               .WithPrompt(Prompt.SelectAccount)
               .ExecuteAsync();
         }
         catch (MsalException msalex)
         {
            label1.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
         }
      }
      catch (Exception ex)
      {
         label1.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
      }
      return authResult;
   }


   private async Task Logout()
   {
      var accounts = await _publicClientApp.GetAccountsAsync();
      if (accounts.Any())
      {
         try
         {
            await _publicClientApp.RemoveAsync(accounts.FirstOrDefault());
            this.label1.Text = "User has signed-out";
            this.label4.Text = "User has signed-out";
         }
         catch (MsalException ex)
         {
            throw new Exception($"Error signing-out user: {ex.Message}");
         }
      }
   }
   private async void loginButton_Click(object sender, EventArgs e)
   {
      var authResult = await Login();
      label4.Text = authResult.Account.Username;

      WindowsIdentity current = WindowsIdentity.GetCurrent();
      WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
      label1.Text = windowsPrincipal.Identity.Name;
   }
}
