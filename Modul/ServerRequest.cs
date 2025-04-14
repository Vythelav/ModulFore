using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Media.Animation;
using System.Collections.Specialized;
using System.Net.Http;
using System.Windows;

namespace ModulFo
{
    public static class ServerRequest
    {

        static HttpClient HttpClient = new HttpClient();
        public static async Task<String> getFio(string url) {
            try
            {
                HttpResponseMessage request = await HttpClient.GetAsync(url);
                return await HttpClient.GetStringAsync(url);
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
                return "";
            }
        }
    }
}
