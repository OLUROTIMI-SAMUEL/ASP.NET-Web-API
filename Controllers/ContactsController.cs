using Building_A_Web_API.DATA;
using Building_A_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Building_A_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // this is our local host 
    public class ContactsController : Controller
    {
        private readonly Contact_API_DB_Context DbContext;
        public ContactsController(Contact_API_DB_Context DbContext)
        {
            this.DbContext = DbContext;
        }

       // public Contact_API_DB_Context DbContext { get; }

        // first we start by getting "HttpGet" so the question is what are we getting= contact, we will then put it inside
        [HttpGet("Contact")]  
        //we then type in the fuction 
        public async Task<IActionResult> GetContact()
        {  
            //what ever we return here is what the user will get 
            return Ok(await DbContext.Contacts.ToListAsync());

        }
       
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await DbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

 
        //this is used to save something in our data base. when dealing with post you will need to have an object passed along in which our use
            // will give us the object or information so that we can save it in data base 
        [HttpPost]

        //the "AddContactRequest & addContactRequest" there are actually our request body.
        public async Task <IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone

            };

            await DbContext.Contacts.AddAsync(contact);
            await DbContext.SaveChangesAsync(); 

            return Ok(contact);

        }
        // this is for updating data
        [HttpPut]
        [Route("{id:guid}")]

        public async Task <IActionResult> UpdateContact([FromRoute]Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact =  await DbContext.Contacts.FindAsync(id);

            if(contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;

                await DbContext.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }


        //this is for deleting data 
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
          var contact = await DbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                DbContext.Remove(contact);
                await DbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }
    }
}
