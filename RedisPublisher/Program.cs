// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:1453");
ISubscriber sub = redis.GetSubscriber();

while (true)
{
    Console.WriteLine("Mesaj");
    string message = Console.ReadLine();
    await sub.PublishAsync("Kanal.*",message);    
}
