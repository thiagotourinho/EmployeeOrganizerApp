using System.Net.Http.Headers;


namespace EmployeeOrganizerApp.MVC
{
    public static class GlobalVariables
    {

        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables() 
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:5240/");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
