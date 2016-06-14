using AutoMapper;

namespace DQuery.Mapper
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, byte[]>().ConvertUsing(new Base64Converter());
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
