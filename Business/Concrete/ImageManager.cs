using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, Image image)
        {
            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(true,"Resim Eklendi");
            
        }

        public IResult Delete(Image image)
        {
            FileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAllByImage()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetImageByCarId(int carId)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(p=>p.CarId==carId));
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = FileHelper.Update(_imageDal.Get(p => p.ImageId == image.ImageId)
                .ImagePath, file);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(true,"Güncelleme Başarılı");
        }
    }
}
