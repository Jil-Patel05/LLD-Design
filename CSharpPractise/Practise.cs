using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace OOPS_Practise.CSharpPractise
{
    public class CShaprtPractise
    {
        int[] arr;
        int[,] arr2;
        int[][] arr3;
        List<List<int>> list = new List<List<int>>();
        public CShaprtPractise()
        {
        }

        private void arrayTolist(List<int> l1)
        {

        }
        public void listPractise(int n)
        {
            // arr = new int[n]; // 1D Array
            // arr2 = new int[n, n]; // Everything is stored as big block in memory
            // arr3 = new int[n][]; // Each row is stored in different location, must have to initilize each row

            // int[] a1 = { 1, 2, 3, 4, 5 }; // Only works as declartion after that a1 is not reassigned with a1 = 
            // int[] a2 = new int[] { 10, 20, 30 }; // reassigned anywhere you to reassign
            // int[,] matrix1 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            // int[,] matrix2 = new int[,] { { 1, 2 }, { 3, 4 } };
            // int[,] matrix3 = { { 1, 2 }, { 3, 4 } };
            // int[][] jagged = new int[2][];
            // jagged[0] = new int[] { 1, 2, 3 };
            // jagged[1] = new int[] { 4, 5 };


            // List<int> nl = new List<int> { 1, 2, 3, 4 };
            // List<int> l1 = new List<int>(10);// 10 elemt stored on array
            // List<int> l2 = new List<int>(a1);
            // List<int> l3 = new List<int>(a2);// Comver any list
            //                                  // arrayTolist(a1); // Now allowed only used for initialize
            // List<List<int>> l4 = new List<List<int>> { l1, l2, l3 };
            // l4.Add(l3);
            // l4[0] = l2;

            // List<int> l5 = Enumerable.Repeat(-1, n).ToList();
            // int[] a4 = new int[n];
            // Array.Fill(a4, -1);
            // int[,] a5 = new int[n, n];
            // int[][] jagged1 = Enumerable.Range(0, n)
            //                .Select(_ => Enumerable.Repeat(-1, n).ToArray())
            //                .ToArray();

            // IEnumerable(LINQ returns new item always) has only method GetEnumerator

            // IEnumerable<int> ie = new List<int> { 1, 2, 3, 4 };
            // ie.Append(2); // returs new IEnumerabke 
            // It allows you to use foreach because foreach internally calls GetEnumerator().
            // Almost all collections (List<T>, Array, HashSet<T>, Dictionary<K,V>, etc.) implement it.
            // foreach (int item in ie)
            // {
            //     Console.WriteLine(item);
            // }
            // var enumerator = ie.GetEnumerator();
            // while (enumerator.MoveNext())
            // {
            //     Console.WriteLine(enumerator.Current);
            // }
            // IEnumerable<T> → for in-memory traversal (LINQ to Objects).
            // IQueryable<T> → for remote query execution (LINQ to SQL/EF/other providers).
            // Both support deferred execution, but:
            // IEnumerable<T> executes logic in C# code.
            // IQueryable<T> builds an expression tree → translated into something else (SQL, Mongo query, etc.).

            // ICollection<int> collection = new List<int> { 1, 2, 3, 4 };
            // collection.Add(5);
            // Collection give some more power to the List, by providing some modification options
            // Add/Remove
            // collection.Count // Not available in IEnumerable
            // collection.Count() // Used on any IEnumerable type as it is LINQ, but for IEnumerable TC O(n)

            // IList<int> list1 = new List<int> { 1, 2, 3, 4 };
            // List<int> list2 = new List<int> { 1, 2, 3, 4 };
            // int a = list1[0];
            // IList Provides Index related featured to list
            // Use IList<T> (or even more general ICollection<T> / IEnumerable<T>) in APIs, fields, and properties for flexibility.
            // Use List<T> only when constructing the object or when you need List<T>-specific features.

            List<int> ls = new List<int>(); // List implement all interfaces
            // IReadOnlyCollection
            // IReadOnlyList
        }

        public void PairPractise(int n)
        {
            // In older version tuple is used
            // Make custom class for it better approach for readabilty

            // ValueTuple<int, string, int, string> vt = (1, "hello", 2, "Hey");
            ValueTuple<int, string, int, string> vt = ValueTuple.Create(1, "hello", 2, "Hey");
            Console.WriteLine(vt.Item1);
            Console.WriteLine(vt.Item2);
            Console.WriteLine(vt.Item3);
            Console.WriteLine(vt.Item4);

            // (int id, string name) p = (1, "Hey");
            // (int id, string name, int id2, string name2) p = (1, "Hey", 2, "Hello");
            (int, string, int, string) p = ValueTuple.Create(1, "Hey", 2, "Hello");
            Console.WriteLine(p.Item1);
            Console.WriteLine(p.Item2);

            List<(int id, string name)> ls = new List<(int id, string name)> { (1, "Hey"), (2, "Hello") };
            int id = ls[0].id;
            string name = ls[0].name;

            // KeyValuePair<(int id, string name), int> kv = new KeyValuePair<(int id, string name), int>();
        }

        public void dictionarypractise(int n)
        {
            Dictionary<int, int> d = new Dictionary<int, int>(); // Unordered_map of c++
            SortedDictionary<int, int> d2 = new SortedDictionary<int, int>(); // map of c++
            ConcurrentDictionary<int, int> d1 = new ConcurrentDictionary<int, int>(); // Used for multi thread operation(Limited operations are thread safe use it only)
        }

        public void setPractise(int n)
        {
            HashSet<int> s1 = new HashSet<int>(); // unordered_set of c++
            SortedSet<int> s2 = new SortedSet<int>(); // set of c++

            // ImmutableHashSet<int> s3 = new ImmutableHashSet<int>(); // Wrong
            // ImmutableSortedSet<int> s4 = new ImmutableSortedSet<int>(); // Wrong

            ImmutableHashSet<int> s3 = ImmutableHashSet.Create<int>(1, 2, 3);
            ImmutableHashSet<int> s4 = s3.Add(4);

            // Unlike HashSet<T>, ImmutableHashSet<T> does not have a public constructor.
            // Instead, it uses static factory methods to create instances.

            // FrozenSet -> immutable not have Add or modification method only read only loop-ups
        }
        public void linqPractise()
        {
            var people = new List<Person> {
             new(){Id=1, Name="Alice", Age=30, City="NY"},
             new(){Id=2, Name="Bob",   Age=25, City="SF"},
             new(){Id=3, Name="Carol", Age=35, City="NY"},
             new(){Id=4, Name="Dave",  Age=40, City="LA"}
            };
            int id = people.Where((elm) => elm.Id == 1 || elm.Id == 2).Select((elm) => elm.Id).FirstOrDefault();
        }
    }
    class Person { public int Id; public string Name; public int Age; public string City; }
}