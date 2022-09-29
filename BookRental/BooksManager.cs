using BookRental.Common;
using BookRental.Data;
using BookRental.Model.DTO;
using BookRental.Model.Models;

namespace BookRental
{
    public class BooksManager
    {
        public Result AddBook(Book book)
        {
            Result result = new Result(true, string.Empty);

            BookDTO bookDto = new BookDTO()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
            };

            try
            {
                using (var context = new BookRentalContext())
                {
                    context.Books.Add(bookDto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Description = e.Message;
            }

            return result;
        }

        public Result UpdateBook(Book book)
        {
            Result result = new Result(true, string.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    var entity = context.Books.Where(p => p.Id == book.Id).FirstOrDefault();

                    if (entity == null)
                        return new Result(false, "No entity to update");

                    entity.Title = book.Title;
                    entity.Author = book.Author;
                    entity.ISBN = book.ISBN;

                    context.Books.Update(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Description = e.Message;
            }

            return result;
        }

        public Result DeleteBook(int bookId)
        {
            Result result = new Result(true, string.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    var entity = context.Books.Where(p => p.Id == bookId).FirstOrDefault();

                    if (entity == null)
                        return new Result(false, "No entity to update");

                    context.Books.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Description = e.Message;
            }

            return result;
        }
    }
}
