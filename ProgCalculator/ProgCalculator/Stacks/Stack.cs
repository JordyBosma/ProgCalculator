using System.Collections.Generic;

namespace ProgCalculator.Stacks
{
    abstract class Stack : Cleaner
    {
        /// <summary>
        /// Pakt de value van de gegeven index
        /// </summary>
        /// <param name="index">De index van de stack item</param>
        /// <returns>Null of double</returns>
        public abstract double? GetItem(int index);

        /// <summary>
        /// Verwijderd de waarde van de gegeven index
        /// </summary>
        /// <param name="index">de index van de stack item</param>
        public abstract void Delete(int index);

        /// <summary>
        /// Wordt gebruikt om alle items in de list te resetten
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Controleer of de gebruiker wil opsommen, verminderen, vermenigvuldigen of delen
        /// </summary>
        /// <param name="item">Eerste nummer van de calculatie</param>
        /// <param name="ExecuteCalc">Opsommen(+), Aftrekken(-), Vermenigvuldigen(*) of Delen(/)</param>
        /// <returns>double?</returns>
        public double? ExecuteCalc(double? item, char ExecuteCalc)
        {
            double? calcu;
            if (item != null && GetItem(1) != null)
            {
                switch (ExecuteCalc)
                {
                    case ('+'):
                        calcu = item + GetItem(1);
                        break;
                    case ('-'):
                        calcu = item - GetItem(1);
                        break;
                    case ('*'):
                        calcu = item * GetItem(1);
                        break;
                    case ('/'):
                        calcu = item / GetItem(1);
                        break;
                    default:
                        return null;
                }
                Delete(1);
                return calcu;
            }
            return null;
        }

        /// <summary>
        /// Returnt een list om te laten zien in listbox
        /// </summary>
        /// <returns>Returns a list with all the items of the stack.</returns>
        public List<double?> GetLst()
        {
            List<double?> resultLst = new List<double?>();

            int i = 0;
            while (GetItem(i) != null)
            {
                resultLst.Add(GetItem(i));
                i++;
            }
            return resultLst;
        }
    }
}
