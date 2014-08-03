using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Program
{
    static void Main(string[] args)
    {

        //$priceOfGoods;$buyersCash
        string line = "15.23;20";

        var left = line.Split(';').First();
        var right = line.Split(';').Last();

        var leftVal = (int)(Double.Parse(left) * 100);
        var rightVal = (int)(Double.Parse(right) * 100);
        var temp = getLineVal(leftVal, rightVal);
        Console.WriteLine(temp);
        Console.ReadKey();


    }

    private static string getLineVal(int left, int right)
    {

        if (left > right) return "ERROR";
        if (left == right) return "ZERO";

        var Cash = new Dictionary<int, string>();
        Cash[1] = "PENNY";
        Cash[5] = "NICKEL";
        Cash[10] = "DIME";
        Cash[25] = "QUARTER";
        Cash[50] = "HALF DOLLAR";
        Cash[100] = "ONE";
        Cash[500] = "FIVE";
        Cash[1000] = "TEN";
        Cash[2000] = "TWENTY";
        Cash[5000] = "FIFTY";
        Cash[10000] = "ONE HUNDRED";

        var theChange = right - left;

        var Numbers = new List<int>();
        Numbers.Add(10000);
        Numbers.Add(5000);
        Numbers.Add(2000);
        Numbers.Add(1000);
        Numbers.Add(500);
        Numbers.Add(100);
        Numbers.Add(50);
        Numbers.Add(25);
        Numbers.Add(10);
        Numbers.Add(5);
        Numbers.Add(1);
   
        string temp = "";
        foreach (var num in Numbers)
        {
            int x = 0;
            while (theChange >= num)
            {
                if (x == 0)
                    temp += Cash[num];
                else
                    temp += "," + Cash[num];
                x++;
                theChange -= num;
            }
            if (x > 0) temp += "\n";
        }

        return temp;
    }

}