using BookStoreAPI.Configurations;
using BookStoreAPI.Models;
using Lib.Helper;
using Lib.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreAPI.Orchestrations
{
    public class BookOrchestrator
    {
        private readonly IOptions<OrderConfiguration> _orderConfiguration;
        private readonly IOptions<StoreConfiguration> _storeConfiguration;
        public BookOrchestrator(IOptions<OrderConfiguration> orderConfiguration, IOptions<StoreConfiguration> storeConfiguration)
        {
            _orderConfiguration = orderConfiguration;
            _storeConfiguration = storeConfiguration;
        }

        public string CreateOrder(Order order, CancellationToken cancellationToken)
        {
            //The book order is available, isn't it
            return XmlHelper.SerializeXmlObjectToFile<Order>(order, _orderConfiguration.Value.Path);
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            ConcurrentBag<Book> listBook = new ConcurrentBag<Book>();

            var storeATasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreA.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                listBook.Add(book);
            });
            var storeBTasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreB.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                listBook.Add(book);
            });

            await Task.WhenAll(storeATasks);
            await Task.WhenAll(storeBTasks);

            return listBook;
        }

        public async Task<IEnumerable<BookStoreModel>> GetBook(string id)
        {
            ConcurrentBag<BookStoreModel> listBook = new ConcurrentBag<BookStoreModel>();

            var storeATasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreA.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                if (book.ISBNCode == id)
                {
                    listBook.Add(new BookStoreModel
                    {
                        ISBNCode = book.ISBNCode,
                        Author = book.Author,
                        BookName= book.Name,
                        Store = new StoreModel
                        {
                            StoreID = "IDStoreA",
                            StoreName = "StoreA",
                            Price = book.Price,
                            Quantity = book.Quantity
                        }
                    });
                }
            });
            var storeBTasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreB.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                if (book.ISBNCode == id)
                {
                    listBook.Add(new BookStoreModel
                    {
                        ISBNCode = book.ISBNCode,
                        Author = book.Author,
                        BookName = book.Name,
                        Store = new StoreModel
                        {
                            StoreID = "IDStoreB",
                            StoreName = "StoreB",
                            Price = book.Price,
                            Quantity = book.Quantity
                        }
                    });
                }
            });

            await Task.WhenAll(storeATasks);
            await Task.WhenAll(storeBTasks);

            return listBook;
        }

        public async Task<IEnumerable<Book>> SearchtBook(string searchString)
        {
            ConcurrentBag<Book> listBook = new ConcurrentBag<Book>();

            var storeATasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreA.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                if (book.Name.Contains(searchString)|| book.ISBNCode.Contains(searchString)|| book.Author.Contains(searchString))
                {
                    listBook.Add(book);
                }
            });
            var storeBTasks = Directory.EnumerateFiles(_storeConfiguration.Value.StoreB.Path, "*.xml").Select(async c =>
            {
                string contents = File.ReadAllText(c);
                var book = XmlHelper.DeserializeXmlFileToObject<Book>(contents);
                if (book.Name.Contains(searchString) || book.ISBNCode.Contains(searchString) || book.Author.Contains(searchString))
                {
                    listBook.Add(book);
                }
            });

            await Task.WhenAll(storeATasks);
            await Task.WhenAll(storeBTasks);

            return listBook;
        }
    }
}
