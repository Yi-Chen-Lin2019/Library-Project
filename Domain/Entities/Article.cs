using System;
using Domain.AggregateRoots;

namespace Domain.Entities
{
    public class Article : ItemDescriptor
    {
        public String Subject { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Article()
        {
        }
    }
}
