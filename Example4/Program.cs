using System;
using System.Collections.Generic;
using System.Linq;

namespace Example4
{
    internal static class Program
    {
        private static void Main()
        {
            // 초기화
            var characterNames = new String[]
            {
                "Downes",
                "Benson",
                "Fletcher",
                "Gearing",
            };

            var characters = characterNames.Select(name => new Character(name));
            var gifts = new Gift[]
            {
                new Gift("Cola", 3),
                new Gift("Meal", 6),
                new Gift("Flower", 10),
            };

            // 간단한 게임 루프
            var targetFavor = 100;
            while (true)
            {
                Console.WriteLine("Current character status:");
                foreach (var character in characters)
                    Console.WriteLine($"\t{character.Name}: Favor {character.Favor}/{targetFavor}");

                // 캐릭터를 선택.
                Console.WriteLine("Select target npc:");
                var targetCharacter = SelectByUserInput(characters, (ch, name) => ch.Name == name);

                Console.WriteLine("Select gift:");
                foreach (var gift in gifts)
                    Console.WriteLine($"\t{gift.GiftName}: +{gift.FavorDiff} Favor");

                // 선물을 선택.
                var targetGift = SelectByUserInput(gifts, (gift, name) => gift.GiftName == name);

                // 선물 호감도 만큼 캐릭터 호감도를 올린다.
                Console.WriteLine($"You gave {targetGift.GiftName} to {targetCharacter.Name}!");
                targetCharacter.IncreaseFavor(targetGift.FavorDiff);

                // 적당한 게임 종료 조건.
                if (targetCharacter.Favor > targetFavor)
                    break;

                Console.WriteLine();
            }
        }

        /// <summary>
        /// 유저 입력을 받아오는 함수. 유저가 입력한 string에 매칭되는 list의 원소를 리턴한다.
        /// </summary>
        /// <typeparam name="T">list 원소의 타입.</typeparam>
        /// <param name="list">선택 list.</param>
        /// <param name="match">list의 각 원소와 string이 매칭되는지 체크하는 함수.</param>
        /// <returns>유저에 의해 선택된 list 원소</returns>
        private static T SelectByUserInput<T>(IEnumerable<T> list, Func<T, String, bool> match)
        {
            while (true)
            {
                var input = Console.ReadLine().Trim();

                if (list.Any(elem => match(elem, input)))
                    return list.First(elem => match(elem, input));
                else
                    Console.WriteLine($"Invalid input: {input}");
            }
        }
    }
}
