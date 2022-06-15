using DataAccessLayer.Absract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserMessageDal : GenericRepository<UserMessage>, IUserMessageDal
    {
        public List<UserMessage> GetUserMessagesWithUser()
        {
           using (var c=new Context())
            {
                //ınclude referans işlmindeki user tablosuna girmesini sağlıyor hata fırlatmsını önlüyor.
                return c.UserMessages.Include(x => x.User).ToList();
            }
        }
    }
}
