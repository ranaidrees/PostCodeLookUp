﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PostCodeDataAccess.DataAccess
{
    public static class JsonDownloader
    {
        //public static async Task<T> DownloadSerializedJsonDataAsync<T>(string url, APIType apiType) where T : new()
        public static async Task<T> DownloadSerializedJsonDataAsync<T>(string url) where T : new()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //if (apiType == APIType.YouTube)
                //{
                //    httpClient.DefaultRequestHeaders.Add("youtube-api-key", WebConfigurationManager.AppSettings["YouTube_API_KEY"]);
                //}

                string jsonData;
                try
                {
                    jsonData = await httpClient.GetStringAsync(url);
                }
                catch (Exception)
                {
                    return default(T);
                }
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : default(T);
            }
        }
    }


}
