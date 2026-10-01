using System.Net.Sockets;
using System.Text;

// Serverens adresse
const string host = "localhost";

// Fast portnummer
const int port = 5000;

// Opretter en TCP client
TcpClient client = new TcpClient();

// Forbinder til serveren
client.Connect(host, port);

// Skriver når forbindelsen er oprettet
Console.WriteLine("Connected to server!");

// Henter datastrømmen til kommunikationen
NetworkStream stream = client.GetStream();

// Beskeden der skal sendes
string message = "PING";

// Laver teksten om til bytes
byte[] data = Encoding.UTF8.GetBytes(message);

// Sender bytes til serveren - data(hvilken byte skal sendes, 0 hvor i arayet, data.length hvor mange bytes skal vi sende)
stream.Write(data, 0, data.Length);

Console.WriteLine("Sending: PING");

// Buffer til svaret fra serveren
byte[] buffer = new byte[1024];

// Modtager bytes fra serveren
int bytesRead = stream.Read(buffer, 0, buffer.Length);

// Laver bytes om til tekst
string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

// Viser serverens svar
Console.WriteLine("Received: " + response);