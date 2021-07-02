using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DelegatesAndLambdas {
    class Hero {
        public string firstName { get; }
        public string lastName { get; }
        public bool canFly { get; }
        public Hero(string first_name, string last_name, bool can_fly) {
            this.firstName = first_name;
            this.lastName = last_name;
            this.canFly = can_fly;
        }
    }

    class Program {
        // this collection is not manipulated here, we just need to read from it
        // so use IEnumerable
        // We included generisc and made it more generic
        // we replaced delegate with Func, a pre-defined delegate
        public static IEnumerable<T> FilterItems<T>(Func<T, bool> filter, IEnumerable<T> items) {
            foreach (var item in items) {
                if (filter(item)) {
                    yield return item;
                }
            }
        }

        // We can use Func<T (input), bool (return type)> instead
        //public delegate bool Filter<T>(T hero);

        public static void CountToInfinity() {
            for(var i = 0; i < 1000000000; i++) {

            }
        }

        // Action is a delegate that returns nothing and takes no param
        public static void MeasureTime(Action fn) {
            var watch = Stopwatch.StartNew();
            fn();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }

        // A generic measure time that takes T and returns T
        public static T MeasureTimeFunc<T>(Func<T> fn) {
            var watch = Stopwatch.StartNew();
            var res = fn();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            return res;
        }

        public static int CalculateSomeResult() {
            // mock some heavy computations and returns int
            for (var i = 0; i < 1000000000; i++) ;
            return 42;
        }

        static void Main(string[] args) {

            var heroes = new List<Hero> {
                new Hero("Bruce", "Wayne", false),
                new Hero("Peter", "Parker", true),
                new Hero("Saitama", String.Empty, false),
                new Hero("Tony", "Stark", true),
                new Hero("Xblade", string.Empty, false)
            };

            var result = FilterItems(h => h.canFly, heroes);
            var names = FilterItems(h => h.StartsWith("h"), new[] { "Holmes", "Homer", "Dan", "House" });
            var even = FilterItems(num => num % 2 == 0, new[] { 1, 2, 3, 4, 5 });

            MeasureTime(() => CountToInfinity());
        }
    }
}
