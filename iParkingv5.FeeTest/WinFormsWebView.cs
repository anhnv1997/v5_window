using IdentityModel.OidcClient.Browser;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Forms
{
    public class WinFormsWebView : IBrowser
    {
        private readonly Form _formFactory;
        private BrowserOptions _options;
        private WebView2 _webView;

        public WinFormsWebView(WebView2 webView2, Form frm)
        {
            this._webView = webView2;
            this._formFactory = frm;
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken token = default)
        {
            _options = options;


            var signal = new SemaphoreSlim(0, 1);

            var browserResult = new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };

            this._formFactory.FormClosed += (o, e) =>
            {
                signal.Release();
            };

            this._webView.NavigationStarting += (s, e) =>
            {
                if (IsBrowserNavigatingToRedirectUri(new Uri(e.Uri)))
                {
                    e.Cancel = true;
                    var test = BrowserResultType.Success;
                    browserResult = new BrowserResult()
                    {
                        ResultType = BrowserResultType.Success,
                        Response = new Uri(e.Uri).AbsoluteUri
                    };

                    signal.Release();
                    //this._formFactory.Close();
                }
            };

            try
            {
                this._formFactory.Controls.Add(this._webView);
                this._webView.Show();

                //this._formFactory.Show();

                // Initialization
                await this._webView.EnsureCoreWebView2Async(null);

                // Delete existing Cookies so previous logins won't remembered
                this._webView.CoreWebView2.CookieManager.DeleteAllCookies();

                // Navigate
                this._webView.CoreWebView2.Navigate(_options.StartUrl);

                await signal.WaitAsync();
            }
            finally
            {
                this._formFactory.Hide();
                this._webView.Hide();
            }

            return browserResult;
        }

        private bool IsBrowserNavigatingToRedirectUri(Uri uri)
        {
            return uri.AbsoluteUri.StartsWith(_options?.EndUrl);
        }
    }
}