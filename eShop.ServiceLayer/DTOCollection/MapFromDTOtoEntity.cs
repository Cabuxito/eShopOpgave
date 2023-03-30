using eShop.ServiceLayer.ModelsDTO;
using eShop.DataLayer.Entities;

namespace eShop.ServiceLayer.DTOCollection
{
    public static class MapFromDTOtoEntity
    {
        public static Product ConvertFromDTOtoProduct (this ProductsDTO productsDTO)
        {
            return new Product
            {
                ProductId = productsDTO.MasterKey,
                Title = productsDTO.Title,
                Description = productsDTO.Description,
                Price = productsDTO.Price,
                Stock = productsDTO.Stock,
                Manufacture = productsDTO.Manufacture,
            };
        }

        public static Orders ConvertFromDTOtoOrders(this OrderProductsDTO ordersDTO)
        {
            return new Orders
            {
                BuyDate = ordersDTO.BuyDate,

            };
        }

        public static Customer ConvertFromDTOtoCustomer(this CustomerDTO customerDTO)
        {
            return new Customer
            {
                CustomerID = customerDTO.PrivateNumber,
                Firstname = customerDTO.Firstname,
                Lastname = customerDTO.Lastname,
                Address = customerDTO.Address,
                Email= customerDTO.Email,
            };
        }

    }
}
