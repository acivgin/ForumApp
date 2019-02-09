﻿using System;

namespace LamdaForum.Web.Forum.Models
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        //Stored in the cloud so just need url of the image
        public string ImageUrl { get; set; }
    }
}
