using MunicipalityApp.Models;

namespace MunicipalityApp.Data
{
    public class IssueNode
    {
        public Issue Data { get; set; }
        public IssueNode? Next { get; set; }

        public IssueNode(Issue data)
        {
            Data = data;
        }
    }

    public class IssueQueue
    {
        private IssueNode? _head;
        private IssueNode? _tail;
        private int _counter;
        private readonly object _lock = new object();

        public void Enqueue(Issue item) //(GeeksforGeeks, 2025)
        {
            lock (_lock)
            {
                item.Id = ++_counter;

                var node = new IssueNode(item);
                if (_tail == null)
                {
                    _head = _tail = node;
                }
                else
                {
                    _tail.Next = node;
                    _tail = node;
                }
            }
        }

        public List<Issue> GetAll() //(GeeksforGeeks, 2025)
        {
            var list = new List<Issue>();
            lock (_lock)
            {
                var cur = _head;
                while (cur != null)
                {
                    list.Add(cur.Data);
                    cur = cur.Next;
                }
            }
            return list;
        }

        public bool IsEmpty()
        {
            lock (_lock) return _head == null;
        }
    }
}

//GeeksforGeeks (2024). Queue using Linked List in C. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/c/queue-using-linked-list-in-c/ [Accessed 10 Sep. 2025].


