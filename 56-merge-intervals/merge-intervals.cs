using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) {
            return new int[0][];
        }
        
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        
        List<int[]> merged = new List<int[]>();
        merged.Add(intervals[0]);
        
        for (int i = 1; i < intervals.Length; i++) {
            int[] last = merged[merged.Count - 1];
            int[] current = intervals[i];
            
            if (current[0] <= last[1]) {
                last[1] = Math.Max(last[1], current[1]);
            } else {
                merged.Add(current);
            }
        }
        
        return merged.ToArray();
    }
}