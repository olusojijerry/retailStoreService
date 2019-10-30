using eCommerce.Contract.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Services
{
	public class BasketService
	{
		IRepositoryBase<Basket> baskets;
		private IRepositoryBase<Voucher> vouchers;
		private IRepositoryBase<VoucherType> voucherTypes;
		private IRepositoryBase<BasketVoucher> basketVouchers;

		public const string BasketSessionName = "eCommerceBasket";

		public BasketService(IRepositoryBase<Basket> basket, IRepositoryBase<Voucher> voucher, IRepositoryBase<VoucherType>
			voucherType, IRepositoryBase<BasketVoucher> basketVouchers)
		{
			this.baskets = basket;
			this.vouchers = voucher;
			this.voucherTypes = voucherType;
			this.basketVouchers = basketVouchers;
		}

		private Basket createNewBasket(HttpContextBase httpContext)
		{
			//create new cookie
			HttpCookie cookie = new HttpCookie(BasketSessionName);
			//create new basket and set the creation date
			Basket basket = new Basket();
			basket.date = DateTime.Now;
			basket.basketId = Guid.NewGuid();

			//add to the basket and persist to the database
			baskets.Insert(basket);
			baskets.Commit();

			//add basketId to a cookie
			cookie.Value = basket.basketId.ToString();
			cookie.Expires = DateTime.Now.AddDays(1);
			httpContext.Response.Cookies.Add(cookie);

			return basket;
		}

		public bool AddToBasket(HttpContextBase httpContext, int productId, int quantity)
		{
			bool success = true;

			Basket basket = GetBasket(httpContext);
			BasketItem item = basket.basketItems.FirstOrDefault(i => i.productId == productId);

			if(item == null)
			{
				item = new BasketItem()
				{
					basketId = basket.basketId,
					productId = productId,
					quantity = quantity
				};
				basket.basketItems.Add(item);
			}
			else
			{
				item.quantity = item.quantity + quantity;
			}
			baskets.Commit();

			return success;

		}

		public Basket GetBasket(HttpContextBase httpContext)
		{
			HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
			Basket basket = new Basket();

			Guid basketId;

			if (cookie != null)
			{
				if (Guid.TryParse(cookie.Value, out basketId))
				{
					basket = baskets.GetById(basketId);
				}
			}
			else
			{
				basket = createNewBasket(httpContext);
			}
			return basket;
		}

		public void AddVoucher(string voucherCode, HttpContextBase httpContext)
		{
			Basket basket = GetBasket(httpContext);
			Voucher voucher = vouchers.GetAll().FirstOrDefault(v => v.voucherCode == voucherCode);

			if (voucher != null)
			{
				VoucherType voucherType = voucherTypes.GetById(voucher.voucherId);
				if (voucherType != null)
				{
					BasketVoucher basketVoucher = new BasketVoucher();
					if (voucherType.type == "MoneyOff")
					{
						MoneyOff(voucher, basket, basketVoucher);
					}
					if (voucherType.type == "PercentOff")
					{
						PercentOff(voucher, basket, basketVoucher);
					}

					baskets.Commit();
				}
			}
		}
		
		public void MoneyOff(Voucher voucher, Basket basket, BasketVoucher basketVoucher)
		{
			decimal basketTotal = basket.BasketTotal();

			if (voucher.minSpeed < basketTotal)
			{
				basketVoucher.value = voucher.value * -1;
				basketVoucher.voucherCode = voucher.voucherCode;
				basketVoucher.voucherDescription = voucher.voucherDescription;
				basketVoucher.voucherId = voucher.voucherId;
				basket.basketVoucher.Add(basketVoucher);
			}

		}

		public void PercentOff(Voucher voucher, Basket basket, BasketVoucher basketVoucher)
		{
			if (voucher.minSpeed > basket.BasketTotal())
			{
				basketVoucher.value = (voucher.value * (basket.BasketTotal()/100)) * -1 ;
				basketVoucher.voucherCode = voucher.voucherCode;
				basketVoucher.voucherDescription = voucher.voucherDescription;
				basketVoucher.voucherId = voucher.voucherId;
				basket.basketVoucher.Add(basketVoucher);
			}
		}
	}
}
