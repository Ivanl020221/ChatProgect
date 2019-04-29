using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat2._0.Entity;
using Chat2._0.Utilites;

namespace Chat2._0.ConnectionClass
{
    class Chat 
    {
        public ChatRoom GetChatRoomInfo(long ChatRoomID) => ApiConnect.ApiContext<ChatRoom>(Controller.ChatRoom, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("ChatRoomID", ChatRoomID)).GetParams());
        public IEnumerable<Message> GetMessage(long ChatRoomIDForMessage) => ApiConnect.ApiContext<IEnumerable<Message>>(Controller.ChatRoom, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("ChatRoomIDForMessage", ChatRoomIDForMessage)).GetParams());
        public IEnumerable<Employee> GetEmployees(long ChatRoomID) => ApiConnect.ApiContext<IEnumerable<Employee>>(Controller.Auth, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("ChatRoomIDForUer", ChatRoomID)).GetParams());
        public void Rename(string Topic, long ChatRoomId) => ApiConnect.ApiContext<ChatRoom,ChatRoom>(Controller.ChatRoom, Metod.PUT, null, FromType.UriFullType, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("Topic", Topic), ParamsGenerator.CreateParams("IdRoom", ChatRoomId)).GetParams());
        public ChatRoom CreateChatRoom(string TopicName, IEnumerable<long> employees) => ApiConnect.ApiContext<ChatRoom, IEnumerable<long>>(Controller.ChatRoom, Metod.POST, employees,FromType.UriFullType, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("TopicName", TopicName)).GetParams());
        public void SendMessage(string Message, long IdEmp, long IdRoom) => ApiConnect.ApiContext<Message, Message>(Controller.ChatRoom, Metod.POST, null, FromType.UriFullType, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("Message", Message), ParamsGenerator.CreateParams("IdEmp", IdEmp), ParamsGenerator.CreateParams("IdRoom", IdRoom)).GetParams());
        public void AddEmp(long RoomId, long IdEmp) => ApiConnect.ApiContext<Employee, Employee>(Controller.ChatRoom, Metod.POST, null, FromType.UriFullType, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("RoomId", RoomId), ParamsGenerator.CreateParams("IdEmp", IdEmp)).GetParams());
    }
}
