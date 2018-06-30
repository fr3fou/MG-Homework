using System;
//d̴̖̟͔̳̲̳ͣͧ́͂̕è̵̶͍̙̰̭͍̰̗̫̬ͫͥ̋͑̀͂ͬ̄ͥ̋͌̌̎̀s̵͌ͨ̄ͥ̉͆̋̓̋ͩ̌̿̄̋͏͎͇̱̻̤͔̟̘̟p̵̡̧̺̬͔͎͔̪͍̪̟̪̹̼̯̘̖̗̽̈̑̆ͤ̑ͪͦ͋̍̆ͩ͐̌ͯ̀͡a͊ͨ̃̄ͤ̊ͬ̚͏̡̱̬̬̻̩͖̣̮͠c̡͍̼̣̦̻̆ͯ̉̿ͥ͋̐͋ͫͦ͂̎ͪ̌́͡i̶̩̝͖̭͍͚͚̝̱͙̠̠̤̱͖ͩ̊͂̓̅́ͪͥͪ́͜ţ̳̻̜̯̲̦̱͔͖̙͉̂ͫ̐͊̏́ͦ̃͛̚͞ͅǒ̔ͥ̌̓̉ͫ́̋ͦ͌ͫ̈̈́ͨ̎͜͏̧̙͇̟̗̰̤͍͎̦̩̻̤͞
namespace G_Podtochka
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentDayDistance = int.Parse(Console.ReadLine()); // km za tekushtiq den
            double dailyIncrease = double.Parse(Console.ReadLine()); // dnewno uwelichawane
            double targetDistance = double.Parse(Console.ReadLine()); // kraina cel
            int totalDays = 0; // obsht broj dni
            double totalDistance = 0; // obshto razstoyanie izminato
            while (totalDistance <= targetDistance)
            {
                currentDayDistance *= (100+dailyIncrease)/100; // uwelichi km za tekushtiq den
                totalDistance += currentDayDistance; // dobawi tekushtiq den kum obshtoto razstoyanie
                totalDays++; // uwelichi dnite
            }
            Console.WriteLine("{0} days, {1} km", totalDays, totalDistance);
        }
    }
}
