using System;
using System.Threading;
using Confluent.Kafka;
using System.Text.Json;
using System.Collections.Generic;
using ConsumerKafka.Domain.Entity;
using ConsumerKafka.Domain.Service;

namespace ConsumerKafka
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            BolsaFamiliaService service = new BolsaFamiliaService();
            
            var conf = new ConsumerConfig
            {
                GroupId = "consumer-group-1",
                BootstrapServers = "192.168.0.37:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("bolsa-familia");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);

                            BeneficiarioEntity beneficiario = JsonSerializer.Deserialize<BeneficiarioEntity>(cr.Value);
                            service.ExibirTotaisBolsaFamilia(beneficiario);

                            //Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
