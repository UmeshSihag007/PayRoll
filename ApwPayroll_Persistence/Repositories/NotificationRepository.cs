using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Persistence.Data;

namespace ApwPayroll_Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;
        public NotificationRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public Task FetchNotification(string id)
        {
            throw new NotImplementedException();
        }

/*        public async Task<List<int>> Delete(List<int> locationId)
        {
var data = await _applicationDataContext.HolidayTypeRuleLocation
        }*/
    }
}
