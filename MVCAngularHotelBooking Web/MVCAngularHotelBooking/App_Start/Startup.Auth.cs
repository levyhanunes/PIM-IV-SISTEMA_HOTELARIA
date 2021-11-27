using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using MVCAngularHotelBooking.Models;

namespace MVCAngularHotelBooking
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Permite que o aplicativo valide o carimbo de segurança quando o usuário efetua login.
                    // Este é um recurso de segurança usado quando você altera uma senha ou adiciona um login externo à sua conta.
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Permite que o aplicativo armazene temporariamente as informações do usuário quando eles estão verificando o segundo fator no processo de autenticação de dois fatores.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Habilita o aplicativo a lembrar o segundo fator de verificação de login, como telefone ou e-mail.
            // Depois de marcar esta opção, sua segunda etapa de verificação durante o processo de login será lembrada no dispositivo de onde você se conectou.
            // Isso é semelhante à opção RememberMe quando você faz o login.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            //A BAIXO É PARA O APP ANDROID, NÃO REALIZEI TESTES AINDA :SNUFF:
            //
            // Remova o comentário das linhas a seguir para permitir o login com provedores de login de terceiros
            //app.UseMicrosoftAccountAuthentication (
            //    ID do Cliente: "",
            // clientSecret: "");

            //app.UseTwitterAuthentication (
            //   Chave do consumidor: "",
            //   consumidor secreto: "");

            //app.UseFacebookAuthentication (
            // appId: "",
            // appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions ()
            // {
            // ClientId = "",
            // ClientSecret = ""
            //});
        }
    }
}