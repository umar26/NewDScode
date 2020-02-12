using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSConsoleApp2
{

	public class solution
	{
		public class SinglyLinkedListNode
		{

			public int data;
			public SinglyLinkedListNode next;

			public SinglyLinkedListNode(int nodeData)
			{
				this.data = nodeData;
				this.next = null;
			}

			public static void printLinkedList(SinglyLinkedListNode head)
			{
				SinglyLinkedListNode currnode;
				currnode = head;
				while (currnode != null)
				{
					Console.WriteLine(currnode.data);
					currnode = currnode.next;
				}

			}
		}

		public class SinglyLinkedList
		{
			public SinglyLinkedListNode head;
			public SinglyLinkedListNode tail;

			public SinglyLinkedList()
			{
				this.head = null;
				this.tail = null;
			}

			public void InsertNode(int nodeData)
			{
				SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

				if (this.head == null)
				{
					this.head = node;
				}
				else
				{
					this.tail.next = node;
				}

				this.tail = node;
			}
		}

		#region singly link list node  problems
		public static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
		{
			SinglyLinkedListNode node = new SinglyLinkedListNode(data);
			if (head == null)
			{

				return node;
			}
			SinglyLinkedListNode currnode = head;
			while (currnode.next != null)
			{
				currnode = currnode.next;
			}

			currnode.next = node;


			//SinglyLinkedListNode.printLinkedList(head);
			return head;
		}
		public static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode head, int data)
		{
			SinglyLinkedListNode node = new SinglyLinkedListNode(data);
			if (head == null)
			{

				return node;
			}
			node.next = head;
			return node;
		}

		public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
		{
			SinglyLinkedListNode node = new SinglyLinkedListNode(data);
			if (head == null)
			{

				return node;
			}

			if(position==0)
			{
				node.next = head;
				head = node;
				return head;
			}
			SinglyLinkedListNode currnode = head;
			for (int i = 1
; i < position; i++)
			{
				currnode = currnode.next;
			}
			node.next = currnode.next;
			currnode.next = node;

			return head;
		}

		static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
		{

			SinglyLinkedListNode currnode = head;
			SinglyLinkedListNode prevnode = null;
			if(position==0)
			{
				head = currnode.next;
				return head;
			}
			for (int i = 1; i <= position; i++)
			{
				prevnode = currnode;
				currnode = currnode.next;
			}
			prevnode.next = currnode.next;

			return head;

		}

		public static void reversePrint(SinglyLinkedListNode head)
		{
			List<int> vallist = new List<int>();
			
			if (head == null)
				return;
			SinglyLinkedListNode currnode = head;
			while(currnode!=null)
			{
				vallist.Add(currnode.data);
				currnode = currnode.next;
			}

			for (int i = vallist.Count-1; i>= 0 ; i--)
			{
				Console.WriteLine(vallist[i]);
			}
		}

		static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
		{
			if (head == null)
				return head;

			SinglyLinkedListNode prev = null;
			SinglyLinkedListNode curr = head;
			SinglyLinkedListNode next = null;
			while(curr!=null)
			{
				next = curr.next;
				curr.next = prev;
				prev = curr;
				curr = next;
			}

			head = prev;
			return head;
		}

		static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)

		{
			SinglyLinkedListNode currnode1 = head1;
			SinglyLinkedListNode currnode2 = head2;
			bool isEqualList = false;
			while (currnode1!=null)
			{
				if ((currnode1!=null && currnode2!=null) && currnode1.data == currnode2.data)
				{
					isEqualList = true;
					currnode1 = currnode1.next;
					currnode2 = currnode2.next;
				}

				else
				{
					return false;
				}
			}
			return isEqualList;
		}

	public	static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
		{
			SinglyLinkedList finallinklist = new SinglyLinkedList();
			//finallinklist.InsertNode()
			SinglyLinkedListNode currnode1 = head1;
			SinglyLinkedListNode currnode2 = head2;

			while (currnode1 != null && currnode2 != null)
			{
				if (currnode1.data < currnode2.data)
				{
					finallinklist.InsertNode(currnode1.data);
					currnode1 = currnode1.next;
				}
				else if (currnode1.data > currnode2.data)
				{
					finallinklist.InsertNode(currnode2.data);
					currnode2 = currnode2.next;
				}
				else
				{
					finallinklist.InsertNode(currnode1.data);
					finallinklist.InsertNode(currnode2.data);
					currnode1 = currnode1.next;
					currnode2 = currnode2.next;
				}

			}

			if(currnode1==null)
			{
				finallinklist.tail.next = currnode2;
			}
			else if(currnode2==null)
			{
				finallinklist.tail.next = currnode1;
			}
			return finallinklist.head;
		}

		static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)


		{

			Dictionary<int, int> keycountdic = new Dictionary<int, int>();
			SinglyLinkedListNode currnode = head;
			SinglyLinkedListNode prevnode = null;
			int data = 0;
			while(currnode!=null)
			{
				
				data = currnode.data;
				

				if(keycountdic.ContainsKey(data))
				{
					 prevnode.next = currnode.next;
						currnode.next = null;
					currnode = prevnode.next;
				}
				else
				{
					keycountdic.Add(data, 1);
					prevnode = currnode;
					currnode = currnode.next;

				}
			}
			return head;

		}

		static bool hasCycle(SinglyLinkedListNode head)
		{
			
			Dictionary<SinglyLinkedListNode, bool> visiteddic = new Dictionary<SinglyLinkedListNode, bool>();

			SinglyLinkedListNode currnode = head;
			bool isCycle = false;
			while(currnode!=null)
			{
				if (visiteddic.ContainsKey(currnode))
				{
					isCycle = true;

					break;
				}
				else
				{
					visiteddic.Add(currnode, true);
				}
				currnode = currnode.next;
			}
			return isCycle;
		}

		static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
		{

			Dictionary<SinglyLinkedListNode, bool> visiteddic = new Dictionary<SinglyLinkedListNode, bool>();
			SinglyLinkedListNode currnode1 = head1;
			while(currnode1!=null)
			{
				visiteddic.Add(currnode1, true);
				currnode1 = currnode1.next;
				
			}
			SinglyLinkedListNode currnode2 = head2;
			while(currnode2!=null)
			{
				if(visiteddic.ContainsKey(currnode2))
				{
					break;
				}
				currnode2 = currnode2.next;
			}
			return currnode2.data;
		}

		#endregion


		public class DoublyLinkedListNode
		{
			public int data;
			public DoublyLinkedListNode next ;
			public DoublyLinkedListNode prev ;

			public DoublyLinkedListNode(int data)
			{
				this.data = data;
				this.next = null;
				this.prev = null;
			}
		}

		public class DoublyLinkList
		{
			public DoublyLinkedListNode head;
			 public DoublyLinkedListNode tail;

			public DoublyLinkList()
			{
				this.head = null;
				this.tail = null;
			}

			public void insertNode(int data)
			{
				DoublyLinkedListNode node = new DoublyLinkedListNode(data);
				if (this.head == null)
					this.head = node;
				else
				{
					this.tail.next = node;
					node.prev = this.tail;
				}

				this.tail = node;
			}
		}

		public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
		{
			DoublyLinkedListNode node = new DoublyLinkedListNode(data);
			if (head == null)
				head = node;

			DoublyLinkedListNode currnode = head;
			
			while(currnode.next!=null && currnode.data<=data)
			{
				//prevnode = currnode;
				currnode = currnode.next;	
			}
			if(currnode==head)
			{
				node.next = currnode;
				currnode.prev = node;
				head = node;
			}
		else if(currnode.next==null && currnode.data<=data)
			{
				currnode.next = node;
				node.prev = currnode;
			}
			else 
			{
				node.next = currnode;
				currnode.prev.next = node;
				currnode.prev = node;
			}


			return head;

		}

		public static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
		{
			if (head == null)
				return head;

			DoublyLinkedListNode curnode = head;
			DoublyLinkedListNode prevnode = null;
			while(curnode!=null)
			{
				prevnode = curnode.prev;
				curnode.prev = curnode.next;
				curnode.next = prevnode;
				curnode = curnode.prev;
			}

			//prevnode = prevnode;
			if (prevnode != null)
			{
				head = prevnode.prev;
			}
			return head;

		}
	}
}
