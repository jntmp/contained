using System;

namespace Contained
{
    public class Container<T>
    {
        public T PayLoad { get; set; }
        public Exception Error { get; set; }    
        public bool HasError { get; set; }

        public Container<T> Try(Action statement)
        {
            var result = new Container<T>();

            try
            {
                statement.Invoke();
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.HasError = true;
            }

            return result;
        }

        public Container<T> Try(Func<T> statement)
        {
            var result = new Container<T>();

            try
            {
                result.PayLoad = statement.Invoke();
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.HasError = true;
            }

            return result;
        }

        public Container<T> Else(Func<T> statement)
        {
            return this.Try(statement);
        }

        public Container<T> Catch(Action<Exception> statement)
        {
            if (Error != null)
            {
                statement.Invoke(Error);
            }

            return this;
        }

    }
}
