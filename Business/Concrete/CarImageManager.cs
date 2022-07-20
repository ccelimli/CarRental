using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        //Add
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var resultofUpload= _fileHelper.Upload(file, PathConstant.ImagePath);
            if (!resultofUpload.Success)
            {
                return resultofUpload;
            }
            carImage.ImagePath = resultofUpload.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        //Delete
        public IResult Delete(CarImage carImage)
        {
            var result= _fileHelper.Delete(PathConstant.ImagePath + carImage.ImagePath);
            if (!result.Success)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        //GetAll
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        //GetByCarId
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carId));
            if (result != null)
            {
                return GetDefaultImage(carId);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(carImage => carImage.CarId == carId), Messages.ImagesListed);
        }

        //GetByImageId
        public IDataResult<CarImage> GetByImageId(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carImage => carImage.Id == Id), Messages.ImageListed);
        }

        //Update
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _fileHelper.Update(file, PathConstant.ImagePath + carImage.ImagePath, PathConstant.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            carImage.Date=DateTime.Now;
            carImage.ImagePath = result.Message;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        //GetDefaultImage
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            var defaultCarImage = new List<CarImage>();
            defaultCarImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "no-photos.png" });

            return new SuccessDataResult<List<CarImage>>(defaultCarImage);
        }

        //CheckIfCarImageLimit
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        //CheckCarImage
        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(carImage => carImage.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
