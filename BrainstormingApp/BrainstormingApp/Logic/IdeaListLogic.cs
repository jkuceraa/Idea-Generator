using BrainstormingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BrainstormingApp.Logic
{
    class IdeaListLogic
    {
        public static string GenerateUrl(string word)
        {
            return String.Concat("https://api.datamuse.com/words?rel_trg=", word);
        }

        public static async Task<List<IdeaList>> GetRelated(string relatedWord)
        {
            List<IdeaList> ideas = new List<IdeaList>();
            var url = GenerateUrl(relatedWord);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var relatedRoot = JsonConvert.DeserializeObject<IdeaRoot>(json);
            }


                return ideas;
        }
    }
}
