using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Entities.Enums;
using Pedidos.Entities;
using System.Diagnostics;
using System.Globalization;

namespace Pedidos.Entities
{
    internal class Order
    {
        public DateTime Date { get; set; }
        public Enum Status { get; set; }
        public Client client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime date, OrdersStatus status, Client client)
        {
            Date = date;
            Status = status;
            this.client = client;
        }
        public void AddItem(OrderItem itens)
        {
            Items.Add(itens);
        }

        public void RemoveItem(OrderItem itens)
        {
            Items.Remove(itens);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }   





        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Sumary: ");
            sb.AppendLine("Order moment: ");
            sb.Append(Date.ToString("DD/MM/YY"));
            sb.AppendLine();
            sb.Append("Order status: ");
            sb.Append(Status);
            sb.AppendLine();
            sb.Append("Client: ");
            sb.Append(client);
            sb.AppendLine();
            sb.Append("Order items:");
            sb.AppendLine();
            foreach (OrderItem item in Items)
            {
                sb.Append(item);
            }
            sb.AppendLine("Total price: $ " + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }


    }
}
