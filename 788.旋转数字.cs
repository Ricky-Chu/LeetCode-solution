/*
 * @lc app=leetcode.cn id=788 lang=csharp
 *
 * [788] 旋转数字
 *
 * https://leetcode-cn.com/problems/rotated-digits/description/
 *
 * algorithms
 * Easy (59.79%)
 * Likes:    68
 * Dislikes: 0
 * Total Accepted:    10.8K
 * Total Submissions: 18.1K
 * Testcase Example:  '10'
 *
 * 我们称一个数 X 为好数, 如果它的每位数字逐个地被旋转 180 度后，我们仍可以得到一个有效的，且和 X 不同的数。要求每位数字都要被旋转。
 * 
 * 如果一个数的每位数字被旋转以后仍然还是一个数字， 则这个数是有效的。0, 1, 和 8 被旋转后仍然是它们自己；2 和 5
 * 可以互相旋转成对方（在这种情况下，它们以不同的方向旋转，换句话说，2 和 5 互为镜像）；6 和 9
 * 同理，除了这些以外其他的数字旋转以后都不再是有效的数字。
 * 
 * 现在我们有一个正整数 N, 计算从 1 到 N 中有多少个数 X 是好数？
 * 
 * 
 * 
 * 示例：
 * 
 * 输入: 10
 * 输出: 4
 * 解释: 
 * 在[1, 10]中有四个好数： 2, 5, 6, 9。
 * 注意 1 和 10 不是好数, 因为他们在旋转之后不变。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * N 的取值范围是 [1, 10000]。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private bool IsGood(int x)
    {
        bool flag = false;
        while (x != 0)
        {
            int t = x % 10;
            if (t == 3 || t == 4 || t == 7)
            {
                return false;
            }
            if (t == 2 || t == 5 || t == 6 || t == 9)
            {
                flag = true;
            }
            x = x / 10;
        }
        return flag;
    }
    public int RotatedDigits(int N)
    {
        int sum = 0;
        for (int i = 1; i <= N; i++)
        {
            if (IsGood(i)) sum++;
        }
        return sum;
    }
}
// @lc code=end

