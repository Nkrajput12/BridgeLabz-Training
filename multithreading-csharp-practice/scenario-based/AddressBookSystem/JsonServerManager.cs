using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class JsonServerRepository
    {
        private readonly RestClient client;

        public JsonServerRepository()
        {
            client = new RestClient("http://localhost:3000");
        }

        // UC 16 & 17: Write to JSON Server
        public async Task SaveToRemoteAsync(List<Contacts> contacts)
        {
            foreach (var contact in contacts)
            {
                var request = new RestRequest("contacts", Method.Post);
                request.AddJsonBody(contact);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                    Console.WriteLine($"[API] {contact.FirstName} synced to Server.");
                else
                    Console.WriteLine($"[Error] Could not sync {contact.FirstName}: {response.ErrorMessage}");
            }
        }

        // UC 16 & 17: Read from JSON Server
        public async Task<List<Contacts>> LoadFromRemoteAsync()
        {
            var request = new RestRequest("contacts", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {
                return JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            }
            return new List<Contacts>();
        }
    }
}