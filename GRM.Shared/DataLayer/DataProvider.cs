using GRM.Shared.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;

namespace GRM.Shared.DataLayer
{
    public class DataProvider
    {
        public void PostContractFiles(string filePath)
        {
            using (var client = new WebClient())
            {
                client.QueryString.Add("filePath", filePath);

                client.UploadValues("https://localhost:44383/api/LoadContractsFile", client.QueryString);
            }  
        }

        public void PostPartnersFiles(string filePath)
        {
            using (var client = new WebClient())
            {
                client.QueryString.Add("filePath", filePath);

                client.UploadValues("https://localhost:44383/api/LoadPartnersFile", client.QueryString);
            }
        }

        public IEnumerable<Contracts> GetContractsByCriteria(Criteria criteria)
        {
            List<Contracts> response;

            using (var client = new WebClient())
            {
                client.QueryString.Add("date", criteria.Date);
                client.QueryString.Add("partner", criteria.Partner);

                var byteArray = client.UploadValues("https://localhost:44383/api/GetContractsByCritera", client.QueryString);
                var bytesAsString = Encoding.UTF8.GetString(byteArray);

                response = JsonConvert.DeserializeObject<List<Contracts>>(bytesAsString);

            }

            return response;
        }

        public static T Deserialize<T>(byte[] data) where T : class
        {
            using (var stream = new MemoryStream(data))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
                return JsonSerializer.Create().Deserialize(reader, typeof(T)) as T;
        }
    }
}
