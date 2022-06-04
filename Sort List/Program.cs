namespace Sort_List
{
  public class ListNode
  {
    public int val { get; set; }
    public ListNode next { get; set; }
    public ListNode(int val = -1, ListNode next = null)
    {
      this.val = val;
      this.next = next;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      ListNode head = new ListNode(4);
      head.next = new ListNode(2);
      head.next.next = new ListNode(1);
      head.next.next.next = new ListNode(3);
      Solution s = new Solution();
      var result = s.SortList(head);
    }
  }
  public class Solution
  {
    public ListNode SortList(ListNode head)
    {
      // Step 1 - find the middle of the linkedlist.
      // Step 2 - perform merge sort for each half
      // a. divide.
      // b. merge.

      if (head == null || head.next == null) return head;
      // Step 1
      ListNode slow = head;
      ListNode fast = head;
      // use of prev is to capture the previous node of middle, as we are dividing the list from middle, so from middle to end we have right list, and head to prev we 
      // will have left list
      ListNode prev = null;

      while (fast != null && fast.next != null)
      {
        prev = slow;
        slow = slow.next;
        fast = fast.next.next;
      }

      // Step 2
      // a. divide

      // break the list into two half and mark the left list end as null
      prev.next = null;
      // left list
      var list1 = head;
      // right list
      var list2 = slow;

      var left = SortList(list1);
      var right = SortList(list2);

      // b. merge
      ListNode proxy = new ListNode(-1);
      ListNode top = proxy;
      while (left != null || right != null)
      {
        int val1 = left == null ? int.MaxValue : left.val;
        int val2 = right == null ? int.MaxValue : right.val;
        if (val1 < val2)
        {
          top.next = left;
          left = left.next;
        }
        else
        {
          top.next = right;
          right = right.next;
        }
        top = top.next;
      }

      return proxy.next;
    }
  }
}
