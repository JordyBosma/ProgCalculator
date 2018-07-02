using System.Collections.Generic;
using System.Linq;

namespace ProgCalculator.Stacks
{
    class ListSt : Stack
    {
        private List<double?> listSt = new List<double?>() { null };
        public double? item;

        /// <summary>
        /// Voeg een nieuw item aan de list toe
        /// </summary>
        /// <param name="index">De index van de listStack</param>
        /// <param name="value">De waarde die moet worden toegevoegd</param>
        public void Add(int index, double? value)
        {
            if (listSt.First() == null) // stop conditie
                listSt[0] = value;
            else if (index > 0) // Als de index niet op de eerste waarde zit
            {
                listSt[index] = listSt[index - 1];
                listSt[index - 1] = null;
                Add(index - 1, value);
            }
            else
            {
                listSt.Add(null);
                Add(listSt.Count - 1, value);
            }
            item = listSt[0];
        }

        // Gerefereert in Stack.cs
        public override double? GetItem(int index)
        {
            if (index < listSt.Count) { return listSt[index]; }

            return null;
        }

        // Gerefereert in Stack.cs
        public override void Delete(int index)
        {
            if (index <= listSt.Count - 1) { listSt[index] = null; }
        }

        // Gerefereert in Stack.cs
        public override void Clear()
        {
            listSt.Clear();
            listSt.Add(null);
        }

        //Finaliseert de List Stack
        ~ListSt()
        {
            Cleaner clean = new Cleaner();
            clean.Dispose();
        }
    }
}
