using BookRental.Common;
using BookRental.Data;
using BookRental.Model.DTO;

namespace BookRental
{
    public class LoansManager
    {
        public Result LoanBook(DateTime dateOfLoan, int readerId, string bookTitle)
        {
            Result result = new Result(true, string.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    //checking if book is available

                    //Create list of book IDs, that have a specific Title
                    var bookList = context.Books.Where(book => book.Title.ToLower().Equals(bookTitle.ToLower())).ToList();

                    //if list of book IDs is null or empty, there is no book with this title in the book rental
                    if (bookList == null)
                        return new Result(false, "There is no book with this title in the book rental");

                    if (bookList.Count == 0)
                        return new Result(false, "There is no book with this title in the book rental");

                    //check if the book with the specified id has ever been loanses or has been returned
                    int bookIdToLoan = -1;
                    for(int i = 0; i < bookList.Count; i++)
                    {
                        var everLoanses = context.Loans.Any(p => p.BookId == bookList[i].Id);
                        if(!everLoanses)
                        {
                            bookIdToLoan = bookList[i].Id;
                            break;
                        }
                        var bookIsNotAvailable = context.Loans.Where(p => p.BookId == bookList[i].Id).Where(r => r.DateOfReturn == null).Any();
                        if (!bookIsNotAvailable)
                        {
                            bookIdToLoan = bookList[i].Id;
                            break;
                        }
                    }

                    if (bookIdToLoan == -1)
                        return new Result(false, "There is no book available with the given title");

                    LoanDto loanDto = new LoanDto()
                    {
                        DateOfLoan = dateOfLoan,
                        DateOfReturn = null,
                        ReaderId = readerId,
                        BookId = bookIdToLoan
                    };

                    context.Loans.Add(loanDto);
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

        public Result ReturnBook(DateTime dateOfReturn, int bookId)
        {
            Result result = new Result(true, string.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    var entity = context.Loans.Where(loan => loan.BookId == bookId && loan.DateOfReturn == null).FirstOrDefault();

                    if(entity == null)
                        return new Result(false, "There is no loanses book with specific title");

                    entity.DateOfReturn = dateOfReturn;

                    context.Loans.Update(entity);
                    context.SaveChanges();

                }
            }
            catch (Exception e )
            {
                result.IsSuccess = false;
                result.Description = e.Message;
            }

            return result;
        }
    }
}
