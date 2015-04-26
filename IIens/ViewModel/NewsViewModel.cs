using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using IIens.Model;
using Newtonsoft.Json;

namespace IIens.ViewModel
{
    class NewsViewModel
    {
        public ObservableCollection<News> News { get; set; }
        
        public async Task WebReq()
        {
            var result = new ObservableCollection<News>();

            var filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.IncompleteChain);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
            var clientOb = new HttpClient(filter);
            var connectionUri = new Uri("https://magadeva.iiens.net/IIEns/apiie.php");
            var pairs = new Dictionary<string, string> {{"type", "news"}};
            var formContent = new HttpFormUrlEncodedContent(pairs);
            var response = await clientOb.PostAsync(connectionUri, formContent);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response);
                    var data = JsonConvert.DeserializeObject<News[]>(response.Content.ToString());
                    Debug.WriteLine(response.Content);
                    foreach (var news in data)
                    {
                        result.Add(news);
                    }
                News = result;
            }
        }
    }
}
