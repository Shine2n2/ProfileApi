using ProfileAPI.DTOs;

namespace ProfileAPI.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfileAsync();
    }

}
