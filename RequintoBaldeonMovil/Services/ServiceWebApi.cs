using RequintoBaldeonMovil.Models;
using Newtonsoft.Json;
using RequintoBaldeonMovil.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UIsrael.Models;

namespace RequintoBaldeonMovil.Services
{
    public static class ServiceWebApi
    {
       // private const string UrlWebApi = "http://localhost:5000/api/";


        private static  HttpClient cliente;//= CrearCliente(UrlWebApi);

        public static void incializa(string UrlWebApi)
        {
            cliente= CrearCliente(UrlWebApi);
        }
        


        private static HttpClient CrearCliente(string url)
        {
            HttpClient c = new HttpClient();
            c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/JSON"));
            c.BaseAddress = new Uri(url);
            return c;

        }


        public async static Task<List<T>> Get<T>(string controller) where T : new()
        {
            HttpResponseMessage respuesta = await cliente.GetAsync(controller);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                return lista;
            }

            return new List<T>();
        }
        public async static Task<List<T>> ObtenerItems<T>(string controlador) where T : new()
        {
            HttpResponseMessage respuesta = await cliente.GetAsync(controlador);

            if (respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                return lista;
            }
            else
            {
                return new List<T>();
            }

        }

        public static async Task<T> ObtenerItem<T>(string controlador, string id) where T : new()
        {
            var respuesta = await cliente.GetAsync($"{controlador}/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<T>(contenido);
                return item;
            }

            return new T();
        }
        
        public static async Task<string> LoginSIGE(string controlador, string id,string pine) 
        {
            pine = Tools.R(pine);
            HttpResponseMessage respuesta = await cliente.GetAsync($"{controlador}/{id}/{pine}");
            
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                Result result = JsonConvert.DeserializeObject<Result>(contenido);
                return result.msg;
            }

            return "Servidor no disponible. Intente más tarde";
        }



    }
}
