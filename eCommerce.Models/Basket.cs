using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class Basket
	{
		public Guid basketId { get; set; }
		public DateTime date { get; set; }
		public virtual ICollection<BasketItem> basketItems { get; set; }
		public virtual ICollection<BasketVoucher> basketVoucher { get; set; }

		public decimal BasketTotal()
		{
			throw new NotImplementedException();
		}
	}
}
