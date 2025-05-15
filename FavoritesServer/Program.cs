using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

class FavoritesServer
{
    static List<string> favoriteFoods = new List<string>();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Server started on port 5000");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            var stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int read = stream.Read(buffer, 0, buffer.Length);
            string request = Encoding.UTF8.GetString(buffer, 0, read);

            string response = "";

            if (request.StartsWith("ADD:"))
            {
                string food = request.Substring(4);
                favoriteFoods.Add(food);
                response = "Added: " + food;
            }
            else if (request == "GET")
            {
                response = string.Join(",", favoriteFoods);
            }

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);

            client.Close();
        }
    }
}
