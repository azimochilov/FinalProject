using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Data.Repository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class UserService : IUserService
{
    private IUserRepository userRepository = new UserRepository();    
    public async ValueTask<Response<UserDto>> AddAsync(UserDto model)
    {
        var existingEntity = userRepository.SelectAllAsync()
            .Where(u => u.Username == model.Username).ToList();

        if (existingEntity.Any())
            return new Response<UserDto>
            {
                Code = 400,
                Message = "Username is already taken",
                Value = null
            };

        var mappedEntity = new User
        {
            Username = model.Username,            
            CreatedAt = DateTime.Now,
            Password = model.Password,
            Name = model.Name,
            Email= model.Email
        };

        var insertedEntity = await userRepository.InsertAsync(mappedEntity);        
        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = model
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var existingEntity = await userRepository.SelectAsync(id);

        if (existingEntity is null)
            return new Response<bool>
            {
                Code = 404,
                Message = "Not found",
                Value = false
            };

        await userRepository.DeleteAsync(id);

        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllAsync()
    {
        var entities = userRepository.SelectAllAsync().ToList();
        var modelDtos = new List<UserDto>();

        foreach (var item in entities)
        {
            modelDtos.Add(new UserDto
            {
                Username = item.Username,
                Name = item.Name,
                Password= item.Password,
                Email = item.Email
            });
        }

        return new Response<List<UserDto>>
        {
            Code = 200,
            Message = "Success",
            Value = modelDtos
        };
    }

    public async ValueTask<Response<UserDto>> GetByIdAsync(long id)
    {
        var entity = await userRepository.SelectAsync(id);

        if (entity is null)
            return new Response<UserDto>
            {
                Code = 404,
                Message = "Not found"
            };

        var mappedDto = new UserDto
        {
            Username = entity.Username,
            Name = entity.Name,
            Password = entity.Password,
            Email = entity.Email            
        };

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<UserDto>> UpdateAsync(long id, UserDto model)
    {
        var existedEntity = await userRepository.SelectAsync(id);

        if (existedEntity is null)
            return new Response<UserDto>
            {
                Code = 404,
                Message = "Not found"
            };

        existedEntity.Username = model.Username;
        existedEntity.Email = model.Email;
        existedEntity.Name = model.Name;
        existedEntity.Password = model.Password;
        existedEntity.UpdatedAt = DateTime.Now;

        var updatedEntity = await userRepository.UpdateAsync(existedEntity);

        var mappedDto = new UserDto
        {
            Username = updatedEntity.Username,                                    
            Name= updatedEntity.Name,
            Password = updatedEntity.Password,
            Email = updatedEntity.Email
        };

        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedDto
        };
    }
}
