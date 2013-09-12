namespace GeoDataSource
{
    public class PhoneInformation
    {
        public string Country { get; set; }
        public int CountryCode { get; set; }
        public int MobilePrefix { get; set; }
        public int NumberOfDigitsAfterMobilePrevix { get; set; }
        public string Comment { get; set; }

        public bool Reliable
        {
            get { return (MobilePrefix != 0 && NumberOfDigitsAfterMobilePrevix != 0); }
            private set { }
        }

        public string RegexPattern
        {
            get
            {
                var exp = string.Format(@"^({0})[-\t ]?({1})[-\t ]?(", CountryCode, MobilePrefix);
                for (int i = 0; i < NumberOfDigitsAfterMobilePrevix; i++)
                {
                    exp += @"\d";
                }

                exp = exp + ")$";
                return exp;
            }
        }

    }
}
