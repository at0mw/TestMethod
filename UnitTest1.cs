using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestResult;
using System.Collections.Generic;

namespace TestResult;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethodFewestCoins()
    {
        Dictionary<int, int> dic1 = FewestCoins(125);
        Dictionary<int, int> dic2 = new Dictionary<int, int>()
        {
            {50, 2},
            {20, 1},
            {5, 1}
        };

        bool comparison = CompareDicts(dic1 , dic2);
        Assert.IsTrue(comparison);

        dic1 = FewestCoins(50);
        dic2 = new Dictionary<int, int>()
        {
            {50, 1}
        };

        comparison = CompareDicts(dic1 , dic2);
        Assert.IsTrue(comparison);

        dic1 = FewestCoins(1600);
        dic2 = new Dictionary<int, int>()
        {
            {50, 32}
        };

        comparison = CompareDicts(dic1 , dic2);
        Assert.IsTrue(comparison);

        dic1 = FewestCoins(1782);
        dic2 = new Dictionary<int, int>()
        {
            {50, 35},
            {20, 1},
            {10, 1},
            {2, 1}
        };

        comparison = CompareDicts(dic1 , dic2);
        Assert.IsTrue(comparison);

        dic1 = FewestCoins(1782223);
        dic2 = new Dictionary<int, int>()
        {
            {50, 35644},
            {20, 1},
            {2, 1}
        };

        comparison = CompareDicts(dic1 , dic2);
        Assert.IsTrue(comparison);
    }

    public bool CompareDicts(Dictionary<int, int> dic1, Dictionary<int, int> dic2)
    {
        if (!(dic1.Count == dic2.Count))
            return false;
        foreach (var key in dic1.Keys)
        {
            if (!dic2.ContainsKey(key))
                return false;
            else
                if(!(dic1[key]==dic2[key]))
                    return false;
        }
        return true;
    }

    public Dictionary<int,int> FewestCoins(double input)
    {
        Dictionary<int, int> output = new Dictionary<int, int>();
        double[] coins = { 50,20,10,5,2,1 };        
        foreach(double coin in coins)
        {
            double result = input / coin;
            if (result >= 1)
            {
                long coinUsed = (long) result;
                double remaining = result - coinUsed;
                output.Add((int)coin, (int)coinUsed);
                if (remaining >= 10)
                    remaining = remaining/ 10;
                input = remaining * coin;
            }
        }
        return output;
    }
}