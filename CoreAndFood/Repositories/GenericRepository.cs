using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
	public class GenericRepository<T> where T : class,new()
	{

		Context context = new Context();

		public List<T> TList()
		{
			return context.Set<T>().ToList();
		}

		public void TAdd(T t)
		{
			context.Set<T>().Add(t);
			context.SaveChanges();
		}
		public void TDelete(T t)
		{
			context.Set<T>().Remove(t);
			context.SaveChanges();
		}
		public void TUpdate(T t)
		{
			context.Set<T>().Update(t);
			context.SaveChanges();
		}

		public T TGet(int id)
		{
			return context.Set<T>().Find(id);

		}

		public List<T> TList(string p) 
		{
			return context.Set<T>().Include(p).ToList();
		}

		//belirli bir özelliğe göre arama yapmak istediğimiz zaman kullanacağımız fonksiyon
		public List<T> List(Expression<Func<T, bool>> filter) 
		{
		   return context.Set<T>().Where(filter).ToList();
		}
	}
}
