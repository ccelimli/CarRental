﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //Add
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(rent => rent.Id == rental.Id && (rent.ReturnDate==null || rent.ReturnDate>DateTime.Now)).Any();
            if (result)
            {
                return new ErrorResult(Messages.CannotRent);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded); 
            }
        }

        //Delete
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //GetAll
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalsListed);
        }

        //GetByCarId
        public IDataResult<List<Rental>> GetByCarId(int CarId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental=>rental.CarId==CarId),Messages.RentalsListed);
        }

        //GetByCustomerId
        public IDataResult<List<Rental>> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental=>rental.CustomerId==CustomerId),Messages.RentalsListed);
        }

        //GetById
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental=>rental.Id==Id),Messages.RentalListed);
        }

        //GetByRentDate
        public IDataResult<List<Rental>> GetByRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental=>rental.RentDate==rentDate),Messages.RentalsListed);
        }

        //GetByReturnDate
        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental => rental.ReturnDate == returnDate), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalsListed);
        }

        //Update
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}