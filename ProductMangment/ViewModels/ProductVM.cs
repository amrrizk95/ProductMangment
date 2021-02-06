using ProductMangment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMangment.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public double Price { get; set; }
        public DateTime LastUpdated { get; set; }


        public static implicit operator ProductVM(Product product)
        {
            var modelVM = new ProductVM();
            modelVM.Name = product.Name;
            modelVM.Id = product.Id;
            modelVM.Price = product.Price;
            modelVM.PhotoPath = product.PhotoPath;
            modelVM.LastUpdated = product.LastUpdated;

            return modelVM;
        }
        public static implicit operator Product(ProductVM productVM)
        {
            var model = new Product();
            model.Name = productVM.Name;
            model.Id = productVM.Id;
            model.Price = productVM.Price;
            model.PhotoPath = productVM.PhotoPath;
            model.LastUpdated = productVM.LastUpdated;

            return model;
        } 

        public static  List<Product> getAll(IUnitOfWork UnitOfWork)
        {
            var result = UnitOfWork.ProductRepository.GetAll();
            return result;
        } 
        public static Product get(IUnitOfWork UnitOfWork,int id)
        {
            return UnitOfWork.ProductRepository.Get(id);
        }
        public static bool AddNew(IUnitOfWork UnitOfWork,Product model)
        {
            try
            {
            model.CreatedDate = DateTime.Now;
            model.LastUpdated = DateTime.Now;
                UnitOfWork.ProductRepository.Add(model);
                UnitOfWork.Complete();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public static bool Edit(IUnitOfWork UnitOfWork, Product model)
        {
            try
            {

                UnitOfWork.ProductRepository.Update(model);
                UnitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public static bool Remove(IUnitOfWork UnitOfWork, int id)
        {
            Product Product = UnitOfWork.ProductRepository.Get(id);
            if (Product==null)
            {
                return false;
            }
            try
            {
                Product.LastUpdated = DateTime.Now;
                UnitOfWork.ProductRepository.Remove(Product);
                UnitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }

}
