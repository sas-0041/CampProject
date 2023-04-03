using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
           _colorDal.Add(color);
            return new SuccessResult(true, "Renk Eklendi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color); 
            return new SuccessResult(true, "Renk silindi");
        }

        public IDataResult<List<Color>> GetAllByColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co=>co.ColorId==colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(true, "Renk güncellendi");
        }
    }
}
