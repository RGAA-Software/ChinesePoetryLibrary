using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Net.Http;
using ABI.System;
using System.Diagnostics;
using ChinesePoetryLibrary.Src;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChinesePoetryLibrary.Pages
{

    public sealed partial class Settings : Page
    {

        private Context context;

        public Settings()
        {
            context = ((App)Application.Current).context;
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string info = await RequestInfo("https://www.baidu.com");
            Debug.WriteLine(info);

            context.Test();

        }

        async Task<string> RequestInfo(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // 确保响应状态为成功
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            } catch(HttpRequestException e)
            {
                return null;
            }
        }
    }
}
