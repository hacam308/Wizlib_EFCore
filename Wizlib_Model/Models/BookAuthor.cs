using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizlib_Model.Models
{
    public class BookAuthor
    {
        public int Book_Id { get; set; }
        public int Author_Id { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
