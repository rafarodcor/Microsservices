using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private NpgsqlConnection GetConnectionPostgreSQL()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            var connection = GetConnectionPostgreSQL();
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
                return new Coupon { ProductName = "No discount", Amount = 0, Description = "No discount Description" };

            return coupon;
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            var connection = GetConnectionPostgreSQL();

            var created = await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { coupon.ProductName, coupon.Description, coupon.Amount });

            if (created == 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            var connection = GetConnectionPostgreSQL();

            var updated = await connection.ExecuteAsync
                ("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });

            if (updated == 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            var connection = GetConnectionPostgreSQL();

            var deleted = await connection.ExecuteAsync
               ("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (deleted == 0)
                return false;

            return true;
        }
    }
}