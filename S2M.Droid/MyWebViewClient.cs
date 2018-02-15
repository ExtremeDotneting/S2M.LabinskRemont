using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace S2M.Droid
{
    public class MyWebViewClient : WebViewClient
    {
        public event Action PageFinishedEvent;
        const string valueInjectKey = "valueinject/";
        
        [Obsolete]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
           

            view.LoadUrl(url);
            return false;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            PageFinishedEvent?.Invoke();
        }
    }
}