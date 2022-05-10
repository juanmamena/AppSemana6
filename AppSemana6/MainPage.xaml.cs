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
        string UrlJson = "http://172.20.10.7:8080/yoreparo-api/v1/category/createCategory";

        public MainPage()
        {
            InitializeComponent();
        }

        async void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            try {
                var client = new HttpClient();

                Category category = new Category();

                category.description = txtDescripcion.Text;
                category.image = txtUrlImagen.Text;
                category.isActive = txtActivo.Text;

                string json = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(UrlJson, content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Categoria creada con exito", "OK");
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
