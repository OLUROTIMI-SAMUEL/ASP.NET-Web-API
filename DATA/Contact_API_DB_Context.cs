using Building_A_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Building_A_Web_API.DATA
{
    public class Contact_API_DB_Context:   DbContext
    {
        public Contact_API_DB_Context(DbContextOptions options) : base(options)
        {

        }

        public  DbSet<Contact> Contacts { get; set; } //this is our table in the data base.

    }
}
