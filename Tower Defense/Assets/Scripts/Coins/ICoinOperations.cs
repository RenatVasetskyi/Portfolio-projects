namespace Coins
{
    public interface ICoinOperations
    {
        public void BuyTower(int price);
        public void UpgradeTower(float price);
        public void GetBonus();
    }
}
