// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:1453");
ISubscriber sub = redis.GetSubscriber();


    await sub.SubscribeAsync("Kanal.*" , (channel , value)=>{
        Console.Write(value);
    });

    Console.Read();
