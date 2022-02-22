using static System.Console;
using System;

public class main {
	public static void Main() {
		var list = new genlist<double[]>();
		char[] delimiters = {' ', '\t', '\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line!=null; line=ReadLine()) {
			var words = line.Split(delimiters, options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0; i<n; i++) numbers[i] = double.Parse(words[i]);
			list.push(numbers);
		}
	for(int i = 0; i<list.size; i++) {
		var numbers = list.data[i];
		foreach(var number in numbers) Write($"{number:e} ");
		WriteLine();
	}
		WriteLine($"List size: {list.size}.");
		WriteLine("Removing entries 2 then entry 3 twice, and re-writing.");
		list.remove(2);
		WriteLine($"List size: {list.size}.");
		WriteLine($"List capacity: {list.capacity}.");
		for(int i = 0; i<list.size; i++) {
		var numbers = list.data[i];
		foreach(var number in numbers) Write($"{number:e} ");
		WriteLine();
		}
		list.remove(3);
		list.remove(3);
		WriteLine($"List size: {list.size}.");
		WriteLine($"List capacity: {list.capacity}.");
		for(int i = 0; i<list.size; i++) {
		var numbers = list.data[i];
		foreach(var number in numbers) Write($"{number:e} ");
		WriteLine();
		}
		try {
		WriteLine("Removing index 1 four times to test attempting to remove nothing.");
		for(int i = 0; i<4; i++)list.remove(1);
		}
		catch {WriteLine("IndexOutOfRangeExeption.");}
		for(int i = 0; i<list.size; i++) {
		var numbers = list.data[i];
		foreach(var number in numbers) Write($"{number:e} ");
		WriteLine();
		}
		WriteLine($"List size: {list.size}.");
		WriteLine($"List capacity: {list.capacity}.");

		WriteLine("Try removing index -1 to test attempting bad index.");
		try{list.remove(-1);}
		catch{WriteLine("IndexOutOfRangeExeption, removing -1 not posible.");}
		WriteLine($"List size: {list.size}.");
		WriteLine($"List capacity: {list.capacity}.");

		
	}

}
