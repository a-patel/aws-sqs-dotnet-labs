//#region Imports
//using AwsSQSLabs.Web.Messaging;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//#endregion

//namespace AwsSQSLabs.Web.Extensions
//{
//    public static class MessageSubscriberExtensions
//    {
//        public static Task SubscribeAsync<T>(this IMessageSubscriber subscriber, Func<T, Task> handler, CancellationToken cancellationToken = default) where T : class
//        {
//            return subscriber.SubscribeAsync<T>((msg, token) => handler(msg), cancellationToken);
//        }

//        public static Task SubscribeAsync<T>(this IMessageSubscriber subscriber, Action<T> handler, CancellationToken cancellationToken = default) where T : class
//        {
//            return subscriber.SubscribeAsync<T>((msg, token) =>
//            {
//                handler(msg);
//                return Task.CompletedTask;
//            }, cancellationToken);
//        }

//        public static Task SubscribeAsync(this IMessageSubscriber subscriber, Func<IMessage, CancellationToken, Task> handler, CancellationToken cancellationToken = default)
//        {
//            return subscriber.SubscribeAsync<IMessage>((msg, token) => handler(msg, token), cancellationToken);
//        }

//        public static Task SubscribeAsync(this IMessageSubscriber subscriber, Func<IMessage, Task> handler, CancellationToken cancellationToken = default)
//        {
//            return subscriber.SubscribeAsync((msg, token) => handler(msg), cancellationToken);
//        }

//        public static Task SubscribeAsync(this IMessageSubscriber subscriber, Action<IMessage> handler, CancellationToken cancellationToken = default)
//        {
//            return subscriber.SubscribeAsync((msg, token) =>
//            {
//                handler(msg);
//                return Task.CompletedTask;
//            }, cancellationToken);
//        }
//    }
//}
