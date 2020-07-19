using Contracts.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.Examples.Request
{
    public class CreateUserRequestExample : IExamplesProvider<CreateUserRequest>
    {
        public CreateUserRequest GetExamples()
        {
            return new CreateUserRequest
            {
                Email = "mymailaddress@gmail.com",
                Password = "mypassword",
                ConfirmPassword="mypassword",
                PhoneNumber="",
                UserName= "mymailaddress@gmail.com"
            };
        }
    }
}
