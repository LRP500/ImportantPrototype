namespace ImportantPrototype.Stats.Factories
{
    public class CharacterStatCollectionFactory : StatCollectionFactory<CharacterStatCollection>
    {
        protected override string AssetPath => "CharacterStats"; 
        
        public override CharacterStatCollection Create()
        {
            return new CharacterStatCollection(Stats);
        }
    }
}