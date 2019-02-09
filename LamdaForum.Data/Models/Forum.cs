using System;
using System.Collections.Generic;

namespace LamdaForum.Core.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        //Stored in the cloud so just need url of the image
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }

    }
}
