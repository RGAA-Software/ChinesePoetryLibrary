using ChinesePoetryLibrary.Src;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChinesePoetryLibrary
{
    public sealed partial class MainWindow : Window
    {
        private Context context;

        public MainWindow(Context ctx)
        {
            context = ctx;

            this.InitializeComponent();
            //SystemBackdrop = new DesktopAcrylicBackdrop();
            //SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            AppWindow.SetIcon("Assets/icon.ico");

            //
            AppTitleBar.Loaded += AppTitleBar_Loaded;
            AppTitleBar.SizeChanged += AppTitleBar_SizeChanged;
            //

            NavView.SelectedItem = NavItemAuthor;
            ContentFrame.Navigate(Type.GetType("ChinesePoetryLibrary.Pages.Author"));

        }

        private void LoadPage(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
            string pageName = "ChinesePoetryLibrary.Pages." + ((string)selectedItem.Tag);
            Type pageType = Type.GetType(pageName);

            Debug.WriteLine("ContentFrame is null: " + (ContentFrame == null).ToString());
            
            ContentFrame.Navigate(pageType);
        }

        private void AppTitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (ExtendsContentIntoTitleBar == true)
            {
                // Set the initial interactive regions.
                SetRegionsForCustomTitleBar();
            }
        }

        private void AppTitleBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ExtendsContentIntoTitleBar == true)
            {
                // Update interactive regions if the size of the window changes.
                SetRegionsForCustomTitleBar();
            }
        }

        private void SetRegionsForCustomTitleBar()
        {
            double scaleAdjustment = AppTitleBar.XamlRoot.RasterizationScale;

            RightPaddingColumn.Width = new GridLength(AppWindow.TitleBar.RightInset / scaleAdjustment);
            LeftPaddingColumn.Width = new GridLength(AppWindow.TitleBar.LeftInset / scaleAdjustment);

            GeneralTransform transform = TitleBarSearchBox.TransformToVisual(null);
            Rect bounds = transform.TransformBounds(new Rect(0, 0,
                                                             TitleBarSearchBox.ActualWidth,
                                                             TitleBarSearchBox.ActualHeight));
            Windows.Graphics.RectInt32 SearchBoxRect = GetRect(bounds, scaleAdjustment);

            transform = PersonPic.TransformToVisual(null);
            bounds = transform.TransformBounds(new Rect(0, 0,
                                                        PersonPic.ActualWidth,
                                                        PersonPic.ActualHeight));
            Windows.Graphics.RectInt32 PersonPicRect = GetRect(bounds, scaleAdjustment);

            var rectArray = new Windows.Graphics.RectInt32[] { SearchBoxRect, PersonPicRect };

            InputNonClientPointerSource nonClientInputSrc =
                InputNonClientPointerSource.GetForWindowId(this.AppWindow.Id);
            nonClientInputSrc.SetRegionRects(NonClientRegionKind.Passthrough, rectArray);
        }

        private Windows.Graphics.RectInt32 GetRect(Rect bounds, double scale)
        {
            return new Windows.Graphics.RectInt32(
                _X: (int)Math.Round(bounds.X * scale),
                _Y: (int)Math.Round(bounds.Y * scale),
                _Width: (int)Math.Round(bounds.Width * scale),
                _Height: (int)Math.Round(bounds.Height * scale)
            );
        }
    }
}
