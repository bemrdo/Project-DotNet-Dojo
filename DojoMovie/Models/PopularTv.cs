﻿namespace DojoMovie.Models
{
    public class PopularTv
    {
        public int page { get; set; }
        public int total_result { get; set; }
        public int total_pages { get; set; }
        public Tv[] results { get; set; }
    }
}
