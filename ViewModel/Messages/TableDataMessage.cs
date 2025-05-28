using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ViewModel.Messages
{
    /// <summary>
    /// Message for sending data.
    /// </summary>
    public class TableDataMessage: ValueChangedMessage<TableData>
    {

        public TableDataMessage(TableData value) : base(value) 
        { 
        }
    }
}
