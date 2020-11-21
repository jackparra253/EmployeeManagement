using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Entities.DTO;
using IData;
using Newtonsoft.Json;

namespace Data
{
    public class EmployeeExternalService : IEmployeeExternalService
    {
        public List<EmployeeExternal> GetAll()
        {
            List<EmployeeExternal> employeesExternals = new List<EmployeeExternal>();

            var client = new HttpClient();

            const string netApiEmployees = "https://masglobaltestapi.azurewebsites.net/api/Employees";

            return EmployeesExternals(employeesExternals, client, netApiEmployees);

        }

        private static List<EmployeeExternal> EmployeesExternals(List<EmployeeExternal> employeesExternals, HttpClient client, string netApiEmployees)
        {
            Task<HttpResponseMessage> getAsync = client.GetAsync(netApiEmployees);

            Task task = getAsync
                .ContinueWith((taskwithresponse) =>
                {
                    HttpResponseMessage response = taskwithresponse.Result;
                    Task<string> jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    employeesExternals = JsonConvert.DeserializeObject<List<EmployeeExternal>>(jsonString.Result);
                });

            task.Wait();

            return employeesExternals;
        }
    }
}
