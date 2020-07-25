using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Models
{
    public class CreateAlbumRequestModel
    {
        [Required] public string Title { get; set; }

        [Required] public int AlbumId { get; set; }
    }

    public class CreateAlbumRequestModel2
    {
        [Required] public string Title { get; set; }
    }
}
