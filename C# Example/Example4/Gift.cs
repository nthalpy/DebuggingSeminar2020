using System;

namespace Example4
{
    internal sealed class Gift
    {
        public readonly String GiftName;
        public readonly int FavorDiff;

        public Gift(String giftName, int favorDiff)
        {
            GiftName = giftName;
            FavorDiff = favorDiff;
        }
    }
}