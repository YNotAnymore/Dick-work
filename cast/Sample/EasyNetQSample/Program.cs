using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using EasyNetQ.FluentConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EasyNetQSample
{
    class Program
    {
        static void Main(string[] args)
        {

            IBus bus = RabbitHutch.CreateBus("");

            AutoSubscriber subscriber = new MySubscriber(bus, "wetherService");
            //subscriber.Subscribe(assembly);
            subscriber.SubscribeAsync(typeof(Program).Assembly.GetTypes());

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }

    public class MySubscriber : AutoSubscriber
    {
        public MySubscriber(IBus bus, string subscriptionIdPrefix) : base(bus, subscriptionIdPrefix)
        {
        }

        private static string[] GetTopAttributeValues(AutoSubscriberConsumerInfo subscriptionInfo)
        {
            return (from a in subscriptionInfo.ConsumeMethod.GetCustomAttributes(typeof(ForTopicAttribute), inherit: true).OfType<ForTopicAttribute>()
                    select a.Topic).ToArray();
        }

        private static SubscriptionConfigurationAttribute GetSubscriptionConfigurationAttributeValue(AutoSubscriberConsumerInfo subscriptionInfo)
        {
            return subscriptionInfo.ConsumeMethod.GetCustomAttributes(typeof(SubscriptionConfigurationAttribute), inherit: true).OfType<SubscriptionConfigurationAttribute>().FirstOrDefault();
        }

        private static Action<ISubscriptionConfiguration> TopicInfo(AutoSubscriberConsumerInfo subscriptionInfo)
        {
            string[] topAttributeValues = GetTopAttributeValues(subscriptionInfo);
            if (topAttributeValues.Length != 0)
            {
                return GenerateConfigurationFromTopics(topAttributeValues);
            }
            return delegate (ISubscriptionConfiguration configuration)
            {
                configuration.WithTopic("#");
            };
        }

        private static Action<ISubscriptionConfiguration> GenerateConfigurationFromTopics(string[] topics)
        {
            return delegate (ISubscriptionConfiguration configuration)
            {
                string[] array = topics;
                foreach (string topic in array)
                {
                    configuration.WithTopic(topic);
                }
            };
        }


        private static Action<ISubscriptionConfiguration> AutoSubscriberConsumerInfo(AutoSubscriberConsumerInfo subscriptionInfo)
        {
            SubscriptionConfigurationAttribute configSettings = GetSubscriptionConfigurationAttributeValue(subscriptionInfo);
            if (configSettings == null)
            {
                return delegate
                {
                };
            }
            return delegate (ISubscriptionConfiguration configuration)
            {
                if (configSettings.PrefetchCount > 0)
                {
                    configuration.WithPrefetchCount(configSettings.PrefetchCount);
                }
                if (configSettings.Expires > 0)
                {
                    configuration.WithExpires(configSettings.Expires);
                }
                configuration.WithAutoDelete(configSettings.AutoDelete).WithPriority(configSettings.Priority);
            };
        }


        private Action<ISubscriptionConfiguration> GenerateConfigurationAction(AutoSubscriberConsumerInfo subscriptionInfo)
        {
            return delegate (ISubscriptionConfiguration sc)
            {
                ConfigureSubscriptionConfiguration(sc);
                TopicInfo(subscriptionInfo)(sc);
                AutoSubscriberConsumerInfo(subscriptionInfo)(sc);
            };
        }


        protected override void InvokeMethods(IEnumerable<KeyValuePair<Type, AutoSubscriberConsumerInfo[]>> subscriptionInfos, string dispatchName, MethodInfo genericBusSubscribeMethod, Func<Type, Type> subscriberTypeFromMessageTypeDelegate)
        {
            foreach (KeyValuePair<Type, AutoSubscriberConsumerInfo[]> subscriptionInfo in subscriptionInfos)
            {
                AutoSubscriberConsumerInfo[] value = subscriptionInfo.Value;
                foreach (AutoSubscriberConsumerInfo autoSubscriberConsumerInfo in value)
                {
                    Delegate @delegate = AutoSubscriberMessageDispatcher.GetType().GetMethod(dispatchName, BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(autoSubscriberConsumerInfo.MessageType, autoSubscriberConsumerInfo.ConcreteType)
                        .CreateDelegate(subscriberTypeFromMessageTypeDelegate(autoSubscriberConsumerInfo.MessageType), AutoSubscriberMessageDispatcher);
                    AutoSubscriberConsumerAttribute subscriptionAttribute = GetSubscriptionAttribute(autoSubscriberConsumerInfo);
                    string text = (subscriptionAttribute != null) ? subscriptionAttribute.SubscriptionId : GenerateSubscriptionId(autoSubscriberConsumerInfo);
                    MethodInfo methodInfo = genericBusSubscribeMethod.MakeGenericMethod(autoSubscriberConsumerInfo.MessageType);
                    Action<ISubscriptionConfiguration> action = GenerateConfigurationAction(autoSubscriberConsumerInfo);
                    methodInfo.Invoke(bus, new object[3]
                    {
                text,
                @delegate,
                action
                    });
                }
            }
        }

    }

    public class WeatherForecastConsumer : IConsumeAsync<string>
    {
        [AutoSubscriberConsumer(SubscriptionId = "msg.test.sub")]
        public Task ConsumeAsync(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();
            return Task.CompletedTask;
        }
    }

}
