namespace MovieNetDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }
        public int User_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
