using System.Net;
using System.Net.Sockets;
using System.Text;

// Fast portnummer (const int ergo fast værdi kan ikke ændres)
const int port = 5000;

// Opretter serveren på denne computer
TcpListener listener = new TcpListener(IPAddress.Loopback, port);

// Starter serveren
listener.Start();

Console.WriteLine("Server started...");
Console.WriteLine("Waiting for client...");

// Venter på en client
TcpClient client = listener.AcceptTcpClient();

Console.WriteLine("Client connected!");

// Henter datastrømmen til kommunikationen
NetworkStream stream = client.GetStream();

// Buffer til modtagne bytes
byte[] buffer = new byte[1024];

// Modtager bytes fra clienten
int bytesRead = stream.Read(buffer, 0, buffer.Length);

// Bytes tilbage til tekst
string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

// Viser beskeden
Console.WriteLine("Received: " + message);

// Beskeden der skal sendes tilbage
string response = "PONG";

// Laver teksten om til bytes
byte[] responseData = Encoding.UTF8.GetBytes(response);

// Sender PONG tilbage til clienten
stream.Write(responseData, 0, responseData.Length);

Console.WriteLine("Sending: " + response);