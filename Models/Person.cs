using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ChuckSwapi.Models
{
    public class Person
    {
        public string Name { get; set; } 
        [JsonProperty("birth_year")]
        public string BirthYear{ get; set; } 
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; } 
        public string Gender { get; set; }
        [JsonProperty("hair_color")]
        public string HairColor{ get; set; } 
        public string Height { get; set; } 
        public string Mass { get; set; }
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; } 
        public string HomeWorld { get; set; } 
        public List<string> Films { get; set; } 
        public List<string> Species { get; set; } 
        public List<string> StarShips { get; set; } 
        public List<string> Vehicles { get; set; } 
        public string Url { get; set; } 
        public string Created { get; set; } 
        public string Edited { get; set; } 
    }
}
