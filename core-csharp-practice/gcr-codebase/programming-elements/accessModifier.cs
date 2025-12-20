using System;
namespace ProjectA
{
	public class Base{
		public string public1 = "public";
		private string private1 = "private";
		internal string internal1 = "internal";
		protected string protected1 = "protected";
		protected internal string protected_internal = "protected_internal";
		private protected string private_protected = "private_protected";
			
		public void SameClass(){
			//all are accessible here.
			Console.WriteLine("--- Inside Same Class ---");
			Console.WriteLine(private1);
			Console.WriteLine(public1);
			Console.WriteLine(internal1);
			Console.WriteLine(protected1);
			Console.WriteLine(protected_internal);
			Console.WriteLine(private_protected);
		}
	}
		
	// derived class
	
	public class Derived : Base{
		public void Test(){
			Console.WriteLine("\n Inside Derived Class(Same Project)");
			//Console.WriteLine(private1); this is not accessible here, everyone is accessible except private
			Console.WriteLine(public1);
			Console.WriteLine(internal1);
			Console.WriteLine(protected1);
			Console.WriteLine(protected_internal);
			Console.WriteLine(private_protected);
			
		}
	
	}
	
	//non derived class
	public class NonDerived{
		public void Test(){
			Base obj = new Base();
			Console.WriteLine("\n Inside NonDerived Class(Same Project)");
			//Console.WriteLine(private1); private is not accessible here
			Console.WriteLine(obj.public1);
			Console.WriteLine(obj.internal1);
			//Console.WriteLine(protected1); protected is not accessible here
			Console.WriteLine(obj.protected_internal); 
			//Console.WriteLine(obj.private_protected);private_protected is not accessible here
		}
	
	}
	
	public class Program{
	
		public static void Main(string[]args){
			Base ob = new Base();
			ob.SameClass();
			Derived d = new Derived();
			d.Test();

			NonDerived nd = new NonDerived();
			nd.Test();
		
		}
	}
		
		
}
