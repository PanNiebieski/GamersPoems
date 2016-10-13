
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersPoems.Controllers
{
    [Route("me/[controller]")]
    public class ContactController
    {
        [Route("[action]")]
        public string Phone()
        {
            return "555-BUT";
        }

        [Route("")]
        public string Email()
        {
            return "franko@gmail.com";
        }
    }
}
