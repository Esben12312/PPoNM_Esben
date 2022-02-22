using static System.Console;
using System;

public class node<T>{
	public T item;
	public node<T> next;
	public node(T item){this.item=item;}
}

public class list<T> {
	public node<T> first=null, current = null;
	public void push(T item){
		if(first==null){
			first = new node<T>(item);
			current = first;
		}
		else {
			current.next = new node<T>(item);
			current = current.next;
		}
	}
	public void start(){current = first;}
	public void next(){current = current.next;}
}

public class main {
	public static void Main() {
		list<int> a = new list<int>();
		WriteLine("Pushing numbers 1 to 5");
		a.push(1);
		a.push(2);
		a.push(3);
		a.push(4);
		a.push(5);

		for(a.start(); a.current != null; a.next()){
			WriteLine(a.current.item);
		}
		list<int> b = new list<int>();
		WriteLine("Pushing nubmers 1 to 15");
		for(int i = 1; i < 16; i++)b.push(i);
		
		for(b.start(); b.current != null; b.next()){
		WriteLine(b.current.item);
		}
		WriteLine("Succes");
	}
}