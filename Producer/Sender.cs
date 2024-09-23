using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("MetaQueue", false, false, false, null);

        var message = "Bienvenido al curso de rabbitMQ y .NET";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", "MetaQueue", null, body);
        Console.WriteLine("El mensaje fue enviado {0}", message);
    }
    Console.WriteLine("Preciona [enter ] para salir de la aplicacion");
    Console.ReadLine();
}

