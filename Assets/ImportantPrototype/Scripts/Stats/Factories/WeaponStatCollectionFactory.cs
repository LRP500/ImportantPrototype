namespace ImportantPrototype.Stats.Manager
{
    public class WeaponStatCollectionFactory : StatCollectionFactory<WeaponStatCollection>
    {
        protected override string AssetPath => "WeaponStats"; 
        
        public override WeaponStatCollection Create()
        {
            return new WeaponStatCollection(Stats);
        }
    }
}