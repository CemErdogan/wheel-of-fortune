using UnityEngine;

namespace PopupSystem
{
    public struct SpinRewardPopupContext : IPopupContext
    {
        public readonly int Amount;
        public readonly string Id;
        public readonly Sprite Icon;

        public SpinRewardPopupContext(int rewardAmount, string id, Sprite rewardIcon)
        {
            Amount = rewardAmount;
            Id = id;
            Icon = rewardIcon;
        }
    }
}