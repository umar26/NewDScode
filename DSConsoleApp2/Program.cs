using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			#region commented code
			//	Graph<int> graph = new Graph<int>();
			//	graph.AddNode(1);
			//	graph.AddNode(2);
			//	graph.AddNode(3);
			//	graph.AddNode(4);
			//	graph.AddNode(5);
			//	graph.AddNode(6);
			//	graph.AddEdge(1, 2);
			//	graph.AddEdge(1, 3);
			//	graph.AddEdge(2, 4);
			//	graph.AddEdge(2, 5);
			//	graph.AddEdge(3, 5);
			//	graph.AddEdge(4, 6);
			//	graph.AddEdge(4, 5);
			//	graph.AddEdge(5, 6);

			//foreach(GraphNode<int> item in 	graph.Nodes)
			//	{
			//		var neighbours = graph.GetNeighboursByValue(item.Value);
			//		Console.WriteLine("neighbours of {1} are {0}", neighbours,item.Value);
			//	}
			//	Console.WriteLine("BFS Traversal============================");
			//	graph.BFS(1);
			//	Console.WriteLine("DFS Traversal ====================================");
			//	graph.DFS(1);
			//executeBalance();
			//string str = "((()((sswer()((";
			//List<string> resu = RemoveToBalance(str);
			//Console.WriteLine($"original string {str}");
			//foreach (var item in resu)
			//{
			//	Console.WriteLine($"{item}");
			//}

			//int[][] a = new int[4][];
			//a[0] = new int[3] { 2, 6, 8 };
			//a[1] = new int[3] { 3, 5, 7 };
			//a[2] = new int[3] { 1, 8, 1 };
			//a[3] = new int[3] { 5, 9, 15 };


			//long axval = arrayManipulation(10, a);

			//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

			//string firstinput = Console.ReadLine();
			//int querycount = Convert.ToInt32(firstinput);
			//for (int i = 0; i < querycount; i++)
			//{
			//	string input = Console.ReadLine();
			//	string[] strinput = input.Split(' ');
			//	if (strinput.Length == 2)
			//	{
			//		int input1 = Convert.ToInt32(strinput[0]);
			//		int input2 = Convert.ToInt32(strinput[1]);

			//		SolveQuery(input1, input2);
			//	}
			//	else if (strinput.Length == 1)
			//	{
			//		int input1 = Convert.ToInt32(strinput[0]);
			//		SolveQuery(input1, null);
			//	}

			//	}

			//Qwith2Stack.SolveQuery(1, 42);
			//Qwith2Stack.SolveQuery(2,null);
			#endregion
			string str = "AbhiUmar";
			int diff = 'a' - 'A';
			char[] charstr = str.ToCharArray();
		
			Console.WriteLine("char vale {0}", 'c'-0);
			Console.WriteLine("char vale {0}", (char)('a' +diff));
			Console.WriteLine("char vale {0}", 'C'-0);
			Console.ReadKey();
			solution s = new solution();
			//solution.SinglyLinkedList slist = new solution.SinglyLinkedList();
			//solution.SinglyLinkedList slist2 = new solution.SinglyLinkedList();
			//for (int i = 1; i <= 5; i++)
			//{
			//	solution.SinglyLinkedListNode headnode = solution.insertNodeAtTail(slist.head, 5 * i);

			//	slist.head = headnode;
			//}
			//for (int i = 1; i <= 5; i++)
			//{
			//	solution.SinglyLinkedListNode headnode = solution.insertNodeAtTail(slist2.head,10 * i);

			//	slist2.head = headnode;
			//}
			//solution.insertNodeAtPosition(slist.head, 1, 2);
			//solution.reversePrint(slist.head);
			//solution.mergeLists(slist.head, slist2.head);
			//solution.SinglyLinkedListNode.printLinkedList(slist.head);

			solution.DoublyLinkList dblylinklist = new solution.DoublyLinkList();
			//for (int i = 1; i < 4; i++)
			//{
			//	dblylinklist.insertNode(i);
			//}
			//dblylinklist.insertNode(2);
			//dblylinklist.insertNode(3);
			//dblylinklist.insertNode(4);
			//dblylinklist.insertNode(10);
			//solution.sortedInsert(dblylinklist.head,1);

			BinaryTree<int> tree = new BinaryTree<int>(10);
			tree.root.Left = new Node<int>(20);
			tree.root.Right = new Node<int>(30);
			tree.root.Left.Left = new Node<int>(40);
			tree.root.Left.Right = new Node<int>(50);
			tree.root.Left.Right.Left = new Node<int>(60);
			tree.root.Left.Right.Right = new Node<int>(70);

			var height= tree.HeightOfTree(tree.root);
			Console.WriteLine($"Height of tree {height}");
			//tree.InOrderTeaversal(tree.root);
			Console.ReadLine();
			// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
		}

		static void ArrayDiagram(int count)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;

			Console.Write(ConsoleKey.Tab);

			for (int i = 0; i < count; i++)
			{

				Console.Write("__");

			}
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write(ConsoleKey.Tab);

			for (int i = 0; i < count; i++)
			{
				Console.Write("| ");

			}
			Console.WriteLine();
			Console.Write(ConsoleKey.Tab);
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			for (int i = 0; i < count; i++)
			{
				Console.Write("__");
			}

		}

		static bool isBalance(string str)
		{
			// ))(a)((
			int ctr = 0;
			char[] symbols = str.ToCharArray();
			for (int i = 0; i < symbols.Length; i++)
			{
				if (symbols[i] == '(') ctr++;
				else if (symbols[i] == ')') ctr--;
				if (ctr < 0) return false;
			}
			return ctr == 0;
		}
		static void executeBalance()
		{
			ConsoleKeyInfo nextrey;
			do
			{
				Console.WriteLine();
				Console.WriteLine("Please enter string to verify balance bracket");
				string str = Console.ReadLine();

				bool isbal = isBalanceForAllBracketTypes(str);
				Console.WriteLine($"str={str}  is balance {isbal}");
				Console.WriteLine("do you want more hit y or n");
				nextrey = Console.ReadKey();
			}
			while (nextrey.Key == ConsoleKey.Y);

			Console.ReadKey();
		}

		static bool isBalanceForAllBracketTypes(string str)
		{
			Stack<char> charStack = new Stack<char>();
			char[] symbols = str.ToCharArray();

			for (int i = 0; i < symbols.Length; i++)
			{
				if (symbols[i] == '(' || symbols[i] == '{' || symbols[i] == '[')
					charStack.Push(symbols[i]);
				else if (symbols[i] == ')' || symbols[i] == '}' || symbols[i] == ']')
				{
					if (charStack.Count == 0)
						return false;
					if (!isMatchigBracket(charStack.Pop(), symbols[i]))
						return false;
				}

			}
			if (charStack.Count == 0)
				return true;
			else
				return false;
		}

		static bool isMatchigBracket(char char1, char char2)
		{
			return char1 == '(' && char2 == ')' || char1 == '{' && char2 == '}' || char1 == '[' && char2 == ']';
		}

		static List<string> RemoveToBalance(string str)
		{
			Queue<string> Q = new Queue<string>();
			Dictionary<string, bool> visited = new Dictionary<string, bool>();
			List<string> solutions = new List<string>();
			Q.Enqueue(str);
			int ctr = 0;
			while (Q.Count > 0)
			{
				var dstr = Q.Dequeue();
				if (visited.ContainsKey(dstr)) continue;

				visited.Add(dstr, true);
				bool found = false;
				if (isBalance(dstr))
				{
					found = true;
					solutions.Add(dstr);
				}
				if (found) continue;
				char[] strarray = dstr.ToCharArray();
				for (int i = 0; i < strarray.Length; i++)
				{
					ctr++;
					if (strarray[i] == '(' || strarray[i] == ')')
					{
						string toaddstr = dstr.Substring(0, i) + dstr.Substring(i + 1, strarray.Length - i - 1);
						Q.Enqueue(toaddstr);
					}
				}
			}
			Console.WriteLine($" no fo times for loop executed {ctr}");
			return solutions;
		}

		//static int Stackheight(int[] h1, int[] h2, int[]h3)
		//{

		//}

		static int[] reverseArray(int[] a)
		{
			int[] b = new int[a.Length];

			for (int i = a.Length, k = 0; i >= 0; i--, k++)
			{
				b[k] = a[i];
				Console.Write(a[i] + " ");
			}
			return b;
		}

		static int[] leftrotation(int[] a, int d)
		{

			int runcnt = d % a.Length;
			while (runcnt > 0)
			{
				int fele = a[0];
				for (int i = 0; i < a.Length - 1; i++)
				{

					a[i] = a[i + 1];
				}
				a[a.Length - 1] = fele;
				runcnt--;
			}
			return a;
		}
		static int[] leftrotationlineartime(int[] a, int d)
		{
			int runcnt = d % a.Length;
			if (runcnt == 0)
				return a;
			int[] b = new int[a.Length];
			int lastindextost = a.Length - runcnt;
			for (int i = 0; i < lastindextost; i++)
			{
				b[i] = a[runcnt + i];
			}

			for (int i = lastindextost, k = 0; i < b.Length; i++, k++)
			{
				b[i] = a[k];
			}

			return b;
		}

		static int[] matchingStrings(string[] strings, string[] queries)
		{
			Dictionary<string, int> stringcnts = new Dictionary<string, int>();
			for (int i = 0; i < strings.Length; i++)
			{
				if (stringcnts.ContainsKey(strings[i]))
				{

					stringcnts[strings[i]] += 1;

				}
				else
				{
					stringcnts.Add(strings[i], 1);
				}
			}

			int[] resultset = new int[queries.Length];
			for (int i = 0; i < queries.Length; i++)
			{
				if (stringcnts.ContainsKey(queries[i]))
				{
					resultset[i] = stringcnts[queries[i]];
				}
				else
					resultset[i] = 0;
			}

			return resultset;

		}

		static long arrayManipulation(int n, int[][] queries)
		{
			long[] array = new long[n];

			int startindex, endindex, sumval;

			for (int i = 0; i < queries.Length; i++)
			{
				startindex = queries[i][0];
				endindex = queries[i][1];
				sumval = queries[i][2];

				for (int k = startindex; k <= endindex; k++)
				{
					array[k - 1] = array[k - 1] + sumval;
				}

			}

			//long maxvalue= array.Max();
			Array.Sort(array);
			long maxvalue = array.ToList().OrderByDescending(r => r).FirstOrDefault();
			//long maxvalue= array[array.Length - 1];
			foreach (var item in array)
			{
				Console.WriteLine(item);
			}
			return maxvalue;

		}


		static Stack<int> stack1= new Stack<int>();
		static Stack<int> stack2 = new Stack<int>();

		
		static void Enqueue(int item)
		{
			stack1.Push(item);
		}

		static void Dequeue()
		{
			if (stack2.Count == 0)
			{
				while (stack1.Count > 0)
				{
					int popeditem = stack1.Pop();
					stack2.Push(popeditem);
				}
			}

			stack2.Pop();
		}

		static void PrintHeadElement()
		{
			if (stack2.Count == 0)
			{
				while (stack1.Count > 0)
				{
					int popeditem = stack1.Pop();
					stack2.Push(popeditem);
				}
			}
			int peekedele = stack2.Peek();
			Console.WriteLine(peekedele);
		}

		public static void SolveQuery(int operation, int? value)
		{
			switch (operation)
			{
				case 1:
					Enqueue((int)value);
					break;
				case 2:
					Dequeue();
					break;
				case 3:
					PrintHeadElement();
					break;
			}
		}


	}

	 class Qwith2Stack
	{
		static Stack<int> stack1;
		static Stack<int> stack2;

		static Qwith2Stack()
		{
			stack1 = new Stack<int>();
			stack2 = new Stack<int>();
		}

	static	void Enqueue(int item)
		{
			stack1.Push(item);
		}

	static	void Dequeue()
		{
			if (stack2.Count == 0)
			{
				while(stack1.Count>0)
				{ 
					int popeditem = stack1.Pop();
					stack2.Push(popeditem);
				}
			}

			stack2.Pop();
		}

	static void PrintHeadElement()
		{
			if (stack2.Count == 0)
			{
				while(stack1.Count>0)
				{
					int popeditem = stack1.Pop();
					stack2.Push(popeditem);
				}
			}
			int peekedele= stack2.Peek();
			Console.WriteLine(peekedele);
		}

	public	static void SolveQuery(int operation, int? value)
		{
			switch(operation)
			{
				case 1:
					Enqueue((int)value);
					break;
				case 2:
					Dequeue();
					break;
				case 3:
					PrintHeadElement();
					break;
			}
		}

	}
}
