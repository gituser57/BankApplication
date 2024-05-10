using System;
using System.Collections;



namespace ExceptionApp
{
    public class CustomArray : IEnumerable/*<double>*/
    {
        private readonly double[] array;
        private int first, last, length;

        /// <summary>
        /// Should return first index of array
        /// </summary>

        public int First
        {
            get { return first; }
            private set
            {
                first = value;
                last = first + Length - 1;
            }
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        /// 
        public int Last
        {
            get { return last; }
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length
        {
            get { return length; }
            private set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException("Value of length is smaller than 0 ");
                }

            }
        }

        /// <summary>
        /// Should return array by its reference 
        /// </summary>   

        public double[] Array
        {
            get
            {
                return array;
            }

        }

        /// <summary>
        /// Constructor with first index and length
        public CustomArray(int first, int length)
        {
            array = new double[length];
            Length = length;
            First = first;
        }

        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        public CustomArray(int first, IEnumerable<double> list)
        {
            if (list != null)
            {
                Length = list.Count();
                First = first;
               // array = new double[Length];
                array = list.ToArray();

            }
            else
            {
                throw new ArgumentNullException(nameof(list));
            }
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params double[] list)
        {
            if (list != null)
            {
                if (list.Length > 0)
                {
                    Length = list.Length;
                    First = first;
                    array = new double[Length];
                    array = list;
                }
                else
                {
                    throw new ArgumentException("list has no elements ");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(list));
            }
        }

        /// <summary>
        /// Indexer with get and set  properties
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns> Return element of array at specific index</returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception>     
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public double this[int item]
        {

            get
            {
                var edge = item - First;
                if (edge >= 0 && edge <= Length - 1)
                {
                    return array[edge];
                }
                throw new ArgumentException("index out of array range");
            }
            set
            {
                //if (value != null)
                {
                    var edge = item - First;
                    if (edge >= 0 && edge <= Length - 1)
                    {
                        array[edge] = value;
                    }
                    else
                    {
                        throw new ArgumentException("index out of array range");
                    }

                }
                //else
                //{
                //    throw new ArgumentNullException(nameof(value));
                //}


            }
        }

        public IEnumerator GetEnumerator()
        {
            //return Array.GetEnumerator();
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
