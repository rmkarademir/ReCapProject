using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color> { 
                new Color{Id=1, Name="Mavi"},
                new Color{Id=2, Name="Kırmızı"},
                new Color{Id=3, Name="Beyaz"},
                new Color{Id=4, Name="Siyah"},
                new Color{Id=5, Name="Gri"},
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToUpdate.Name = color.Name;
        }
    }
}
