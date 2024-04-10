using Confluent.Kafka;

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "helpful-starfish-14766-us1-kafka.upstash.io:9092",
    SaslMechanism = SaslMechanism.ScramSha256,
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslUsername = "aGVscGZ1bC1zdGFyZmlzaC0xNDc2NiQ_c-kKpftU9ZHCrcsixMfd0m-jpyksnD0",
    SaslPassword = "NTlmMjRjMGMtNWIwYi00OWE5LTgyYTMtYTA4MTQ1MzY0ZWVk",
    GroupId = "YOUR_CONSUMER_GROUP",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

consumer.Subscribe("topico-exemplo");

while (true)
{
    var cr = consumer.Consume(TimeSpan.FromSeconds(1));
    if (cr != null)
    {
        Console.WriteLine($"Event key {cr.Message.Key}, value {cr.Message.Value}");
    }
}