using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppSemana6
{
    public partial class GetPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
      
        string UrlJson = "http://192.168.68.101:8080/yoreparo-api/v1/category/getAllCategories";
        List<Category> ListaCategorias = new List<Category>();

        public GetPage()
        {
            InitializeComponent();
        }

        async void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            var responseString = await client.GetStringAsync(UrlJson);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            ListaCategorias = JsonConvert.DeserializeObject<List<Category>>(data);
            foreach (var category in ListaCategorias)
            {
                lblDescripcion.Text = category.description;
                lblId.Text = category.categoryId.ToString();
                lblImagen.Text = category.image;
                lblEsActivo.Text = category.isActive;

                break;

            }
            //await Application.Current.MainPage.DisplayAlert("Response", data, "Ok");
        }
    }
}
