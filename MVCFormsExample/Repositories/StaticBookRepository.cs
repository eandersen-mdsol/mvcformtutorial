using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MVCFormsExample.Models;

namespace MVCFormsExample.Repositories
{
    public class StaticBookRepository : IBookRepository
    {
        private static readonly ConcurrentDictionary<Guid, Book> Books = new ConcurrentDictionary<Guid, Book>();

        public Book GetById(Guid id)
        {
            return !Books.ContainsKey(id) ? null : Books[id];
        }

        public void Upsert(Book book)
        {
            Books[book.Id] = book;
        }

        public IEnumerable<Book> All { get { return Books.Values; } }
    }
}