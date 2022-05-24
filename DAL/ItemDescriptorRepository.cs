using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Dapper;
using Domain.AggregateRoots;
using Domain.Common;
using Domain.Entities;

namespace DAL
{
    public class ItemDescriptorRepository : BaseRepository, IItemDescriptorRepository
    {
        public ItemDescriptorRepository(DataContext context) : base(TableNames.ItemDescriptorTableName, context) { }

        public async Task<int> AddAsync(ItemDescriptor entity)
        {
            int id = -1;
            using (var conn = dataContext.CreateConnection())
            {
                if (entity is Book book)
                {
                    await conn.QuerySingleAsync<int>($"INSERT INTO {tableName} OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = book.Title, Author = book.Author, Publisher = book.Publisher, Year = book.Year, Description = book.Description, Borrow_Type = book.BorrowType.ToString(), ID_Type = "Book" });
                    id = await conn.ExecuteAsync("INSERT INTO [Book] VALUES(@ID, @ISBN, @Subject, @Edition)", new { ID = id, ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition });
                }
                else if (entity is Map map)
                {
                    await conn.QuerySingleAsync<int>($"INSERT INTO {tableName} OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = map.Title, Author = map.Author, Publisher = map.Publisher, Year = map.Year, Description = map.Description, Borrow_Type = map.BorrowType.ToString(), ID_Type = "Map" });
                    id = await conn.ExecuteAsync("INSERT INTO [Map] VALUES(@ID)", new { ID = id });
                }
                else if (entity is Article article)
                {
                    await conn.QuerySingleAsync<int>($"INSERT INTO {tableName} OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = article.Title, Author = article.Author, Publisher = article.Publisher, Year = article.Year, Description = article.Description, Borrow_Type = article.BorrowType.ToString(), ID_Type = "Article" });
                    id = await conn.ExecuteAsync("INSERT INTO [Article] VALUES(@ID, @Subject, @ReleaseDate)", new { ID = id, Subject = article.Subject, ReleaseDate = article.ReleaseDate });
                }
                return id;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dataContext.CreateConnection())
            {
                String type = await conn.QuerySingleAsync<String>("SELECT [ItemDescriptor].[ItemDescriptor_Type] FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                if (type == "Book")
                {
                    await conn.ExecuteAsync("DELETE FROM [BOOK] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                else if (type == "Map")
                {
                    await conn.ExecuteAsync("DELETE FROM [Map] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                else if (type == "Article")
                {
                    await conn.ExecuteAsync("DELETE FROM [Article] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                return 0;
            }
        }

        public async Task<IEnumerable<ItemDescriptor>> GetAllAsync()
        {
            using (var connection = dataContext.CreateConnection())
            {
                List<ItemDescriptor> result = new List<ItemDescriptor>();

                // articles
                var articlesQuery = $"SelectAllArticles";
                List<Article> articles = (List<Article>)await connection.QueryAsync<Article>(articlesQuery);
                articles.ForEach(it => result.Add(it));

                // books
                var booksQuery = $"SelectAllBooks";
                List<Book> books = (List<Book>)await connection.QueryAsync<Book>(booksQuery);
                books.ForEach(it => result.Add(it));

                // maps
                var mapsQuery = $"SelectAllMaps";
                List<Map> maps = (List<Map>)await connection.QueryAsync<Map>(mapsQuery);
                maps.ForEach(it => result.Add(it));

                return result;
            }
        }

        public async Task<Result<ItemDescriptor>> GetByIdAsync(int id)
        {
            using (var connection = dataContext.CreateConnection())
            {
                String type = await connection.QuerySingleAsync<String>("SELECT [ItemDescriptor].[ItemDescriptor_Type] FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });

                if (type == "Book")
                {
                    return await connection.QuerySingleAsync<Book>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher], [Book].[ISBN], [BOOK].[Subject], [BOOK].[Edition] FROM [ItemDescriptor] INNER JOIN [Book] ON [ItemDescriptor].[ID] = [Book].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else if (type == "Map")
                {
                    return await connection.QuerySingleAsync<Map>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher] FROM [ItemDescriptor] INNER JOIN [Map] ON [ItemDescriptor].[ID] = [Map].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else if (type == "Article")
                {
                    return await connection.QuerySingleAsync<Article>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher], [Article].[Subject], [Article].[ReleaseDate] FROM [ItemDescriptor] INNER JOIN [Article] ON [ItemDescriptor].[ID] = [Article].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else { throw new Exception(); }
            }
        }

        public async Task<int> UpdateAsync(ItemDescriptor entity)
        {
            using (var conn = dataContext.CreateConnection())
            {
                if (entity is Book book)
                {
                    await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = book.Title, Author = book.Author, Publisher = book.Publisher, Year = book.Year, Description = book.Description, bt = book.BorrowType.ToString(), ID = book.ID });
                    return await conn.ExecuteAsync("UPDATE [Book] SET ISBN = @ISBN, Subject = @Subject, Edition = @Edition WHERE ID = @ID", new { ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition, ID = book.ID });
                }
                else if (entity is Map map)
                {
                    return await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = map.Title, Author = map.Author, Publisher = map.Publisher, Year = map.Year, Description = map.Description, bt = map.BorrowType.ToString(), ID = map.ID });
                    //return await conn.ExecuteAsync("UPDATE [MAP] SET ISBN = @ISBN, Subject = @Subject, Edition = @Edition", new { ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition });
                }
                else if (entity is Article article)
                {
                    await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = article.Title, Author = article.Author, Publisher = article.Publisher, Year = article.Year, Description = article.Description, bt = article.BorrowType.ToString(), ID = article.ID });
                    return await conn.ExecuteAsync("UPDATE [Article] SET Subject = @Subject, ReleaseDate = @ReleaseDate WHERE ID = @ID", new { Subject = article.Subject, ReleaseDate = article.ReleaseDate, ID = article.ID });
                }
                return 0;
            }
        }
    }
}
