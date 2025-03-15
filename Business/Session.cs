using System;

namespace BookHaven.Business
{
    public static class Session
    {
        public static Guid LoggedInUserID { get; set; }
        public static string LoggedInUserRole { get; set; }

        public static void SetUser(Guid userId, string username, string role)
        {
            LoggedInUserID = userId;
            LoggedInUserRole = role.Trim();  // Trim spaces
        }
    }
}
