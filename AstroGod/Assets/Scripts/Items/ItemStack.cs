using UnityEngine;

public class ItemStack : IItem
{
    public readonly StackableItem itemData;
    ItemData IItem.ItemData => itemData;
    public int Amount { get; private set; }

    public ItemStack(StackableItem _itemData, int _amount)
    {
        itemData = _itemData;
        Amount = _amount;
    }

    public int AddAmount(int amountToAdd)
    {
        int remainderAmount; // Amount that was not added due to stack limit
        int stackLimit = itemData.StackLimit;

        if (Amount + amountToAdd <= stackLimit)
        {
            Amount += amountToAdd;
            remainderAmount = 0;
        }
        else
        {
            remainderAmount = amountToAdd - (stackLimit - Amount);
            Amount = stackLimit; 
        }
        return remainderAmount;
    }

    public int ReduceAmount(int amountToReduce)
    {
        int amountReduced;
        if (Amount - amountToReduce >= 0)
        {
            Amount -= amountToReduce;
            amountReduced = amountToReduce;
        } else
        {
            amountReduced = Amount;
            Amount = 0;
        }
        return amountReduced;
    }

    public bool Consume(GameObject consumer)
    {
        if (Amount > 0)
        {
            itemData.Consume(consumer);
            Amount--;
            return true;
        }
        return false;
    }
}
