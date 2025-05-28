using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ViewModel.Messages
{
    /// <summary>
    /// Message for requesting data.
    /// </summary>

    public class RequestTableMessage : ValueChangedMessage<object>
        {
            public RequestTableMessage(object value) : base(value) 
            { 

            }
        }
}
