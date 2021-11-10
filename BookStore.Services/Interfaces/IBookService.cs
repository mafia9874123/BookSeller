using Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        string CreateOrder(Order order, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetAllBook();
        Task<IEnumerable<BookStoreModel>> GetBook(string id);
        Task<IEnumerable<Book>> SearchtBook(string searchString);
    }
}
