using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicLibrary.Domain.Dto;

namespace MusicLibrary.api.Extensions
{
    public static class AlbumsExtensions
    {
        public static AlbumCreateDto MapToAlbumCreateDto(this Album album)
        {
            return new ClassRoomCreateDto
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                CourseID = classRoom.CourseID
            };
        }

        public static ClassRoom MapAsNewEntity(this ClassRoomCreateDto classRoom)
        {
            return new ClassRoom
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                CourseID = classRoom.CourseID
            };
        }
    }
}
