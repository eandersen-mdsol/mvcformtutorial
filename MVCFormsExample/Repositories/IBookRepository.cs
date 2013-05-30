using System;
using System.Collections.Generic;
using MVCFormsExample.Models;

namespace MVCFormsExample.Repositories
{
    public interface IBookRepository
    {
        Book GetById(Guid id);
        void Upsert(Book book);
        IEnumerable<Book> All { get; }
    }
}