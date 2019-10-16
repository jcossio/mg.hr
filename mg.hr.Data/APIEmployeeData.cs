using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using mg.hr.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace mg.hr.Data
{
    /// <summary>
    /// Class that implements the metods related to the data access
    /// </summary>
    public class APIEmployeeData : IEmployeeData
    {
        private readonly IConfiguration config;
        List<Employee> employees;

        /// <summary>
        /// Constructor where we initialize the list of employees seeded from the Web API
        /// </summary>
        /// <param name="config">application configuration reference</param>
        public APIEmployeeData(IConfiguration config)
        {
            // Grab the initial employee data from the Web API provided
            using (var httpClient = new HttpClient())
            {
                // Store config reference for later use
                this.config = config;
                // Grap Data URI
                var seedURI = config["SeedDataURI"];
                if (string.IsNullOrEmpty(seedURI))
                    seedURI = "http://masglobaltestapi.azurewebsites.net/api/Employees";
                // Pull the initial data
                httpClient.BaseAddress = new Uri(seedURI);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body and convert to employee 
                    employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Method that returns all the employees
        /// </summary>
        /// <returns>List of employees</returns>
        public IEnumerable<Employee> GetAll()
        {
            return from e in employees
                   orderby e.name
                   select e;
        }
    }
}
