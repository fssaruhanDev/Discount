using Discount.Data.ORM.Base;
using Discount.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.BASE
{
    public class BaseLogic<T> : IDisposable where T : BaseEntity
    {

        protected EntityConnection db;
        protected DbSet<T> _context;


        public BaseLogic()
        {
        }

        public BaseLogic(EntityConnection entityConnection)
        {

            db = entityConnection;
            _context = db.Set<T>();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public bool Insert(T entity)
        {
            try
            {
                _context.Add(entity);
                entity.CreateDate = DateTime.Now;
                entity.IsActive = true;
                entity.IsDeleted = false;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public T GetByID(int id)
        {
            return _context.FirstOrDefault(x => x.IsActive == true && x.IsDeleted == false && x.ID == id);
        }

        public bool Update(T entity)
        {
            var _entity = _context.Find(entity.ID);
            db.Entry(_entity).CurrentValues.SetValues(entity);
            _entity.IsActive = true;
            _entity.UpdateDate = DateTime.Now;
            SaveChanges();
            return true;
        }

        public List<T> GetLambda(Expression<Func<T, bool>> _lambda)
        {
            string lambda = _lambda.ToString();
            return _context.Where(x => x.IsActive == true && x.IsDeleted == false).Where(_lambda).ToList();
        }


        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(db);
        }
    }
}
