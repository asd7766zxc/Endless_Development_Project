using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio
{
    public class Node
    {
        public void AddNode(Node node)
        {
            if (collection == null)
                collection = new List<Node>();
            
            collection.Add(node);
        }
        public List<Node> collection { get; set; }
        public object Value { get; set; }
    }
}
