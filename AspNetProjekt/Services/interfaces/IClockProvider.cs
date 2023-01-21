namespace AspNetProjekt.Services.interfaces
{
    public interface IClockProvider
    {
        DateTime Now();
        DateTime Epoch();
    }
}
