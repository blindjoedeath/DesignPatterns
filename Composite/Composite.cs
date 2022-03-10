using System;
using System.Linq;
using System.Collections.Generic;	

namespace Patterns.Composite
{
	public interface IMonetary
	{
		double GetPrice();
	}

	public class Product: IMonetary
	{
		double price;
		string name;

		public Product(double price, string name)
		{
			this.price = price;
			this.name = name;
		}

		public double GetPrice()
		{
			Console.WriteLine($"Getting price of product: {this.name}");
			return this.price;
		}
	}

	public class Combo: IMonetary
	{
		Product[] products;
		double discount;

		public Combo(Product[] products, double discount)
		{
			this.products = products;
			this.discount = discount;
		}

		public double GetPrice()
		{
			Console.WriteLine($"Getting price of combo");
			return this.products.Aggregate(0.0, (seed, product) => seed + product.GetPrice()) - this.discount;
		}
	}

	public class Cart: IMonetary
	{
		public Product[] products;

		public Combo[] combos;

		public double credits;

		public Cart(Product[] products, Combo[] combos, double credits)
		{
			this.products = products;
			this.combos = combos;
			this.credits = credits;
		}
		
		public Double GetPrice()
		{ 
			return (this.products as IMonetary[]).Concat(this.combos)
				.Aggregate(0.0, (seed, moneraty) => seed + moneraty.GetPrice()) - this.credits;
		}
	}
}