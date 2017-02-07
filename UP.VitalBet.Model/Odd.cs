namespace UP.VitalBet.Model
{
    public class Odd: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string SpecialBetValue { get; set; } 

        public int BetId { get; set; }
        
    }
}
