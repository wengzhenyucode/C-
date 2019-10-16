using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最长回文子串查找
{
    //回文串就是正着读和反着读一样的字符串
    //比如说字符串aba和abba都是回文串，因为它们对称，
    //反过来还是和本身一样。反之，字符串abac就不是回文串。
    //看到回文串的可以的长度可能是奇数，也可能是偶数，
    //这就添加了回文串问题的难度，解决该类问题的核心是双指针。
    /*寻找回文串的问题核心思想是：从中间开始向两边扩散来判断回文串。对于最长回文子串，就是这个意思：
    for 0 <= i < len(s):
    找到以 s[i] 为中心的回文串
    更新答案
    但是呢，我们刚才也说了，回文串的长度可能是奇数也可能是偶数，如果是abba这种情况，没有一个中心字符，上面的算法就没辙了。所以我们可以修改一下:
    for 0 <= i < len(s):
    找到以 s[i] 为中心的回文串
    找到以 s[i] 和 s[i+1] 为中心的回文串
    更新答案*/
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abacdebabe";
            str = LongestPalindrome(str);
            Console.WriteLine("{0}",str);
            Console.ReadKey();
        }
        private static string Palindrome( string str,int l,int r)
        {
            while (l >= 0 && r < str.Length && str[l] == str[r])
            {
                l--;
                r++;
            }
            return str.Substring(l + 1, r - l -1);
        }
        private static string LongestPalindrome(string s)
        {
            string res="";
            for (int i = 0; i < s.Length; i++)
            {
                string res1=Palindrome( s, i, i);
                string res2 = Palindrome( s, i, i + 1);
                res = res.Length > res1.Length ? res : res1;
                res = res.Length > res2.Length ? res : res2;
            }
            return res;
        }
    }
}
