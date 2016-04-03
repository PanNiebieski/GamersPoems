using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersPoems.Services
{
    public interface IMessages
    {
        string Hello();
    }

    public class Messages : IMessages
    {
        public string Hello()
        {
            return "Cez Hello";
        }
    }
}
