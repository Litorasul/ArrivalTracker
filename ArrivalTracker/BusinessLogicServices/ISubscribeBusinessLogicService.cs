namespace ArrivalTracker.BusinessLogicServices;

public interface ISubscribeBusinessLogicService
{
    public Task SubscribeToFourthArrivalService();
    public string GetToken();
    public DateTime GetTokenExperationDate();

}
