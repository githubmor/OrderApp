namespace Core.Models
{
    public class KalaElectionDto : KalaDto
    {
        public Sherkat Sherkat { get; set; }
        public Moshtari Moshtari { get; set; }

        public KalaDto getKalaDto()
        {
            return this as KalaDto;
        }
    }

    public enum Sherkat
    {
        Andisheh,
        Imen

    }
    public enum Moshtari
    {
        Sazehgostar,
        Sapco

    }
}