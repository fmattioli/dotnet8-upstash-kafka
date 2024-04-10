using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;

namespace Upstash.Api.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] string conteudoMensagem)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "helpful-starfish-14766-us1-kafka.upstash.io:9092",
                SaslMechanism = SaslMechanism.ScramSha256,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "aGVscGZ1bC1zdGFyZmlzaC0xNDc2NiQ_c-kKpftU9ZHCrcsixMfd0m-jpyksnD0",
                SaslPassword = "NTlmMjRjMGMtNWIwYi00OWE5LTgyYTMtYTA4MTQ1MzY0ZWVk"
            };

            using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            await producer.ProduceAsync("topico-exemplo", new Message<Null, string> { Value = conteudoMensagem });
            Console.WriteLine("Message sent successfully");

            return Ok();
        }
    }
}
