using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class BasketVoucher
	{
		public int basketVoucherType { get; set; }
		
		public int voucherId { get; set; }
		public Guid basketId { get; set; }
		[MaxLength(10)]
		public string voucherCode { get; set; }
		[MaxLength(100)]
		public string voucherType { get; set; }
		public decimal value { get; set; }
		[MaxLength(150)]
		public string voucherDescription { get; set; }
		public int appliesToProductId { get; set; }
	}
}
