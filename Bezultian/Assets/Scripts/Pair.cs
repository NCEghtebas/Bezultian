﻿public class Pair<T1, T2>
{
	public T1 First { get; private set; }
	public T2 Second { get; private set; }
	internal Pair(T1 first, T2 second)
	{
		First = first;
		Second = second;
	}
	public override string ToString(){
		try{
			return "("+First+","+Second +")";
		}catch{
			return "";
		}
	}
}

public static class Pair
{
	public static Pair<T1, T2> New<T1, T2>(T1 first, T2 second)
	{
		var tuple = new Pair<T1, T2>(first, second);
		return tuple;
	}
}