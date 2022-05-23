﻿using Application.Contracts.Persistence;
using Dapper;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemRepository : IItemRepository<Entity>
    {
        public ItemRepository()
        {
        }
        private IDbConnection NewConnection()
        {
            return new SqlConnection(new ConnectionString().GetConnectionString());
        }
        public async Task<int> AddAsync(Entity entity)
        {
            using (var conn = NewConnection())
            {
                if (entity is Book book)
                {
                    int id = await conn.QuerySingleAsync<int>("INSERT INTO [ItemDescriptor] OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = book.Title, Author = book.Author, Publisher = book.Publisher, Year = book.Year, Description = book.Description, Borrow_Type = book.Borrow_Type.ToString(), ID_Type = "Book" });
                    await conn.ExecuteAsync("INSERT INTO [Book] VALUES(@ID, @ISBN, @Subject, @Edition)", new { ID = id, ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition });
                    return id;
                }
                else if (entity is Map map)
                {
                    int id = await conn.QuerySingleAsync<int>("INSERT INTO [ItemDescriptor] OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = map.Title, Author = map.Author, Publisher = map.Publisher, Year = map.Year, Description = map.Description, Borrow_Type = map.Borrow_Type.ToString(), ID_Type = "Map" });
                    await conn.ExecuteAsync("INSERT INTO [Map] VALUES(@ID)", new { ID = id});
                    return id;
                }
                else if (entity is Article article)
                {
                    int id = await conn.QuerySingleAsync<int>("INSERT INTO [ItemDescriptor] OUTPUT inserted.id VALUES(@Title, @Author, @Publisher, @Year, @Description, @Borrow_Type, @ID_Type)",
                        new { Title = article.Title, Author = article.Author, Publisher = article.Publisher, Year = article.Year, Description = article.Description, Borrow_Type = article.Borrow_Type.ToString(), ID_Type = "Article" });
                    await conn.ExecuteAsync("INSERT INTO [Article] VALUES(@ID, @Subject, @ReleaseDate)", new { ID = id, Subject = article.Subject, ReleaseDate = article.ReleaseDate });
                    return id;
                }
                return 0;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = NewConnection())
            {
                String type = await conn.QuerySingleAsync<String>("SELECT [ItemDescriptor].[ItemDescriptor_Type] FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                if(type == "Book")
                {
                    await conn.ExecuteAsync("DELETE FROM [BOOK] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                else if(type == "Map")
                {
                    await conn.ExecuteAsync("DELETE FROM [Map] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                else if(type == "Article")
                {
                    await conn.ExecuteAsync("DELETE FROM [Article] WHERE ID = @ID", new { ID = id });
                    return await conn.ExecuteAsync("DELETE FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });
                }
                return 0;
            }
        }

        public async Task<Result<Entity>> GetByIdAsync(int id)
        {
            using (var conn = NewConnection())
            {
                String type = await conn.QuerySingleAsync<String>("SELECT [ItemDescriptor].[ItemDescriptor_Type] FROM [ItemDescriptor] WHERE ID = @ID", new { ID = id });

                if (type == "Book")
                {
                    return await conn.QuerySingleAsync<Book>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher], [Book].[ISBN], [BOOK].[Subject], [BOOK].[Edition] FROM [ItemDescriptor] INNER JOIN [Book] ON [ItemDescriptor].[ID] = [Book].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else if (type == "Map")
                {
                    return await conn.QuerySingleAsync<Map>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher] FROM [ItemDescriptor] INNER JOIN [Map] ON [ItemDescriptor].[ID] = [Map].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else if (type == "Article")
                {
                    return await conn.QuerySingleAsync<Article>("SELECT [ItemDescriptor].[ID], [ItemDescriptor].[Year], [ItemDescriptor].[Author], [ItemDescriptor].[Title], [ItemDescriptor].[Borrow_Type], " +
                        "[ItemDescriptor].[Description], [ItemDescriptor].[Publisher], [Article].[Subject], [Article].[ReleaseDate] FROM [ItemDescriptor] INNER JOIN [Article] ON [ItemDescriptor].[ID] = [Article].[ID] " +
                        "WHERE [ItemDescriptor].[ID] = @ID", new { ID = id });
                }
                else { throw new Exception(); }
            }
        }

        public async Task<int> UpdateAsync(Entity entity)
        {
            using(var conn = NewConnection())
            {
                if (entity is Book book)
                {
                    await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = book.Title, Author = book.Author, Publisher = book.Publisher, Year = book.Year, Description = book.Description, bt = book.Borrow_Type.ToString(), ID = book.ID });
                    return await conn.ExecuteAsync("UPDATE [Book] SET ISBN = @ISBN, Subject = @Subject, Edition = @Edition WHERE ID = @ID", new { ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition, ID = book.ID });
                }
                else if (entity is Map map)
                {
                    return await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = map.Title, Author = map.Author, Publisher = map.Publisher, Year = map.Year, Description = map.Description, bt = map.Borrow_Type.ToString(), ID = map.ID });
                    //return await conn.ExecuteAsync("UPDATE [MAP] SET ISBN = @ISBN, Subject = @Subject, Edition = @Edition", new { ISBN = book.ISBN, Subject = book.Subject, Edition = book.Edition });
                }
                else if (entity is Article article)
                {
                    await conn.ExecuteAsync("UPDATE [ItemDescriptor] SET Title = @Title, Author = @Author, Publisher = @Publisher, Year = @Year, Description = @Description, Borrow_Type = @bt WHERE ID = @ID",
                        new { Title = article.Title, Author = article.Author, Publisher = article.Publisher, Year = article.Year, Description = article.Description, bt = article.Borrow_Type.ToString(), ID = article.ID });
                    return await conn.ExecuteAsync("UPDATE [Article] SET Subject = @Subject, ReleaseDate = @ReleaseDate WHERE ID = @ID", new { Subject = article.Subject, ReleaseDate = article.ReleaseDate, ID = article.ID });
                }
                return 0;
            }
        }
    }
}
