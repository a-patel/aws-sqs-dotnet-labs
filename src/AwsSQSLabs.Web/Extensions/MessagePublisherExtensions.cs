//#region Imports
//using AwsSQSLabs.Web.Messaging;
//using System;
//using System.Threading.Tasks;
//#endregion

//namespace AwsSQSLabs.Web.Extensions
//{
//    public static class MessagePublisherExtensions
//    {
//        public static Task PublishAsync<T>(this IMessagePublisher publisher, T message, TimeSpan? delay = null) where T : class
//        {
//            return publisher.PublishAsync(typeof(T), message, delay);
//        }
//    }
//}
