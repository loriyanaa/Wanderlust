using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wanderlust.WebClient.Areas.Admin.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        public string UploaderAvatar { get; set; }

        public string UploaderUsername { get; set; }

        public string ImageUrl { get; set; }

        public bool HasBeenHidden { get; set; }
    }
}