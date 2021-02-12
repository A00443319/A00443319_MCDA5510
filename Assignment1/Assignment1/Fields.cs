namespace SampleAssignment1
{
    public static class Fields
    {

        public const string F_NAME = "First Name";
        public const string L_NAME = "Last Name";
        public const string STREET_NO = "Street Number";
        public const string STREET = "Street";
        public const string CITY = "City";
        public const string PROVINCE = "Province";
        public const string POSTAL_CODE = "Postal Code";
        public const string COUNTRY = "Country";
        public const string PH_NUM = "Phone Number";
        public const string EMAIL = "email Address";


        public static string writeInCsv()
        {
            return F_NAME + "," + L_NAME + "," + STREET_NO +
                "," + STREET + "," + CITY + "," + PROVINCE + "," + POSTAL_CODE + "," + COUNTRY + "," + PH_NUM + "," + EMAIL;
        }
    }

}