using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BlogAppV1.BusinessLogic.BaseServ
{
    public class BaseService
    {
        protected readonly UnitOfWork unit;
        public CurrentUserDto CurrentUser;

        public BaseService(UnitOfWork unitOfWork, CurrentUserDto currentUserDto)
        {
            unit = unitOfWork;
            CurrentUser = currentUserDto;
        }

        protected TResult ExecuteInTransaction<TResult>(Func<UnitOfWork, TResult> func)
        {
            using(var transactionScope = new TransactionScope())
            {
                var result = func(unit);

                transactionScope.Complete();

                return result;
            }
        }

        protected void ExecuteInTransaction<TResult>(Action<UnitOfWork> action)
        {
            using (var transactionScope = new TransactionScope())
            {
                action(unit);

                transactionScope.Complete();
            }
        }


    }
}
