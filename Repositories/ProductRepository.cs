using System;
using Dapper;
using ProductsAPI.Helpers;
using WebApi.Entities;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> GetByEmail(string email);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Products
        """;
            return await connection.QueryAsync<Product>(sql);
        }

        public async Task<Product> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Products 
            WHERE Id = @id
        """;
            return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { id });
        }

        public async Task<Product> GetByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Products 
            WHERE Email = @email
        """;
            return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { email });
        }

        public async Task Create(Product Product)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            INSERT INTO Products (Descricao,Nome,Preco)
            VALUES (@Descricao,@Nome,@Preco)
        """;
            await connection.ExecuteAsync(sql, Product);
        }

        public async Task Update(Product Product)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            UPDATE Products 
            SET Descricao = @Descricao,
                Nome = @Nome,
                Preco = @Preco
            WHERE Id = @Id
        """;
            await connection.ExecuteAsync(sql, Product);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM Products 
            WHERE Id = @id
        """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}