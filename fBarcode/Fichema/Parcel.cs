using System;
using fBarcode.Exceptions;
using System.Collections.Generic;
using fBarcode.Utils;

namespace fBarcode.Fichema
{
	public abstract class Parcel
	{
		public static Parcel createParcel(string orderNumber)
		{
			if (!PohodaService.hasOrder(orderNumber))
			{
				throw new OrderNotFoundException(orderNumber);
			}
			Dictionary<string, object> orderData = PohodaService.GetOrderData(orderNumber);
			var refDopravci = orderData["refDopravci"];
			try
			{
				switch (Convert.ToInt32(refDopravci))
				{
					case 10:
					case 14:
					case 15:
					case 16:
					case 18:
					case 19:
					case 22:
						return new CzechPostParcel(orderData);
					case 3:
					case 24:
						return new GlsParcel(orderData);
					case 7:
					case 25:
						return new DpdParcel(orderData);
					default:
						throw new CourierNotFoundException(orderNumber, refDopravci.ToString());
				}
			} catch (Exception e)
			{
				throw new CourierNotFoundException(orderNumber, refDopravci.ToString());
			}
		}
		public Parcel(Dictionary<string, object> orderData)
		{
			// TO DO zbytek
			// Ve Fichemě musím doprogramovat konverzi orderData na správné objekty podle toho jaké objekty mi databáze vrátí.
		}
	}



	public class CzechPostParcel : Parcel
	{
		public CzechPostParcel(Dictionary<string, object> orderData) : base(orderData)
		{

		}
	}
	public class DpdParcel : Parcel
	{
		public DpdParcel(Dictionary<string, object> orderData) : base(orderData)
		{

		}
	}
	public class ZasilkovnaParcel : Parcel
	{
		public ZasilkovnaParcel(Dictionary<string, object> orderData) : base(orderData)
		{

		}
	}
	public class GlsParcel : Parcel
	{
		public GlsParcel(Dictionary<string, object> orderData) : base(orderData)
		{

		}
	}
}