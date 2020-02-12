using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSConsoleApp2
{
	public class GraphNode<T>
	{
		T value;
		List<GraphNode<T>> neighbours;


		public GraphNode(T value)
		{
			this.value = value;
			neighbours = new List<GraphNode<T>>();
		}

	public	T Value
		{
			get { return value; }
		}

	public	IList<GraphNode<T>> Neighbours
		{

			get { return this.neighbours.AsReadOnly(); }
		}

	public	bool AddNeighbour(GraphNode<T> neighbour)
		{

			if (neighbours.Contains(neighbour))
			{
				return false;
			}
			else
			{
				neighbours.Add(neighbour);
				return true;
			}
		}

	public	bool RemoveNeighbour(GraphNode<T> neighbour)
		{

			return neighbours.Remove(neighbour);

		}

	public	bool RemoveAllNeighbours()
		{
			foreach (var item in neighbours)
			{
				neighbours.Remove(item);
			}
			return true;
		}

	public override string ToString()
		{
			StringBuilder nodeString = new StringBuilder();
			nodeString.Append("[Node Value: " + value + " Neighbours: ");
			foreach (var item in neighbours)
			{
				nodeString.Append(item.value + " ");
			}
			nodeString.Append("]");

			return nodeString.ToString();
		}
			

	}

	public class Graph<T>
	{

		List<GraphNode<T>> nodes = new List<GraphNode<T>>();


		public Graph()
		{

		}

		public int Count
		{
			get { return nodes.Count; }
		}

		public IList<GraphNode<T>> Nodes
		{
			get { return nodes.AsReadOnly();}
		}


		public void Clear()
		{
			foreach (GraphNode<T> node in nodes)
			{
				node.RemoveAllNeighbours();
			}

			foreach (var node in nodes)
			{
				nodes.Remove(node);
			}
		}

		public bool AddNode(T value)
		{
			if(Find(value)!=null)
			{
				// duplicate value
				return false;
			}
			else
			{
				nodes.Add(new GraphNode<T>(value));
				return true;
			}
		}

		public bool AddEdge(T value1, T value2)
		{
			GraphNode<T> node1 = Find(value1);
			GraphNode<T> node2 = Find(value2);
			if (node1 == null || node2 == null)
			{
				return false;
			}
			else if (node1.Neighbours.Contains(node2))
			{
				return false;
			}
			else
			{
				node1.AddNeighbour(node2);
				node2.AddNeighbour(node1);
			}
			return true;		
		}
		public GraphNode<T>Find(T value)
		{
			foreach (GraphNode<T> node in nodes)
			{
				if(node.Value.Equals(value))
				{
					return node;
				}
			}
			return null;
		}

		public string GetNeighboursByValue(T value)
		{
			string neighboursstr = string.Empty;
			GraphNode<T> currNode = Find(value);
			if(currNode!=null)
			{
				List<GraphNode<T>> neighbours = currNode.Neighbours.ToList();

				neighboursstr = currNode.ToString();
			
				
			}
			return neighboursstr;
		}


		// complexity is O(V+E)
		public void BFS(T startnodeval) 
		{

			Queue<T> queue = new Queue<T>();
			queue.Enqueue(startnodeval);

			Dictionary<T, bool> visited = new Dictionary<T, bool>(Count);
			int k = 0;
			visited.Add(startnodeval, true);
			Console.WriteLine(" [{1}]: adding to visited list value is {0}", startnodeval, ++k);
			while (queue.Count!=0)
			{
				T dequeval = queue.Dequeue();
				Console.WriteLine("[{1}] : Dequeue value is {0}", dequeval,++k);
				var isAvail= Find(dequeval);
				if(isAvail!=null)
				{
					List<GraphNode<T>> neighbours = isAvail.Neighbours.ToList();
					for (int i = 0; i < neighbours.Count; i++)
					{
						T cureleval = neighbours[i].Value;
						if(!visited.ContainsKey(cureleval))
						{
							visited.Add(cureleval, true);
							Console.WriteLine(" [{1}]: adding to visited list value is {0}", cureleval,++k);
							queue.Enqueue(cureleval);
							Console.WriteLine("adding to queue  {0}", cureleval);
						}
					}

				}
			}
		}

		public void DFS(T startnodeval)
		{

			Stack<T> stack = new Stack<T>();
			Dictionary<T, bool> visited = new Dictionary<T, bool>(Count);
			visited.Add(startnodeval, true);
			int k = 0;
			Console.WriteLine("[{1}] visited  first item value {0}", startnodeval,++k);
			stack.Push(startnodeval);
			
			while(stack.Count>0)
			{
				T curele = stack.Pop();
				Console.WriteLine(" [{1}] next element  poped -> {0}", curele,++k);
				GraphNode<T> currNode = Find(curele);
				List<GraphNode<T>> neighbrs = currNode.Neighbours.ToList();
				foreach (var item in neighbrs)
				{
					if(!visited.ContainsKey(item.Value))
					{
						visited.Add(item.Value, true);
						Console.WriteLine("[{1}]: visited item value {0}", item.Value,++k);
						stack.Push(item.Value);
					}
				}

			}
			

		}
	}


}
