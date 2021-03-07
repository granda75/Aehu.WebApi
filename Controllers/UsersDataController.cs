using Aehu.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace Aehu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDataController : ControllerBase
    {
        [HttpGet]
        public async Task<bool> GetDataAndSaveToFiles()
        {
            await CreateJsonFile("https://jsonplaceholder.typicode.com/users", "users.json");
            await CreateJsonFile("https://jsonplaceholder.typicode.com/posts", "posts.json");
            await CreateJsonFile("https://jsonplaceholder.typicode.com/comments", "comments.json");
          
            return true;
        }
        
        private async Task CreateJsonFile(string url, string fileName)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string currentPath = Directory.GetCurrentDirectory();
                    string jsonFolderPath = Path.Combine(currentPath, "JsonFiles\\");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    System.IO.File.WriteAllText(jsonFolderPath + fileName, apiResponse);
                }
            }
        }

        // ⦁	Get all posts with Title , Author, Thumbnail and # of comments 
        public async Task<bool> GetAllPosts()
       {
            return  true; 
       }

    }
}
