using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Bussiness.Concrete;
using ECommerceApi.Contexts;
using ECommerceApi.DataAccess.Abstract;
using ECommerceApi.DataAccess.EF;
using ECommerceApi.DataAccess.Repositories;

namespace ECommerceApi.Extensions
{
    public static class ServiceExtension
    {

        public static void AddServiceExtension(this IServiceCollection Services) // this bu metodun bir genişletme metodu olduğunu belirtir
        {
            Services.AddDbContext<EDbContext>();

            Services.AddScoped<IProductRepository, EFProductDal>();
            Services.AddScoped<IProductService, ProductManager>();

            Services.AddScoped<IAddressRepository, EFAddressDal>();
            Services.AddScoped<IAddressService, AddressManager>();

            Services.AddScoped<ICategoryRepository, EFCategoryDal>();
            Services.AddScoped<ICategoryService, CategoryManager>();

            Services.AddScoped<ICommentRepository, EFCommentDal>();
            Services.AddScoped<ICommentService, CommentManager>();

            Services.AddScoped<IOrderRepository, EFOrderDal>();
            Services.AddScoped<IOrderService, OrderManager>();
            
            Services.AddScoped<IPictureRepository, EFPictureDal>();
            Services.AddScoped<IPictureService, PictureManager>();
            
            Services.AddScoped<IStoreRepository, EFStoreDal>();
            Services.AddScoped<IStoreService, StoreManager>();
            
            Services.AddScoped<IUserRepository, EFUserDal>();
            Services.AddScoped<IUserService, UserManager>();
            
            //Services.AddScoped<IRepository, EFDal>();
            //Services.AddScoped<IService, Manager>();


            // Generic yapıları constructurlarda kullandığım için 
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }


    }
}
