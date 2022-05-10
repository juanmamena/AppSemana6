using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppSemana6
{
    public partial class MainPage : ContentPage
    {

        private static readonly HttpClient client = new HttpClient();
        List<Category> ListaCategorias = new List<Category>();
        string UrlJson = "http://192.168.68.101:8080/yoreparo-api/v1/category/createCategory";

        public MainPage()
        {
            InitializeComponent();
        }

        async void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            try {
                var client = new HttpClient();
                Uri uri = new Uri(string.Format(UrlJson, string.Empty));
                Category category = new Category();

                category.description = txtDescripcion.Text;
                category.image = txtUrlImagen.Text;
                category.isActive = txtActivo.Text;

                string json = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Categoria creada con exito", "OK");
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error: "+ response.StatusCode+" Detalle: "+response.ToString(), "OK");
                    
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message, "OK");
            }


        }

         void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
        

            
        }
    }
}
