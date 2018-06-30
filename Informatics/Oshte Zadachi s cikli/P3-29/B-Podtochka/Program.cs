using System;
//d̴̖̟͔̳̲̳ͣͧ́͂̕è̵̶͍̙̰̭͍̰̗̫̬ͫͥ̋͑̀͂ͬ̄ͥ̋͌̌̎̀s̵͌ͨ̄ͥ̉͆̋̓̋ͩ̌̿̄̋͏͎͇̱̻̤͔̟̘̟p̵̡̧̺̬͔͎͔̪͍̪̟̪̹̼̯̘̖̗̽̈̑̆ͤ̑ͪͦ͋̍̆ͩ͐̌ͯ̀͡a͊ͨ̃̄ͤ̊ͬ̚͏̡̱̬̬̻̩͖̣̮͠c̡͍̼̣̦̻̆ͯ̉̿ͥ͋̐͋ͫͦ͂̎ͪ̌́͡i̶̩̝͖̭͍͚͚̝̱͙̠̠̤̱͖ͩ̊͂̓̅́ͪͥͪ́͜ţ̳̻̜̯̲̦̱͔͖̙͉̂ͫ̐͊̏́ͦ̃͛̚͞ͅǒ̔ͥ̌̓̉ͫ́̋ͦ͌ͫ̈̈́ͨ̎͜͏̧̙͇̟̗̰̤͍͎̦̩̻̤͞
namespace B_Podtochka
{
    class Program
    {
        static void Main(string[] args)
        {
            double lewa = double.Parse(Console.ReadLine());
            double lihwa = double.Parse(Console.ReadLine());
            int godini = int.Parse(Console.ReadLine());
            int i = 1;
            while (i<=godini)
            {
                lewa *= (100 + lihwa) / 100; // 100% + 3% lihwa = 103% = 1.03 PRIMER
                i++;
            }
            Console.WriteLine(lewa);
        }
    }
}
