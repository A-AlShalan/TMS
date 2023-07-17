using AutoMapper;
using TMS.Dtos;

namespace TMS.Helpers
{
	public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<UpdateTaskDto, Tasks>();
        }
	}
}

