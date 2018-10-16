using Slugify;

namespace AssignmentWeb.Repository.Helper
{
    public static class Helper
    {
        public static string GenerateSlug(string text)
        {
            SlugHelper slugGenerator = new SlugHelper();

            var slug = slugGenerator.GenerateSlug(text);
            return slug;
        }
    }
}
