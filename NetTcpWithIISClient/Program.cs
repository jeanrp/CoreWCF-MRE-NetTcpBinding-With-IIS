using System;
using System.ServiceModel;
using NetTcpWithIISClient.Service;

namespace NetTcpWithIISClient
{
    internal class Program
    {
        private static void Main()
        {
            WrappedServiceCall(new ServiceClient(), it => it.GetData(10));
        }

        private static void WrappedServiceCall<T>(ClientBase<T> service, Action<T> action) where T : class
        {
            var success = false;
            try
            {
                action(service as T);

                if (service.State == CommunicationState.Faulted) return;

                service.Close();
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
            finally
            {
                if (!success)
                    service.Abort();
            }
        }
    }
}