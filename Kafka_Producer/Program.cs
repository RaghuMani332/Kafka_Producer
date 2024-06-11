// See https://aka.ms/new-console-template for more information
using Kafka_Producer;

Console.WriteLine("Hello, World!");
MessageProducer p = new MessageProducer();
p.produceMessage();