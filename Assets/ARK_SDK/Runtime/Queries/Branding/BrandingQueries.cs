namespace ARK.SDK.Queries.Branding
{
    public static class BrandingQueries
    {
        public const string Branding = @"
                    query Branding {
              branding {
                customColor
                image
                logoBgColor
                primaryColor
                secondaryColor
              }
            }";
    }
}