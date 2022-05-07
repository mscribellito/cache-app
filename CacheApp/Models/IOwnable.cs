using System;

namespace CacheApp.Models
{

    public interface IOwnable
    {

        // user ID from AspNetUser table.
        public string? UserId { get; set; }

    }

}