using SalesManagementSystem.DAL.Repositories;
using SalesManagementSystem.DATA.Entites;
using SalesManagementSystem.SERVICE.DTOs.UserModels;
using SalesManagementSystem.SERVICE.Interfaces;

namespace SalesManagementSystem.SERVICE;

public class UserService :IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;   
    }
    
    
    
    public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserModel
        {
            UserName = user.UserName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            UserId = user.UserId
        });
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserModel>> GetAllUsersWithPersonAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return null;

        }
        return new UserModel
        {
            UserName = user.UserName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            
        };


    }

   

    public Task<ResponseModel> UpdateUserAsync(int userId, UpdateUserModel userModel)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel> RegisterUserAsync(RegisterUserModel userModel)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(userModel.Email);
        if (existingUser!=null)
        {
            return new ResponseModel { Success = false, Massage = "User already exists" };
        }

        Person newPerson = new Person()
        {
            FirstName = userModel.Person.FirstName,
            LastName = userModel.Person.LastName,
            Address = userModel.Person.Addres,
            Phone = userModel.Person.Phone,
            PersonTypeID = 1

        };
    
        var newUser = new User
        {
            UserName = userModel.UserName,
            Email = userModel.Email,
            PasswordHash = userModel.Password,
        };
        await _userRepository.AddAsync(newUser);    
        
        return new ResponseModel{Success = true, Massage = "User created successfully!"};   
    }

    public Task<ResponseModel> UpdateUserAsync(UpdateUserModel userModel)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> LoginUserAsync(LoginModel userModel)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel> AssignRoleAsync(int userId, int roleId)
    {
        throw new NotImplementedException();
    }
}