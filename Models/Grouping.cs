using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Grouping<T> : ObservableCollection<T>
{
	//public K Key { get; private set; }

	public Grouping(IEnumerable<T> items)
	{
		foreach (var item in items)
			this.Items.Add(item);
	}
}

