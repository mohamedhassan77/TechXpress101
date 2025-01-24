using TechXpress.Data;
using TechXpress.Models;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync();
    Task<UserProfile> GetUserProfileByIdAsync(int id);
    Task AddUserProfileAsync(UserProfile userProfile);
    Task UpdateUserProfileAsync(UserProfile userProfile);
    Task DeleteUserProfileAsync(int id);
}

public class UserProfileService : IUserProfileService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync()
    {
        return await _unitOfWork.UserProfiles.GetAllAsync();
    }

    public async Task<UserProfile> GetUserProfileByIdAsync(int id)
    {
        return await _unitOfWork.UserProfiles.GetByIdAsync(id);
    }

    public async Task AddUserProfileAsync(UserProfile userProfile)
    {
        await _unitOfWork.UserProfiles.AddAsync(userProfile);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateUserProfileAsync(UserProfile userProfile)
    {
        _unitOfWork.UserProfiles.Update(userProfile);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteUserProfileAsync(int id)
    {
        var userProfile = await _unitOfWork.UserProfiles.GetByIdAsync(id);
        if (userProfile != null)
        {
            _unitOfWork.UserProfiles.Remove(userProfile);
            await _unitOfWork.CompleteAsync();
        }
    }


}