using IdentityModel.OidcClient.Browser;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IParkingv5.RegisterCard.Forms
{
    public class WinFormsWebView : IBrowser
    {
        private readonly Form _formFactory;
        private BrowserOptions _options;
        private WebView2 _webView;

        public WinFormsWebView(WebView2 webView2, Form frm)
        {
            _webView = webView2;
            _formFactory = frm;
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken token = default)
        {
            _options = options;


            var signal = new SemaphoreSlim(0, 1);

            var browserResult = new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };

            _formFactory.FormClosed += (o, e) =>
            {
                signal.Release();
            };

            _webView.NavigationStarting += (s, e) =>
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
                _formFactory.Controls.Add(_webView);
                _webView.Show();

                //this._formFactory.Show();

                // Initialization
                await _webView.EnsureCoreWebView2Async(null);

                // Delete existing Cookies so previous logins won't remembered
                _webView.CoreWebView2.CookieManager.DeleteAllCookies();

                // Navigate
                _webView.CoreWebView2.Navigate(_options.StartUrl);

                await signal.WaitAsync();
            }
            finally
            {
                _formFactory.Hide();
                _webView.Hide();
            }

            return browserResult;
        }

        private bool IsBrowserNavigatingToRedirectUri(Uri uri)
        {
            return uri.AbsoluteUri.StartsWith(_options?.EndUrl);
        }
    }
}