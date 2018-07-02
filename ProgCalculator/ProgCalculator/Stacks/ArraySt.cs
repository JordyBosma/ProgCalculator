using System.Linq;

namespace ProgCalculator.Stacks
{
    class ArraySt : Stack
    {
        double?[] arraySt = new double?[15];
        public double? item;

        /// <summary>
        /// Voeft een nieuwe item toe aan array stack
        /// </summary>
        /// <param name="index">De index van de listStack</param>
        /// <param name="value">De waarde die toegevoegd moet worden</param>
        public void Add(int index, double? value)
        {
            ArrayResize(index);

            if (arraySt[0] == null) // Stop conditie
                arraySt[0] = value;
            else if (index > 0) // Als de index niet bij de eerste waarde is
            {
                arraySt[index] = arraySt[index - 1];
                arraySt[index - 1] = null;
                Add(index - 1, value);
            }
            // Als de user een nieuwe waarde probeert toe te voegen, maar arrayStack[0] heeft al een waarde
            else
                Add(CntArray(), value); // Start opnieuw maar aan het einde van de stack

            item = arraySt[0];
        }

        /// <summary>
        /// Increment grootte van de array als hij te klein is
        /// </summary>
        /// <param name="index">De index die gecontroleerd moet worden</param>
        private void ArrayResize(int index)
        {
            if (index >= arraySt.Length)
            {
                // Kopieër naar een tijdelijke stack
                double?[] arrayStackTemp = new double?[arraySt.Length];
                arraySt.CopyTo(arrayStackTemp, 0);

                // Kopieër de items terug
                arraySt = new double?[arraySt.Length + 15];
                arrayStackTemp.CopyTo(arraySt, 0);
            }
        }

        // Gerefeert in Stack.cs
        public override double? GetItem(int index)
        {
            if (index < arraySt.Count()) { return arraySt[index]; }

            return null;
        }

        // Gerefeert in Stack.cs
        public override void Delete(int index)
        {
            if (index <= CntArray()) { arraySt[index] = null; }
            Sort(); //Sorteer array
        }

        /// <summary>
        /// Sorteerd de stack zodat alle NULL's aan het einde zitten
        /// </summary>
        /// <param name="index">De index van de lijst</param>
        private void Sort(int index = 0)
        {
            if (arraySt[index + 1] != null || arraySt[index] != null)
            {
                if (arraySt[index] == null)
                {
                    arraySt[index] = arraySt[index + 1];
                    arraySt[index + 1] = null;
                    Sort(index + 1);
                }
                else
                    Sort(index + 1);
            }
        }

        /// <summary>
        /// Telt de waardes in de array die niet NULL zijn
        /// </summary>
        /// <returns>Returnt nummer van niet NULL objecten</returns>
        private int CntArray()
        {
            int count = 0;
            foreach (double? value in arraySt)
            {
                if (value != null) { count++; }
            }
            return count;
        }

        public override void Clear()
        {
            arraySt = new double?[15];
        }

        /// <summary>
        /// Finaliseert de ArraySt
        /// </summary>
        ~ArraySt()
        {
            Cleaner cleaner = new Cleaner();
            cleaner.Dispose();
        }
    }
}
