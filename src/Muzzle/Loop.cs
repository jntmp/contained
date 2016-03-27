using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Muzzle
{
    public class Loop
    {
        public class Options
        {
            public Options()
            {
                Threads = 1;
            }

            public Action<int> OnIteration { get; set; }
            public Action<Exception> OnError { get; set; }
            public bool Parallel { get; set; }
            public int Threads { get; set; }
        }

        public static void Each<T>(IEnumerable<T> list, Action<T> iteration)
        {
            Each<T>(list, iteration, new Options() { Threads = 1 } );
        }

        public static void Each<T>(IEnumerable<T> list, Action<T> iteration, Options options)
        {
            var count = 1;
            var pOptions = new ParallelOptions { MaxDegreeOfParallelism = options.Threads };

            Parallel.ForEach<T>(list, pOptions, (p) =>
            {
                var ctr = new Container<T>().Try(() => { iteration.Invoke(p); });

                if (ctr.HasError && options.OnError != null)
                    options.OnError.Invoke(ctr.Error);

                if (options.OnIteration != null)
                {
                    options.OnIteration(count);
                    Interlocked.Increment(ref count);
                }
            });
        }
    }
}
