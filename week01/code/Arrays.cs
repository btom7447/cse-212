public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // PLAN:
        // 1. Create a new array of type double with size equal to 'length'
        // 2. Loop from index 0 up to (length - 1)
        // 3. For each index i:
        //      - Compute the multiple as number * (i + 1)
        //      - Store that value in the array at position i
        // 4. Return the filled array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // PLAN:
        // 1. Understand that rotating right by 'amount' means:
        //      - The last 'amount' elements move to the front of the list
        //      - The remaining elements shift to the right
        // 2. Determine how many elements will stay at the front after rotation:
        //      - splitIndex = data.Count - amount
        // 3. Use GetRange to slice the list into two parts:
        //      - First part: elements from index 0 to splitIndex - 1
        //      - Second part: elements from index splitIndex to the end
        // 4. Clear the original list
        // 5. Add the second part first, then the first part
        // 6. This modifies the existing list directly

        int splitIndex = data.Count - amount;

        // Get the two slices
        List<int> firstPart = data.GetRange(0, splitIndex);
        List<int> secondPart = data.GetRange(splitIndex, data.Count - splitIndex);

        // Clear the original list
        data.Clear();

        // Rebuild the list in rotated order
        data.AddRange(secondPart);
        data.AddRange(firstPart);
    }
}