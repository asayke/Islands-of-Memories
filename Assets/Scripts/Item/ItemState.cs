
    public class ItemState : IItemState
    {
        private int _amount;
        private bool _isEquip;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }
        
        public bool IsEquip
        {
            get => _isEquip;
            set => _isEquip = value;
        }

        public ItemState(int amount = 1)
        {
            _amount = amount;
            _isEquip = false;
        }
    }