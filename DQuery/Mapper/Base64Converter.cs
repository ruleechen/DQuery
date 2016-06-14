using AutoMapper;

namespace DQuery.Mapper
{
    public class Base64Converter : ITypeConverter<string, byte[]>
    {
        public byte[] Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull)
            {
                return null;
            }

            var base64String = context.SourceValue.ToStringOrEmpty();

            if (string.IsNullOrEmpty(base64String))
            {
                return new byte[0];
            }

            return System.Convert.FromBase64String(base64String);
        }
    }
}
