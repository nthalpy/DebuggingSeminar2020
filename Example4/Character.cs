using System;

namespace Example4
{
    /// <summary>
    /// 캐릭터에 관한 데이터.
    /// </summary>
    internal sealed class Character
    {
        /// <summary>
        /// 캐릭터의 이름.
        /// </summary>
        public readonly String Name;

        /// <summary>
        /// 캐릭터의 호감도.
        /// </summary>
        public int Favor { get; private set; }

        public Character(String name)
        {
            Name = name;
            Favor = 0;
        }

        /// <summary>
        /// 캐릭터의 호감도를 올리는 함수.
        /// </summary>
        /// <param name="diff">호감도를 올릴 양. 양수여야 한다.</param>
        public void IncreaseFavor(int diff)
        {
            if (diff <= 0)
                throw new ArgumentException($"Unexpected delta: {diff}. delta should be positive.");

            Favor += diff;
        }
    }
}