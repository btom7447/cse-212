using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items A(2), B(5), C(3), D(5). Dequeue should return highest priority first.
    // Expected Result: B, D, C, A
    // Defect(s) Found: Original code failed to remove items and could pick wrong items if last element had highest priority.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);
        pq.Enqueue("D", 5);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException("The queue is empty.")
    // Defect(s) Found: Original code handled empty queue correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected InvalidOperationException.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: FIFO behavior for items with same priority
    // Expected Result: Enqueue X(4), Y(4), Z(2) → Dequeue returns X first, then Y, then Z
    // Defect(s) Found: Original code incorrectly returned last item with same priority instead of first.
    public void TestPriorityQueue_FIFOSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 4);
        pq.Enqueue("Y", 4);
        pq.Enqueue("Z", 2);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with descending priorities
    // Expected Result: Dequeue returns items in strict descending order
    // Defect(s) Found: Original code did not remove items; ordering could be broken.
    public void TestPriorityQueue_StrictDescending()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and interleaved insertion
    // Expected Result: FIFO is respected within same priority group
    // Defect(s) Found: Original code could pick last inserted of same priority
    public void TestPriorityQueue_InterleavedSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 3);
        pq.Enqueue("D", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }
}