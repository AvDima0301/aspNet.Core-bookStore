using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_First.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Image { get; set; }

        public List<Book> Books { get; set; }
    }
}
