using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JustEatDataAccess.Models;
using PostCodeDataAccess.DataAccess;

namespace JustEatDataAccess.DataAccess
{
    public class PostCodeApiDataReader:IDataReader
    {

        public async Task<PostCodeResult> GetPostCodeResults(string outCode)
            {
                PostCodeResult postCodeResult = await JsonDownloader.DownloadSerializedJsonDataAsync<PostCodeResult>("http://api.postcodes.io/postcodes/" + outCode);
                //JSON result has been deserialized to <List<YourCustomClass>> and assigned to yourCustomC
                return postCodeResult;
            }
    }

   
}
