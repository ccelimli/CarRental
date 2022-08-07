using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        IDataResult<List<User>> GetByFirstName(string Name);
        IDataResult<List<User>> GetByLastName(string lastName);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByPhoneNumber(string PhoneNumber);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
