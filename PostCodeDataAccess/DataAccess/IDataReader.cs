using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustEatDataAccess.Models;
//http://www.theyworkforyou.com/api/getMP?postcode=Ig1+2pa&output=xml&key=Ahdj9zFLeBFZGUTwkUDGLKCk&getMP
//http://maps.met.police.uk/access.php?area=E05000507&sort=rate
//http://api.postcodes.io/postcodes/ig1%202pa
namespace JustEatDataAccess.DataAccess
{
    public interface IDataReader
    {
        Task<PostCodeResult> GetPostCodeResults(string outCode);
    }

   
   
}
