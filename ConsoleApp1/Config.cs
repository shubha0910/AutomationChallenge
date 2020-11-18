

namespace PaylocityBenifitsDashboard
{
    public static class Config
    {
        public static string BaseURL = "https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login";

        public static class Credentials
        {
            public static class Valid
            {
                public static string Username = "TestUser40";
                public static string Password = "##ls^?/F#iX7";

            }

            public static class Invalid
            {
                public static class Username
                {
                    public static string BlankUserName = "";
                    public static string SpecialCharUserName = "TestUser41";
                }

                public static class Password
                {
                    public static string BlankPassword = "";
                    public static string NumericPassword = "1234567";
                }
            }
        }
        public static class EmployeeInfo
        {
            public static class ValidEmployeeInfo
            {
                public static string FirstName = "Mike";
                public static string LastName = "Scott";
                public static string NumberOfDependents = "2";

            }

            public static class BlankEmployeeInfo
            {
                public static string FirstName = "";
                public static string LastName = "";
                public static string NumberOfDependents = "";
            }

            public static class OutofRangeDependentInfo
            {
                public static string FirstName = "Todd";
                public static string LastName = "Packer";
                public static string NumberOfDependents = "33";
            }

            public static class UpdateEmployeeInfo
            {
                public static string FirstName = "Jim";
                public static string LastName = "Halpert";
                public static string NumberOfDependents = "4";
            }

        }

    }
}
