using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int Id);
        IDataResult<List<Rental>> GetByCarId(int CarId);
        IDataResult<List<Rental>> GetByCustomerId(int CustomerId);
        IDataResult<List<Rental>> GetByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetByReturnDate(DateTime returnDate);
    }
}
