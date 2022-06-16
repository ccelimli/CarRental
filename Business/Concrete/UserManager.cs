using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidFirstName);
            }
            if(user.Password.Length<6 || user.Password.Length > 20)
            {
                return new ErrorResult(Messages.InvalidPassword);
            }
            if (user.PhoneNumber.StartsWith("0"))
            {
                return new ErrorResult(Messages.InvalidPhoneNumber);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User> (_userDal.Get(user=>user.Email==email),Messages.UserListed);
        }

        public IDataResult<List<User>> GetByFirstName(string Name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(user=>user.FirstName==Name),Messages.UsersListed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(user=>user.Id==Id),Messages.UserListed);
        }

        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(user=>user.LastName==lastName),Messages.UsersListed);
        }

        public IDataResult<User> GetByPhoneNumber(string PhoneNumber)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.PhoneNumber == PhoneNumber));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}