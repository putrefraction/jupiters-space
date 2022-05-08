using System.ComponentModel.DataAnnotations;

namespace jupiters_space.Models {
    public class Post {
        public int Id {get; set;}
        public string? Title {get; set;}
        public string? Subtitle {get; set;}

        [DataType(DataType.Date)]
        public DateTime PostDate {get; set;}
        public string? Content {get; set;}

    }


}