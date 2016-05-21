
namespace DQuery.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToStringOrEmpty(this object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }
    }
}
