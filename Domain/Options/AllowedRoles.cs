using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Options
{
    public static class AllowedRoles
    {
        public const string Super = "super";
        public const string Admin = "admin";
        public const string User = "user";
        public const string Client = "client";
        public const string Super_Admin = Super + "," + Admin;
        public const string Super_Admin_User = Super + "," + Admin + "," + User;
        public const string Super_Admin_User_Client = Super + "," + Admin + "," + User + "," + Client;

    }
}
