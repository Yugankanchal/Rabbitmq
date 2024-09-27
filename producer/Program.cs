    using System;
    using System.Text;
    using RabbitMQ.Client;


    var factory = new ConnectionFactory()
    {
        HostName = "localhost"
    };

    var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

    channel.QueueDeclare(
        queue: "LetterBox",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null
    );

    var message = "This is my First message Hello Everyone";

    var encodeMessage = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "LetterBox", null, encodeMessage);

    Console.WriteLine($"published message {message}");