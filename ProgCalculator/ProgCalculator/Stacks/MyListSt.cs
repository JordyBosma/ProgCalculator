namespace ProgCalculator.Stacks
{
    class MyListSt<T> : Stack
    {
        public double? item;
        private MyListSt<T> next;

        /// <summary>
        /// Voegt een nieuw item aan de MyListSt toe
        /// </summary>
        /// <param name="index"></param>
        /// <param name="val">The value that needs to be added</param>
        public void Add(int index, double? val)
        {
            // stop condition
            if (item == null)
                item = val;
            else if (next == null)
            {
                next = new MyListSt<T>();
                next.item = item;
                item = null;
                Add(0, val);
            }
            else
            {
                next.Add(0, item);
                item = val;
            }
        }

        // Gerefereerd in Stack.cs
        public override double? GetItem(int index)
        {
            if (index == 0)
                return item;
            else
            {
                if (next != null)
                    return next.GetItem(index - 1);
                else
                    return null;
            }
        }

        // Documented in Stack.cs
        public override void Delete(int index)
        {
            if (index == 0)
                item = null;
            else
            {
                if (next != null)
                    next.Delete(index - 1);
            }
            // Stack sorteren
            Sort();
        }

        /// <summary>
        /// Sorteert de stack zodat all null pointers verwijderd zijn aan het einde
        /// </summary>
        public void Sort()
        {
            if (next != null || item != null)
            {
                if (item == null)
                {
                    item = next.item;
                    next.item = null;
                    next.Sort();
                }
                else
                    next.Sort();
            }
        }

        // Gerefereerd in Stack.cs
        public override void Clear()
        {
            int index = 0;

            while (GetItem(0) != null)
            {
                Delete(0);
                index++;
            }
            FlushNext();
        }


        /// <summary>
        /// Maakt alle volgende variabelen: NULL
        /// </summary>
        private void FlushNext()
        {
            if (next != null)
            {
                next.FlushNext();
                next = null;
            }
        }

        /// <summary>
        /// Finaliseert de MyListSt
        /// </summary>
        ~MyListSt()
        {
            Cleaner cleaner = new Cleaner();
            cleaner.Dispose();
        }
    }
}
