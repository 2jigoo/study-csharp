namespace delegate_event
{
    class Program
    {

        delegate void WorkDelegate(char arg1, int arg2, int arg3);

        static void Ex1Mathmatics()
        {
            Mathematics math = new Mathematics();
            /*
            WorkDelegate work = math.Calculate; // new WorkDelegate(math.Calculate);

            work('+', 10, 5);
            work('-', 10, 5);
            work('*', 10, 5);
            work('/', 10, 5);
            */

            math.allCalculate(10, 5);
        }

        delegate int Calculate(int a, int b);

        static void Ex2Calcuator()
        {
            Calculate Callback;

            Callback = Calculator.Plus;
            Console.WriteLine(Callback(3, 4));

            Callback = Calculator.Minus;
            Console.WriteLine(Callback(10, 5));
        }

        static void Ex3Sorter()
        {
            int[] arr = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sort Ascending...");
            Sorter.BubbleSort(arr, new Sorter.Compare(Sorter.AscendCompare));
            
            foreach (int i in arr)
                Console.Write($"{i} ");


            int[] arr2 = { 7, 2, 8, 10, 11 };

            Console.WriteLine("\nSort Descending...");
            Sorter.BubbleSort(arr2, new Sorter.Compare(Sorter.DescendCompare));

            foreach (int i in arr2)
                Console.Write($"{i} ");

        }

        static void Ex4GenericSorter()
        {
            int[] arr = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sort Ascending...");
            GenericSorter.BubbleSort<int>(arr, new GenericSorter.Compare<int>(GenericSorter.AscendCompare));

            foreach (int i in arr)
                Console.Write($"{i} ");


            string[] arr2 = { "abc", "def", "ghi", "mno", "jkl" };

            Console.WriteLine("\nSort Descending...");
            GenericSorter.BubbleSort<string>(arr2, new GenericSorter.Compare<string>(GenericSorter.DescendCompare));

            foreach (int i in arr)
                Console.Write($"{i} ");
        }

        static void Ex5DelegateChains()
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            notifier.EventOccured += listener1.SomethingHappened;
            notifier.EventOccured += listener2.SomethingHappened;
            notifier.EventOccured += listener3.SomethingHappened;
            notifier.EventOccured("You've got mail");

            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappened;
            notifier.EventOccured("Download complete.");

            Console.WriteLine();

            notifier.EventOccured = new Notify(listener1.SomethingHappened)
                    + new Notify(listener3.SomethingHappened);
            notifier.EventOccured("Nuclear launch detected.");

            Console.WriteLine();

            Notify notify1 = listener1.SomethingHappened;
            Notify notify2 = listener2.SomethingHappened;

            notifier.EventOccured = (Notify) Delegate.Combine(notify1, notify2);
            notifier.EventOccured("Fire!!!");

            Console.WriteLine();

            notifier.EventOccured = (Notify) Delegate.Remove(notifier.EventOccured, notify2);
            notifier.EventOccured("RPG!");

        }

        static void Main(String[] args)
        {

            // Ex1Mathmatics();
            // Ex2Calcuator();
            // Ex3Sorter();
            // Ex4GenericSorter();
            Ex5DelegateChains();

        }

    }
}


