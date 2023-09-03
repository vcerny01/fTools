using System;
using System.Drawing;

namespace fBarcode.Exceptions
{
	public class OrderNotFoundException : Exception
	{
        public override string Message { get; }
		public OrderNotFoundException(string orderNumber)
		{
			Message = $"Objednávka s číslem {orderNumber} nebyla v databázi nalezena.";
		}
    }
	public class CourierNotFoundException : Exception
	{
        public override string Message { get; }
		public CourierNotFoundException(string orderNumber, string refDopravci)
		{
			Message = $"Dopravce (RefDopravci = {refDopravci}) pro objednávku s číslem {orderNumber} chybí nebo není podporován.";
		}
    }
	public class OrderParameterNotFoundException : Exception
	{
        public override string Message { get;}
		public OrderParameterNotFoundException(string orderNumber, string parameterName)
		{
			Message = $"U objednávky s číslem {orderNumber} je parametr {parameterName} ve špatném formátu nebo chybí.";
		}
    }
}