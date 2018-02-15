using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Webkit;
using System.IO;
using System.Net;
using System;
using Java.Lang;
using System.Threading.Tasks;
using Android.Content.PM;
using Android.Content;
using static System.Net.Mime.MediaTypeNames;


namespace S2M.Droid
{
    [Activity(Label = "Натяжные потолки г. Лабинск", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public partial class MainActivity : Activity
    {
        public WebView WV;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            SetContentView(Resource.Layout.Main);
            // Set our view from the "main" layout resource            
            WebView wv = FindViewById<WebView>(Resource.Id.MyWebView);
            int backTaps = 0;
            var ev=new EventHandler<View.KeyEventArgs>((s, e) =>
            {
                if (e.KeyCode == Keycode.Back)
                {
                    e.Handled = true;
                    if (backTaps > 1)
                    {
                        if ( WV.CanGoBack())
                        {
                            backTaps = 0;
                            WV.GoBack();
                            
                        }
                        else
                        {
                            Finish();
                        }
                    }
                    else
                    {
                        backTaps++;
                    }
                }
                
            });
            wv.KeyPress += ev;
            WV = wv;
            wv.Settings.JavaScriptEnabled = true;
#if DEBUG
            WebView.SetWebContentsDebuggingEnabled(true);
#endif

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                CookieManager.Instance.SetAcceptThirdPartyCookies(wv, true);
            }
            else
            {
                CookieManager.Instance.SetAcceptCookie(true);
            }


            var wvc = new MyWebViewClient();
            wv.SetWebViewClient(wvc);
            wv.AddJavascriptInterface(new MyJSInterface(this), "CSharp");

            wv.Settings.BuiltInZoomControls = true;
            //wv.Settings.DefaultZoom =  WebSettings.ZoomDensity.Far;
            wv.Settings.SetSupportZoom(true);
            wv.Settings.DisplayZoomControls = false;
            wv.Settings.LightTouchEnabled = true;
            wv.Settings.DatabaseEnabled = true;
            wv.Settings.LoadWithOverviewMode = true;
            wv.Settings.UseWideViewPort = true;

            wv.LoadUrl("file:///android_asset/index.html");
        }

        public async override void OnBackPressed()
        {
            var t=Task.Run(() =>
            {
                if (WV.CanGoBack())
                {
                    WV.GoBack();
                }
                else
                {
                    Finish();
                }
            });
            await t;
        }

        public  override bool OnKeyDown(Keycode keyCode, KeyEvent ev)
        {

            if (keyCode==Keycode.Back && WV.CanGoBack())
            {
                WV.GoBack();
                return true;
            }
            else
            {
                Finish();
            }
            return false;
        }


    }

    
}

