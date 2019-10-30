using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
	public class Voucher
	{
		public int voucherId { get; set; }
		[MaxLength(10)]
		public string voucherCode { get; set; }
		public int voucherType { get; set; }
		[MaxLength(150)]
		public string voucherDescription { get; set; }
		public int appliesToProductId { get; set; }
		public decimal value { get; set; }
		public decimal minSpeed { get; set; }
		public bool multipleUse { get; set; }
		[MaxLength(255)]
		public string assignedTo { get; set; }


	}
}
