using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //Add
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
        }

        //Delete
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        //GetAll
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        //GetByCompanyName
        public IDataResult<List<Customer>> GetByCompanyName(string companyName)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(customer => customer.CompanyName == companyName), Messages.CustomersListed);
        }

        //GetById
        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(customer =>new User().Id == Id), Messages.CustomerListed);
        }

        //Update
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}