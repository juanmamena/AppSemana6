using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AppSemana6
{
    public partial class GetCategoriesPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();

        string UrlJson = "http://192.168.68.101:8080/yoreparo-api/v1/category/getAllCategories";
        List<Category> ListaCategorias = new List<Category>();
        ObservableCollection<Category> _categorias; 

        public GetCategoriesPage()
        {
            InitializeComponent();
            getCategories();

            
        }

        private async void getCategories()
        {
            var responseString = await client.GetStringAsync(UrlJson);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            ListaCategorias = JsonConvert.DeserializeObject<List<Category>>(data);

            _categorias = new ObservableCollection<Category>(ListaCategorias);
            this.categorias.ItemsSource = _categorias;

        }

        async void categorias_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var details =e.Item as Category;
            await Navigation.PushAsync(new CategoryPage(details.categoryId, details.description, details.image, details.isActive));
        }
    }
}
