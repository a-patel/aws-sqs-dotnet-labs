//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AwsSQSLabs.Web.Messaging
//{
//    public interface IMessageSubscriber
//    {
//        Task SubscribeAsync<T>(Func<T, CancellationToken, Task> handler, CancellationToken cancellationToken = default) where T : class;
//    }

//    public static class MessageBusExtensions
//    {
//    }
//}
