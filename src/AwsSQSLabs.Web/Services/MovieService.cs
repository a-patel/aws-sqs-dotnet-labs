#region Imports
using System;
using System.Threading.Tasks;
using AwsSQSLabs.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Amazon.SQS;
using Amazon;
using Amazon.SQS.Model;
using AwsSQSLabs.Web.Configuration;
using Newtonsoft.Json;
#endregion

namespace AwsSQSLabs.Web.Services
{
    public class MovieService : IMovieService
    {
        #region Members

        private readonly ILogger<MovieService> _logger;
        private readonly AmazonSQSClient _sqsClient;
        private readonly string _queueUrl;

        #endregion

        #region Ctor

        public MovieService(IOptions<SQSConfig> settings, ILogger<MovieService> logger)
        {
            _logger = logger;

            try
            {
                var amazonSQSConfig = new AmazonSQSConfig();

                amazonSQSConfig.RegionEndpoint = RegionEndpoint.GetBySystemName(settings.Value.AWSRegion);
                amazonSQSConfig.Validate();

                _sqsClient = new AmazonSQSClient(amazonSQSConfig);
                _queueUrl = settings.Value.QueueUrl;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Couldn't create an instance of MovieService");
                throw;
            }
        }

        #endregion

        #region Methods

        public async Task PublishMovie(MovieModel movieData)
        {
            try
            {
                var data = JsonConvert.SerializeObject(movieData);

                var sendMessageRequest = new SendMessageRequest(_queueUrl, data);

                sendMessageRequest.MessageAttributes.Add("Publisher",
                    new MessageAttributeValue()
                    {
                        DataType = "String",
                        StringValue = "AwsSQSLabs.Web"
                    }
                );

                var sendMessageResponse = await _sqsClient.SendMessageAsync(sendMessageRequest);

                // save queue data
                _logger.LogInformation($"MessageId: {sendMessageResponse.MessageId}, SequenceNumber: {sendMessageResponse.SequenceNumber}");
                var metadata = sendMessageResponse.ResponseMetadata;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't publish an movie to SQS");
                throw;
            }
        }

        #endregion
    }
}
