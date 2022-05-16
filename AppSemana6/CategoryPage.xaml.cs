using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppSemana6
{
    public partial class CategoryPage : ContentPage

    {
        private static readonly HttpClient client = new HttpClient();
        string UrlJson = "http://192.168.68.101:8080/yoreparo-api/v1/category/updateCategory";

        public CategoryPage(int categoryId, String description, String image, String isActive )
        {
            InitializeComponent();
            lblId.Text = categoryId.ToString();
            txtDescripcion.Text = description;
            txtUrlImagen.Text = image;
            txtActivo.Text = isActive.ToString();
        }

        async void btnActualizar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var client = new HttpClient();
                Uri uri = new Uri(string.Format(UrlJson, string.Empty));
                Category category = new Category();

                category.description = txtDescripcion.Text;
                category.image = txtUrlImagen.Text;
                category.isActive = txtActivo.Text;
                category.categoryId = (int)Int64.Parse(lblId.Text);

                string json = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Categoria actualizada con exito", "OK");
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error: " + response.StatusCode + " Detalle: " + response.ToString(), "OK");

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
