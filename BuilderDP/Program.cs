using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    class Program
    {
        static void Main(string[] args)

        //gerçek hayatla ilişkilenrime yapamdım.
        {
            ProductDirector productDirector = new ProductDirector();
            productDirector.GenerateProduct(new NewCustomerProductBuilder());

            ProductDirector productDirector2 = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector2.GenerateProduct(builder);
            var model = builder.GetModel();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountedApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bevarage";
            model.ProductName = "chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice *(decimal) 0.90;
            model.DiscountedApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bevarage";
            model.ProductName = "chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice * (decimal)0.90;
            model.DiscountedApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }

}
