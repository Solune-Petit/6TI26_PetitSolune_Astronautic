using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    internal class Inventaire
    {
		private int[] _items;

		public int[] Items
		{
			get { return _items; }
			set { _items = value; }
		}

		public Inventaire(int[] items)
		{
			_items = items;
		}

	}
}
