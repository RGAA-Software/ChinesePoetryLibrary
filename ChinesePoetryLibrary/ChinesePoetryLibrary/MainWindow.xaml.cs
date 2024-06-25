using ChinesePoetryLibrary.Src;
using Microsoft.UI.Composition.SystemBackdrops;
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

    }
}
