import java.util.Collections;
import java.util.List;
import java.util.PriorityQueue;

import sun.jvm.hotspot.gc.shared.CollectedHeapName;

/*
 * @lc app=leetcode.cn id=218 lang=java
 *
 * [218] 天际线问题
 *
 * https://leetcode-cn.com/problems/the-skyline-problem/description/
 *
 * algorithms
 * Hard (39.88%)
 * Likes:    159
 * Dislikes: 0
 * Total Accepted:    5.9K
 * Total Submissions: 14.2K
 * Testcase Example:  '[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]'
 *
 * 
 * 城市的天际线是从远处观看该城市中所有建筑物形成的轮廓的外部轮廓。现在，假设您获得了城市风光照片（图A）上显示的所有建筑物的位置和高度，请编写一个程序以输出由这些建筑物形成的天际线（图B）。
 * 
 * ⁠   
 * 
 * 每个建筑物的几何信息用三元组 [Li，Ri，Hi] 表示，其中 Li 和 Ri 分别是第 i 座建筑物左右边缘的 x 坐标，Hi 是其高度。可以保证 0
 * ≤ Li, Ri ≤ INT_MAX, 0 < Hi ≤ INT_MAX 和 Ri - Li > 0。您可以假设所有建筑物都是在绝对平坦且高度为 0
 * 的表面上的完美矩形。
 * 
 * 例如，图A中所有建筑物的尺寸记录为：[ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ]
 * 。
 * 
 * 输出是以 [ [x1,y1], [x2, y2], [x3, y3], ... ]
 * 格式的“关键点”（图B中的红点）的列表，它们唯一地定义了天际线。关键点是水平线段的左端点。请注意，最右侧建筑物的最后一个关键点仅用于标记天际线的终点，并始终为零高度。此外，任何两个相邻建筑物之间的地面都应被视为天际线轮廓的一部分。
 * 
 * 例如，图B中的天际线应该表示为：[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0]
 * ]。
 * 
 * 说明:
 * 
 * 
 * 任何输入列表中的建筑物数量保证在 [0, 10000] 范围内。
 * 输入列表已经按左 x 坐标 Li  进行升序排列。
 * 输出列表必须按 x 位排序。
 * 输出天际线中不得有连续的相同高度的水平线。例如 [...[2 3], [4 5], [7 5], [11 5], [12 7]...]
 * 是不正确的答案；三条高度为 5 的线应该在最终输出中合并为一个：[...[2 3], [4 5], [12 7], ...]
 * 
 * 
 */

// @lc code=start
class Solution {
    public class Nod{
        int x;
        boolean start;
        int h;
        public Nod(int x, boolean start, int h){
            this.x = x;
            this.start = start;
            this.h = h;
        }
    }
    public List<List<Integer>> getSkyline(int[][] buildings) {
        List<Nod> nods = new ArrayList<Nod>();
        PriorityQueue<Integer> heap = new PriorityQueue<>((n1, n2) -> n2-n1);
        List<List<Integer>> res = new ArrayList<>();
        for(int[] building : buildings){
            nods.add(new Nod(building[0], true, building[2]));
            nods.add(new Nod(building[1], false, building[2]));
        }
        Collections.sort(nods, (n1, n2) -> n1.x-n2.x);
        int j = 0;
        int prevheight = 0;
        while(j<nods.size()){
            int curx = nods.get(j).x;
            while(j<nods.size() && curx == nods.get(j).x){
                Nod node = nods.get(j);
                if(node.start) heap.add(node.h);
                else heap.remove(node.h);
                j++;
            }
            int curh = 0;
            if(!heap.isEmpty()) curh = heap.peek();
            if(curh!=prevheight){
                prevheight = curh;
                List<Integer> tmp = new ArrayList<>();
                tmp.add(curx);
                tmp.add(curh); 
                res.add(new ArrayList<>(tmp));
            }          
        }
        return res;
    }
}
// @lc code=end

