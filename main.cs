using System;

//you need a subscriber: class that has functions that do things - Main has functions that print stuff
//you need a publisher: class that has event that can hold functions to do stuff - Dog has Bark event

class MainClass {
	public static void Main() {
		Console.WriteLine("Hello!");
		Dog odie = new Dog();
		odie.Bark += KaushikHeardBark; //adding subscriber 1
		odie.Bark += ShreyaHeardBark; //adding subscriber 2
		//odie.Bark += RaviHeardBark; does not work b/c EventHandler delegate has format of void return and takes in object, and EventArgs as params
		odie.OnBark(EventArgs.Empty); //calling the OnBark function
	}

	public static void KaushikHeardBark(object sender, EventArgs e)
	{
		Console.WriteLine("Kaushik heard the bark!");
	}
	public static void ShreyaHeardBark(object sender, EventArgs e)
	{
		Console.WriteLine("Shreya heard the bark!");
	}
	public static int RaviHeardBark(object sender, EventArgs e)
	{
		Console.WriteLine("Ravi heard the bark!");
		return (0);
	}
}

public class Dog {
	public event EventHandler Bark;

	public void OnBark(EventArgs e) {
		Bark.Invoke(this, e); //basically saying to notify all subscribers, you can also just do Bark(this, e)
	}	
}