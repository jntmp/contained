using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzzle
{
    public class Api
    {
        private static readonly Api instance = new Api();
        public static Api Instance { get { return instance; } }

        public Container<T> Contain<T>(Action statement)
        {
            return new Container<T>().Try(statement);
        }

        public Container<T> Contain<T>(Func<T> statement)
        {
            return new Container<T>().Try(statement);
        }


    }
}
