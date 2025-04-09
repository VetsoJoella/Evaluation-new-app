using System;

public class Intervalle
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    // Constructeur pour initialiser les dates
    public Intervalle(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
 
    public Intervalle(){}
}
