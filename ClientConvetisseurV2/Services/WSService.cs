using ClientConvetisseurV2.Models;
using ClientConvetisseurV2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvetisseurV2.Services
{
    internal class WSService
    {
        private static WSService instance = null;
        private HttpClient client = new HttpClient();
        private const string path = "https://localhost:7114/api/";
        public WSService()
        {
            
        }

        public static WSService GetInstance()
        {
            if (instance == null)
            {
                instance = new WSService();
            }
            return instance;
        }
        public async Task<List<Devise>> GetAllDevisesAsync()
        {
            try
            {
                List<Devise> devises = null;
                HttpResponseMessage response = await client.GetAsync(path + "devises/");
            
                if(response.IsSuccessStatusCode)
                    devises = await response.Content.ReadAsAsync<List<Devise>>();

                return devises;
            } catch
            {
                await Dialog.DisplayDialogAsync("No result", "Service injoignable", "Ok");
                return new List<Devise>();
            }
        }
    }
}
