using HelloWebAPI.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWebAPI.UI.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        //Kann man auch in die AppSettings -> auslagern und via IConfiguration einlesen. 
        private string _baseUrl = "https://localhost:44381/api/Movie/";
        
        public MovieService(HttpClient httpClient) //Wird via IOC Container Verfügbar gemacht
        {
            _httpClient = httpClient;
        }


        public async Task<List<Movie>> GetAll()
        {
            //AnfrageObjekt
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _baseUrl);
            HttpResponseMessage reponseResult = await _httpClient.SendAsync(request);

            string jsonText = await reponseResult.Content.ReadAsStringAsync();

            List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

            return movieList;
        }

        public async Task<Movie> GetById(int id)
        {
            string extendetURL = _baseUrl + id.ToString();

            HttpResponseMessage response = await _httpClient.GetAsync(extendetURL);
            string jsonText = await response.Content.ReadAsStringAsync();

            Movie currentMovie = JsonConvert.DeserializeObject<Movie>(jsonText);

            return currentMovie;
        }
        public async Task InsertMovie(Movie movie)
        {
            string jsonText = JsonConvert.SerializeObject(movie);

            StringContent data = new StringContent(jsonText, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, data);
        }

        public async Task UpdateMovie(Movie movie)
        {
            string extendetURL = _baseUrl + movie.Id.ToString();

            string json = JsonConvert.SerializeObject(movie);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(extendetURL, data);
        }

        public async Task DeleteMovie(int id)
        {
            string url = _baseUrl + id.ToString();
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
        }
    }



}
