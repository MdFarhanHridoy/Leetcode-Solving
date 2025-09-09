using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (frequencyMap.ContainsKey(num)) {
                frequencyMap[num]++;
            } else {
                frequencyMap.Add(num, 1);
            }
        }
        
        List<int>[] buckets = new List<int>[nums.Length + 1];
        foreach (var entry in frequencyMap) {
            int frequency = entry.Value;
            if (buckets[frequency] == null) {
                buckets[frequency] = new List<int>();
            }
            buckets[frequency].Add(entry.Key);
        }
        
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--) {
            if (buckets[i] != null) {
                result.AddRange(buckets[i]);
            }
        }
        
        return result.Take(k).ToArray();
    }
}