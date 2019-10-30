﻿using eCommerce.DAL.Data;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
	public class ProductRepository : RepositoryBase<Product>
	{
		public ProductRepository(DataContext context): base (context)
		{
			if (context == null)
			{
				throw new ArgumentException();
			}
		}
	}
}

//		internal DataContext context;
//		public ProductRepository(DataContext context)
//		{
//			this.context = context;
//		}

//		public virtual Product GetById(object id)
//		{
//			return context.Products.Find(id);
//		}

//		public virtual IQueryable<Product> GetAll()
//		{
//			return context.Products;
//		}

//		public virtual void Insert(Product entity)
//		{
//			context.Products.Add(entity);
//		}

//		public virtual void Update(Product entity)
//		{
//			context.Products.Attach(entity);
//			context.Entry(entity).State = EntityState.Modified;
//		}

//		public virtual void Delete(Product entity)
//		{
//			if (context.Entry(entity).State == EntityState.Detached)
//				context.Products.Attach(entity);

//			context.Products.Remove(entity);
//		}
//	}
//}
