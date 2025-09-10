using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        IList<IList<int>> result = new List<IList<int>>();
        if (nums1.Length == 0 || nums2.Length == 0 || k == 0) {
            return result;
        }
        
        PriorityQueue<(int, int), int> heap = new PriorityQueue<(int, int), int>();
        
        for (int i = 0; i < Math.Min(nums1.Length, k); i++) {
            heap.Enqueue((i, 0), nums1[i] + nums2[0]);
        }
        
        while (k-- > 0 && heap.Count > 0) {
            var (i, j) = heap.Dequeue();
            result.Add(new List<int> { nums1[i], nums2[j] });
            
            if (j + 1 < nums2.Length) {
                heap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
            }
        }
        
        return result;
    }
}