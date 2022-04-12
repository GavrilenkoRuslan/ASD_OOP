using System;
using System.Diagnostics;


namespace ASD1
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public class LinearList
    {
        Node head;
        Node tail;
        int count = 0;

        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void LinearSearch()
        {
            int tofind, place = 1;
            Print();
            do
            {
                Console.WriteLine("Enter element ");
            } while (!Int32.TryParse(Console.ReadLine(), out tofind));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Node current = head;
            bool found = false;
            while (current != null && !found)
            {
                if (current.Data == tofind)
                {
                    found = true;
                }
                else
                {
                    current = current.Next;
                    place++;
                }
            }
            sw.Stop();
            if (found == true)
                Console.WriteLine("Was found on index " + place);
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine("Time spend " + sw.Elapsed);
        }
        public void BarrierSearch()
        {
            int tofind, amount = 1;
            Print();
            do
            {
                Console.WriteLine("Enter element ");
            } while (!Int32.TryParse(Console.ReadLine(), out tofind));
            Node current = new Node(tofind);
            Node cur = head;
            tail.Next = current;
            current.Next = null;
            Console.WriteLine("The second list: ");
            Print();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (cur.Data != tofind)
            {
                cur = cur.Next;
                amount++;
            }
            sw.Stop();
            if (amount == count + 1)
            {
                Console.WriteLine("Element can't be found ");
            }
            else
            {
                Console.WriteLine("Element was found on place " + amount);
            }
            Console.WriteLine("Time spend: " + sw.Elapsed);
            tail.Next = null;

        }
        public void BinarySearch()
        {
            ToArrayDo();
            int x, L = 0, R = count - 1;
            int middle = -1;
            Node current = head;
            do
            {
                Console.WriteLine("Enter x: ");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            var time = new Stopwatch();
            time.Start();
            while (L <= R)
            {
                middle = (L + R) / 2;
                current = head;
                for (int i = 0; i < middle; i++)
                {
                    current = current.Next;
                }
                if (current.Data == x)
                    L = R + 1;
                else if (current.Data < x)
                    L = middle + 1;
                else
                    R = middle - 1;
            }
            time.Stop();
            if (current.Data != x)
                Console.WriteLine("Element can't be found");
            else
                Console.WriteLine("X is on place number: " + middle);
            Console.WriteLine("Time spend: " + time.Elapsed);
        }
        public void GoldenSearch()
        {
            ToArrayDo();
            int x, L = 0, R = count - 1;
            double golden = 0.618;
            Node current = head;
            int middle = -1;
            Stopwatch lebro = new Stopwatch();
            do
            {
                Console.WriteLine("Enter x: ");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            lebro.Start();
            while (L<=R)
            {
                middle = Convert.ToInt32(L + golden * (R - L));
                current = head;
                for (int i = 0; i < middle; i++)
                {
                    current = current.Next;
                }
                if (current.Data == x)
                    L = R + 1;
                else if (current.Data < x)
                    L = middle + 1;
                else
                    R = middle - 1;
            }
            lebro.Stop();
            if (current.Data == x)
                Console.WriteLine("Element was found on index " + middle);
            else
                Console.WriteLine("Element can't be found");
            Console.WriteLine("Time spend: " + lebro.Elapsed);
        }
        void ToArrayDo()
        {
            Node current = head;
            int[] a = new int[count];
            for (int i = 0; i < count; i++)
            {
                a[i] = current.Data;
                current = current.Next;
            }

            current = head;
            Console.WriteLine();
            Program.SortMethod(a);

            for (int i = 0; i < a.Length; i++)
            {
                current.Data = a[i];
                current = current.Next;
            }
            Print();
        }
    }

    class Program
    {
        static int[] arr;
        static LinearList list;
        static void Main(string[] args)
        {
            Console.WriteLine("ASD LAB 1 Gavrilenko Ruslan IPZ-11/1");
            Menu();
        }
        static void Menu()
        {
            int massive_choose, type_choose;
            char _rewrite = 'n';
            while (true)

            {
                do
                {
                    Console.WriteLine("Choose massive(1) or linear-associated list(2)");
                } while (!Int32.TryParse(Console.ReadLine(), out massive_choose) || massive_choose < 1 || massive_choose > 2);
                switch (massive_choose)
                {
                    case 1:
                        EnterMassive(_rewrite);
                        break;
                    case 2:
                        EnterList(_rewrite);
                        break;
                }

                do
                {
                    Console.WriteLine("Linear search(1), Linear barrier search(2), binary search(3), binary golden search(4)");
                } while (!Int32.TryParse(Console.ReadLine(), out type_choose) || type_choose < 1 || type_choose > 4);
                switch (type_choose)
                {
                    case 1:
                        if (massive_choose == 1)
                            LinearSearch();
                        else
                            list.LinearSearch();
                        break;
                    case 2:
                        if (massive_choose == 1)
                            BarrierSearch();
                        else
                            list.BarrierSearch();
                        break;
                    case 3:
                        if (massive_choose == 1)
                            BinarySearch();
                        else
                            list.BinarySearch();
                        break;
                    case 4:
                        if (massive_choose == 1)
                            GoldenSearch();
                        else
                            list.GoldenSearch();
                        break;
                }
                do
                {
                    Console.WriteLine("If you want to rewrite your array, enter y");
                } while (!Char.TryParse(Console.ReadLine(), out _rewrite));
            }

        }
        static void EnterMassive(char _rewrite)
        {
            if (arr == null || _rewrite == 'y')
            {
                int n, limit;
                do
                {
                    Console.WriteLine("Enter number of elemenets:");
                } while (!Int32.TryParse(Console.ReadLine(), out n) || n < 1);
                do
                {
                    Console.WriteLine("Enter limit of random number");
                } while (!Int32.TryParse(Console.ReadLine(), out limit) || n < 1);
                arr = new int[n];
                RandomGenerator(arr, limit);
                ArrOutput("Your massive: ", arr);
            }
        }

        static void RandomGenerator(int[] arr, int limit)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-limit, limit);
            }
        }

        static void ArrOutput(string welcome, int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine(welcome);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void EnterList(char _rewrite)
        {
            if (_rewrite == 'y' || list == null)
            {
                Console.WriteLine("Enter number of elements: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter randLimit");
                int randlim = Convert.ToInt32(Console.ReadLine());
                list = new LinearList();
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    list.Add(rand.Next(-randlim, randlim));
                }
                list.Print();
            }
        }
        static void LinearSearch()
        {
            int x, i = 0, N = 0;
            var sw = new Stopwatch();
            bool found = false;
            do
            {
                Console.WriteLine("Enter x");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            sw.Start();
            while (i < arr.Length && !found)
            {
                if (arr[i] == x)
                {
                    N = i;
                    found = true;
                }
                else
                    i++;
            }
            if (found == false)
                Console.WriteLine("Element can't be found");
            else
                Console.WriteLine("Element found on place number " + N);
            sw.Stop();
            Console.WriteLine("Time spent :" + sw.Elapsed);
        }
        static void BarrierSearch()
        {
            int x, i = 0;
            int[] barr = new int[arr.Length + 1];
            var sw = new Stopwatch();
            do
            {
                Console.WriteLine("Enter x");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            for (int k = 0; k < arr.Length; k++)
                barr[k] = arr[k];
            barr[arr.Length] = x;
            ArrOutput("Second massive", barr);
            sw.Start();
            while (barr[i] != x)
                i++;
            if (i == barr.Length - 1)
            {
                Console.WriteLine("Element can't be found");
            }
            else
                Console.WriteLine("Element was found on index " + i);
            sw.Stop();
            Console.WriteLine("Time spent: " + sw.Elapsed);
        }

        static void BinarySearch()
        {
            SortMethod(arr);
            ArrOutput("Sorted array: ", arr);

            int L = 0;
            int R = arr.Length - 1;
            int m = 0, x;
            var sw = new Stopwatch();
            do
            {
                Console.WriteLine("Enter x");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            sw.Start();
            while (L <= R)
            {
                m = (L + R) / 2;
                if (arr[m] == x)
                    L = R + 1;
                if (arr[m] < x) L = m + 1;
                else R = m - 1;
            }
            sw.Stop();
            if (arr[m] == x)
                Console.WriteLine("Element was found on index " + m);
            else
                Console.WriteLine("Element can't be found ");
            Console.WriteLine("Time spent: " + sw.Elapsed);

        }
        static void GoldenSearch()
        {
            SortMethod(arr);
            ArrOutput("Sorted array: ", arr);

            int L = 0;
            int R = arr.Length - 1;
            int m = 0, x, goal = 0;
            double golden = 0.618;
            var sw = new Stopwatch();
            do
            {
                Console.WriteLine("Enter x");
            } while (!Int32.TryParse(Console.ReadLine(), out x));
            sw.Start();
            while (L <= R)
            {
                m = Convert.ToInt32(L + golden * (R - L));
                if (arr[m] > x)
                    R = m - 1;
                else if (arr[m] < x)
                {
                    L = m + 1;
                }
                else
                {
                    goal = m;
                    L = R + 1;
                }
            }
            sw.Stop();
            if (arr[goal] == x)
                Console.WriteLine("Element was found at index " + goal);
            else
                Console.WriteLine("Element can't be found");
            Console.WriteLine("Time spent: " + sw.Elapsed);

        }
        static public void SortMethod(int[] _array)
        {
            int tmp, b;
            for (int i = 1; i < _array.Length; i++)
            {
                b = i;
                while (b >= 1)
                {
                    if (_array[b] < _array[b - 1])
                    {
                        tmp = _array[b];
                        _array[b] = _array[b - 1];
                        _array[b - 1] = tmp;
                        b--;
                    }
                    else
                        b = 0;
                }
            }
        }
    }
    
}
