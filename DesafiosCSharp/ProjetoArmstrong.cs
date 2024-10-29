using System;
using System.Linq;

public static class ProjetoArmstrong{
    public static bool IsArmstrong(this int num){

        int sum = 0;
        int temp = num;
        int length = num.ToString().Length;
        
        while(temp > 0){
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, length);
            temp /= 10;
        }
        
        return sum == num;
    }
}