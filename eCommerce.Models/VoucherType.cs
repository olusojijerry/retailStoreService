using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
	public class VoucherType
	{
		public int voucherTypeId { get; set; }
		public string voucherModule { get; set; }
		[MaxLength(30)]
		public string type { get; set; }
		[MaxLength(150)]
		public string description { get; set; }
	}
}
