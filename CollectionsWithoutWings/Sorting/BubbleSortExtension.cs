﻿using System;
using System.Collections.Generic;

namespace CollectionsWithoutWings.Sorting
{
    public static class BubbleSortExtension
    {
        public static void BubbleSort<T>(this IList<T> list) where T : IComparable<T>
        {
            BubbleSortHelper(list, null);
        }

        public static void BubbleSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            BubbleSortHelper(list, comparer);
        }

        private static void BubbleSortHelper<T>(this IList<T> list, IComparer<T> comparer)
        {            
            Func<T, T, int> compareFunction;

            if (comparer == null)
            {
                compareFunction = (x, y) => ((IComparable<T>)x).CompareTo(y);
            }
            else
            {
                compareFunction = (x, y) => comparer.Compare(x, y);
            }

            var n = list.Count;
            var swapped = true;

            while (swapped)
            {
                swapped = false;

                for (var i = 1; i < n; i++)
                {
                    if (compareFunction(list[i - 1], list[i]) == 1) 
                    {
                        Swap(list, i - 1, i);
                        swapped = true;
                    }
                }
            }
        }

        private static void Swap<T>(IList<T> list, int v, int i)
        {
            var tmp = list[v];
            list[v] = list[i];
            list[i] = tmp;
        }
    }
}
