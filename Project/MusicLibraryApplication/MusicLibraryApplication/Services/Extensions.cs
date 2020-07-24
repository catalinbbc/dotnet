using MusicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicLibrary.Application.Services
{
    public static class Extensions
    {
        public static List<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(u => u.WithoutPassword()).ToList();
        }

    }
}
