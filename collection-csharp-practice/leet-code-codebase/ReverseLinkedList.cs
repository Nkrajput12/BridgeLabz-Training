/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        // Base case: if head is null or head is the last node
        if (head == null || head.next == null)
        {
            return head;
        }

        // Recursively reverse the rest of the list
        ListNode reversedList = ReverseList(head.next);

        // Reverse the current node's pointer
        head.next.next = head;
        head.next = null;

        return reversedList;
    }
}