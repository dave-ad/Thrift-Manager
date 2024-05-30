namespace ThriftManager.Domain.ValueObjects;

public record ContributionTimeline
{
    public int Slots { get; }
    public Period Period { get; }
    public int Tenure { get; }
    public int DueDay { get; }

    private ContributionTimeline()
    {
        Period = Period.Unknown;
        Tenure = 0;
        DueDay = 0;
        Slots = 0;
    }

    private ContributionTimeline(int slots, Period period, int tenure, int dueDay)
    {
        Period = period;
        Tenure = tenure;
        DueDay = dueDay;
        Slots = slots;
    }
    public static ContributionTimeline Default() => new();
    public static ContributionTimeline Create(int slots, Period period, int tenure, int dueDay) =>
        new(slots, period, tenure, dueDay);
}
