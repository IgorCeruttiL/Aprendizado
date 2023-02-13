using System;
using Pedidos.Entities.Enums;
using Pedidos.Entities;
using System.ComponentModel;

namespace Pedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dados do cliente.
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client clientes = new Client(name, email, date);

            //Data do pedido.
            Console.Write("Enter order data: ");
            DateTime data = DateTime.Now;

            //status do pedido convertido dos enum.
            Console.Write("Status: ");
            OrdersStatus status = (OrdersStatus)Enum.Parse(typeof(OrdersStatus), Console.ReadLine());

            //Entrando com a quantidade de itens, nome e valor.
            Order order = new Order(DateTime.Now, status, clientes);
            Console.Write("How many itens in this order: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product Name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());
                Product produto = new Product(nameProduct, price);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());


                OrderItem orderItem = new OrderItem(quantity, price, produto);
                order.AddItem(orderItem);


            }

            
            Console.WriteLine(order);

           
        }
    }
}