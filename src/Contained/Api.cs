using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contained
{
    public static class Api
    {
        #region TryCatch
        public static Container<T> Contain<T>(Action statement)
        {
            return Activator.CreateInstance<Container<T>>().Try(statement);
            //return new Container<T>().Try(statement);
        }

        public static Container<T> Contain<T>(Func<T> statement)
        {
            return Activator.CreateInstance<Container<T>>().Try(statement);
        }
        #endregion

        #region Loops
        public static void Iterate<T>(
            IEnumerable<T> list,
            Action<T> iteration
            )
        {
            Iterate<T>(list, iteration, null, null, 1);
        }

        public static void Iterate<T>(
            IEnumerable<T> list,
            Action<T> iteration,
            Action<int> onIteration
            )
        {
            Iterate<T>(list, iteration, onIteration, null, 1);
        }

        public static void Iterate<T>(
           IEnumerable<T> list,
           Action<T> iteration,
           Action<int> onIteration,
           Action<Exception> onError
           )
        {
            Iterate<T>(list, iteration, onIteration, onError, 1);
        }

        public static void Iterate<T>(
            IEnumerable<T> list, 
            Action<T> iteration,
            Action<int> onIteration,
            Action<Exception> onError,
            int threads
            )
        {
            var count = 1;
            var pOptions = new ParallelOptions { MaxDegreeOfParallelism = threads };

            Parallel.ForEach<T>(list, pOptions, (p) =>
            {
                var ctr = new Container<T>().Try(() => { iteration.Invoke(p); });

                if (ctr.HasError && onError != null)
                    onError.Invoke(ctr.Error);

                if (onIteration != null)
                {
                    onIteration(count);
                    Interlocked.Increment(ref count);
                }
            });
        }
        #endregion

        #region Parsing
        public static T Parse<T>(string val, T defaultVal = default(T))
        {
            return Parsing.ParseOrDefault<T>(val, defaultVal);
        }
        #endregion
    }
}
