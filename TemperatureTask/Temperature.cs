namespace MainProgram.TemperatureTask;
class Temperature
{
    public double Monday { get; set; }
    public double Tuesday { get; set; }
    public double Wednesday { get; set; }
    public double Thursday { get; set; }
    public double Friday { get; set; }
    public double Saturday { get; set; }
    public double Sunday { get; set; }

    public double this[int day]
    {
        get
        {
            if (day == 0)
            {
                return Monday;
            }
            else if (day == 1)
            {
                return Tuesday;
            }
            else if (day == 2)
            {
                return Wednesday;
            }
            else if (day == 3)
            {
                return Thursday;
            }
            else if (day == 4)
            {
                return Friday;
            }
            else if (day == 5)
            {
                return Saturday;
            }
            else if (day == 6)
            {
                return Sunday;
            }
            else
            {
                throw new Exception("Day must be from 0 to 6.");
            }
        }
        set
        {
            if (day == 0)
            {
                Monday = value;
            }
            else if (day == 1)
            {
                Tuesday = value;
            }
            else if (day == 2)
            {
                Wednesday = value;
            }
            else if (day == 3)
            {
                Thursday = value;
            }
            else if (day == 4)
            {
                Friday = value;
            }
            else if (day == 5)
            {
                Saturday = value;
            }
            else if (day == 6)
            {
                Sunday = value;
            }
            else
            {
                throw new Exception("Day must be from 0 to 6.");
            }
        }
    }

    public double GetAverageTemperature()
    {
        return (Monday + Tuesday + Wednesday + Thursday +
            Friday + Saturday + Sunday) / 7;
    }
}
