using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (true)
            {
                
            }
            _rentalDal.Add(rental);
            return new SuccessResult(true, "Kiralama başarılı.");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(true, "Kiralama Silindi.");
        }

        public IDataResult<List<Rental>> GetAllByResult()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll()); 
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(true, "Kiralama Güncellendi.");
        }
    }
}
