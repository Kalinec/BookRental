using BookRental.Common;
using BookRental.Data;
using BookRental.Model;
using BookRental.Model.Models;
using BookRental.Models.Enums;

namespace BookRental
{
    public class ReadersManager
    {
        public Result AddReader(Reader reader)
        {
            Result result = new Result(true, string.Empty);

            ReaderDto readerDto = new ReaderDto()
            {
                Name = reader.Name,
                Surname = reader.Surname,
                Pesel = reader.Pesel,
                RoleId = (int) reader.Role
            };

            try
            {
                using (var context = new BookRentalContext())
                {
                    context.Readers.Add(readerDto);
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

        public Result UpdateReader(Reader reader)
        {
            Result result = new Result(true, String.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    var entity = context.Readers.Where(p => p.Id == reader.Id).FirstOrDefault();

                    if (entity == null)
                        return new Result(false, "No entity to update");

                    Role currentRole = (Role)entity.RoleId;
                    Role newRole = reader.Role;
                    if (currentRole.Equals(Role.lecturer) && newRole.Equals(Role.student))
                        return new Result(false, "Can't cast lecturer to student role");
                    if (currentRole.Equals(Role.employee) && !newRole.Equals(Role.employee))
                        return new Result(false, "Can't cast employee to another role");

                    entity.Name = reader.Name;
                    entity.Surname = reader.Surname;
                    entity.Pesel = reader.Pesel;
                    entity.RoleId = (int) reader.Role;

                    context.Readers.Update(entity);
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

        public Result DeleteReader(int readerId)
        {
            Result result = new Result(true, string.Empty);

            try
            {
                using (var context = new BookRentalContext())
                {
                    var entity = context.Readers.Where(p => p.Id == readerId).FirstOrDefault();

                    if (entity == null)
                        return new Result(false, "No entity to delete");

                    context.Readers.Remove(entity);
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
