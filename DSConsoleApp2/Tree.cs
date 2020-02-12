using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSConsoleApp2
{
	public class BinaryTree<T>
	{
		public Node<T> root;

		public BinaryTree(T key)
		{
			root = new Node<T>(key);
		}

		public BinaryTree()
		{
			root = null;
		}

		public void InOrderTeaversal(Node<T> root)
		{
			if (root == null)
				return;
			InOrderTeaversal(root.Left);
			Console.Write(root.Key + "," );
			InOrderTeaversal(root.Right);
		}

		public void LevelOrderTraversal(Node<T> root)
		{

		}

		public int HeightOfTree(Node<T> root)
		{
			Queue<Node<T>> queue = new Queue<Node<T>>();
			queue.Enqueue(root);
			int height = 0;
		

			while(1==1)
			{
				int nodeCount = queue.Count; // current node count at a level 
				if (nodeCount == 0) // if no nodes in queue than all leaves node is covered
					return height;

				height++;// move to next level 
				// Enque child nodes at same level 
				while(nodeCount>0)
				{
					Node<T> node = queue.Peek();
					Console.WriteLine($"visited node key {node.Key}");
					queue.Dequeue();
					if (node.Left != null)
						queue.Enqueue(node.Left);
					if (node.Right != null)
						queue.Enqueue(node.Right);
					nodeCount--;
				}

			}
		}
	}

	 public class Node <T>{
	public T Key;
	public Node<T> Left, Right;

		public Node(T key)
		{
			Key = key;
			Left = Right = null;
		}
	}


}
