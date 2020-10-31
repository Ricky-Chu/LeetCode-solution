using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=692 lang=csharp
 *
 * [692] 前K个高频单词
 *
 * https://leetcode-cn.com/problems/top-k-frequent-words/description/
 *
 * algorithms
 * Medium (52.00%)
 * Likes:    172
 * Dislikes: 0
 * Total Accepted:    19.8K
 * Total Submissions: 38K
 * Testcase Example:  '["i", "love", "leetcode", "i", "love", "coding"]\n2'
 *
 * 给一非空的单词列表，返回前 k 个出现次数最多的单词。
 * 
 * 返回的答案应该按单词出现频率由高到低排序。如果不同的单词有相同出现频率，按字母顺序排序。
 * 
 * 示例 1：
 * 
 * 
 * 输入: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
 * 输出: ["i", "love"]
 * 解析: "i" 和 "love" 为出现次数最多的两个单词，均为2次。
 * ⁠   注意，按字母顺序 "i" 在 "love" 之前。
 * 
 * 
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"],
 * k = 4
 * 输出: ["the", "is", "sunny", "day"]
 * 解析: "the", "is", "sunny" 和 "day" 是出现次数最多的四个单词，
 * ⁠   出现次数依次为 4, 3, 2 和 1 次。
 * 
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * 假定 k 总为有效值， 1 ≤ k ≤ 集合元素数。
 * 输入的单词均由小写字母组成。
 * 
 * 
 * 
 * 
 * 扩展练习：
 * 
 * 
 * 尝试以 O(n log k) 时间复杂度和 O(n) 空间复杂度解决。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        // Count of Frequency of each word 
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach(var word in words)
        {
            if (!dict.ContainsKey(word))
                dict.Add(word, 1);
            else
                dict[word]++;

        }
        // dictionary in C# has inbuilt method for sorting both key and value 
        // Sort first by frequency and then by key in case of tie like same frequency 
        List<KeyValuePair<string, int>> test =
           dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).ToList();

        //  return top k keys from dict  
        return test.Select(x => x.Key).ToList();

    }
}
// @lc code=end

