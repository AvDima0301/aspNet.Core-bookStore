using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_First.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }

        public Author Author { get; set; }

    }
}
