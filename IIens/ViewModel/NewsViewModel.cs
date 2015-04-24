using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Windows.Storage ;
using Newtonsoft.Json;
using IIens.Model;
using System.Windows.Input;
using Windows.Web.Http;
using Windows.UI.Popups;
using Windows.Web.Http.Filters;
using Windows.Security.Cryptography.Certificates;

namespace IIens.ViewModel
{
    class NewsViewModel
    {
        public ObservableCollection<News> News { get; set; }
        
        public async Task webReq()
        {
            ObservableCollection<News> result = new ObservableCollection<News>();

            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.IncompleteChain);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
            HttpClient clientOb = new Windows.Web.Http.HttpClient(filter);
            Uri connectionUri = new Uri("https://magadeva.iiens.net/IIEns/apiie.php");
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("type", "news");
            HttpFormUrlEncodedContent formContent = new HttpFormUrlEncodedContent(pairs);
            HttpResponseMessage response = await clientOb.PostAsync(connectionUri, formContent);
            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(response);
                //var dialog = new MessageDialog(response.Content.ToString());
                //await dialog.ShowAsync();
                    var data = JsonConvert.DeserializeObject<News[]>(response.Content.ToString());
                    System.Diagnostics.Debug.WriteLine(response.Content);
                    foreach (News news in data)
                    {
                        result.Add(news);
                        System.Diagnostics.Debug.WriteLine(news.titre);
                    }
                News = result;
                System.Diagnostics.Debug.WriteLine(News.Count);
            }
        }
    }
}
