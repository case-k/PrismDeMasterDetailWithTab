using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(PrismDeMasterDetailWithTab.iOS.Renderers.TopTabbedRenderer))]

namespace PrismDeMasterDetailWithTab.iOS.Renderers
{
    /// <summary>
    /// iOSのTabbedPageのタブバーを上側に表示するためのRenderer
    /// 
    /// http://ticktack.hatenablog.jp/entry/2017/01/21/111847
    /// ぴーさんログから拝借
    /// </summary>
    public class TopTabbedRenderer : Xamarin.Forms.Platform.iOS.TabbedRenderer
    {
        // stackoverflowの回答を元にタブバーの位置を上に変更 http://stackoverflow.com/questions/29579992/positioning-uitabbar-at-the-top
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            TabBar.InvalidateIntrinsicContentSize();

            var orientation = UIApplication.SharedApplication.StatusBarOrientation;

            nfloat tabSize = 44.0f;

            if (orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight)
            {
                tabSize = 32.0f;
            }

            var tabFrame = TabBar.Frame;
            tabFrame.Height = tabSize;
            tabFrame.Y = View.Frame.Y;
            TabBar.Frame = tabFrame;

            // 強制的にぼかしを再描画する小技らしい
            TabBar.Translucent = false;
            TabBar.Translucent = true;
        }
    }
}
