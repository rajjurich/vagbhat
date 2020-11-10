using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api/";
        public static class Accounts
        {
            public const string Token = "Token";
            public const string Refresh = "Refresh";
        }

        public static class Patients
        {
            public const string Get = Root + "Patient";
        }
    }
}
