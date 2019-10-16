using mg.hr.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace mg.hr.Pages
{
    public class EmployeesModel : PageModel
    {
        // Holds the pointer to the app config
        private readonly IConfiguration _config;

        // Model exposed (output model)
        public IEnumerable<EmployeeDTO> Employees { get; set; }

        // Model binding two ways (Here SearchText should receive info from the request). This property binds to the textbox on the view
        [BindProperty(SupportsGet =true)]
        public string SearchText { get; set; }

        /// <summary>
        /// Constructor that injects the employee data
        /// </summary>
        /// <param name="config">app config data reference</param>
        public EmployeesModel(IConfiguration config)
        {
            // Store for later use
            this._config = config;
        }

        /// <summary>
        /// Get method for the page
        /// </summary>
        public void OnGet()
        {
            // Grap employees from our API
            using (var httpClient = new HttpClient())
            {
                var apiUrl = _config["ApiUrl"];
                if (string.IsNullOrEmpty(apiUrl))
                    apiUrl = "https://localhost:44350/api/Employees";
                // Pull the employee data based on search text
                httpClient.BaseAddress = new Uri($"{apiUrl}/{SearchText}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body and convert to employee 
                    Employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    // Return an empty list if something happened
                    Employees = new List<EmployeeDTO>();
                }
            }

        }
    }
}